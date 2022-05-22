namespace Tringle.Repository
{
    public class DataContext<T> where T : class
    {
        public readonly string _path;

        public DataContext()
        {
            _path = Directory.GetCurrentDirectory() + "/" + typeof(T).Name + ".json";
        }
    }
}
