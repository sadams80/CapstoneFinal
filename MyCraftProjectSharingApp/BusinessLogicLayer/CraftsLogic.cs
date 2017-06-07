using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.BusinessLogicObjects;
using BusinessLogicLayer.BusinessLogicMappers;
using DataAccessLayer.DataAccessObjects;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class CraftsLogic
    {
        static BusinessLogicMapperCrafts _craftMapper = new BusinessLogicMapperCrafts();
        static CraftsDataAccess _craftDataAccess = new CraftsDataAccess();
        public void AddCraft(BusinessLogicCrafts bCraft)
        {
            _craftDataAccess.AddCraft(_craftMapper.MapCraft(bCraft));
        }
        public List<BusinessLogicCrafts> GetCrafts()
        {
            List<BusinessLogicCrafts> bCrafts = new List<BusinessLogicCrafts>();
            List<DataAccessCrafts> dCrafts = new List<DataAccessCrafts>();
            dCrafts = _craftDataAccess.GetCrafts();
            bCrafts = _craftMapper.MapCrafts(dCrafts);
            return bCrafts;
        }
        public BusinessLogicCrafts GetCraftByCraftId(int craftId)
        {
            return _craftMapper.MapCraft(_craftDataAccess.GetCraftByCraftId(craftId));
        }
        public BusinessLogicCrafts GetCraftByCraftName(string craftName)
        {
            return _craftMapper.MapCraft(_craftDataAccess.GetCraftsByCraftName(craftName));
        }
        public void UpdateCraft(int craftId, BusinessLogicCrafts bCraft)
        {
            _craftDataAccess.UpdateCraft(craftId, _craftMapper.MapCraft(bCraft));
        }
        public void DeleteCraft(int craftId)
        {
            _craftDataAccess.DeleteCraft(craftId);
        }
    }
}
