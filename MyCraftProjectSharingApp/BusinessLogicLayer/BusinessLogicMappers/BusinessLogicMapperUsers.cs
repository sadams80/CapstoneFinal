using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataAccessObjects;
using BusinessLogicLayer.BusinessLogicObjects;

namespace BusinessLogicLayer.BusinessLogicMappers
{
    public class BusinessLogicMapperUsers
    {
        static PaswordHashLogic _businessLogic = new PaswordHashLogic();
        public DataAccessUsers MapUser(BusinessLogicUsers bUser)
        {
            DataAccessUsers dUser = new DataAccessUsers();
            dUser.User_ID = bUser.User_ID;
            dUser.FirstName = bUser.FirstName;
            dUser.LastName = bUser.LastName;
            dUser.Age = bUser.Age;
            dUser.Gender = bUser.Gender;
            dUser.Email = bUser.Email;
            dUser.Username = bUser.Username;
            dUser.Password = _businessLogic.HashPassword(bUser.Password);
            dUser.House_ID = bUser.House_ID;
            dUser.Role_ID = bUser.Role_ID;
            return dUser;
        }
        public BusinessLogicUsers MapUser(DataAccessUsers dUser)
        {
            BusinessLogicUsers bUser = new BusinessLogicUsers();
            bUser.User_ID = dUser.User_ID;
            bUser.FirstName = dUser.FirstName;
            bUser.LastName = dUser.LastName;
            bUser.Age = dUser.Age;
            bUser.Gender = dUser.Gender;
            bUser.Email = dUser.Email;
            bUser.Username = dUser.Username;
            bUser.Password = dUser.Password;
            bUser.House_ID = dUser.House_ID;
            bUser.Role_ID = dUser.Role_ID;
            return bUser;
        }
        public List<BusinessLogicUsers> MapUsers(List<DataAccessUsers> dUsers)
        {
            List<BusinessLogicUsers> bUsers = new List<BusinessLogicUsers>();
            foreach (DataAccessUsers dUser in dUsers)
            {
                bUsers.Add(MapUser(dUser));
            }
            return bUsers;
        }
        public List<DataAccessUsers> MapUsers(List<BusinessLogicUsers> bUsers)
        {
            List<DataAccessUsers> dUsers = new List<DataAccessUsers>();
            foreach (BusinessLogicUsers bUser in bUsers)
            {
                dUsers.Add(MapUser(bUser));
            }
            return dUsers;
        }

    }
}
