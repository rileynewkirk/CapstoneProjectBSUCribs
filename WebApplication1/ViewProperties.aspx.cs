using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication1
{
    public partial class ViewProperties : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["userType"]) == 2)
            {
                LiteralControl nav = new LiteralControl();
                nav.Text = "<a href=\"Registration.aspx\">Users</a>";
                navADD.Controls.Add(nav);
            }


            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM table4;", conn);
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable);


            GridView1.DataSource = dataTable;
            GridView1.DataBind();

        }
    }
}