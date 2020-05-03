using System.Threading.Tasks;
using LabelService.Models;

namespace LabelService.DatabaseContext
{
    public interface ILabelRepository
    {
        Task<bool> CreateLabel(Label label);
        Task<bool> DeleteLabel(Label label);
        Task<Label> GetLabel(int id);
    }
}