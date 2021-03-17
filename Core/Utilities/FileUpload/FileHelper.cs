using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileUpload
{
   public class FileHelper
    {
        private static string directory = Environment.CurrentDirectory + @"\wwwroot\images\";
       
        public static IResult Add(IFormFile file)
        {
            if (file.FileName.Length > 0)
            {
                var guidName = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(file.FileName);  //sondaki eklentisi al
                using (FileStream stream =File.Create(directory+guidName+extension))
                {
                    file.CopyTo(stream);
                    stream.Flush();

                }
                return new SuccessResult((guidName+extension));
            }
            return new ErrorResult();
        }
        public static IResult Delete(string file)
        {
            File.Delete(directory + file);
            return new SuccessResult();
        }
        public static IResult Update(IFormFile file,string path)
        {
            var guidName = Guid.NewGuid().ToString();
            var extension = Path.GetExtension(file.FileName);
            FileHelper.Delete(path);
            FileHelper.Add(file);
            return new SuccessResult(guidName+extension);
        }

    }
}
