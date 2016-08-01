using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoHelper.Model
{
    public class FileInfoComponents
    {
        public string FileOldName { get; set; }
        public string FileNewName { get; set; }
        public string FileId { get; set; }
        public string FileDescription { get; set;}
        public string FileExtension { get; set; }

        public int ComponentCount { get; set; }
        public bool Additional { get; set; }

        public FileInfoComponents() : this("None") {}
        public FileInfoComponents(string OldFileName)
        {
            if (OldFileName != "None" && !string.IsNullOrWhiteSpace(OldFileName))
            {
                Parsing(OldFileName);
            }
        }

        public void Parsing(string OldFileName)
        {
            FileNewName = "";
            FileId = OldFileName.Substring(OldFileName.LastIndexOf('_') + 1, OldFileName.LastIndexOf('.') - OldFileName.LastIndexOf('_') - 1);
            FileOldName = OldFileName.Substring(OldFileName.LastIndexOf('\\') + 1);
            FileExtension = OldFileName.Substring(OldFileName.LastIndexOf('.'));

        }
        
        public string CombineNewName()
        {
            string temp="";
            temp = (Additional? "Доп_" : "") + FileDescription + "_" + FileId + FileExtension;

            FileNewName = temp;
            return FileNewName;
        }

    }
}
