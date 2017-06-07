using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer.BusinessLogicObjects;
using MyCraftProjectSharingApp.Models;

namespace MyCraftProjectSharingApp.Mappers
{
    public class MapperDifficulty
    {
        public BusinessLogicDifficulty MapDifficulty(Difficulty difficulty)
        {
            BusinessLogicDifficulty bDifficulty = new BusinessLogicDifficulty();
            bDifficulty.Difficulty_ID = difficulty.Difficulty_ID;
            bDifficulty.DifficultyLevel = difficulty.DifficultyLevel;
            return bDifficulty;
        }
        public Difficulty MapDifficulty(BusinessLogicDifficulty bDifficulty)
        {
            Difficulty difficulty = new Difficulty();
            difficulty.Difficulty_ID = bDifficulty.Difficulty_ID;
            difficulty.DifficultyLevel = bDifficulty.DifficultyLevel;
            return difficulty;
        }
        public List<Difficulty> MapDifficulties(List<BusinessLogicDifficulty> bDifficulties)
        {
            List<Difficulty> difficulties = new List<Difficulty>();
            foreach (BusinessLogicDifficulty bDifficulty in bDifficulties)
            {
                difficulties.Add(MapDifficulty(bDifficulty));
            }
            return difficulties;
        }
    }
}