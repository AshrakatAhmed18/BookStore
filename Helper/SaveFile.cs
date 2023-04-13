using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BooksEccommerce.Helper
{
    public class SaveFile
    {
        public static string SaveFilee(IFormFile file, string path)
        {
            var FilePath = Directory.GetCurrentDirectory() + path;
            var FileName = Guid.NewGuid() + Path.GetFileName(file.FileName);
            var FinalPath = Path.Combine(FilePath, FileName);
            using (var Stream = new FileStream(FinalPath, FileMode.Create))
            {
                 file.CopyTo(Stream);
            }
            return $"/images/{FileName}";
        }
        public static async Task DeletFileAsync(string path)
        {
            var oldFilePath = Directory.GetCurrentDirectory() + "/wwwroot/" + path;
            if (File.Exists(oldFilePath))
            {
                // If file found, delete it    
                File.Delete(oldFilePath);
            }
        }
    }
}
