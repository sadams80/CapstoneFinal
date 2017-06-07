using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataAccessObjects;
using BusinessLogicLayer.BusinessLogicObjects;

namespace BusinessLogicLayer.BusinessLogicMappers
{
    public class BusinessLogicMapperRoles
    {
        public DataAccessRoles MapRole(BusinessLogicRoles bRoles)
        {
            DataAccessRoles dRoles = new DataAccessRoles();
            dRoles.Role_ID = bRoles.Role_ID;
            dRoles.RoleName = bRoles.RoleName;
            return dRoles;
        }

        public BusinessLogicRoles MapRole(DataAccessRoles dRoles)
        {
            BusinessLogicRoles bRoles = new BusinessLogicRoles();
            bRoles.Role_ID = dRoles.Role_ID;
            bRoles.RoleName = dRoles.RoleName;
            return bRoles;
        }

        public List<BusinessLogicRoles> MapRoles(List<DataAccessRoles> dRoles)
        {
            List<BusinessLogicRoles> bRoles = new List<BusinessLogicRoles>();
            foreach (DataAccessRoles dRole in dRoles)
            {
                bRoles.Add(MapRole(dRole));
            }
            return bRoles;
        }

        public List<DataAccessRoles> MapRoles(List<BusinessLogicRoles> bRoles)
        {
            List<DataAccessRoles> dRoles = new List<DataAccessRoles>();
            foreach (BusinessLogicRoles bRole in bRoles)
            {
                dRoles.Add(MapRole(bRole));
            }
            return dRoles;
        }
    }
}
