using kingofTime.Models.ReadDocs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kingofTime.Models
{
    public class MainModel
    {
        private PDFReader PDFReader;

        public MainModel()
        {
            PDFReader = new PDFReader();
        }

        public void LoadPDF()
        {
            PDFReader.Read("");
        }

    }
}
