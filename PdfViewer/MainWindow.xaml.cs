﻿using Patagames.Pdf.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PdfViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string pdfDocumentPath = "Resources\\sample.pdf";
        private const string pngDocumentPath = "Resources\\sample.png";
        public MainWindow()
        {
            InitializeComponent();
            ConvertPdfToPng();
        }

        private void ConvertPdfToPng()
        {
            PdfDocument document = PdfDocument.Load(pdfDocumentPath);
            int width = (int) document.Pages[0].Width;
            int height = (int) document.Pages[0].Height;

            WriteableBitmap image = document.Render(0, width, height);
            image.SaveToPng(pngDocumentPath);

        }
    }
}
