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
        public List<AvailableSlot> GetAll(string instructorName = null)
        {
            var slots = _repository.GetAll();

            if (!string.IsNullOrEmpty(instructorName))
            {
                slots = slots
                    .Where(s => s.InstructorName.ToLower().Contains(instructorName.ToLower()))
                    .ToList();
            }

            return slots;
        }

        // GJEJ sipas ID
        public AvailableSlot GetById(int id)
        {
            return _repository.GetAll().FirstOrDefault(s => s.Id == id);
        }

        // SHTO me validim
        public void Add(AvailableSlot slot)
        {
            if (string.IsNullOrWhiteSpace(slot.InstructorName))
                throw new Exception("Instructor name cannot be empty");

            if (string.IsNullOrWhiteSpace(slot.Time))
                throw new Exception("Time cannot be empty");

            var existingSlots = _repository.GetAll();
            if (slot.Id <= 0)
            {
                slot.Id = existingSlots.Count == 0 ? 1 : existingSlots.Max(s => s.Id) + 1;
            }
            else if (existingSlots.Any(s => s.Id == slot.Id))
            {
                throw new Exception($"Slot with Id {slot.Id} already exists");
            }

            _repository.Add(slot);
            _repository.Save();
        }

        public void Delete(int id)
        {
            var slots = _repository.GetAll();
            var slot = slots.FirstOrDefault(s => s.Id == id);

            if (slot != null)
            {
                slots.Remove(slot);
                _repository.Save();
            }
        }

        public void Update(int id, AvailableSlot updatedSlot)
        {
            var slots = _repository.GetAll();
            var existing = slots.FirstOrDefault(s => s.Id == id);

            if (existing == null)
                throw new Exception("Slot not found");

            if (string.IsNullOrWhiteSpace(updatedSlot.InstructorName))
                throw new Exception("Instructor name cannot be empty");

            if (string.IsNullOrWhiteSpace(updatedSlot.Time))
                throw new Exception("Time cannot be empty");

            // Update fields
            existing.InstructorName = updatedSlot.InstructorName;
            existing.Date = updatedSlot.Date;
            existing.Time = updatedSlot.Time;
            existing.IsBooked = updatedSlot.IsBooked;

            _repository.Save();
        }
    }
}