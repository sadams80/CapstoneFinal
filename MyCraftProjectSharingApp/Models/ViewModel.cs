using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCraftProjectSharingApp.Models
{
    public class ViewModel
    {
        public Users SingleUser { get; set; }
        public List<Users> Users { get; set; }
        public Crafts SingleCraft { get; set; }
        public List<Crafts> Crafts { get; set; }
        public Houses SingleHouse { get; set; }
        public List<Houses> Houses { get; set; }
        public Projects SingleProject { get; set; }
        public List<Projects> Projects { get; set; }
        public Difficulty SingleDifficulty { get; set; }
        public List<Difficulty> Difficulties { get; set; }
        public Roles SingleRole {get;set;}
        public List<Roles> Roles { get; set; }

        public ViewModel()
        {
            SingleUser = new Users();
            Users = new List<Users>();
            SingleCraft = new Crafts();
            Crafts = new List<Crafts>();
            SingleHouse = new Houses();
            Houses = new List<Houses>();
            SingleProject = new Projects();
            Projects = new List<Projects>();
            SingleDifficulty = new Difficulty();
            Difficulties = new List<Difficulty>();
            SingleRole = new Roles();
            Roles = new List<Roles>();
        }
    }
}