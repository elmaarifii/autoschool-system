using Microsoft.AspNetCore.Mvc;
using AutoshkollaAPI.Models;
using AutoshkollaAPI.Services;

namespace AutoshkollaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SlotsController : ControllerBase
    {
        private readonly SlotService _service;

        public SlotsController(SlotService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll(string? instructorName = null, bool? isBooked = null)
        {
            var result = _service.GetAll(instructorName, isBooked);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var slot = _service.GetById(id);

            if (slot == null)
                return NotFound("Slot nuk u gjet");

            return Ok(slot);
        }

        [HttpPost]
        public IActionResult Add([FromBody] AvailableSlot slot)
        {
            try
            {
                _service.Add(slot);
                return Ok("Slot added successfully");
            }
            catch (SlotValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ndodhi nje gabim gjate ruajtjes se slot-it.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("Deleted successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ndodhi nje gabim gjate fshirjes se slot-it.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AvailableSlot slot)
        {
            try
            {
                _service.Update(id, slot);
                return Ok("Updated successfully");
            }
            catch (SlotValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ndodhi nje gabim gjate perditesimit te slot-it.");
            }
        }

        [HttpPost("{id}/book")]
        public IActionResult Book(int id)
        {
            try
            {
                var slot = _service.GetById(id);
                if (slot == null)
                    return NotFound("Slot nuk u gjet");
                if (slot.IsBooked)
                    return BadRequest("Orari është tashmë i rezervuar.");

                slot.IsBooked = true;
                _service.Update(id, slot);
                return Ok(new { message = "Rezervimi u krye." });
            }
            catch (SlotValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ndodhi nje gabim gjate rezervimit.");
            }
        }

        [HttpPost("{id}/release")]
        public IActionResult Release(int id)
        {
            try
            {
                var slot = _service.GetById(id);
                if (slot == null)
                    return NotFound("Slot nuk u gjet");

                slot.IsBooked = false;
                _service.Update(id, slot);
                return Ok(new { message = "Rezervimi u anulua." });
            }
            catch (SlotValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ndodhi nje gabim gjate anulimit te rezervimit.");
            }
        }
    }
}
