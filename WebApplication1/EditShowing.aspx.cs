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
using System.Text.RegularExpressions;

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
                LiteralControl navedit = new LiteralControl();
                navedit.Text = "<a href=\"EditHousingList.aspx\">Edit Housing List</a>";
                editADD.Controls.Add(navedit);
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


        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            //update showing
            Response.Redirect("Calendar.aspx");
        }

        protected void editShowingBtn_Click(object sender, EventArgs e)
        {
            string ID = Request.QueryString["ShowingID"];
            DateTime ogtime = new DateTime();
            string oghouse = "";

            MySqlConnection conn3 = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            string getShowing = "select date_format(Showing_DateTime, '%Y-%m-%d %h:%i'), Address from calendar where Showing_ID = @id";
            conn3.Open();
            MySqlCommand comd3 = new MySqlCommand(getShowing, conn3);
            comd3.Parameters.AddWithValue("id", ID);
            MySqlDataReader dr3 = comd3.ExecuteReader();
            while (dr3.Read())
            {
                ogtime = Convert.ToDateTime(dr3["date_format(Showing_DateTime, '%Y-%m-%d %h:%i')"]);
                oghouse = dr3["Address"].ToString();
            }
            dr3.Close();
            conn3.Close();

            string showingTime = TimePicker.Text;
            string showingDate = DatePicker.Text;
            DateTime showingDateTime = Convert.ToDateTime(showingDate + " " + showingTime);

            string address = AddressDropDownList.SelectedValue;

            string qry = "UPDATE calendar SET Address=@address, Showing_DateTime=@showingDate, Created_DateTime=@dateCreated WHERE Showing_ID=" + ID;
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(qry, conn);

            //cmd.Parameters.AddWithValue("@showingID", ID);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@showingDate", showingDateTime.ToString("yyyy-MM-dd hh:mm"));
            cmd.Parameters.AddWithValue("@dateCreated", DateTime.Now);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            string pat = address + ".*";

            // Instantiate the regular expression object.
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);

            // Match the regular expression pattern against a text string.
            Match m = r.Match(oghouse);

            string t = showingDateTime.ToString("g");
            string showOGTime = ogtime.ToString("g");
            string sbody = "C&M Property Management: A showing that was scheduled on " + showOGTime + " has now been moved to " + t;
            string cancelmsg = "C&M Property Management: A showing that was scheduled on " + showOGTime + "has been cancelled.";

            if (m.Success)
            {
                //text sent to new house informing them of showing
                sbody = "C&M Property Management: A house showing has been scheduled for your residence on " + t;
                MySqlConnection conn2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                conn2.Open();
                string checkShowing = "select * from table4 where PropertyName = @Address";
                MySqlCommand comd = new MySqlCommand(checkShowing, conn2);
                comd.Parameters.AddWithValue("Address", address);
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
                conn2.Close();

                MySqlConnection connd = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                connd.Open();

                string deleteString = "delete from messages where address = @address and phoneNumber = @PhoneNumber";
                MySqlCommand comdd = new MySqlCommand(deleteString, connd);

                comdd.Parameters.AddWithValue("@address", address);
                comdd.Parameters.AddWithValue("@PhoneNumber", Session["PhoneNumber"].ToString());
                comdd.ExecuteNonQuery();
                connd.Close();

                MySqlConnection conni = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                conni.Open();
                string insertString = "insert into messages (Address, MessageBody, phoneNumber) " +
                    "values (@Address, @MessageBody, @PhoneNumber) ";
                MySqlCommand comdi = new MySqlCommand(insertString, conni);
                comdi.Parameters.AddWithValue("@Address", address);
                comdi.Parameters.AddWithValue("@MessageBody", sbody);
                comdi.Parameters.AddWithValue("@PhoneNumber", Session["PhoneNumber"].ToString());
                comdi.ExecuteNonQuery();
                conni.Close();


                //text sent to old house confirming deleted showing
                MySqlConnection conn5 = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                conn5.Open();
                string delShowing = "select * from table4 where PropertyName = @Address";
                MySqlCommand comd5 = new MySqlCommand(delShowing, conn5);
                comd5.Parameters.AddWithValue("Address", oghouse);
                MySqlDataReader dr5 = comd5.ExecuteReader();

                while (dr5.Read())
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
                            body: cancelmsg);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script language=javascript>agree=confirm('The phone number for this user is not a viable twilio phone number, AND THE MESSAGE DID NOT ACTUALLY SEND'); window.location='MassText.aspx';</script>");
                    }
                }
                dr5.Close();
                conn5.Close();

                MySqlConnection conn6 = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                conn6.Open();

                string deleteString6 = "delete from messages where address = @address and phoneNumber = @PhoneNumber";
                MySqlCommand comd6 = new MySqlCommand(deleteString6, conn6);

                comd6.Parameters.AddWithValue("@address", oghouse);
                comd6.Parameters.AddWithValue("@PhoneNumber", Session["PhoneNumber"].ToString());
                comd6.ExecuteNonQuery();
                conn6.Close();

                MySqlConnection conn7 = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                conn7.Open();
                string insertString7 = "insert into messages (Address, MessageBody, phoneNumber) " +
                    "values (@Address, @MessageBody, @PhoneNumber) ";
                MySqlCommand comd7 = new MySqlCommand(insertString7, conn7);
                comd7.Parameters.AddWithValue("@Address", oghouse);
                comd7.Parameters.AddWithValue("@MessageBody", cancelmsg);
                comd7.Parameters.AddWithValue("@PhoneNumber", Session["PhoneNumber"].ToString());
                comd7.ExecuteNonQuery();
                conn7.Close();
            }
            else
            {
                MySqlConnection conn2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                conn2.Open();
                string checkShowing = "select * from table4 where PropertyName = @Address";
                MySqlCommand comd = new MySqlCommand(checkShowing, conn2);
                comd.Parameters.AddWithValue("Address", address);
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
                conn2.Close();

                MySqlConnection connd = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                connd.Open();

                string deleteString = "delete from messages where address = @address and phoneNumber = @PhoneNumber";
                MySqlCommand comdd = new MySqlCommand(deleteString, connd);

                comdd.Parameters.AddWithValue("@address", address);
                comdd.Parameters.AddWithValue("@PhoneNumber", Session["PhoneNumber"].ToString());
                comdd.ExecuteNonQuery();
                connd.Close();

                MySqlConnection conni = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                conni.Open();
                string insertString = "insert into messages (Address, MessageBody, phoneNumber) " +
                    "values (@Address, @MessageBody, @PhoneNumber) ";
                MySqlCommand comdi = new MySqlCommand(insertString, conni);
                comdi.Parameters.AddWithValue("@Address", address);
                comdi.Parameters.AddWithValue("@MessageBody", sbody);
                comdi.Parameters.AddWithValue("@PhoneNumber", Session["PhoneNumber"].ToString());
                comdi.ExecuteNonQuery();
                conni.Close();

            }

            Response.Redirect("Calendar.aspx");
        }
    }
}