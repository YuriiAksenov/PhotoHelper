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
        public string PathFrom { get; set; }
        public string PathTo { get; set; }
        public string FileName { get; set; }
        public string FileId { get; set; }
        public string FileDescription { get; set;}
        public string CompomnentCount { get; set; }

        public bool Additional { get; set; }


        public static FileInfoComponents[] GetFilesInfo(string folderPath)
        {
            
            if(Directory.Exists(folderPath))
            {
                
                var filesNames = Directory.EnumerateFiles(folderPath,"*.*",SearchOption.TopDirectoryOnly);
                if(filesNames!=null)
                {
                    List<FileInfoComponents> arrrayforreturn = new List<FileInfoComponents>() ;
                    
                    foreach(var item in filesNames)
                    {
                        FileInfoComponents currentFolder = new FileInfoComponents();
                        currentFolder.PathFrom = folderPath;
                        currentFolder.PathTo = "";
                        currentFolder.FileName = item.Substring(item.LastIndexOf('\\')+1);
                        arrrayforreturn.Add(currentFolder);
                    }
                    return arrrayforreturn.ToArray();
                }
            }
            return null;
        }
    }
}
