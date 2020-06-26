using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quack
{
    public partial class Product : System.Web.UI.Page
    {
        RadioButtonList sizes = new RadioButtonList();
        RadioButtonList colorsRadio = new RadioButtonList();
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuManager.GenerateMenu(Menu);
            if (Request.QueryString["productId"] != null && Database.GetProductInfo(Request.QueryString["productId"], "nazwa") != null)
            {
                productName.Text = Database.GetProductInfo(Request.QueryString["productId"], "nazwa");
                sizes.Items.Add("S");
                sizes.Items.Add("M");
                sizes.Items.Add("L");
                sizes.Items.Add("XL");
                sizes.Items.Add("XXL");
                sizes.SelectedIndex = 0;
                sizeButtons.Controls.Add(sizes);
                string[] colors = Database.GetProductInfo(Request.QueryString["productId"], "kolory").Split(',');
                foreach (string color in colors)
                {
                    ListItem newColor = new ListItem();
                    newColor.Text = color;
                    newColor.Attributes.Add("onclick", "changeColor('" + color + "')");
                    colorsRadio.Items.Add(newColor);
                }
                colorsRadio.SelectedIndex = 0;
                colorButtons.Controls.Add(colorsRadio);
                string[] images = Database.GetProductInfo(Request.QueryString["productId"], "zdjecia").Split(',');
                foreach (string imageName in images)
                {
                    Debug.WriteLine(imageName);
                    Image image = new Image
                    {
                        ImageUrl = "Products/" + Request.QueryString["productId"] + "/" + imageName
                    };
                    image.Attributes.Add("style", "background-color: " + colorsRadio.SelectedValue);
                    productSlider.Controls.Add(image);
                }
            }
            else
            {
                Response.Redirect("Error404.aspx");
            }
        }

        protected void basketAddButton_Click(object sender, EventArgs e)
        {
            if (Session["user_id"] != null)
            {
                Database.AddToBasket(Session["user_id"].ToString(), Request.QueryString["productId"], basketCount.Text, sizes.SelectedValue, colorsRadio.SelectedValue);
                Response.Redirect("Basket.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}