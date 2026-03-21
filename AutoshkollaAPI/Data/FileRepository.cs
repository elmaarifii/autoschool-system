using System.Text.Json;

namespace AutoshkollaAPI.Data
{
    public class FileRepository<T> : IRepository<T>
    {
        private readonly string _filePath;
        private List<T> _items;

        public FileRepository(string filePath)
        {
            _filePath = filePath;

            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _items = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            else
            {
                _items = new List<T>();
            }
        }

        public List<T> GetAll()
        {
            return _items;
        }

        public T GetById(int id)
        {
            return _items.FirstOrDefault();
        }

        public void Add(T entity)
        {
            _items.Add(entity);
        }

        public void Save()
        {
            var json = JsonSerializer.Serialize(_items);
            File.WriteAllText(_filePath, json);
        }
    }
}