using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using HGV.Raindrop.Model;


namespace HGV.Raindrop.Clients
{
    public class ItemMetaClient
    {
        public async Task<List<Item>> GetItems()
        {
            var items = new List<Item>();


            using (var client = new HttpClient())
            {
                var npc_items_json = await client.GetStringAsync("https://raw.githubusercontent.com/dotabuff/d2vpkr/master/dota/scripts/npc/items.json");
                var npc_items_root = JObject.Parse(npc_items_json);
                var items_collection = npc_items_root["DOTAAbilities"].ToList();

                var npc_skills_json = await client.GetStringAsync("https://raw.githubusercontent.com/dotabuff/d2vpkr/master/dota/scripts/npc/npc_abilities.json");
                var npc_skills_root = JObject.Parse(npc_skills_json);
                var skill_defaults = npc_skills_root["DOTAAbilities"]["ability_base"];

                var item_data_json = await client.GetStringAsync("https://www.dota2.com/jsfeed/heropediadata?feeds=itemdata");
                var item_data_root = JObject.Parse(item_data_json);
                var item_data = item_data_root["itemdata"];

                foreach (JProperty i in items_collection)
                {
                    var key = i.Name;
                    if (key == "Version")
                        continue;
                    if (key == "item_river_painter")
                        continue;
                    if (key == "item_river_painter2")
                        continue;
                    if (key == "item_river_painter3")
                        continue;
                    if (key == "item_river_painter4")
                        continue;
                    if (key == "item_river_painter5")
                        continue;
                    if (key == "item_river_painter6")
                        continue;
                    if (key == "item_river_painter7")
                        continue;

                    // Create hero
                    var item = new Item();
                    item.key = key;
                    item.tag = key.Replace("item_", "");
                    item.name = (string)item_data[item.tag]["dname"];

                    // Set defaults
                    MapItem(item, skill_defaults);

                    // Map Hero details
                    var data = (JToken)i.First;
                    MapItem(item, data);

                    items.Add(item);
                }
            }

            return items;
        }

        private void MapItem(Item item, JToken item_data)
        {
            if (item_data["ID"] != null)
            {
                item.item_id = (int)item_data["ID"];
            }
            
        }
    }
}
