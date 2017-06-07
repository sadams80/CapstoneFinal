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
    public class UsersDataAccess
    {
        static string _connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        static string _errorLog = ConfigurationManager.ConnectionStrings["ErrorLog"].ConnectionString;
        static DataAccessMapperUsers _mapper = new DataAccessMapperUsers();
        public void AddUser(DataAccessUsers userToAdd)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("sp_CreateUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@FirstName", userToAdd.FirstName);
                cmd.Parameters.AddWithValue("@LastName", userToAdd.LastName);
                cmd.Parameters.AddWithValue("@Age", userToAdd.Age);
                cmd.Parameters.AddWithValue("@Gender", userToAdd.Gender);
                cmd.Parameters.AddWithValue("@Email", userToAdd.Email);
                cmd.Parameters.AddWithValue("@Username", userToAdd.Username);
                cmd.Parameters.AddWithValue("@Password", userToAdd.Password);
                cmd.Parameters.AddWithValue("@House_ID", userToAdd.House_ID);
                cmd.Parameters.AddWithValue("@Role_ID", 1);
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
        public List<DataAccessUsers> GetUsers()
        {
            DataTable usersTable = new DataTable();
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("sp_ViewUsers", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(usersTable);
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
            return _mapper.TableToListOfUsers(usersTable);
        }
        public DataAccessUsers GetUserByUsername(string username)
        {
            DataAccessUsers user = new DataAccessUsers();
            foreach (DataAccessUsers dUser in GetUsers())
            {
                if(username == dUser.Username)
                {
                    user = dUser;
                }
            }
            return user;
        }
        public DataAccessUsers GetUserByUserId(int userId)
        {
            DataAccessUsers user = new DataAccessUsers();
            foreach (DataAccessUsers dUser in GetUsers())
            {
                if (userId == dUser.User_ID)
                {
                    user = dUser;
                }
            }
            return user;
        }
        public void DeleteUser(int userId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("sp_DeleteUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@User_ID", userId);
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
        public void UpdateUser(int userId, DataAccessUsers userToUpdate)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("sp_UpdateUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@User_ID", userId);
                cmd.Parameters.AddWithValue("@FirstName", userToUpdate.FirstName);
                cmd.Parameters.AddWithValue("@LastName", userToUpdate.LastName);
                cmd.Parameters.AddWithValue("@Age", userToUpdate.Age);
                cmd.Parameters.AddWithValue("@Gender", userToUpdate.Gender);
                cmd.Parameters.AddWithValue("@Email", userToUpdate.Email);
                cmd.Parameters.AddWithValue("@Username", userToUpdate.Username);
                cmd.Parameters.AddWithValue("@Password", userToUpdate.Password);
                cmd.Parameters.AddWithValue("@Role_ID", userToUpdate.Role_ID);
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
    }
}
