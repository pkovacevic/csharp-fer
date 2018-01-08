using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Demo03_AzureStorage.Utilities
{
    public class AzureStorageUtility
    {
        private readonly string _accountName;
        private readonly string _accountKey;

        public AzureStorageUtility(string accountName, string accountKey)
        {
            _accountName = accountName;
            _accountKey = accountKey;
        }

        public async Task<string> Upload(string containerName, byte[] data)
        {
            StorageCredentials storageCredentials = new StorageCredentials(_accountName, _accountKey);
            // Create cloudstorage account by passing the storagecredentials
            CloudStorageAccount storageAccount = new CloudStorageAccount(storageCredentials, true);

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Get reference to the blob container by passing the name by reading the value from the configuration (appsettings.json)
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync(BlobContainerPublicAccessType.Blob, new BlobRequestOptions(), new OperationContext());

            // Get the reference to the block blob from the container
            string fileName = Guid.NewGuid().ToString();
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

            // Upload the file
            await blockBlob.UploadFromByteArrayAsync(data, 0, data.Length);

            return blockBlob.Uri.ToString();
        }
    }
}
