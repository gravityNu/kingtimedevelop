using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace kingofTime.Models.ReadDocs
{
    public class PDFReader
    {
        [DllImport("pdftool.dll")]
        private static extern IntPtr LoadPDF(StringBuilder path);


        public int Read(string FileName)
        {
            var aa = LoadPDF(new StringBuilder("1月.pdf"));
            return 0;
        }
    }
}
