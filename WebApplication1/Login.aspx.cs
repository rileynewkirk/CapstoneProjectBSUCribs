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

        }
        protected void ButtonLogin_click(object sender, EventArgs e)
        {
            UserUtil customer = new UserUtil();
            customer.UserName = TextBoxUserName.Text;
            customer.password = TextBoxPassword.Text;
            if (customer.checkPassword())
            {
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
