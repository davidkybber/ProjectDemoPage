using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ProjectDemoPage
{
    public class AzureBlobConnectionFactory : IAzureBlobConnectionFactory
    {
        const string _blobContainerName = "imagecontainer";
        static CloudBlobClient _blobClient;
        static CloudBlobContainer _blobContainer;
        private readonly IConfiguration _configuration;

        public AzureBlobConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration; 
        }
        public async Task<CloudBlobContainer> GetBlobContainer()
        {
            if (_blobContainer != null)
            {
                return _blobContainer;
            }

            var blobClient = GetClient();
            _blobContainer = blobClient.GetContainerReference(_blobContainerName);

            if(await _blobContainer.CreateIfNotExistsAsync())
            {
                await _blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }
            return _blobContainer;
        }

        private CloudBlobClient GetClient()
        {
            if (_blobClient != null)
            {
                return _blobClient;
            }

            var storageConnectionString = _configuration["StorageConnectionString"];
            if (string.IsNullOrWhiteSpace(storageConnectionString))
            {
                throw new ArgumentException("StorageConnectionString in config file cannot be null or white space");
            }

            if (!CloudStorageAccount.TryParse(storageConnectionString, out CloudStorageAccount storageAccount))
            {
                throw new Exception("Could not create Storage Account with storage connections string.");
            }

            _blobClient = storageAccount.CreateCloudBlobClient();

            return _blobClient;
        }
    }
}