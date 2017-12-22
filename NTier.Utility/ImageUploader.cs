using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NTier.Utility
{
    public class ImageUploader
    {

        public static string UploadSingleImage(string serverPath,HttpPostedFileBase file)
        {
            if (file!=null)
            {
                var uniqueName = Guid.NewGuid();
                serverPath = serverPath.Replace("~", string.Empty);

                var fileArray = file.FileName.Split('.');
                string extension = fileArray[fileArray.Length - 1].ToLower();//Image uzantısını yakalıyoruz.

                var fileName = uniqueName + "." + extension;

                if (extension=="jpg" || extension =="png" || extension=="jpeg" || extension=="gif")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath+fileName)))
                    {
                        return "1";
                    }
                    else
                    {
                        var filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);

                        file.SaveAs(filePath);
                        return serverPath + fileName;
                    }
                }
                else
                {
                    return "2";
                }
            }
            return "0";
        }

    }
}
