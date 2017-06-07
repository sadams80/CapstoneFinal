using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer.BusinessLogicObjects;
using MyCraftProjectSharingApp.Models;

namespace MyCraftProjectSharingApp.Mappers
{
    public class MapperRoles
    {
        public BusinessLogicRoles MapRole(Roles role)
        {
            BusinessLogicRoles bRole = new BusinessLogicRoles();
            bRole.Role_ID = role.Role_ID;
            bRole.RoleName = role.RoleName;
            return bRole;
        }
        public Roles MapRole(BusinessLogicRoles bRole)
        {
            Roles role = new Roles();
            role.Role_ID = bRole.Role_ID;
            role.RoleName = bRole.RoleName;
            return role;
        }
        public List<Roles> MapRoles(List<BusinessLogicRoles> bRoles)
        {
            List<Roles> roles = new List<Roles>();
            foreach (BusinessLogicRoles bRole in bRoles)
            {
                roles.Add(MapRole(bRole));
            }
            return roles;
        }
    }
}