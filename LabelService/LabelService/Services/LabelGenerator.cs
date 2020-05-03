using LabelService.DTO;
using LabelService.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using LabelService.Models;

namespace LabelService.Services
{
    public class LabelGenerator : ILabelGenerator
    {
        private LabelDataProvider _provider;

        public LabelGenerator()
        {
            _provider = new LabelDataProvider();
        }

        public string Generate(Label label, string identcode)
        {
            identcode = identcode.PadLeft(12, '0');
            _provider.Inicialize(label);
            var image = new Bitmap(400, 640);
            using (var graphic = Graphics.FromImage(image))
            {
                Brush brushBlack = Brushes.Black;

                var fontRegular = new Font(new FontFamily("Arial"), 10, FontStyle.Regular);
                var fontHeader = new Font(new FontFamily("Arial"), 14, FontStyle.Bold);

                graphic.Clear(Color.White);

                graphic.DrawString(_provider.GetSenderCompanyNameOrName, fontRegular, brushBlack, 20, 20);
                graphic.DrawString(_provider.GetSenderStreetHomeNo, fontRegular, brushBlack, 20, 60);
                graphic.DrawString(_provider.GetSenderZipCity, fontRegular, brushBlack, 20, 80);

                graphic.DrawString(_provider.GetReceiverCompanyNameOrName, fontHeader, brushBlack, 60, 190);
                graphic.DrawString(_provider.GetReceiverStreetHomeNo, fontRegular, brushBlack, 60, 230);
                graphic.DrawString(_provider.GetReceiverZipCity, fontRegular, brushBlack, 60, 250);
                graphic.DrawString(_provider.GetReceiverAnyContact, fontRegular, brushBlack, 60, 270);

                graphic.DrawString(_provider.GetDeliveryInstruction, fontRegular, brushBlack, 20, 360);
                graphic.DrawString(_provider.GetPrice, fontRegular, brushBlack, 20, 380);
                graphic.DrawString(_provider.GetWeight, fontRegular, brushBlack, 20, 400);

                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                Image img = b.Encode(BarcodeLib.TYPE.UPCA, identcode, Color.Black, Color.White, 200, 50);
                graphic.DrawImage(img, 100, 500);
                graphic.DrawString(identcode, fontRegular, brushBlack, 150, 550);
            }

            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] imageBytes = stream.ToArray();
            return Convert.ToBase64String(imageBytes);
        }
    }
}
