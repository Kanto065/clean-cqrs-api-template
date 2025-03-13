using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shared.Wrappers;

namespace Shared.Contracts
{
    public interface IFileManagementRepository
    {
        Task<Response<string>> UploadFile(IFormFile file, string directory);
        Response<bool> DeleteFile(string path);
    }
}
