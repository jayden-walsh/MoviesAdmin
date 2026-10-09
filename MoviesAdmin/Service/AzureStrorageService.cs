using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MoviesAdmin.Service
{
    public class AzureStrorageService : IAzureStrorageService
    {
        private readonly IConfiguration _configuration;

        private readonly BlobServiceClient _blobServiceClient;
        private string containerName;

        public AzureStrorageService(IConfiguration configuration)
        {
            _configuration = configuration;
            containerName = _configuration["AzureStorage:ContainerName"] ?? throw new InvalidOperationException("Missing configuration: AzureStorage:ContainerName");
            string connectionString = _configuration["AzureStorage:ConnectionString"] ?? throw new InvalidOperationException("Missing configuration: AzureStorage:ConnectionString");
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task<string> UploadFileAsync(IFormFile file, string filename)
        {
            if (file == null) throw new ArgumentNullException(nameof(file));
            if (string.IsNullOrWhiteSpace(filename)) throw new ArgumentException("Filename must be provided", nameof(filename));

            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync();

            var blobClient = containerClient.GetBlobClient(filename);

            using (var stream = file.OpenReadStream())
            {
                // UploadAsync(stream, overwrite: true) is available on BlobClient
                await blobClient.UploadAsync(stream, overwrite: true);
            }

            // Return the URI (or change to return whatever value your interface expects)
            return blobClient.Uri.ToString();
        }
    }
}
