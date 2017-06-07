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
    public class ProjectsLogic
    {
        static BusinessLogicMapperProjects _projectMapper = new BusinessLogicMapperProjects();
        static ProjectsDataAccess _projectDataAccess = new ProjectsDataAccess();
        public void AddProject(BusinessLogicProjects bProject)
        {
            _projectDataAccess.AddProject(_projectMapper.MapProject(bProject));
        }
        public List<BusinessLogicProjects> GetProjects()
        {
            List<BusinessLogicProjects> bProjects = new List<BusinessLogicProjects>();
            List<DataAccessProjects> dProjects = new List<DataAccessProjects>();
            dProjects = _projectDataAccess.GetProjects();
            bProjects = _projectMapper.MapProjects(dProjects);
            return bProjects;
        }
        public BusinessLogicProjects GetProjectByProjectId(int projectId)
        {
            return _projectMapper.MapProject(_projectDataAccess.GetProjectByProjectId(projectId));
        }
        public void UpdateProject(int projectId, BusinessLogicProjects bProject)
        {
            _projectDataAccess.UpdateProject(projectId, _projectMapper.MapProject(bProject));
        }
        public void DeleteProject(int projectId)
        {
            _projectDataAccess.DeleteProject(projectId);
        }
    }
}
