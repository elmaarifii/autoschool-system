using AutoshkollaAPI.Models;

namespace AutoshkollaAPI.Data
{
    public class FileRepository<T> : IRepository<T> where T : IEntity
    {
        private readonly string _filePath;

        public FileRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<T> GetAll()
        {
            var lines = File.ReadAllLines(_filePath).Skip(1);
            var list = new List<T>();

            foreach (var line in lines)
            {
                var parts = line.Split(',');

                var slot = new AvailableSlot
                {
                    Id = int.Parse(parts[0]),
                    InstructorName = parts[1],
                    Date = DateTime.Parse(parts[2]),
                    Time = parts[3],
                    IsBooked = bool.Parse(parts[4])
                };

                list.Add((T)(object)slot);
            }

            return list;
        }

        public T GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public void Add(T entity)
        {
            var slot = entity as AvailableSlot;

            var line = $"{slot.Id},{slot.InstructorName},{slot.Date:yyyy-MM-dd},{slot.Time},{slot.IsBooked}";
            File.AppendAllText(_filePath, "\n" + line);
        }

        public void Save()
        {
            // nuk përdoret për CSV
        }
    }
}