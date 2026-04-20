using AutoshkollaAPI.Data;
using AutoshkollaAPI.Models;

namespace AutoshkollaAPI.Services
{
    public class SlotService
    {
        private readonly IRepository<AvailableSlot> _repository;

        public SlotService(IRepository<AvailableSlot> repository)
        {
            _repository = repository;
        }

        public List<AvailableSlot> GetAll(string? instructorName = null, bool? isBooked = null)
        {
            var slots = _repository.GetAll();

            if (!string.IsNullOrWhiteSpace(instructorName))
            {
                slots = slots
                    .Where(s => s.InstructorName.Contains(instructorName.Trim(), StringComparison.OrdinalIgnoreCase))
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

        public AvailableSlot? GetById(int id)
        {
            return _repository.GetAll().FirstOrDefault(s => s.Id == id);
        }

        public void Add(AvailableSlot slot)
        {
            ValidateSlot(slot, isUpdate: false);
            NormalizeSlot(slot);
            _repository.Add(slot);
        }

        public void Delete(int id)
        {
            var slot = GetById(id);
            if (slot == null)
                throw new KeyNotFoundException("Slot nuk u gjet.");

            _repository.Delete(id);
        }

        public void Update(int id, AvailableSlot updatedSlot)
        {
            var existing = GetById(id);
            if (existing == null)
                throw new KeyNotFoundException("Slot nuk u gjet.");

            updatedSlot.Id = id;
            ValidateSlot(updatedSlot, isUpdate: true);
            NormalizeSlot(updatedSlot);

            existing.InstructorName = updatedSlot.InstructorName;
            existing.Date = updatedSlot.Date.Date;
            existing.Time = updatedSlot.Time;
            existing.IsBooked = updatedSlot.IsBooked;

            _repository.Save();
        }

        private void ValidateSlot(AvailableSlot slot, bool isUpdate)
        {
            if (slot == null)
                throw new SlotValidationException("Te dhenat e slot-it mungojne.");

            if (slot.Id <= 0)
                throw new SlotValidationException("ID duhet te jete numer pozitiv.");

            if (!isUpdate && GetById(slot.Id) != null)
                throw new SlotValidationException("Ekziston tashme nje slot me kete ID.");

            if (string.IsNullOrWhiteSpace(slot.InstructorName))
                throw new SlotValidationException("Emri i instruktorit nuk mund te jete bosh.");

            if (string.IsNullOrWhiteSpace(slot.Time))
                throw new SlotValidationException("Ora nuk mund te jete bosh.");

            if (!TimeOnly.TryParse(slot.Time, out _))
                throw new SlotValidationException("Ora duhet te jete ne format te vlefshem, p.sh. 09:00.");

            if (slot.Date == default)
                throw new SlotValidationException("Data eshte e detyrueshme.");
        }

        private static void NormalizeSlot(AvailableSlot slot)
        {
            slot.InstructorName = slot.InstructorName.Trim();
            slot.Time = slot.Time.Trim();
            slot.Date = slot.Date.Date;
        }
    }
}
