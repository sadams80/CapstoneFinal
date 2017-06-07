using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.BusinessLogicMappers;
using BusinessLogicLayer.BusinessLogicObjects;
using DataAccessLayer;
using DataAccessLayer.DataAccessObjects;

namespace BusinessLogicLayer
{
    public class UsersLogic
    {
        static BusinessLogicMapperUsers _userMapper = new BusinessLogicMapperUsers();
        static UsersDataAccess _userDataAccess = new UsersDataAccess();
        public void AddUser(BusinessLogicUsers bUser)
        {
            _userDataAccess.AddUser(_userMapper.MapUser(bUser));
        }
        public BusinessLogicUsers GetUserByUsername(string username)
        {
           return _userMapper.MapUser(_userDataAccess.GetUserByUsername(username));
        }
        public BusinessLogicUsers GetUserByUserId(int userId)
        {
            return _userMapper.MapUser(_userDataAccess.GetUserByUserId(userId));
        }
        public List<BusinessLogicUsers> GetUsers()
        {
            List<BusinessLogicUsers> bUsers = new List<BusinessLogicUsers>();
            List<DataAccessUsers> dUsers = new List<DataAccessUsers>();
            dUsers = _userDataAccess.GetUsers();
            bUsers = _userMapper.MapUsers(dUsers);
            return bUsers;
        }
        public void DeleteUser(int userId)
        {
            _userDataAccess.DeleteUser(userId);
        }
        public void UpdateUser(int userId, BusinessLogicUsers bUser)
        {
            _userDataAccess.UpdateUser(userId, _userMapper.MapUser(bUser));
        }
    }
}
