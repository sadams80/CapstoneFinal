using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessObjects
{
    public class DataAccessUsers
    {
        public int User_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int House_ID { get; set; }
        public int Role_ID { get; set; }
        public string RoleName { get; set; }
    }
}
