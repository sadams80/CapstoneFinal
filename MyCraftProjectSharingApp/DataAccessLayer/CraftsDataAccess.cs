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
    public class CraftsDataAccess
    {
        static string _connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        static string _errorLog = ConfigurationManager.ConnectionStrings["ErrorLog"].ConnectionString;
        static DataAccessMapperCrafts _mapper = new DataAccessMapperCrafts();
        public void AddCraft(DataAccessCrafts craftToAdd)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("sp_CreateCraft", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@CraftName", craftToAdd.CraftName);
                cmd.Parameters.AddWithValue("@Description", craftToAdd.Description);
                cmd.Parameters.AddWithValue("@User_ID", craftToAdd.User_ID);
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
        public List<DataAccessCrafts> GetCrafts()
        {
            DataTable craftsTable = new DataTable();
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("sp_ViewCrafts", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(craftsTable);
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
            return _mapper.TableToListOfCrafts(craftsTable);
        }
        public DataAccessCrafts GetCraftByCraftId(int craftId)
        {
            DataAccessCrafts craft = new DataAccessCrafts();
            foreach (DataAccessCrafts dCraft in GetCrafts())
            {
                if (craftId == dCraft.Craft_ID)
                {
                    craft = dCraft;
                }
            }
            return craft;
        }
        public DataAccessCrafts GetCraftsByCraftName(string craftName)
        {
            DataAccessCrafts dCrafts = new DataAccessCrafts();
            foreach (DataAccessCrafts craft in GetCrafts())
            {
                if (craftName == craft.CraftName)
                {
                    dCrafts = craft;
                }
            }
            return dCrafts;
        }
        public void UpdateCraft(int craftId, DataAccessCrafts craftToUpdate)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("sp_UpdateCraft", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@Craft_ID", craftId);
                cmd.Parameters.AddWithValue("@CraftName", craftToUpdate.CraftName);
                cmd.Parameters.AddWithValue("@Description", craftToUpdate.Description);
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
        public void DeleteCraft(int craftId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("sp_DeleteCraft", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@Craft_ID", craftId);
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
