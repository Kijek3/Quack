using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quack
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuManager.GenerateMenu(Menu);
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            if (login.Text != "" && password.Text != "")
            {
                MySqlConnection conn = Database.Connect();
                if (conn != null)
                {
                    MySqlCommand command = conn.CreateCommand();
                    command.CommandText = "INSERT INTO `uzytkownicy` (`login`, `password_hash`) VALUES ('" + login.Text + "', '" + Crypto.CreatePassword(password.Text) + "');";
                    MySqlDataReader reader = command.ExecuteReader();
                    conn.Close();
                    Response.Redirect("Login.aspx");
                }
            } else
            {
                errorLabel.Text = "Musisz uzupełnić wszystkie pola";
            }
        }

        protected void loginRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}