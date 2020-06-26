using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quack
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Session["isAdmin"]))
            {
                Response.Redirect("Login.aspx?redirectUrl=AddProduct.aspx");
            }
            MenuManager.GenerateMenu(Menu);
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string files = "";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFile fu = Request.Files[i];
                if (fu.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(fu.FileName);
                    files += fileName + ",";
                }
            }
            if (files.Length > 0)
                files = files.Substring(0, files.Length - 1);
            string price = productPrice.Text;
            string[] priceArray = price.Split('.');
            if (priceArray.Length == 1)
            {
                price += ".00";
            }
            else if (priceArray[1].Length == 1)
            {
                price += "0";
            }
            string colors = "";
            foreach (ListItem item in colorsCheckbox.Items)
            {
                if (item.Selected)
                {
                    colors += item.Value + ",";
                }
            }
            if (colors.Length > 0)
                colors = colors.Substring(0, colors.Length - 1);

            MySqlConnection conn = Database.Connect();
            //conn.Close();
            //conn = null;
            if (conn != null)
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO `produkty` (`nazwa`, `kategoria`, `opis`, `zdjecia`, `cena`, `kolory`) VALUES ('" + productName.Text + "', '" + productCategory.Text + "', '" + productDescription.Text + "', '" + files + "', '" + price + "', '" + colors + "');";
                MySqlDataReader reader = command.ExecuteReader();
                reader.Close();
                command = conn.CreateCommand();
                command.CommandText = "SELECT MAX(id) as id FROM produkty";
                reader = command.ExecuteReader();
                string lastId = "unknown";
                while (reader.Read())
                {
                    lastId = reader["id"].ToString();
                }
                conn.Close();
                Directory.CreateDirectory(Server.MapPath("~/Products/" + lastId));
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFile fu = Request.Files[i];
                    if (fu.ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(fu.FileName);
                        fu.SaveAs(Server.MapPath("~/Products/" + lastId + "/") + fileName);
                    }
                }

            }
        }
    }
}