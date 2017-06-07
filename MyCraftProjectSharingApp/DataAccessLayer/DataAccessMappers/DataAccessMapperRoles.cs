using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer.DataAccessObjects;

namespace DataAccessLayer.DataAccessMappers
{
    public class DataAccessMapperRoles
    {
        public List<DataAccessRoles> TableToListOfRoles(DataTable rolesTable)
        {
            List<DataAccessRoles> dRoles = new List<DataAccessRoles>();
            if (rolesTable != null && rolesTable.Rows.Count > 0)
            {
                foreach (DataRow row in rolesTable.Rows)
                {
                    DataAccessRoles dRole = new DataAccessRoles();
                    dRole = RowToRoles(row);
                    dRoles.Add(dRole);
                }
            }
            return dRoles;
        }
        public static DataAccessRoles RowToRoles(DataRow tableRow)
        {
            DataAccessRoles dRole = new DataAccessRoles();
            dRole.Role_ID = (int)tableRow["Role_ID"];
            dRole.RoleName = tableRow["RoleName"].ToString();
            return dRole;
        }
    }
}
