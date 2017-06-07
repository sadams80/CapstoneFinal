using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer.BusinessLogicObjects;
using MyCraftProjectSharingApp.Models;

namespace MyCraftProjectSharingApp.Mappers
{
    public class MapperCrafts
    {
        public BusinessLogicCrafts MapCraft(Crafts craft)
        {
            BusinessLogicCrafts bCraft = new BusinessLogicCrafts();
            bCraft.Craft_ID = craft.Craft_ID;
            bCraft.CraftName = craft.CraftName;
            bCraft.Description = craft.Description;
            bCraft.User_ID = craft.User_ID;
            return bCraft;
        }
        public Crafts MapCraft(BusinessLogicCrafts bCraft)
        {
            Crafts craft = new Crafts();
            craft.Craft_ID = bCraft.Craft_ID;
            craft.CraftName = bCraft.CraftName;
            craft.Description = bCraft.Description;
            craft.User_ID = bCraft.User_ID;
            return craft;
        }
        public List<Crafts> MapCrafts(List<BusinessLogicCrafts> bCrafts)
        {
            List<Crafts> crafts = new List<Crafts>();
            foreach (BusinessLogicCrafts bCraft in bCrafts)
            {
                crafts.Add(MapCraft(bCraft));
            }
            return crafts;
        }
        public List<BusinessLogicCrafts> MapCrafts(List<Crafts> crafts)
        {
            List<BusinessLogicCrafts> bCrafts = new List<BusinessLogicCrafts>();
            foreach (Crafts craft in crafts)
            {
                bCrafts.Add(MapCraft(craft));
            }
            return bCrafts;
        }
    }
}