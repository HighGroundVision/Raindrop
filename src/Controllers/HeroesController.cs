using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HGV.Basilius.Model;
using HGV.Basilius.Clients;

namespace HGV.Raindrop.Controllers
{
    [Produces("application/json")]
    [Route("api/heroes")]
    public class HeroesController : Controller
    {
        // GET api/heroes/
        [HttpGet("")]
        [ResponseCache(Duration = 3600)]
        public async Task<List<Hero>> Get()
        {
            var client = new HeroMetaClient();
            var heroes = await client.GetHeroes();
            return heroes;
        }
    }
}