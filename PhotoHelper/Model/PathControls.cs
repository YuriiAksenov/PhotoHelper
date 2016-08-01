using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoHelper.Model
{
    static public class PathControls
    {
        static public string PathFrom { get; set; }
        static public string PathTo { get; set; }
        static public string Filter { get; set; } = "*.*";
        static public SearchOption SearchOption { get; set; } = SearchOption.TopDirectoryOnly;
    }
}
