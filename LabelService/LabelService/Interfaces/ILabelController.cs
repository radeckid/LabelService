using LabelService.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LabelService.Interfaces
{
    public interface ILabelController
    {
        Task<IActionResult> DeleteLabel(string identfier);
        Task<IActionResult> GetLabel(string id);
        Task<IActionResult> CreateLabel(LabelDTO label);
    }
}
