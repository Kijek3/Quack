using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Quack
{
    public class MenuManager : System.Web.UI.Page
    {
        public static void GenerateMenu(Panel menu)
        {
            #region LeftMenu
            Panel leftMenu = new Panel();
            //string[] languages = new string[2] { "PL", "EN" };
            leftMenu.Attributes.Add("class", "leftMenu");
            //foreach (string language in languages)
            //{
            //    HtmlGenericControl languageMenu = new HtmlGenericControl("div") { InnerText = language };
            //    leftMenu.Controls.Add(languageMenu);
            //}
            Button basketMenu = new Button { Text = "Koszyk" };
            basketMenu.Click += (sender, e) => RedirectToPage(sender, e, "Basket.aspx");
            leftMenu.Controls.Add(basketMenu);
            Button contactMenu = new Button() { Text = "Kontakt" };
            contactMenu.Click += (sender, e) => RedirectToPage(sender, e, "Contact.aspx");
            leftMenu.Controls.Add(contactMenu);
            menu.Controls.Add(leftMenu);
            #endregion
            #region LogoNav
            Panel logoNav = new Panel();
            logoNav.Attributes.Add("class", "logoNav");
            HtmlGenericControl hyperlink = new HtmlGenericControl("a");
            hyperlink.Attributes.Add("href", "Index.aspx");
            Image logo = new Image();
            logo.ImageUrl = "quacker.png";
            logo.AlternateText = "logo";
            logo.Height = 50;
            hyperlink.Controls.Add(logo);
            logoNav.Controls.Add(hyperlink);
            menu.Controls.Add(logoNav);
            #endregion
            #region RightMenu
            Panel rightMenu = new Panel();
            rightMenu.Attributes.Add("class", "rightMenu");
            if (HttpContext.Current.Session["user"] != null)
            {
                Button settingsMenu = new Button { Text = "Witaj " + HttpContext.Current.Session["user"].ToString() };
                if (Convert.ToBoolean(HttpContext.Current.Session["isAdmin"]))
                    settingsMenu.Click += (sender, e) => RedirectToPage(sender, e, "AdminUsers.aspx");
                else
                    settingsMenu.Click += (sender, e) => RedirectToPage(sender, e, "Index.aspx");
                rightMenu.Controls.Add(settingsMenu);
                if (Convert.ToBoolean(HttpContext.Current.Session["isAdmin"]))
                {
                    Button addMenu = new Button { Text = "Dodaj produkt" };
                    addMenu.Click += (sender, e) => RedirectToPage(sender, e, "AddProduct.aspx");
                    rightMenu.Controls.Add(addMenu);
                }
                Button logoutButton = new Button { Text = "Wyloguj się" };
                logoutButton.Click += (sender, e) => Logout(sender, e);
                rightMenu.Controls.Add(logoutButton);
            }
            else
            {
                Button registerMenu = new Button { Text = "Zarejestruj się" };
                registerMenu.Click += (sender, e) => RedirectToPage(sender, e, "Register.aspx");
                rightMenu.Controls.Add(registerMenu);
                Button loginMenu = new Button { Text = "Zaloguj się" };
                loginMenu.Click += (sender, e) => RedirectToPage(sender, e, "Login.aspx");
                rightMenu.Controls.Add(loginMenu);
            }
            menu.Controls.Add(rightMenu);
            #endregion
        }

        protected static void RedirectToPage(object sender, EventArgs e, string url)
        {
            HttpContext.Current.Response.Redirect(url);
        }

        protected static void Logout(object sender, EventArgs e)
        {
            HttpContext.Current.Session["user"] = null;
            HttpContext.Current.Session["user_id"] = null;
            HttpContext.Current.Session["isAdmin"] = null;
            HttpContext.Current.Response.Redirect("Index.aspx");
        }
    }
}