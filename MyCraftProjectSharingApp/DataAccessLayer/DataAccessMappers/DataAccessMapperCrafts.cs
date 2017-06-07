using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer.DataAccessObjects;

namespace DataAccessLayer.DataAccessMappers
{
    public class DataAccessMapperCrafts
    {
        public List<DataAccessCrafts> TableToListOfCrafts(DataTable craftsTable)
        {
            List<DataAccessCrafts> dCrafts = new List<DataAccessCrafts>();
            if (craftsTable != null && craftsTable.Rows.Count > 0)
            {
                foreach (DataRow row in craftsTable.Rows)
                {
                    DataAccessCrafts dCraft = new DataAccessCrafts();
                    dCraft = RowToCrafts(row);
                    dCrafts.Add(dCraft);
                }
            }
            return dCrafts;
        }
        public static DataAccessCrafts RowToCrafts(DataRow tableRow)
        {
            DataAccessCrafts dCraft = new DataAccessCrafts();
            dCraft.Craft_ID = (int)tableRow["Craft_ID"];
            dCraft.CraftName = tableRow["CraftName"].ToString();
            dCraft.Description = tableRow["Description"].ToString();
            dCraft.User_ID = (int)tableRow["User_ID"];
            return dCraft;
        }
    }
}
