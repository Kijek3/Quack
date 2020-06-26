using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quack
{
    public class Database
    {
        public static MySqlConnection Connect()
        {
            string myconnection =
               "Server=127.0.0.1;" +
               //"Port=8080;" +
               "Database=quack;" +
               "User=root;" +
               "Password=;"+
               "CharSet=utf8;";

            MySqlConnection connection = new MySqlConnection(myconnection);

            try
            {
                connection.Open();
                System.Diagnostics.Debug.WriteLine("Connected with database");
                return connection;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return null;
        }

        public static bool CheckAdmin(string user)
        {
            MySqlConnection conn = Connect();
            if (conn != null)
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "SELECT isAdmin FROM uzytkownicy WHERE login='" + user + "'";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToBoolean(reader["isAdmin"]))
                    {
                        conn.Close();
                        return true;
                    }
                }
                conn.Close();
                return false;
            }
            else
            {
                return false;
            }
        }

        public static string GetProductInfo(string productId, string what)
        {
            MySqlConnection conn = Connect();
            if (conn != null)
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "SELECT " + what + " FROM produkty WHERE id='" + productId + "'";
                MySqlDataReader reader = command.ExecuteReader();
                string nazwa = null;
                while (reader.Read())
                {
                    nazwa = reader[what].ToString();
                }
                conn.Close();
                return nazwa;
            }
            else
            {
                return null;
            }
        }

        public static void AddToBasket(string userId, string productId, string count, string size, string color)
        {
            MySqlConnection conn = Connect();
            if (conn != null)
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO koszyk (user_id,product_id,count,size,color) VALUES (" + userId + "," + productId + "," + count + ",'" + size + "','" + color + "')";
                MySqlDataReader reader = command.ExecuteReader();
                conn.Close();
            }
        }
    }
}