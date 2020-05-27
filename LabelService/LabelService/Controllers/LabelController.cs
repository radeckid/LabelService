using System.Threading.Tasks;
using LabelService.DatabaseContext;
using LabelService.DTO;
using LabelService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LabelService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabelController : Controller, ILabelController
    {
        private ILabelRepository _labelRepository;

        public LabelController(ILabelRepository labelRepository)
        {
            _labelRepository = labelRepository;
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteLabel(string identifier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid input, object invalid");
            }

            bool isDeleted = await _labelRepository.DeleteLabel(identifier);

            if (!isDeleted)
            {
                return StatusCode(410);
            }

            return Ok();
        }

        [HttpGet("label/{id}")]
        public async Task<IActionResult> GetLabel(string identcode)
        {
            if (!ModelState.IsValid || identcode == null)
            {
                return BadRequest();
            }

            var label = await _labelRepository.GetLabel(identcode);

            if (label == null)
            {
                return NotFound();
            }

            return Ok(label.Base64);
        }

        [HttpPost("label")]
        public async Task<IActionResult> CreateLabel(LabelDTO label)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid input, object invalid");
            }

            return Ok((await _labelRepository.CreateLabel(label)).Base64);
        }
    }
}