using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer.DataAccessObjects;

namespace DataAccessLayer.DataAccessMappers
{
    public class DataAccessMapperDifficulty
    {
        public List<DataAccessDifficulty> TableToListOfDifficulty(DataTable difficultyTable)
        {
            List<DataAccessDifficulty> dDifficulties = new List<DataAccessDifficulty>();
            if (difficultyTable != null && difficultyTable.Rows.Count > 0)
            {
                foreach (DataRow row in difficultyTable.Rows)
                {
                    DataAccessDifficulty dRole = new DataAccessDifficulty();
                    dRole = RowToDifficulty(row);
                    dDifficulties.Add(dRole);
                }
            }
            return dDifficulties;
        }
        public static DataAccessDifficulty RowToDifficulty(DataRow tableRow)
        {
            DataAccessDifficulty dDifficulty = new DataAccessDifficulty();
            dDifficulty.Difficulty_ID = (int)tableRow["Difficulty_ID"];
            dDifficulty.DifficultyLevel = tableRow["DifficultyLevel"].ToString();
            return dDifficulty;
        }
    }
}
