using AutoshkollaAPI.Models;
using System.Globalization;

namespace AutoshkollaAPI.Data
{
    public class FileRepository<T> : IRepository<T> where T : IEntity
    {
        private readonly string _filePath;
        private List<T>? _items;

        public FileRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<T> GetAll()
        {
            EnsureLoaded();
            return _items!;
        }

        public T GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public void Add(T entity)
        {
            EnsureLoaded();
            _items!.Add(entity);
        }

        public void Save()
        {
            EnsureLoaded();

            Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(_filePath))!);

            if (typeof(T) != typeof(AvailableSlot))
                throw new NotSupportedException($"CSV persistence is only implemented for {nameof(AvailableSlot)}.");

            var lines = new List<string> { "Id,InstructorName,Date,Time,IsBooked" };

            foreach (var entity in _items!)
            {
                var slot = (AvailableSlot)(object)entity;
                var instructor = (slot.InstructorName ?? string.Empty).Replace(",", " ");
                var time = (slot.Time ?? string.Empty).Replace(",", " ");
                lines.Add(
                    string.Join(
                        ",",
                        slot.Id.ToString(CultureInfo.InvariantCulture),
                        instructor,
                        slot.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                        time,
                        slot.IsBooked.ToString(CultureInfo.InvariantCulture)
                    )
                );
            }

            File.WriteAllLines(_filePath, lines);
        }

        private void EnsureLoaded()
        {
            if (_items != null) return;

            if (!File.Exists(_filePath))
            {
                _items = new List<T>();
                Save();
                return;
            }

            var lines = File.ReadAllLines(_filePath);
            var list = new List<T>();

            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(',');
                if (parts.Length < 5) continue;

                var slot = new AvailableSlot
                {
                    Id = int.TryParse(parts[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out var id) ? id : 0,
                    InstructorName = parts[1],
                    Date = DateTime.TryParse(parts[2], CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var dt) ? dt : default,
                    Time = parts[3],
                    IsBooked = bool.TryParse(parts[4], out var booked) && booked
                };

                list.Add((T)(object)slot);
            }

            _items = list;
        }
    }
}