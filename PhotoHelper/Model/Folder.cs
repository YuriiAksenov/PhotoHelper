using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoHelper.Model
{
    public class Folder
    {
        public string oldPath { get; set; }
        public string newPath { get; set; }
        public string fileName { get; set; }
        public string Id { get; set; }
        public string description { get; set;}
        public string count { get; set; }
        
        public bool additional { get; set; }


        public static Folder[] GetFiles(string folderPath)
        {
            
            if(Directory.Exists(folderPath))
            {
                var items = Directory.GetFiles(folderPath);
                if(items!=null)
                {
                    List<Folder> arforreturn = new List<Folder>() ;
                    
                    foreach(var item in items)
                    {
                        Folder currentFolder = new Folder();
                        currentFolder.oldPath = folderPath;
                        currentFolder.newPath = item;
                        currentFolder.fileName = Path.GetFileName(item);
                        arforreturn.Add(currentFolder);
                    }
                    return arforreturn.ToArray();
                }
            }
            return null;
        }
    }
}
