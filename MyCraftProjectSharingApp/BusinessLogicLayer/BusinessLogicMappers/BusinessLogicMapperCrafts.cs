using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataAccessObjects;
using BusinessLogicLayer.BusinessLogicObjects;

namespace BusinessLogicLayer.BusinessLogicMappers
{
    public class BusinessLogicMapperCrafts
    {
        public DataAccessCrafts MapCraft(BusinessLogicCrafts bCraft)
        {
            DataAccessCrafts dCraft = new DataAccessCrafts();
            dCraft.Craft_ID = bCraft.Craft_ID;
            dCraft.CraftName = bCraft.CraftName;
            dCraft.Description = bCraft.Description;
            dCraft.User_ID = bCraft.User_ID;
            return dCraft;
        }
        public BusinessLogicCrafts MapCraft(DataAccessCrafts dCraft)
        {
            BusinessLogicCrafts bCraft = new BusinessLogicCrafts();
            bCraft.Craft_ID = dCraft.Craft_ID;
            bCraft.CraftName = dCraft.CraftName;
            bCraft.Description = dCraft.Description;
            bCraft.User_ID = dCraft.User_ID;
            return bCraft;
        }
        public List<BusinessLogicCrafts> MapCrafts(List<DataAccessCrafts> dCrafts)
        {
            List<BusinessLogicCrafts> bCrafts = new List<BusinessLogicCrafts>();
            foreach (DataAccessCrafts dCraft in dCrafts)
            {
                bCrafts.Add(MapCraft(dCraft));
            }
            return bCrafts;
        }
        public List<DataAccessCrafts> MapCrafts(List<BusinessLogicCrafts> bCrafts)
        {
            List<DataAccessCrafts> dCrafts = new List<DataAccessCrafts>();
            foreach (BusinessLogicCrafts bCraft in bCrafts)
            {
                dCrafts.Add(MapCraft(bCraft));
            }
            return dCrafts;
        }
    }
}
