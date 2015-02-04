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
        
        // GET: api/Search?q=abc
        public IEnumerable<SearchResultDTO> Get(String q)
        {
            CloudBlobContainer container = BlobService.GetCoversContainer(true);
            DateTime expiryTime = DateTime.UtcNow.AddSeconds(30);

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

    }
}
