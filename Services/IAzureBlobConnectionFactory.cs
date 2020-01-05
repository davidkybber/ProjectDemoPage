using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ProjectDemoPage
{
    public interface IAzureBlobConnectionFactory
    {
        Task<CloudBlobContainer> GetBlobContainer();
    }
}