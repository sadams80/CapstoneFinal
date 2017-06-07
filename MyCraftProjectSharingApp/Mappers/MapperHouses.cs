using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer.BusinessLogicObjects;
using MyCraftProjectSharingApp.Models;

namespace MyCraftProjectSharingApp.Mappers
{
    public class MapperHouses
    {
        public BusinessLogicHouses Maphouse(Houses house)
        {
            BusinessLogicHouses bhouse = new BusinessLogicHouses();
            bhouse.House_ID = house.House_ID;
            bhouse.HouseName = house.HouseName;
            bhouse.Motto = house.Motto;
            bhouse.Points = house.Points;
            return bhouse;
        }
        public Houses Maphouse(BusinessLogicHouses bhouse)
        {
            Houses house = new Houses();
            house.House_ID = bhouse.House_ID;
            house.HouseName = bhouse.HouseName;
            house.Motto = bhouse.Motto;
            house.Points = bhouse.Points;
            return house;
        }
        public List<Houses> MapHouses(List<BusinessLogicHouses> bHouses)
        {
            List<Houses> Houses = new List<Houses>();
            foreach (BusinessLogicHouses bHouse in bHouses)
            {
                Houses.Add(Maphouse(bHouse));
            }
            return Houses;
        }
        public List<BusinessLogicHouses> MapHouses(List<Houses> Houses)
        {
            List<BusinessLogicHouses> bHouses = new List<BusinessLogicHouses>();
            foreach (Houses house in Houses)
            {
                bHouses.Add(Maphouse(house));
            }
            return bHouses;
        }
    }
}