using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ServerApp.Repo
{
    public interface IImageRepository
    {
        Task<string> Upload(IFormFile file,string fileName);
    }
}