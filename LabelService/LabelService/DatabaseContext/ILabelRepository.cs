using LabelPlatform.DTO;
using LabelService.Models;
using System.Threading.Tasks;

namespace LabelService.DatabaseContext
{
    public interface ILabelRepository
    {
        Task<Label> CreateLabel(LabelDTO label);
        Task<bool> DeleteLabel(string identifier);
        Task<Label> GetLabel(string id);
    }
}