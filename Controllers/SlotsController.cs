using Microsoft.AspNetCore.Mvc;
using AutoshkollaAPI.Models;
using AutoshkollaAPI.Services;
using AutoshkollaAPI.Data;

namespace AutoshkollaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SlotsController : ControllerBase
    {
        private readonly SlotService _service;

        public SlotsController()
        {
            var repository = new FileRepository<AvailableSlot>("slots.csv");
            _service = new SlotService(repository);
        }

        // GET: api/slots
        [HttpGet]
        public IActionResult GetAll()
        {
            var slots = _service.GetAll();
            return Ok(slots);
        }

        // GET: api/slots/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var slot = _service.GetById(id);

            if (slot == null)
                return NotFound("Slot not found");

            return Ok(slot);
        }

        // POST: api/slots
        [HttpPost]
        public IActionResult Add([FromBody] AvailableSlot slot)
        {
            try
            {
                _service.Add(slot);
                return Ok("Slot added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Deleted successfully");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AvailableSlot slot)
        {
            try
            {
                _service.Update(id, slot);
                return Ok("Updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}