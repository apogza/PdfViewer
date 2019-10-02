using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PdfViewer
{
    public static class WriteableImageExtensions
    {
        public static void SaveToPng(this WriteableBitmap image,string path)
        {
            using (var stream = File.OpenWrite(path))
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
            }
        }
    }
}
