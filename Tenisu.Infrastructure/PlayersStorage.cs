using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenisu.Infrastructure
{
    public class PlayersStorage
    {
       
        public static async Task GetFile()
        {
            string _connectionString = "DefaultEndpointsProtocol=https;AccountName=tenisusto;AccountKey=qB60qb84ZO9Cw70AaCf1valfKi3kFkZ7t1WjQ6Tg57S6lB9K0CcYpiiHGy0BRAryVvMrSHr+EURh+AStwRMlNg==;EndpointSuffix=core.windows.net";
            string _blobName = "PlayersDB.json";
            string _containername = "tenisucontainer";
            string _downloadFilePath = "Data/PlayersDB.json";
            var blobServiceClient = new BlobServiceClient(_connectionString);

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_containername);

            BlobClient blobClient = containerClient.GetBlobClient(_blobName);

            string directoryPath = Path.GetDirectoryName(_downloadFilePath);
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine($"Directory does not exist. Creating: {directoryPath}");
                Directory.CreateDirectory(directoryPath);
            }
            try
            {
                // Download the blob to a local file
                Console.WriteLine($"Downloading blob '{_blobName}' to '{_downloadFilePath}'...");
                //await blobClient.DownloadToAsync(_downloadFilePath);
                string fileContent = await File.ReadAllTextAsync(_downloadFilePath);

                Console.WriteLine("Download completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }


        }

    }
}
