using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Animes.Club.Service
{
    public static class BlobService
    {

        public static CloudBlobContainer GetCoversContainer(bool small = false)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(small ? "small" : "big");
            return container;
        }

        public static string GetBlobSasUri(CloudBlobContainer container, String file_name, DateTime expiryTime)
        {
            if (!String.IsNullOrEmpty(file_name))
            {
                var blob = container.GetBlockBlobReference(file_name);
                SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
                sasConstraints.SharedAccessExpiryTime = expiryTime;
                sasConstraints.Permissions = SharedAccessBlobPermissions.Read;

                string sasContainerToken = blob.GetSharedAccessSignature(sasConstraints);

                return blob.Uri + sasContainerToken;
            }
            else
            {
                return String.Empty;
            }
        }

    }
}