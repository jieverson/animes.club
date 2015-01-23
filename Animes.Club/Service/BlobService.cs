using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Animes.Club.Service
{
    public static class BlobService
    {

        public static string GetBlobSasUri(CloudBlobContainer container, String file_name, DateTime expiryTime)
        {
            var blob = container.GetBlockBlobReference(file_name);
            SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
            sasConstraints.SharedAccessExpiryTime = expiryTime;
            sasConstraints.Permissions = SharedAccessBlobPermissions.Read;

            string sasContainerToken = blob.GetSharedAccessSignature(sasConstraints);

            return blob.Uri + sasContainerToken;
        }

    }
}