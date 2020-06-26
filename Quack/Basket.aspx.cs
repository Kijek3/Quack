using MySql.Data.MySqlClient;
using Quack.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Quack
{
    public partial class Basket : System.Web.UI.Page
    {
        static public List<DropDownList> sizeDropdowns = new List<DropDownList>();
        //static public DropDownList[] sizeDropdowns = new DropDownList[0];
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuManager.GenerateMenu(Menu);
            if (Session["user_id"] != null)
            {
                MySqlConnection conn = Database.Connect();
                if (conn != null)
                {
                    MySqlCommand command = conn.CreateCommand();
                    command.CommandText = "SELECT produkty.nazwa, `koszyk`.`size`,`koszyk`.`color`,`koszyk`.`count`, produkty.cena, produkty.kolory, is_ordered, koszyk.id FROM `produkty` INNER JOIN `koszyk` WHERE `koszyk`.`user_id`=" + Session["user_id"] + " AND `koszyk`.`product_id`=`produkty`.`id` ";
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!Convert.ToBoolean(reader["is_ordered"]))
                        {
                            TableRow row = new TableRow();
                            TableCell cellName = new TableCell()
                            {
                                Text = reader["nazwa"].ToString(),
                                CssClass = "tableName"
                            };
                            row.Controls.Add(cellName);

                            GenerateSizes(reader["size"].ToString(), row);
                            GenerateColors(reader["kolory"].ToString(), reader["color"].ToString(), row);
                            TableCell cellCount = new TableCell()
                            {
                                Text = reader["count"].ToString()
                            };
                            row.Controls.Add(cellCount);
                            TableCell cellDelete = new TableCell();
                            Button deleteButton = new Button() { Text = "Usuń", CssClass = "deleteButton" };
                            deleteButton.CommandArgument = reader["id"].ToString();
                            deleteButton.Click += (sender2, e2) => DeleteOrder(sender2, e2);
                            cellDelete.Controls.Add(deleteButton);
                            row.Controls.Add(cellDelete);
                            TableCell cellPrice = new TableCell()
                            {
                                Text = reader["cena"].ToString() + " PLN"
                            };
                            row.Controls.Add(cellPrice);
                            basketTable.Controls.Add(row);
                        }
                    }
                    reader.Close();
                    command = conn.CreateCommand();
                    command.CommandText = "SELECT SUM(`produkty`.`cena`) as suma, produkty.cena FROM `produkty` INNER JOIN `koszyk` WHERE `koszyk`.`user_id`=" + Session["user_id"] + " AND `koszyk`.`product_id`=`produkty`.`id` AND is_ordered=0 ";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TableRow row = new TableRow();
                        TableCell cellLabel = new TableCell()
                        {
                            Text = "Koszt",
                            ColumnSpan = 5
                        };
                        row.Controls.Add(cellLabel);
                        TableCell cellSum = new TableCell()
                        {
                            Text = reader["suma"].ToString() + " PLN",
                        };
                        row.Controls.Add(cellSum);
                        basketTable.Controls.Add(row);
                    }
                    conn.Close();
                }
            }
            else
            {
                Response.Redirect("Login.aspx?redirectUrl=Basket.aspx");
            }
        }

        public static void GenerateSizes(string startValue, TableRow row)
        {
            TableCell cellSize = new TableCell();
            string[] sizes = { "S", "M", "L", "XL", "XXL" };
            DropDownList cellSizeDrop = new DropDownList();
            cellSizeDrop.AutoPostBack = true;
            cellSizeDrop.SelectedIndexChanged += (sender, e) => CellSizeDrop_SelectedIndexChanged(sender, e);
            foreach (string size in sizes)
            {
                cellSizeDrop.Items.Add(size);
            }
            cellSizeDrop.SelectedValue = startValue;
            cellSize.Controls.Add(cellSizeDrop);
            row.Controls.Add(cellSize);
            sizeDropdowns.Add(cellSizeDrop);
            //sizeDropdowns.Append(cellSizeDrop);
            Debug.WriteLine(sizeDropdowns);
        }

        protected static void CellSizeDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int dropIndex = 0;
            //for (int i = 0; i < sizeDropdowns.Count; i++)
            //{
            //    if (sizeDropdowns.Contains(sender))
            //    {
            //        dropIndex = i;
            //        break;
            //    }
            //}
            //Debug.WriteLine(dropIndex);
            //Debug.WriteLine(Array.IndexOf(sizeDropdowns, sender));
        }

        public static void GenerateColors(string colors, string startValue, TableRow row)
        {
            string[] colorsArr = colors.Split(',');
            TableCell cellColor = new TableCell();
            DropDownList cellColorDrop = new DropDownList();
            cellColorDrop.AutoPostBack = true;
            foreach (string color in colorsArr)
            {
                cellColorDrop.Items.Add(color);
            }
            cellColorDrop.SelectedValue = startValue;
            cellColor.Controls.Add(cellColorDrop);
            row.Controls.Add(cellColor);
        }

        protected void buttonOrder_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = Database.Connect();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE koszyk SET is_ordered=1 WHERE user_id=" + Session["user_id"];
            MySqlDataReader reader = command.ExecuteReader();
            Mail.SendMail("kijolakijek3@gmail.com", "Złożono zamówienie", "Witaj. Twoje zamówienie jest w trakcie realizacji. :)");
            Response.Redirect("Basket.aspx");
        }

        protected void DeleteOrder(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            MySqlConnection conn = Database.Connect();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "DELETE FROM koszyk WHERE id=@id";
            var idParam = new MySqlParameter("id", MySqlDbType.Int64);
            idParam.Value = button.CommandArgument;
            command.Parameters.Add(idParam);
            MySqlDataReader reader = command.ExecuteReader();
            Response.Redirect("Basket.aspx");
        }
    }
}