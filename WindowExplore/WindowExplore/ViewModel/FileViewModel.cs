using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WindowExplore.ViewModel
{
    public class FileViewModel
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string DateCreate { get; set; }
        public string DateModify { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
    }
}