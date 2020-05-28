using LabelPlatform.DTO;
using LabelService.Extensions;
using LabelService.Models;
using LabelService.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LabelService.DatabaseContext
{
    public class LabelRepository : ILabelRepository
    {
        private readonly DataContext _context;
        private readonly ILabelGenerator _labelGenerator;
        private readonly IIdentcodeGenerator _identcodeGenerator;

        public LabelRepository(DataContext context, ILabelGenerator labelGenerator, IIdentcodeGenerator identcodeGenerator)
        {
            _context = context;
            _labelGenerator = labelGenerator;
            _identcodeGenerator = identcodeGenerator;
        }

        public async Task<bool> CreateLabel(Label label)
        {
            await _context.Labels.AddAsync(label);
            return true;
        }

        public async Task<bool> DeleteLabel(string identifier)
        {
            var labelExist = await _context.Labels.FirstAsync(x => x.Identcode == identifier);

            if (labelExist == null)
            {
                return false;
            }

            _context.Labels.Remove(labelExist);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Label> GetLabel(string identcode)
        {
            return await _context.Labels.FirstOrDefaultAsync(x => x.Identcode.Equals(identcode));
        }

        public async Task<Label> CreateLabel(LabelDTO dto)
        {
            Label label = new Label
            {
                Sender = dto.Sender.RetrieveAddress(),
                Receiver = dto.Receiver.RetrieveAddress(),
                Features = dto.Features.RetrieveFeatures(),
                Identcode = _identcodeGenerator.Call(),
            };

            label.Base64 = _labelGenerator.Generate(label);

            await _context.Labels.AddAsync(label).ConfigureAwait(true);
            await _context.SaveChangesAsync();

            return label;
        }
    }
}