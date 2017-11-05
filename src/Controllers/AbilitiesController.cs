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
    [Route("api/abilities")]
    public class AbilitiesController : Controller
    {
        // GET api/abilities/
        [HttpGet("")]
        [ResponseCache(Duration = 3600)]
        public async Task<List<Ability>> Get()
        {
            var client = new HeroMetaClient();
            var heroes = await client.GetHeroes();
            var abilities = heroes.SelectMany(_ => _.abilities).ToList();
            return abilities;
        }
    }
}