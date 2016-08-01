using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoHelper.Model
{
    public class ForCollectionItems
    {
        public string FileName { get; set; }
        public string FileOnlyId { get; set; }

        public static ForCollectionItems[] GetItems(string FolderPath,string Filter="*.*",SearchOption SearchOption=SearchOption.TopDirectoryOnly)
        {
            if(Directory.Exists(FolderPath))
            {
                var files = Directory.GetFiles(FolderPath, Filter,SearchOption);
                if(files!=null)
                {
                    List<ForCollectionItems> listCollectionItems = new List<ForCollectionItems>();
                    foreach(var file in files)
                    {
                        ForCollectionItems collectionItem = new ForCollectionItems();
                        try
                        {
                            collectionItem.FileName = file.Substring(file.LastIndexOf('\\') + 1);
                            if (file.Contains('_'))
                            { collectionItem.FileOnlyId = file.Substring(file.LastIndexOf('_') + 1, file.LastIndexOf('.') - file.LastIndexOf('_') - 1); }
                            else
                            {
                                collectionItem.FileOnlyId = collectionItem.FileName;
                            }
                            listCollectionItems.Add(collectionItem);
                        }
                        catch(Exception e)
                        {
                            throw new Exception("Ошибка в парсинге названия. "+e.Message);
                        }

                    }
                    return listCollectionItems.ToArray();
                }
                
            }
            return null;
        }
    }
}
