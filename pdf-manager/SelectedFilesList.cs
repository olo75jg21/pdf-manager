using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf_manager
{
    internal class FilePath
    {
        private string _Path;
        public string Path { get { return _Path; } set { _Path = value; } }
        public string Name { get { return System.IO.Path.GetFileName(_Path); } }
    }
}
