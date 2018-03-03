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
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using WebApplication1.App_Code;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static List<string> houses = new List<string>();

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

        protected void AddToList(object sender, EventArgs e)
        {
            string selectedHouse = AddressDropDownList.SelectedItem.Text;
            ListOfHouses.Items.Add(selectedHouse);
            houses.Add(selectedHouse);

        }

        protected void createShowings(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.OnClientClick = "this.disabled = true; this.value = 'Creating...';";
            foreach (string house in houses)
            {
                DateTime dateTime = Convert.ToDateTime(DatePicker.Text + " " + TimePicker.Text);
                //string dateTimeString = Convert.ToString(dateTime);

                Showing newShowing = new Showing();
                newShowing.LeasingAgent = Session["user"].ToString();
                newShowing.ShowingDate = dateTime.ToString("yyyy-MM-dd hh:mm" +
                    "");
                newShowing.Client = clientTB.Text;
                newShowing.Address = house;
                newShowing.DateCreated = DateTime.Now.ToString("yy-MM-dd");

                newShowing.addShowings();
                ListOfHouses.Items.Add(newShowing.Showing_ID + newShowing.LeasingAgent + newShowing.ShowingDate + newShowing.Client + newShowing.Address + newShowing.DateCreated);

                string t = dateTime.ToString("g");

                string sbody = "C&M Property Management: A showing has been scheduled for your residence on " + t;

                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                conn.Open();
                string checkShowing = "select * from table4 where PropertyName = @Address";
                MySqlCommand comd = new MySqlCommand(checkShowing, conn);
                comd.Parameters.AddWithValue("Address", house);
                MySqlDataReader dr = comd.ExecuteReader();

                while (dr.Read())
                {
                    const string accountSid = "AC81311ed7d5aa3a5b8debc7306abbb0ee";
                    const string authToken = "17d80aa7c2ad0c26a45b8607fba63dda";
                    TwilioClient.Init(accountSid, authToken);
                    try
                    {
                        var to = new PhoneNumber(dr["Mobile"].ToString());
                        var message = MessageResource.Create(
                            to,
                            from: new PhoneNumber(Session["PhoneNumber"].ToString()),
                            body: sbody);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script language=javascript>agree=confirm('The phone number for this user is not a viable twilio phone number, AND THE MESSAGE DID NOT ACTUALLY SEND'); window.location='MassText.aspx';</script>");
                    }
                }
                dr.Close();
                conn.Close();

                MySqlConnection connd = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                connd.Open();

                string deleteString = "delete from messages where address = @address and phoneNumber = @PhoneNumber";
                MySqlCommand comdd = new MySqlCommand(deleteString, connd);

                comdd.Parameters.AddWithValue("@address", house);
                comdd.Parameters.AddWithValue("@PhoneNumber", Session["PhoneNumber"].ToString());
                comdd.ExecuteNonQuery();
                connd.Close();

                MySqlConnection conni = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                conni.Open();
                string insertString = "insert into messages (Address, MessageBody, phoneNumber) " +
                    "values (@Address, @MessageBody, @PhoneNumber) ";
                MySqlCommand comdi = new MySqlCommand(insertString, conni);
                comdi.Parameters.AddWithValue("@Address", house);
                comdi.Parameters.AddWithValue("@MessageBody", sbody);
                comdi.Parameters.AddWithValue("@PhoneNumber", Session["PhoneNumber"].ToString());
                comdi.ExecuteNonQuery();
                conni.Close();
            }
            houses.Clear();
            Response.Redirect("Calendar.aspx");
            
            
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            houses.Clear();
            Response.Redirect("Calendar.aspx");
        }
    }
}