using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Xps.Packaging;

namespace kingofTime.Models.ReadDocs
{
    public class XPSReader
    {
        public int Read(string FileName)
        {
            System.Windows.Xps.Packaging.XpsDocument doc =
                new System.Windows.Xps.Packaging.XpsDocument(FileName, System.IO.FileAccess.Read);
            return 0;
        }
    }
}
