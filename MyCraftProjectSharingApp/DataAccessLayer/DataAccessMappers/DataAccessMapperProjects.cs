using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer.DataAccessObjects;

namespace DataAccessLayer.DataAccessMappers
{
    public class DataAccessMapperProjects
    {
        public List<DataAccessProjects> TableToListOfProjects(DataTable projectsTable)
        {
            List<DataAccessProjects> dProjects = new List<DataAccessProjects>();
            if (projectsTable != null && projectsTable.Rows.Count > 0)
            {
                foreach (DataRow row in projectsTable.Rows)
                {
                    DataAccessProjects dProject = new DataAccessProjects();
                    dProject = RowToProjects(row);
                    dProjects.Add(dProject);
                }
            }
            return dProjects;
        }
        public static DataAccessProjects RowToProjects(DataRow tableRow)
        {
            DataAccessProjects dProject = new DataAccessProjects();
            dProject.Project_ID = (int)tableRow["Project_ID"];
            dProject.User_ID = (int)tableRow["User_ID"];
            dProject.Craft_ID = (int)tableRow["Craft_ID"];
            dProject.ProjectName = tableRow["ProjectName"].ToString();
            dProject.ProjectBody = tableRow["ProjectBody"].ToString();
            dProject.DifficultyLevel = tableRow["DifficultyLevel"].ToString();
            dProject.Difficulty_ID = (int)tableRow["Difficulty_ID"];
            return dProject;
        }
    }
}
