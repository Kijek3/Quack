using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Quack
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuManager.GenerateMenu(Menu);
            ReadProducts();
        }

        private void ReadProducts()
        {
            MySqlConnection conn = Database.Connect();
            if (conn != null)
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "SELECT DISTINCT kategoria FROM produkty";
                MySqlDataReader reader = command.ExecuteReader();
                List<string> categories = new List<string>();
                while (reader.Read())
                {
                    categories.Add(reader["kategoria"].ToString());
                }
                reader.Close();
                foreach (string category in categories)
                {
                    command.CommandText = "SELECT * FROM produkty WHERE kategoria='" + category + "'";
                    MySqlDataReader reader2 = command.ExecuteReader();
                    var row = new HtmlGenericControl("div");
                    row.Attributes.Add("class", "productsRow");
                    while (reader2.Read())
                    {
                        var container = new HtmlGenericControl("div");
                        container.Attributes.Add("class", "product");
                        container.Attributes.Add("onclick", "redirect('Product.aspx?productId=" + reader2["id"].ToString() + "')");
                        #region Image
                        var productImage = new HtmlGenericControl("div");
                        productImage.Attributes.Add("class", "productImage");
                        var image = new HtmlImage();
                        string imageName = reader2["zdjecia"].ToString().Split(',')[0];
                        image.Src = "Products/" + reader2["id"] + "/" + imageName;
                        image.Alt = reader2["nazwa"].ToString();
                        productImage.Controls.Add(image);
                        container.Controls.Add(productImage);
                        #endregion
                        #region Title
                        var productName = new HtmlGenericControl("div");
                        productName.Attributes.Add("class", "productName");
                        var title = new HtmlGenericControl("h3") { InnerText = reader2["nazwa"].ToString() };
                        productName.Controls.Add(title);
                        container.Controls.Add(productName);
                        #endregion
                        #region Price
                        var productPrice = new HtmlGenericControl("div");
                        productPrice.Attributes.Add("class", "productPrice");
                        var price = new HtmlGenericControl("h4") { InnerText = reader2["cena"].ToString() + " PLN" };
                        productPrice.Controls.Add(price);
                        container.Controls.Add(productPrice);
                        #endregion
                        row.Controls.Add(container);
                    }
                    reader2.Close();
                    var header = new HtmlGenericControl("h2") { InnerText = category };
                    PanelProducts.Controls.Add(header);
                    PanelProducts.Controls.Add(row);
                }
                conn.Close();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Nie udało się połączyć z bazą danych");
            }
        }
    }
}