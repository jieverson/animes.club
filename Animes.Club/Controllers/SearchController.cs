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
using System.Web.Mvc;
using Animes.Club.DTOs;
using System.Text.RegularExpressions;

namespace Animes.Club.Controllers
{
    public class SearchController : ApiController
    {
        // GET: api/Anime
        //public IEnumerable<Anime> Get()
        //{
        //    using (var context = new Animes.Club.Models.AnimesClubContext())
        //    {
        //        return context.Animes.ToList();
        //    }
        //}

        // GET: api/Search?q=abc
        [OutputCache(Duration = 1 * 60)]
        public IEnumerable<SearchResultDTO> Get(String q)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("covers");
            DateTime expiryTime = DateTime.UtcNow.AddMinutes(2);

            using (var context = new AnimesClubContext())
            {
                return context.Animes.Where(x => x.name.ToLower().Contains(q.ToLower())).Take(5).ToList().Select(x => new SearchResultDTO
                {
                    id = x.id,
                    name = x.name,
                    address = Regex.Replace(x.name, @"[^0-9a-zA-Z\._]", "_"),
                    picture = BlobService.GetBlobSasUri(container, x.picture, expiryTime)
                });
            }
        }

        // GET: api/Anime/5
        public Anime Get(long id)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("covers");
            DateTime expiryTime = DateTime.UtcNow.AddSeconds(30);

            using (var context = new AnimesClubContext())
            {
                var anime = context.Animes.Find(id);
                anime.picture = BlobService.GetBlobSasUri(container, anime.picture, expiryTime);
                return anime;
            }
        }

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
