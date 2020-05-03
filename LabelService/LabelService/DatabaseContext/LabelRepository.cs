using System.Data.Entity;
using System.Threading.Tasks;
using LabelService.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LabelService.DatabaseContext
{
    public class LabelRepository : ILabelRepository
    {
        private readonly DataContext _context;

        public LabelRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateLabel(Label label)
        {
            await _context.Labels.AddAsync(label);
            return true;
        }

        public async Task<bool> DeleteLabel(Label label)
        {
            var labelExist = await _context.Labels.FirstAsync(x => x.LabelId == label.LabelId);

            if (labelExist == null)
            {
                return false;
            }

            _context.Labels.Remove(labelExist);
            return true;
        }

        public async Task<Label> GetLabel(int id)
        {
            return await _context.Labels.FirstAsync(x => x.LabelId == id);
        }
    }
}