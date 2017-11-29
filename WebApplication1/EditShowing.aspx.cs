using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.App_Code;

namespace WebApplication1
{
    public partial class EditShowing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //add properties to drop down list
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
            
            //get variables from URL
            string ID = Request.QueryString["showingID"];
            string date = Request.QueryString["showingDate"];
            getShowingsByID(ID,date);
        }

        private void getShowingsByID(string ID, string date)
        {

            string qry = "SELECT Agent_Name, Client_Name,Address FROM calendar WHERE Showing_ID  = '" + ID + "'";
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            conn.Open();
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    var address = rdr["Address"].ToString();
                    addInformationToPage(address, date);
                }
                rdr.Close();
                conn.Close();
            }
        }

        private void addInformationToPage( string address, string date)
        {
            DatePicker.Text = date;
            ListItem item = ListOfHouses.Items.FindByText(address);
            if (item == null)
            {
                ListOfHouses.Items.Add(address);
            }
            

            
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string selectedHouse = AddressDropDownList.SelectedItem.Text;
            ListItem item = ListOfHouses.Items.FindByText(selectedHouse);
            if (item == null)
            {
                ListOfHouses.Items.Add(selectedHouse);
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Calendar.aspx");
        }
    }
}