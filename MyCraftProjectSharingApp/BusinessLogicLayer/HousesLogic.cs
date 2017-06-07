using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.BusinessLogicMappers;
using BusinessLogicLayer.BusinessLogicObjects;
using DataAccessLayer;
using DataAccessLayer.DataAccessObjects;

namespace BusinessLogicLayer
{
    public class HousesLogic
    {
        static HousesDataAccess _housesDataAccess = new HousesDataAccess();
        static BusinessLogicMapperHouses _housesMapper = new BusinessLogicMapperHouses();
        public List<BusinessLogicHouses> GetHouses()
        {
            List<BusinessLogicHouses> bHouses = new List<BusinessLogicHouses>();
            List<DataAccessHouses> dHouses = new List<DataAccessHouses>();
            dHouses = _housesDataAccess.GetHouses();
            bHouses = _housesMapper.MapHouses(dHouses);
            return bHouses;
        }
        public void UpdateHousePoints(long points, int houseId)
        {
            _housesDataAccess.UpdateHousePoints(points, houseId);
        }
        public BusinessLogicHouses TopHousePoints()
        {
            List<BusinessLogicHouses> houseList = GetHouses();

            BusinessLogicHouses topHouse = new BusinessLogicHouses();
            long highestPoints = 0;
            foreach (BusinessLogicHouses house in houseList)
            {
                if (house.Points > highestPoints)
                {
                    highestPoints = house.Points;
                    topHouse.HouseName = house.HouseName;
                    topHouse.Points = highestPoints;
                }
            }
            return topHouse;
        }
    }
}
