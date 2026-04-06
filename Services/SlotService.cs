using AutoshkollaAPI.Models;
using AutoshkollaAPI.Data;

namespace AutoshkollaAPI.Services
{
    public class SlotService
    {
        private readonly IRepository<AvailableSlot> _repository;

        public SlotService(IRepository<AvailableSlot> repository)
        {
            _repository = repository;
        }

        // LISTO me filter
        public List<AvailableSlot> GetAll(string? instructorName = null, bool? isBooked = null)
        {
            try
            {
                var slots = _repository.GetAll();

                if (!string.IsNullOrWhiteSpace(instructorName))
                {
                    slots = slots
                        .Where(s => s.InstructorName.ToLower().Contains(instructorName.ToLower()))
                        .ToList();
                }

                if (isBooked.HasValue)
                {
                    slots = slots
                        .Where(s => s.IsBooked == isBooked.Value)
                        .ToList();
                }

                return slots;
            }
            catch (Exception ex)
            {
                throw new Exception("Gabim gjatë kërkimit të orareve: " + ex.Message);
            }
        }

        // GJEJ sipas ID
        public AvailableSlot? GetById(int id)
        {
            try
            {
                return _repository.GetAll().FirstOrDefault(s => s.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Gabim gjatë kërkimit të slot-it: " + ex.Message);
            }
        }

        // SHTO me validim
        public void Add(AvailableSlot slot)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(slot.InstructorName))
                    throw new Exception("Instructor name cannot be empty");

                if (string.IsNullOrWhiteSpace(slot.Time))
                    throw new Exception("Time cannot be empty");

                _repository.Add(slot);
                _repository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Gabim gjatë shtimit të slot-it: " + ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var slots = _repository.GetAll();
                var slot = slots.FirstOrDefault(s => s.Id == id);

                if (slot == null)
                    throw new Exception("Slot nuk u gjet");

                slots.Remove(slot);
                _repository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Gabim gjatë fshirjes së slot-it: " + ex.Message);
            }
        }

        public void Update(int id, AvailableSlot updatedSlot)
        {
            try
            {
                var slots = _repository.GetAll();
                var existing = slots.FirstOrDefault(s => s.Id == id);

                if (existing == null)
                    throw new Exception("Slot nuk u gjet");

                if (string.IsNullOrWhiteSpace(updatedSlot.InstructorName))
                    throw new Exception("Instructor name nuk mund të jetë bosh");

                if (string.IsNullOrWhiteSpace(updatedSlot.Time))
                    throw new Exception("Time nuk mund të jetë bosh");

                existing.InstructorName = updatedSlot.InstructorName;
                existing.Date = updatedSlot.Date;
                existing.Time = updatedSlot.Time;
                existing.IsBooked = updatedSlot.IsBooked;

                _repository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Gabim gjatë përditësimit të slot-it: " + ex.Message);
            }
        }
    }
}