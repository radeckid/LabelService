using System.Threading.Tasks;
using LabelService.DTO;
using LabelService.Models;

namespace LabelService.DatabaseContext
{
    public interface ILabelRepository
    {
        Task<Label> CreateLabel(LabelDTO label);
        Task<bool> DeleteLabel(string identifier);
        Task<Label> GetLabel(string id);
    }
}