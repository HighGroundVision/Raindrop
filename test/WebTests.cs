using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HGV.Raindrop.Controllers;
using System.Threading.Tasks;

namespace HGV.Raindrop.Test
{
    [TestClass]
    public class WebTests
    {
        [TestMethod]
        public async Task Heroes()
        {
            var controller = new HeroesController();
            var list = await controller.Get();
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public async Task Abilities()
        {
            var controller = new AbilitiesController();
            var list = await controller.Get();
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public async Task Items()
        {
            var controller = new ItemsController();
            var list = await controller.Get();
            Assert.IsTrue(list.Count > 0);
        }
    }
}
