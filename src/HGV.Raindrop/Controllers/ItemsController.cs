using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace HGV.Raindrop.Controllers
{
    [Produces("application/json")]
    [Route("api/items")]
    public class ItemsController : Controller
    {
        // GET api/items
        [HttpGet()]
        //[ResponseCache(Duration = 3600)]
        public async Task<string> Get()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync("https://raw.githubusercontent.com/dotabuff/d2vpkr/master/dota/scripts/npc/items.json");
                return json;
            }
        }
    }
}