using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ServerApp.Repo
{
    public class LocaleStrogeImageRepository : IImageRepository
    {
        public async Task<string> Upload(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),@"Resources\Images",fileName);
            using Stream fileStream = new FileStream(filePath,FileMode.Create);
            await file.CopyToAsync(fileStream);
            return GetServerReleativePath(fileName);
        }

        private string GetServerReleativePath(string fileName)
        {
            return Path.Combine(@"Resources\Images",fileName);
        }
    }
}