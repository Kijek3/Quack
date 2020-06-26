using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Quack
{
    public class Crypto
    {
        public static byte[] createSalt()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            return salt;
        }

        public static byte[] createHash(byte[] salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes("password", salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return hash;
        }

        public static string CreatePassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        public static bool CheckPassword(string login, string password)
        {
            string savedPasswordHash = null;
            MySqlConnection conn = Database.Connect();
            if (conn != null)
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "SELECT password_hash FROM uzytkownicy WHERE login='" + login + "'";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    savedPasswordHash = reader["password_hash"].ToString();
                    byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
                    byte[] salt = new byte[16];
                    Array.Copy(hashBytes, 0, salt, 0, 16);
                    var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
                    byte[] hash = pbkdf2.GetBytes(20);
                    bool goodPass = true;
                    for (int i = 0; i < 20; i++)
                        if (hashBytes[i + 16] != hash[i])
                            goodPass = false;
                    conn.Close();
                    return goodPass;
                }
                conn.Close();
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}