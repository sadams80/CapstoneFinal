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
    public class RolesLogic
    {
        static BusinessLogicMapperRoles _rolesMapper = new BusinessLogicMapperRoles();
        static RolesDataAccess _roleDataAccess = new RolesDataAccess();

        public List<BusinessLogicRoles> GetRoles()
        {
            List<BusinessLogicRoles> bRoles = new List<BusinessLogicRoles>();
            List<DataAccessRoles> dRoles = new List<DataAccessRoles>();
            dRoles = _roleDataAccess.GetRoles();
            bRoles = _rolesMapper.MapRoles(dRoles);
            return bRoles;
        }


    }
}
