using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using HGV.Raindrop.Clients;
using HGV.Raindrop.Model;

namespace HGV.Raindrop.Controllers
{
    [Produces("application/json")]
    [Route("api/items")]
    public class ItemsController : Controller
    {
        // GET api/items
        [HttpGet()]
        //[ResponseCache(Duration = 3600)]
        public async Task<List<Item>> Get()
        {
            var client = new ItemMetaClient();
            var items = await client.GetItems();
            return items;
        }
    }
}