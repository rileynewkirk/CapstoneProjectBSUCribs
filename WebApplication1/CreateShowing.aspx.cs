using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                    conn.Open();
                    string checkShowing = "select distinct PropertyName from  table4";
                    MySqlCommand comd = new MySqlCommand(checkShowing, conn);
                    MySqlDataReader dr = comd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        AddressDropDownList.DataSource = dr;
                        AddressDropDownList.DataTextField = "PropertyName";
                        AddressDropDownList.DataValueField = "PropertyName";
                        AddressDropDownList.DataBind();
                     }

                    dr.Close();
                    conn.Close();
                    AddressDropDownList.Items.Insert(0, new ListItem("--Select Address--", "0"));

            }
        }
    }
}