using LabelPlatform.DTO;
using LabelService.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LabelService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabelController : Controller
    {
        private ILabelRepository _labelRepository;

        public LabelController(ILabelRepository labelRepository)
        {
            _labelRepository = labelRepository;
        }

        [HttpDelete("delete/{identcode}")]
        public async Task<IActionResult> DeleteLabel(string identcode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid input, object invalid");
            }

            bool isDeleted = await _labelRepository.DeleteLabel(identcode);

            if (!isDeleted)
            {
                return StatusCode(410);
            }

            return Ok();
        }

        [HttpGet("label/{identcode}")]
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