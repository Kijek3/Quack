using Quack.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quack
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuManager.GenerateMenu(Menu);
        }

        protected void sendButton_Click(object sender, EventArgs e)
        {
            if (email.Text != "" && subject.Text != "" && messageText.Text != "")
            {
                if (!Mail.SendMail(email.Text, subject.Text, messageText.Text))
                {
                    errorLabel.Text = "Nie udało się wysłać maila";
                }
            } else
            {
                errorLabel.Text = "Musisz uzupełnić wszystkie pola";
            }
        }
    }
}