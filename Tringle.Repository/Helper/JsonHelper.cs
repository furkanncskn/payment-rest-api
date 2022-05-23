using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Tringle.Repository.Helper
{
    public static class JsonHelper
    {
        public static async Task<List<T>> LoadJsonFromFileAsync<T>(string path) where T : class, new()
        {
            using FileStream fs = new(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (fs.Length > 0)
            {
                var list = await JsonSerializer.DeserializeAsync<List<T>>(fs) ?? new List<T>();
                await fs.FlushAsync();
                await fs.DisposeAsync();
                return list;
            }
            return new List<T>();
        }

        public static async Task WriteToJsonFileAsync<T>(string path, List<T> list) where T : class
        {
            using FileStream fs = new(path, FileMode.Create, FileAccess.Write);
            if (fs.CanWrite)
            {
                await JsonSerializer.SerializeAsync(fs, list, new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                });
                await fs.FlushAsync();
                await fs.DisposeAsync();
            }
        }

        public static async Task<T?> GetByIdFromJsonFileAsync<T>(string path, object id) where T : class, new()
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            string? keyName = AttributeHelper.GetPropertiesInfoByAttribute<T>(typeof(KeyAttribute))?.Select(p => p.Name).SingleOrDefault();
            var list = await LoadJsonFromFileAsync<T>(path);
            foreach (var elem in list)
            {
                object? keyValue = properties?.SingleOrDefault(p => p.Name == (keyName ?? string.Empty) || p.Name.ToUpper() == "ID")?.GetValue(elem, null);
                if (keyValue?.Equals(id) == true) { return elem; }
            }
            return null;
        }

        public static async Task<IQueryable<T>> GetAllFromJsonFileAsync<T>(string path) where T : class, new()
        {
            return (await LoadJsonFromFileAsync<T>(path)).AsQueryable();
        }

        public static async Task<IQueryable<T>> WhereJsonFile<T>(string path, Expression<Func<T, bool>> expression) where T : class, new()
        {
            return (await LoadJsonFromFileAsync<T>(path)).AsQueryable().Where(expression);
        }

        public static async Task<bool> AnyJsonFileAsync<T>(string path, Expression<Func<T, bool>> expression) where T : class, new()
        {
            return (await LoadJsonFromFileAsync<T>(path)).AsQueryable().Any(expression);
        }

        public static async Task AddToJsonFileAsync<T>(string path, T entity) where T : class, new()
        {
            await AddRangeToJsonFileAsync<T>(path, new List<T>() { entity });
        }

        public static async Task AddRangeToJsonFileAsync<T>(string path, IEnumerable<T> entities) where T : class, new()
        {
            foreach (var entity in entities)
            {
                var list = await LoadJsonFromFileAsync<T>(path);
                await Task.Run(() => list.Add(entity));
                await WriteToJsonFileAsync(path, list);
            }
        }

        public static async Task DeleteFromJsonFileAsync<T>(string path, T instance) where T : class, new()
        {
            await DeleteRangeFromJsonFile(path, new List<T>() { instance });
        }

        public static async Task DeleteRangeFromJsonFile<T>(string path, IEnumerable<T> entities) where T : class, new()
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            var list = await LoadJsonFromFileAsync<T>(path);
            foreach (var entity in entities)
            {
                object?[] values = properties?.Select(p => p.GetValue(entity, null))?.ToArray() ?? Array.Empty<object>(); ;
                string? keyName = AttributeHelper.GetPropertiesInfoByAttribute<T>(typeof(KeyAttribute))?.Select(p => p.Name).SingleOrDefault();
                PropertyInfo? keypPropertyInfo = properties?.SingleOrDefault(p => p.Name == (keyName ?? string.Empty) || p.Name.ToUpper() == "ID");
                object? entityKeyValue = keypPropertyInfo?.GetValue(entity, null)!;
                for (int i = 0; i < list.Count; i++)
                {
                    object? keyValue = properties?.SingleOrDefault(p => p.Name == keyName)?.GetValue(list[i], null);
                    if (keyValue?.Equals(entityKeyValue) == true)
                    {
                        await Task.Run(() => list.Remove(list[i]));
                    }
                }
            }
            await WriteToJsonFileAsync(path, list);
        }

        public static async Task UpdateFromJsonFileAsync<T>(string path, T entity) where T : class, new()
        {
            await UpdateRangeFromJsonFileAsync(path, new List<T>() { entity });
        }

        public static async Task UpdateRangeFromJsonFileAsync<T>(string path, IEnumerable<T> entities) where T : class, new()
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            var list = await LoadJsonFromFileAsync<T>(path);
            foreach (var entity in entities)
            {
                object?[] values = properties?.Select(p => p.GetValue(entity, null))?.ToArray() ?? Array.Empty<object>(); ;
                string? keyName = AttributeHelper.GetPropertiesInfoByAttribute<T>(typeof(KeyAttribute))?.Select(p => p.Name).SingleOrDefault();
                PropertyInfo? keypPropertyInfo = properties?.SingleOrDefault(p => p.Name == (keyName ?? string.Empty) || p.Name.ToUpper() == "ID");
                object? entityKeyValue = keypPropertyInfo?.GetValue(entity, null)!;
                foreach (var elem in list)
                {
                    object? keyValue = properties?.SingleOrDefault(p => p.Name == keyName)?.GetValue(elem, null);
                    if (keyValue?.Equals(entityKeyValue) == true)
                    {
                        for (int i = 0; i < properties?.Length; i++)
                        {
                            properties[i].SetValue(elem, values[i], null);
                        }
                    }
                }
            }
            await WriteToJsonFileAsync(path, list);
        }
    }
}
