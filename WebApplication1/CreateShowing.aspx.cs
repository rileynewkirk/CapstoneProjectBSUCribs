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
using WebApplication1.App_Code;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static List<string> houses = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {   
            //add addresses to drop down list
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

        protected void AddToList(object sender, EventArgs e)
        {
            string selectedHouse = AddressDropDownList.SelectedItem.Text;
            ListOfHouses.Items.Add(selectedHouse);
            houses.Add(selectedHouse);
           
        }

        protected void createShowings(object sender, EventArgs e)
        {
            foreach(string house in houses)
            {
                Showing newShowing = new Showing();
                newShowing.LeasingAgent = Session["user"].ToString();
                newShowing.ShowingDate = DatePicker.Text;
                newShowing.Client = clientTB.Text; 
                newShowing.Address = house; 
                newShowing.DateCreated = DateTime.Now.ToString("yyMMdd");

                newShowing.addShowings();
                ListOfHouses.Items.Add(newShowing.Showing_ID + newShowing.LeasingAgent + newShowing.ShowingDate + newShowing.Client + newShowing.Address + newShowing.DateCreated);
            }
        }
    }
}