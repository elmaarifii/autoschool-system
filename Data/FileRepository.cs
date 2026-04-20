using AutoshkollaAPI.Models;

namespace AutoshkollaAPI.Data
{
    public class FileRepository<T> : IRepository<T> where T : IEntity
    {
        private readonly string _filePath;
        private List<T> _items;

        public FileRepository(string filePath)
        {
            _filePath = filePath;
            _items = LoadFromFile();
        }

        private List<T> LoadFromFile()
        {
            var list = new List<T>();

            try
            {
                if (!File.Exists(_filePath))
                {
                    File.WriteAllText(_filePath, "Id,InstructorName,Date,Time,IsBooked\n");
                    Console.WriteLine("File nuk u gjet, po krijohet nje file i ri...");
                    return list;
                }

                var lines = File.ReadAllLines(_filePath).Skip(1);

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    var parts = line.Split(',');
                    if (parts.Length < 5)
                    {
                        continue;
                    }

                    var id = int.TryParse(parts[0], out var tempId) ? tempId : 0;
                    var date = DateTime.TryParse(parts[2], out var tempDate) ? tempDate : DateTime.Now;
                    var isBooked = bool.TryParse(parts[4], out var tempBooked) && tempBooked;

                    var slot = new AvailableSlot
                    {
                        Id = id,
                        InstructorName = parts[1],
                        Date = date,
                        Time = parts[3],
                        IsBooked = isBooked
                    };

                    list.Add((T)(object)slot);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Gabim gjate leximit te file.");
            }

            return list;
        }

        public List<T> GetAll()
        {
            return _items;
        }

        public T? GetById(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public void Add(T entity)
        {
            _items.Add(entity);
            Save();
        }

        public void Update(T entity)
        {
            var index = _items.FindIndex(x => x.Id == entity.Id);

            if (index == -1)
                throw new Exception("Item not found");

            _items[index] = entity;
            Save();
        }

        public void Delete(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                _items.Remove(item);
                Save();
            }
        }

        public void Save()
        {
            try
            {
                var lines = new List<string>
                {
                    "Id,InstructorName,Date,Time,IsBooked"
                };

                foreach (var entity in _items)
                {
                    var slot = (AvailableSlot)(object)entity;
                    lines.Add($"{slot.Id},{slot.InstructorName},{slot.Date:yyyy-MM-dd},{slot.Time},{slot.IsBooked}");
                }

                File.WriteAllLines(_filePath, lines);
            }
            catch (Exception)
            {
                Console.WriteLine("Gabim gjate ruajtjes se file.");
            }
        }
    }
}
