using WebApplication1.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using MySql.Data.MySqlClient;




namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            addView();
        }
        private void addView()
        {
            string qry = "Select * From Odometer WHERE name=1";
            int count = 0;

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(qry, conn);

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                count = Convert.ToInt32(rdr["count"].ToString());
            }

            conn.Close();
            rdr.Close();

            count++;

            qry = "UPDATE odometer SET count=" + count + " WHERE name=1";
            conn.Open();

            cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        protected void ButtonLogin_click(object sender, EventArgs e)
        {
            UserUtil customer = new UserUtil();
            customer.UserName = TextBoxUserName.Text;
            customer.password = TextBoxPassword.Text;
            if (customer.checkPassword())
            {

                string qry = "Select PhoneNumber from Users WHERE username='" + TextBoxUserName.Text + "'";
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(qry, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Session["PhoneNumber"] = rdr["PhoneNumber"].ToString();
                }

                //close Data Reader
                rdr.Close();

                //close Connection
                conn.Close();

                Session["user"] = TextBoxUserName.Text;
                Session["usertype"] = getUserType(TextBoxUserName.Text);
                Response.Redirect("Calendar.aspx");
            }
            else
            {
                LabelMessage.Enabled = true;
                LabelMessage.Visible = true;
                LabelMessage.Text = "Password is not correct";
                LabelMessage.ForeColor = Color.Red;
                //Response.AddHeader("refresh", "4; url=ResetPassword.aspx");
            }


        }

        private object getUserType(string text)
        {
            int type = 0;

            string qry = "Select UserType from Users WHERE username='" + text + "'";
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);

            conn.Open();

            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                type = Convert.ToInt32(rdr["UserType"].ToString());
            }

            //close Data Reader
            rdr.Close();

            //close Connection
            conn.Close();

            return type;
        }
    }
}
