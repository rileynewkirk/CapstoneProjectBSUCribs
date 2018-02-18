using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.App_Code;
using System.Data.OleDb;
using System.Data;

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
            updateShowingInfo(ID);
            //getShowingsByID(ID,date);
        }

        public void updateShowingInfo(string ID)
        {
            string address;
            string client;
            string showingDate;
            DateTime dateCreated;
            DateTime showing_Date;


            string qry = @"SELECT date_format(Showing_DateTime, '%Y-%m-%d %h:%i'), Agent_ID, Client_Name, Address FROM calendar WHERE Showing_ID = " + ID;
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            conn.Open();

            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    //showingID = rdr["Showing_ID"].ToString();
                    address = rdr["Address"].ToString();
                    showingDate = rdr["date_format(Showing_DateTime, '%Y-%m-%d %h:%i')"].ToString();
                    client = rdr["Client_Name"].ToString();
                    dateCreated = DateTime.Now;
                    showing_Date = Convert.ToDateTime(showingDate);

                    DatePicker.Text = showing_Date.ToString("yyyy/MM/dd");
                    TimePicker.Text = showing_Date.ToString("hh:mm");

                    //DatePicker.Text = ;
                    //var showingDate = date.ToString(); //.ToString("yyyy-MM-dd");
                    //Showing showing = new Showing(leasingAgent, client, address, showingDate);


                }
                rdr.Close();
                conn.Close();               
            }
            //updateShowing(ID, address, client, showingDate.ToString(), dateCreated.ToString());
        }

        public void updateShowing(string ID)
        {
            string showingTime = TimePicker.Text;
            string showingDate = DatePicker.Text;
            DateTime showingDT = new DateTime();
            DateTime showingDateTime = Convert.ToDateTime(showingDate + " " + showingTime);
            string address = ListOfHouses.Items[0].ToString();
        
            string qry = "UPDATE calendar SET Address=@address, Showing_DateTime=@showingDate, Created_DateTime=@dateCreated WHERE Showing_ID='" + ID + "'";
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(qry, conn);

            //cmd.Parameters.AddWithValue("@showingID", ID);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@showingDate", showingDT.ToString("yyyy-MM-dd hh:mm"));
            cmd.Parameters.AddWithValue("@dateCreated", DateTime.Now);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("Calendar.aspx");
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

        private void addInformationToPage(string address, string date)
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
            //update showing
            Response.Redirect("Calendar.aspx");
        }

        protected void editShowingBtn_Click(object sender, EventArgs e)
        {
            string showingID = Request.QueryString["ShowingID"];
            updateShowing(showingID);
            Response.Redirect("Calendar.aspx");
        }
    }
}