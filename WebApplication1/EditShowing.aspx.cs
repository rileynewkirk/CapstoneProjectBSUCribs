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
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

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

            if (Convert.ToInt32(Session["userType"]) == 2)
            {
                LiteralControl nav = new LiteralControl();
                nav.Text = "<a href=\"Registration.aspx\">Users</a>";
                navADD.Controls.Add(nav);
            }
            if (Session["user"] == null)
            {
                Response.Write("<script language=javascript> var agree; agree=confirm('You have to log in first'); window.location='Login.aspx';</script>");
            }
            if (Session["PhoneNumber"] == null)
            {
                Response.Write("<script language=javascript> var agree; agree=confirm('You have to log in first'); window.location='Login.aspx';</script>");
            }
        }

        //public void updateShowingInfo(string ID)
        //{

        //    string address;
        //    string client;
        //    string showingDate;
        //    DateTime dateCreated;
        //    DateTime showing_Date;


        //    string qry = @"SELECT date_format(Showing_DateTime, '%Y-%m-%d %h:%i'), Agent_ID, Client_Name, Address FROM calendar WHERE Showing_ID = " + ID;
        //    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
        //    MySqlCommand cmd = new MySqlCommand(qry, conn);
        //    conn.Open();

        //    using (MySqlDataReader rdr = cmd.ExecuteReader())
        //    {
        //        while (rdr.Read())
        //        {
        //            //showingID = rdr["Showing_ID"].ToString();
        //            address = rdr["Address"].ToString();
        //            showingDate = rdr["date_format(Showing_DateTime, '%Y-%m-%d %h:%i')"].ToString();
        //            client = rdr["Client_Name"].ToString();
        //            dateCreated = DateTime.Now;
        //            showing_Date = Convert.ToDateTime(showingDate);

        //            //DatePicker.Text = showing_Date.ToString("yyyy/MM/dd");
        //            //TimePicker.Text = showing_Date.ToString("hh:mm");

        //            //DatePicker.Text = ;
        //            //var showingDate = date.ToString(); //.ToString("yyyy-MM-dd");
        //            //Showing showing = new Showing(leasingAgent, client, address, showingDate);


        //        }
        //        rdr.Close();
        //        conn.Close();               
        //    }
        //    //updateShowing(ID, address, client, showingDate.ToString(), dateCreated.ToString());
        //}

        public void updateShowing(string ID)
        {
            /*
            string showingTime = TimePicker.Text;
            string showingDate = DatePicker.Text;
            DateTime showingDateTime = Convert.ToDateTime(showingDate + " " + showingTime);

            string address = ListOfHouses.Items[0].ToString();
        
            string qry = "UPDATE calendar SET Address=@address, Showing_DateTime=@showingDate, Created_DateTime=@dateCreated WHERE Showing_ID='" + ID + "'";
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(qry, conn);

            //cmd.Parameters.AddWithValue("@showingID", ID);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@showingDate", showingDateTime.ToString("yyyy-MM-dd hh:mm"));
            cmd.Parameters.AddWithValue("@dateCreated", DateTime.Now);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("Calendar.aspx");
            */    
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
            //string ID = Request.QueryString["ShowingID"];
            //DateTime ogtime = new DateTime();

            //MySqlConnection conn3 = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            //conn3.Open();
            //string getShowing = "select * from calendar where Showing_ID = " + ID;
            //MySqlCommand comd3 = new MySqlCommand(getShowing, conn3);
            //MySqlDataReader dr3 = comd3.ExecuteReader();

            //while (dr3.Read())
            //{
            //    ogtime = (DateTime)dr3["Showing_Time"];
            //}
            //dr3.Close();
            //conn3.Close();

            string showingTime = TimePicker.Text;
            string showingDate = DatePicker.Text;
            DateTime showingDateTime = Convert.ToDateTime(showingDate + " " + showingTime);

            string address = ListOfHouses.Items[0].ToString();

            string qry = "UPDATE calendar SET Address=@address, Showing_DateTime=@showingDate, Created_DateTime=@dateCreated WHERE Showing_ID='" + ID + "'";
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(qry, conn);

            //cmd.Parameters.AddWithValue("@showingID", ID);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@showingDate", showingDateTime.ToString("yyyy-MM-dd hh:mm"));
            cmd.Parameters.AddWithValue("@dateCreated", DateTime.Now);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();


            //string t = showingDateTime.ToString("g");
            //string showOGTime = ogtime.ToString("g");
            //string sbody = "A showing that was scheduled on " + showOGTime + " has now been moved to " + t;

            //MySqlConnection conn2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            //conn2.Open();
            //string checkShowing = "select * from table4 where PropertyName = @Address";
            //MySqlCommand comd = new MySqlCommand(checkShowing, conn2);
            //comd.Parameters.AddWithValue("Address", address);
            //MySqlDataReader dr = comd.ExecuteReader();

            //while (dr.Read())
            //{
            //    const string accountSid = "AC81311ed7d5aa3a5b8debc7306abbb0ee";
            //    const string authToken = "17d80aa7c2ad0c26a45b8607fba63dda";
            //    TwilioClient.Init(accountSid, authToken);
            //    try
            //    {
            //        var to = new PhoneNumber(dr["Mobile"].ToString());
            //        var message = MessageResource.Create(
            //            to,
            //            from: new PhoneNumber(Session["PhoneNumber"].ToString()),
            //            body: sbody);
            //    }
            //    catch (Exception ex)
            //    {
            //        Response.Write("<script language=javascript>agree=confirm('The phone number for this user is not a viable twilio phone number, AND THE MESSAGE DID NOT ACTUALLY SEND'); window.location='MassText.aspx';</script>");
            //    }
            //}
            //dr.Close();
            //conn2.Close();

            //MySqlConnection connd = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            //connd.Open();

            //string deleteString = "delete from messages where address = @address and phoneNumber = @PhoneNumber";
            //MySqlCommand comdd = new MySqlCommand(deleteString, connd);

            //comdd.Parameters.AddWithValue("@address", address);
            //comdd.Parameters.AddWithValue("@PhoneNumber", Session["PhoneNumber"].ToString());
            //comdd.ExecuteNonQuery();
            //connd.Close();

            //MySqlConnection conni = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            //conni.Open();
            //string insertString = "insert into messages (Address, MessageBody, phoneNumber) " +
            //    "values (@Address, @MessageBody, @PhoneNumber) ";
            //MySqlCommand comdi = new MySqlCommand(insertString, conni);
            //comdi.Parameters.AddWithValue("@Address", address);
            //comdi.Parameters.AddWithValue("@MessageBody", sbody);
            //comdi.Parameters.AddWithValue("@PhoneNumber", Session["PhoneNumber"].ToString());
            //comdi.ExecuteNonQuery();
            //conni.Close();


            Response.Redirect("Calendar.aspx");
        }
    }
}