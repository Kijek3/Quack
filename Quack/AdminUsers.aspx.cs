using MySql.Data.MySqlClient;
using Quack.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quack
{
    public partial class AdminUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuManager.GenerateMenu(Menu);
            if (Session["isAdmin"] != null)
            {
                MySqlConnection conn = Database.Connect();
                if (conn != null)
                {
                    MySqlCommand command = conn.CreateCommand();
                    command.CommandText = "SELECT login, isAdmin FROM uzytkownicy";
                    MySqlDataReader reader = command.ExecuteReader();
                    string userLogin = null;
                    while (reader.Read())
                    {
                        TableRow row = new TableRow();
                        TableCell cellLogin = new TableCell()
                        {
                            Text = reader["login"].ToString(),
                            CssClass = "tableName"
                        };
                        row.Controls.Add(cellLogin);
                        TableCell cellAdmin = new TableCell();
                        Label adminLabel = new Label();
                        if (Convert.ToBoolean(reader["isAdmin"]))
                        {
                            adminLabel.Text = "TAK";
                            adminLabel.ForeColor = System.Drawing.Color.ForestGreen;
                        }
                        else
                        {
                            adminLabel.Text = "NIE";
                            adminLabel.ForeColor = System.Drawing.Color.IndianRed;
                        }
                        cellAdmin.Controls.Add(adminLabel);
                        row.Controls.Add(cellAdmin);

                        TableCell cellMakeAdmin = new TableCell();
                        Button makeAdminButton = new Button() { CssClass = "adminButton" };
                        makeAdminButton.CommandArgument = reader["login"].ToString();
                        if (Convert.ToBoolean(reader["isAdmin"]))
                        {
                            makeAdminButton.Text = "Odbierz uprawnienia administracyjne";
                            makeAdminButton.Click += (sender2, e2) => DeleteAdmin(sender2, e2);
                        }
                        else
                        {
                            makeAdminButton.Text = "Przyznaj uprawnienia administracyjne";
                            makeAdminButton.Click += (sender2, e2) => MakeAdmin(sender2, e2);
                        }
                        cellMakeAdmin.Controls.Add(makeAdminButton);
                        row.Controls.Add(cellMakeAdmin);

                        TableCell cellDelete = new TableCell();
                        Button deleteButton = new Button() { Text = "Usuń użytkownika", CssClass = "deleteButton" };
                        deleteButton.CommandArgument = reader["login"].ToString();
                        deleteButton.Click += (sender2, e2) => DeleteUser(sender2, e2);
                        cellDelete.Controls.Add(deleteButton);
                        row.Controls.Add(cellDelete);
                        usersTable.Controls.Add(row);

                        usersTable.Controls.Add(row);
                    }
                    reader.Close();
                    command = conn.CreateCommand();
                    command.CommandText = "SELECT * FROM koszyk INNER JOIN produkty ON koszyk.product_id=produkty.id INNER JOIN uzytkownicy ON uzytkownicy.id=koszyk.user_id WHERE is_ordered=1";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TableRow row = new TableRow();
                        TableCell cellUser = new TableCell() { Text = reader["login"].ToString() };
                        row.Controls.Add(cellUser);
                        TableCell cellProduct = new TableCell() { Text = reader["nazwa"].ToString() };
                        row.Controls.Add(cellProduct);
                        TableCell cellCount = new TableCell() { Text = reader["count"].ToString() };
                        row.Controls.Add(cellCount);
                        TableCell cellBasket = new TableCell() { Text = reader["color"].ToString() };
                        row.Controls.Add(cellBasket);
                        TableCell cellSize = new TableCell() { Text = reader["size"].ToString() };
                        row.Controls.Add(cellSize);
                        TableCell cellDone = new TableCell();
                        Button doneButton = new Button() { Text = "Zamówienie wysłane", CssClass = "doneButton" };
                        doneButton.CommandArgument = reader["id"].ToString();
                        doneButton.Click += (sender2, e2) => OrderComplete(sender2, e2);
                        cellDone.Controls.Add(doneButton);
                        row.Controls.Add(cellDone);
                        ordersTable.Controls.Add(row);
                    }
                    reader.Close();
                    command = conn.CreateCommand();
                    command.CommandText = "SELECT * FROM produkty";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TableRow row = new TableRow();
                        TableCell cellProduct = new TableCell() { Text = reader["nazwa"].ToString() };
                        row.Controls.Add(cellProduct);
                        TableCell cellCount = new TableCell() { Text = reader["cena"].ToString() };
                        row.Controls.Add(cellCount);
                        TableCell cellDone = new TableCell();
                        Button deleteButton = new Button() { Text = "Usuń produkt", CssClass = "deleteButton" };
                        deleteButton.CommandArgument = reader["id"].ToString();
                        deleteButton.Click += (sender2, e2) => DeleteProduct(sender2, e2);
                        cellDone.Controls.Add(deleteButton);
                        row.Controls.Add(cellDone);
                        productsTable.Controls.Add(row);
                    }
                    reader.Close();
                    conn.Close();
                }
            }
            else
            {
                Response.Redirect("Login.aspx?redirectUrl=AdminUsers.aspx");
            }
        }

        protected void DeleteUser(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            MySqlConnection conn = Database.Connect();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "DELETE FROM uzytkownicy WHERE login=@login";
            var loginParam = new MySqlParameter("login", MySqlDbType.VarChar);
            loginParam.Value = button.CommandArgument;
            command.Parameters.Add(loginParam);
            MySqlDataReader reader = command.ExecuteReader();
            Response.Redirect("AdminUsers.aspx");
        }

        protected void DeleteProduct(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            MySqlConnection conn = Database.Connect();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "DELETE FROM produkty WHERE id=@id";
            var loginParam = new MySqlParameter("id", MySqlDbType.Int64);
            loginParam.Value = button.CommandArgument;
            command.Parameters.Add(loginParam);
            MySqlDataReader reader = command.ExecuteReader();
            Response.Redirect("AdminUsers.aspx");
        }
        protected void MakeAdmin(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            MySqlConnection conn = Database.Connect();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE uzytkownicy SET isAdmin=1 WHERE login=@login";
            var loginParam = new MySqlParameter("login", MySqlDbType.VarChar);
            loginParam.Value = button.CommandArgument;
            command.Parameters.Add(loginParam);
            MySqlDataReader reader = command.ExecuteReader();
            Response.Redirect("AdminUsers.aspx");
        }

        protected void DeleteAdmin(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            MySqlConnection conn = Database.Connect();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE uzytkownicy SET isAdmin=0 WHERE login=@login";
            var loginParam = new MySqlParameter("login", MySqlDbType.VarChar);
            loginParam.Value = button.CommandArgument;
            command.Parameters.Add(loginParam);
            MySqlDataReader reader = command.ExecuteReader();
            Response.Redirect("AdminUsers.aspx");
        }

        protected void OrderComplete(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            MySqlConnection conn = Database.Connect();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE koszyk SET is_ordered=2 WHERE id=@id";
            var idParam = new MySqlParameter("id", MySqlDbType.Int64);
            idParam.Value = button.CommandArgument;
            command.Parameters.Add(idParam);
            MySqlDataReader reader = command.ExecuteReader();
            Mail.SendMail("kijolakijek3@gmail.com", "Zamówienie zostało wysłane", "Twoje zamówienie o numerze " + button.CommandArgument + " już do Ciebie jedzie!");
            Response.Redirect("AdminUsers.aspx");
        }

    }
}