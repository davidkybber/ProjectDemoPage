using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectDemoPage
{
    public interface IAzureBlobService
    {
        Task<IEnumerable<Uri>> ListAsync();
        Task UploadAsync(IFormFileCollection files);
        Task DeleteAsync(string fileUri);
        Task DeleteAllAsync();
    }
}