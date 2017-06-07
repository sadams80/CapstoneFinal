using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataAccessObjects;
using BusinessLogicLayer.BusinessLogicObjects;

namespace BusinessLogicLayer.BusinessLogicMappers
{
    public class BusinessLogicMapperProjects
    {
        public DataAccessProjects MapProject(BusinessLogicProjects bProject)
        {
            DataAccessProjects dProject = new DataAccessProjects();
            dProject.Project_ID = bProject.Project_ID;
            dProject.User_ID = bProject.User_ID;
            dProject.Craft_ID = bProject.Craft_ID;
            dProject.ProjectName = bProject.ProjectName;
            dProject.ProjectBody = bProject.ProjectBody;
            dProject.Difficulty_ID = bProject.Difficulty_ID;
            dProject.DifficultyLevel = bProject.DifficultyLevel;
            return dProject;
        }
        public BusinessLogicProjects MapProject(DataAccessProjects dProject)
        {
            BusinessLogicProjects bProject = new BusinessLogicProjects();
            bProject.Project_ID = dProject.Project_ID;
            bProject.User_ID = dProject.User_ID;
            bProject.Craft_ID = dProject.Craft_ID;
            bProject.ProjectName = dProject.ProjectName;
            bProject.ProjectBody = dProject.ProjectBody;
            bProject.Difficulty_ID = dProject.Difficulty_ID;
            bProject.DifficultyLevel = dProject.DifficultyLevel;
            return bProject;
        }
        public List<BusinessLogicProjects> MapProjects(List<DataAccessProjects> dProjects)
        {
            List<BusinessLogicProjects> bProjects = new List<BusinessLogicProjects>();
            foreach (DataAccessProjects dProject in dProjects)
            {
                bProjects.Add(MapProject(dProject));
            }
            return bProjects;
        }
        public List<DataAccessProjects> MapProjects(List<BusinessLogicProjects> bProjects)
        {
            List<DataAccessProjects> dProjects = new List<DataAccessProjects>();
            foreach (BusinessLogicProjects bProject in bProjects)
            {
                dProjects.Add(MapProject(bProject));
            }
            return dProjects;
        }
    }
}
