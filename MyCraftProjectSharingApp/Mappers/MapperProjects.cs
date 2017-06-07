using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer.BusinessLogicObjects;
using MyCraftProjectSharingApp.Models;

namespace MyCraftProjectSharingApp.Mappers
{
    public class MapperProjects
    {
        public BusinessLogicProjects MapProject(Projects project)
        {
            BusinessLogicProjects bProject = new BusinessLogicProjects();
            bProject.Project_ID = project.Project_ID;
            bProject.User_ID = project.User_ID;
            bProject.Craft_ID = project.Craft_ID;
            bProject.ProjectName = project.ProjectName;
            bProject.ProjectBody = project.ProjectBody;
            bProject.Difficulty_ID = project.Difficulty_ID;
            project.DifficultyLevel = bProject.DifficultyLevel;
            return bProject;
        }
        public Projects MapProject(BusinessLogicProjects bProject)
        {
            Projects project = new Projects();
            project.Project_ID = bProject.Project_ID;
            project.User_ID = bProject.User_ID;
            project.Craft_ID = bProject.Craft_ID;
            project.ProjectName = bProject.ProjectName;
            project.ProjectBody = bProject.ProjectBody;
            project.Difficulty_ID = bProject.Difficulty_ID;
            project.DifficultyLevel = bProject.DifficultyLevel;
            return project;
        }
        public List<Projects> MapProjects(List<BusinessLogicProjects> bProjects)
        {
            List<Projects> projects = new List<Projects>();
            foreach (BusinessLogicProjects bProject in bProjects)
            {
                projects.Add(MapProject(bProject));
            }
            return projects;
        }
        public List<BusinessLogicProjects> MapProjects(List<Projects> projects)
        {
            List<BusinessLogicProjects> bProjects = new List<BusinessLogicProjects>();
            foreach (Projects project in projects)
            {
                bProjects.Add(MapProject(project));
            }
            return bProjects;
        }
    }
}