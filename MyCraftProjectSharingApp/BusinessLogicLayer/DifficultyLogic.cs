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
    public class DifficultyLogic
    {
        static BusinessLogicMapperDifficulty _difficultyMapper = new BusinessLogicMapperDifficulty();
        static DifficultyDataAccess _difficultyDataAccess = new DifficultyDataAccess();
        public List<BusinessLogicDifficulty> GetDifficulty()
        {
            List<BusinessLogicDifficulty> bDifficulties = new List<BusinessLogicDifficulty>();
            List<DataAccessDifficulty> dDifficulties = new List<DataAccessDifficulty>();
            dDifficulties = _difficultyDataAccess.GetDifficulty();
            bDifficulties = _difficultyMapper.MapDifficulties(dDifficulties);
            return bDifficulties;
        }
    }
}
