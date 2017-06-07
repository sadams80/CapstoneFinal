using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer.DataAccessMappers;
using DataAccessLayer.DataAccessObjects;

namespace DataAccessLayer
{
    public class ProjectsDataAccess
    {
        static string _connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        static string _errorLog = ConfigurationManager.ConnectionStrings["ErrorLog"].ConnectionString;
        static DataAccessMapperProjects _projectsMapper = new DataAccessMapperProjects();
        public void AddProject(DataAccessProjects projectToAdd)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("sp_CreateProject", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@ProjectName", projectToAdd.ProjectName);
                cmd.Parameters.AddWithValue("@ProjectBody", projectToAdd.ProjectBody);
                cmd.Parameters.AddWithValue("@Difficulty_ID", projectToAdd.Difficulty_ID);
                cmd.Parameters.AddWithValue("@Craft_ID", projectToAdd.Craft_ID);
                cmd.Parameters.AddWithValue("@User_ID", projectToAdd.User_ID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                using (StreamWriter writer = new StreamWriter(_errorLog))
                {
                    writer.Write("Create Exception: " + error);
                }
            }
            finally
            {
                connection.Close();
            }
        }
        public List<DataAccessProjects> GetProjects()
        {
            DataTable projectsTable = new DataTable();
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("sp_ViewProjects", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(projectsTable);
                }
            }
            catch (Exception error)
            {
                using (StreamWriter writer = new StreamWriter(_errorLog))
                {
                    writer.Write("View Exception: " + error);
                }
            }
            finally
            {
                connection.Close();
            }
            return _projectsMapper.TableToListOfProjects(projectsTable);
        }
        public DataAccessProjects GetProjectByProjectId(int projectId)
        {
            DataAccessProjects projects = new DataAccessProjects();
            foreach (DataAccessProjects dProject in GetProjects())
            {
                if (projectId == dProject.Project_ID)
                {
                    projects = dProject;
                }
            }
            return projects;
        }
        public void UpdateProject(int projectId, DataAccessProjects projectToUpdate)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("sp_UpdateProject", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@Project_ID", projectId);
                cmd.Parameters.AddWithValue("@ProjectName", projectToUpdate.ProjectName);
                cmd.Parameters.AddWithValue("@ProjectBody", projectToUpdate.ProjectBody);
                cmd.Parameters.AddWithValue("@Difficulty_ID", projectToUpdate.Difficulty_ID);
                cmd.Parameters.AddWithValue("@Craft_ID", projectToUpdate.Craft_ID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                using (StreamWriter writer = new StreamWriter(_errorLog))
                {
                    writer.Write("Update Exception: " + error);
                }
            }
            finally
            {
                connection.Close();
            }
        }
        public void DeleteProject(int projectId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("sp_DeleteProject", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("Project_ID", projectId);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                using (StreamWriter writer = new StreamWriter(_errorLog))
                {
                    writer.Write("Delete Exception: " + error);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
