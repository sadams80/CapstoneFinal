using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessObjects
{
    public class DataAccessProjects
    {
        public int Project_ID { get; set; }
        public int User_ID { get; set; }
        public int Craft_ID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectBody { get; set; }
        public int Difficulty_ID { get; set; }
        public string DifficultyLevel { get; set; }
    }
}
