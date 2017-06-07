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
    public class HousesDataAccess
    {
        static string _connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        static string _errorLog = ConfigurationManager.ConnectionStrings["ErrorLog"].ConnectionString;
        static DataAccessMapperHouses _housesMapper = new DataAccessMapperHouses();
        public void UpdateHousePoints(long points, int houseId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("sp_AddPointsByHouse", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@House_ID", houseId);
                cmd.Parameters.AddWithValue("@Points", points);
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
        public List<DataAccessHouses> GetHouses()
        {
            DataTable housesTable = new DataTable();
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("sp_ViewHouses", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(housesTable);
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
            return _housesMapper.TableToListOfHouses(housesTable);
        }
    }
}
