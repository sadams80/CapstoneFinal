using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer.DataAccessObjects;

namespace DataAccessLayer.DataAccessMappers
{
    public class DataAccessMapperHouses
    {
        public List<DataAccessHouses> TableToListOfHouses(DataTable housesTable)
        {
            List<DataAccessHouses> dHouses = new List<DataAccessHouses>();
            if (housesTable != null && housesTable.Rows.Count > 0)
            {
                foreach (DataRow row in housesTable.Rows)
                {
                    DataAccessHouses dHouse = new DataAccessHouses();
                    dHouse = RowToHouses(row);
                    dHouses.Add(dHouse);
                }
            }
            return dHouses;
        }
        public static DataAccessHouses RowToHouses(DataRow tableRow)
        {
            DataAccessHouses dHouse = new DataAccessHouses();
            dHouse.House_ID = (int)tableRow["House_ID"];
            dHouse.HouseName = tableRow["HouseName"].ToString();
            dHouse.Motto = tableRow["Motto"].ToString();
            dHouse.Points = (long)tableRow["Points"];
            return dHouse;
        }
    }
}
