using System.Threading.Tasks;
using LabelService.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using LabelService.Services;

namespace LabelService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabelController : Controller
    {
        private IIdentcodeGenerator _identcodeGenerator;
        private ILabelGenerator _labelGenerator;

        public LabelController(IIdentcodeGenerator identcodeGenerator, ILabelGenerator labelGenerator)
        {
            _identcodeGenerator = identcodeGenerator;
            _labelGenerator = labelGenerator;
        }

        [HttpGet]
        public async Task<IActionResult> GetLabel(string guid)
        {
            return BadRequest("Not implemented");
        }

        [HttpPost("generate")]
        public async Task<IActionResult> CreateLabel(LabelDTO label)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Wrong request");
            }

            var labelBase64 = _labelGenerator.Generate(label, _identcodeGenerator.Call());

            return Ok(labelBase64);
        }
    }
}