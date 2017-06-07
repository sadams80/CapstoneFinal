using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataAccessObjects;
using BusinessLogicLayer.BusinessLogicObjects;

namespace BusinessLogicLayer.BusinessLogicMappers
{
    public class BusinessLogicMapperDifficulty
    {
        public DataAccessDifficulty MapDifficulty(BusinessLogicDifficulty bDifficulty)
        {
            DataAccessDifficulty dDifficulty = new DataAccessDifficulty();
            dDifficulty.Difficulty_ID = bDifficulty.Difficulty_ID;
            dDifficulty.DifficultyLevel = bDifficulty.DifficultyLevel;
            return dDifficulty;
        }

        public BusinessLogicDifficulty MapDifficulty(DataAccessDifficulty dDifficulty)
        {
            BusinessLogicDifficulty bDifficulty = new BusinessLogicDifficulty();
            bDifficulty.Difficulty_ID = dDifficulty.Difficulty_ID;
            bDifficulty.DifficultyLevel = dDifficulty.DifficultyLevel;
            return bDifficulty;
        }

        public List<BusinessLogicDifficulty> MapDifficulties(List<DataAccessDifficulty> dDifficulties)
        {
            List<BusinessLogicDifficulty> bDifficulties = new List<BusinessLogicDifficulty>();
            foreach (DataAccessDifficulty dDifficulty in dDifficulties)
            {
                bDifficulties.Add(MapDifficulty(dDifficulty));
            }
            return bDifficulties;
        }

        public List<DataAccessDifficulty> MapDifficulties(List<BusinessLogicDifficulty> bDifficulties)
        {
            List<DataAccessDifficulty> dDifficulties = new List<DataAccessDifficulty>();
            foreach (BusinessLogicDifficulty bDifficulty in bDifficulties)
            {
                dDifficulties.Add(MapDifficulty(bDifficulty));
            }
            return dDifficulties;
        }
    }
}
