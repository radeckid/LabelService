
using LabelService.DTO;

namespace LabelService.Services
{
    public interface ILabelGenerator
    {
        string Generate(LabelDTO label, string identcode);
    }
}
