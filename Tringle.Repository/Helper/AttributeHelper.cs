using System.Reflection;

namespace Tringle.Repository.Helper
{
    public static class AttributeHelper
    {
        public static IEnumerable<PropertyInfo>? GetPropertiesInfoByAttribute<T>(Type keyType) where T : class
        {
            Type type = typeof(T);

            return type.GetProperties()
                        .ToList()
                        .Where(p => Attribute.GetCustomAttribute(p, keyType) != null);
        }
    }
}
