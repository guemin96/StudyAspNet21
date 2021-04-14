using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NewLoginWebApp.Models
{
    public class Repository
    {
        private SqlConnection conn;

        public Repository()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        }
        public int AddUser(string userId, string password)
        {
            SqlCommand cmd = new SqlCommand("WriteUsers",conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", userId);
            cmd.Parameters.AddWithValue("@Password", password);

            conn.Open();
            var result = cmd.ExecuteNonQuery();
            conn.Close();

            return result;//0,1
        }
        public User GetUserByUserId(string userId)
        {
            var u = new User();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserID = @UserID", conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@UserID", userId);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                u.UID = Convert.ToInt32( reader["UID"]);
                u.UserID = reader["UserID"].ToString();
                u.Password = reader["Password"].ToString();
            }
            conn.Close();
            return u;
        }
    }
}