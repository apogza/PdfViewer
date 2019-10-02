using Patagames.Pdf.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PdfViewer
{
    public static class PdfDocumentExtensions
    {
        public static WriteableBitmap Render(this PdfDocument document, int page, int width, int height)
        {
            WriteableBitmap image = null;
            using (var pdfBitMap = new PdfBitmap(width, height, true))
            {
                document.Pages[0].Render(pdfBitMap,
                    0, 0, width, height,
                    Patagames.Pdf.Enums.PageRotate.Normal, Patagames.Pdf.Enums.RenderFlags.FPDF_NONE);

                image = new WriteableBitmap(pdfBitMap.Width, pdfBitMap.Height, 300, 300, PixelFormats.Bgra32, null);

                image.WritePixels(new Int32Rect(0, 0, pdfBitMap.Width, pdfBitMap.Height),
                    pdfBitMap.Buffer, pdfBitMap.Stride * pdfBitMap.Height, pdfBitMap.Stride, 0, 0);
            }

            return image;
        }
    }
}
