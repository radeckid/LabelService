
using LabelService.DTO;
using LabelService.Models;

namespace LabelService.Services
{
    public interface ILabelGenerator
    {
        string Generate(Label label);
    }
}
