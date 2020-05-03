using System.Net;
using System.Threading.Tasks;
using LabelService.DatabaseContext;
using LabelService.DTO;
using LabelService.Models;
using LabelService.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabelService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabelController : Controller
    {
        private IIdentcodeGenerator _identcodeGenerator;
        private ILabelGenerator _labelGenerator;
        private ILabelRepository _labelRepository;

        public LabelController(IIdentcodeGenerator identcodeGenerator, ILabelGenerator labelGenerator, ILabelRepository labelRepository)
        {
            _identcodeGenerator = identcodeGenerator;
            _labelGenerator = labelGenerator;
            _labelRepository = labelRepository;
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteLabel(LabelDTO label)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid input, object invalid");
            }

            Label labelToDelete = new Label
            {
                SenderName = label.SenderName,
                SenderSurname = label.SenderSurname,
                SenderCity = label.SenderCity,
                SenderCompany = label.SenderCompany,
                SenderStreet = label.SenderStreet,
                SenderZip = label.SenderZip,
                SenderHomeNo = label.SenderHomeNo,
                ReceiverCity = label.ReceiverCity,
                ReceiverCompany = label.ReceiverCompany,
                ReceiverEmail = label.ReceiverEmail,
                ReceiverMobile = label.ReceiverMobile,
                ReceiverName = label.ReceiverName,
                ReceiverStreet = label.ReceiverStreet,
                ReceiverSurname = label.ReceiverSurname,
                ReceiverZip = label.ReceiverZip,
                ReceiverHomeNo = label.ReceiverHomeNo
            };

            bool isDeleted = await _labelRepository.DeleteLabel(labelToDelete);

            if (!isDeleted)
            {
                return StatusCode(410);
            }

            return Ok();
        }

        [HttpGet("label/{id}")]
        public async Task<IActionResult> GetLabel(string id)
        {
            bool isInt = int.TryParse(id, out int result);

            if (!isInt)
            {
                return BadRequest();
            }

            var label = await _labelRepository.GetLabel(result);

            if (label == null)
            {
                return NotFound();
            }

            var labelBase64 = _labelGenerator.Generate(label, _identcodeGenerator.Call());

            return Ok(labelBase64);
        }

        [HttpPost("/label")]
        public async Task<IActionResult> CreateLabel(LabelDTO label)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid input, object invalid");
            }

            Label newLabel = new Label
            {
                SenderName = label.SenderName,
                SenderSurname = label.SenderSurname,
                SenderCity = label.SenderCity,
                SenderCompany = label.SenderCompany,
                SenderStreet = label.SenderStreet,
                SenderZip = label.SenderZip,
                SenderHomeNo = label.SenderHomeNo,
                ReceiverCity = label.ReceiverCity,
                ReceiverCompany = label.ReceiverCompany,
                ReceiverEmail = label.ReceiverEmail,
                ReceiverMobile = label.ReceiverMobile,
                ReceiverName = label.ReceiverName,
                ReceiverStreet = label.ReceiverStreet,
                ReceiverSurname = label.ReceiverSurname,
                ReceiverZip = label.ReceiverZip,
                ReceiverHomeNo = label.ReceiverHomeNo,
                DeliveryIns = label.DeliveryIns,
                Weight = label.Weight,
                Currency = label.Currency,
                Price = label.Price
            };

            bool created = await _labelRepository.CreateLabel(newLabel);

            var labelBase64 = _labelGenerator.Generate(newLabel, _identcodeGenerator.Call());

            if (created)
            {
                return Created("", labelBase64);
            }

            return Conflict();
        }
    }
}