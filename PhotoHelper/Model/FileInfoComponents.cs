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
        public string FullOldName { get; set; }
        public string FullNewName { get; set; }
        public string FullNewNameWithoutPathTo { get; set; }
        public string FileExtension { get; set; }

        public bool Additional { get; set; }

        public void Parsing(string FullOldFileName)
        {
            FullOldName = FullOldFileName;
            FullNewName = "";
            PathFrom = FullOldFileName.Substring(0, FullOldFileName.LastIndexOf('\\'));
            PathTo = "";
            FileId = FullOldFileName.Substring(FullOldFileName.LastIndexOf('_') + 1, FullOldFileName.LastIndexOf('.') - FullOldFileName.LastIndexOf('_') - 1);
            FileName = FullOldFileName.Substring(FullOldFileName.LastIndexOf('\\') + 1);
            FileExtension = FullOldFileName.Substring(FullOldFileName.LastIndexOf('.'));

        }
        
        public string MatchFullNewNameWithoutPathTo()
        {

            string temp="";
            temp = (Additional ? "Доп_" : "") + FileDescription + "_" + FileId + FileExtension;
                if(PathTo!="" && PathTo!=null && PathTo!=string.Empty && string.IsNullOrWhiteSpace(PathTo))
            {
                FullNewName = Path.Combine(PathTo, temp);
            }

            FullNewNameWithoutPathTo = temp;
            return FullNewNameWithoutPathTo;
        }

        
        public static FileInfoComponents[] GetFilesInfo(string folderPathFrom)
        { 
            if(Directory.Exists(folderPathFrom))
            {
                
                var filesNames = Directory.EnumerateFiles(folderPathFrom,"*.*",SearchOption.TopDirectoryOnly);
                if(filesNames!=null)
                {
                    List<FileInfoComponents> arrrayforreturn = new List<FileInfoComponents>() ;
                    
                    foreach(var item in filesNames)
                    {
                        FileInfoComponents currentFolder = new FileInfoComponents();
                        try
                        {
                            currentFolder.FullOldName = item;
                            currentFolder.FullNewName = "";
                            currentFolder.PathFrom = folderPathFrom;
                            currentFolder.PathTo = "";
                            currentFolder.FileId = item.Substring(item.LastIndexOf('_')+1, item.LastIndexOf('.') - item.LastIndexOf('_')-1);
                            currentFolder.FileName = item.Substring(item.LastIndexOf('\\') + 1);
                            currentFolder.FileExtension = item.Substring(item.LastIndexOf('.'));
                        }
                        catch(Exception e)
                        {
                            throw new Exception("Ошибка в преобразовании строк. " +e.Message);
                        }
                        arrrayforreturn.Add(currentFolder);
                    }
                    return arrrayforreturn.ToArray();
                }
            }
            return null;
        }
    }
}
