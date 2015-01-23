using Animes.Club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Animes.Club.Service;

namespace Animes.Club.Controllers
{
    public class AnimeController : ApiController
    {
        // GET: api/Anime
        public IEnumerable<Anime> Get()
        {
            using (var context = new Animes.Club.Models.AnimesClubContext())
            {
                return context.Animes.ToList();
            }
        }

        // GET: api/Anime?filter=abc
        public IEnumerable<Anime> Get(String q)
        {
            if (q.Length > 1)
            {
                //var a = CloudConfigurationManager.GetSetting("StorageConnectionString");
                var a = "DefaultEndpointsProtocol=http;AccountName=animesclub;AccountKey=wwOQtRoXycqHoNr+Q3f6YFDg1QJECpuG/MiK+TywaGR8uDQtMSF76b107WZwOrg6gPbX3KhF5Pbt0aAQIMQv5w==";
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(a);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("covers");
                DateTime expiryTime = DateTime.UtcNow.AddHours(1);

                using (var context = new Animes.Club.Models.AnimesClubContext())
                {
                    var result = context.Animes.Where(x => x.name.ToLower().Contains(q.ToLower())).Take(10).ToList();
                    result.ForEach(x => x.picture = BlobService.GetBlobSasUri(container, x.picture, expiryTime));
                    return result;
                }
            }
            return null;
        }

        

        //// GET: api/Anime/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Anime
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Anime/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Anime/5
        //public void Delete(int id)
        //{
        //}
    }
}
