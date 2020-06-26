using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quack
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuManager.GenerateMenu(Menu);
        }

        protected void registerRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            if (login.Text == "" || password.Text == "")
            {
                errorLabel.Text = "Podaj login i hasło";
                return;
            }
            if (Crypto.CheckPassword(login.Text, password.Text))
            {
                Session["user"] = login.Text;
                Session["isAdmin"] = Database.CheckAdmin(login.Text);
                MySqlConnection conn = Database.Connect();
                if (conn != null)
                {
                    MySqlCommand command = conn.CreateCommand();
                    command.CommandText = "SELECT id FROM uzytkownicy WHERE login='" + login.Text + "'";
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Session["user_id"] = reader["id"];
                    }
                }
                if (Request.QueryString["redirectUrl"] != null)
                {
                    Response.Redirect(Request.QueryString["redirectUrl"]);
                }
                else
                {
                    Response.Redirect("Index.aspx");
                }
            }
            else
            {
                errorLabel.Text = "Dane uwierzytelniania są nieprawidłowe";
            };
        }
    }
}