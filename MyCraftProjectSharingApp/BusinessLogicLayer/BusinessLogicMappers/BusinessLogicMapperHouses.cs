using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataAccessObjects;
using BusinessLogicLayer.BusinessLogicObjects;

namespace BusinessLogicLayer.BusinessLogicMappers
{
    public class BusinessLogicMapperHouses
    {
        public DataAccessHouses MapHouse(BusinessLogicHouses bHouse)
        {
            DataAccessHouses dHouse = new DataAccessHouses();
            dHouse.House_ID = bHouse.House_ID;
            dHouse.HouseName = bHouse.HouseName;
            dHouse.Motto = bHouse.Motto;
            dHouse.Points = bHouse.Points;
            return dHouse;
        }
        public BusinessLogicHouses MapHouse(DataAccessHouses dHouse)
        {
            BusinessLogicHouses bHouse = new BusinessLogicHouses();
            bHouse.House_ID = dHouse.House_ID;
            bHouse.HouseName = dHouse.HouseName;
            bHouse.Motto = dHouse.Motto;
            bHouse.Points = dHouse.Points;
            return bHouse;
        }
        public List<BusinessLogicHouses> MapHouses(List<DataAccessHouses> dHouses)
        {
            List<BusinessLogicHouses> bHouses = new List<BusinessLogicHouses>();
            foreach (DataAccessHouses dHouse in dHouses)
            {
                bHouses.Add(MapHouse(dHouse));
            }
            return bHouses;
        }
        public List<DataAccessHouses> MapHouses(List<BusinessLogicHouses> bHouses)
        {
            List<DataAccessHouses> dHouses = new List<DataAccessHouses>();
            foreach (BusinessLogicHouses bHouse in bHouses)
            {
                dHouses.Add(MapHouse(bHouse));
            }
            return dHouses;
        }
    }
}
