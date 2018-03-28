using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;

namespace WebApplication1
{
    public partial class MassText : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("<script language=javascript> var agree; agree=confirm('You have to log in first'); window.location='Login.aspx';</script>");
            }
            if (Convert.ToInt32(Session["userType"]) != 2)
            {
            }
            else
            {
                LiteralControl nav = new LiteralControl();
                nav.Text = "<a href=\"Registration.aspx\">Users</a>";
                navADD.Controls.Add(nav);
                LiteralControl navedit = new LiteralControl();
                navedit.Text = "<a href=\"EditHousingList.aspx\">Edit Housing List</a>";
                editADD.Controls.Add(navedit);
            }
            if (Session["PhoneNumber"] == null)
            {
                Response.Write("<script language=javascript> var agree; agree=confirm('You have to log in first'); window.location='Login.aspx';</script>");
            }

            if (!IsPostBack)
            {

                string qry = "select * from (select * from messages where phoneNumber = '" + Session["PhoneNumber"].ToString() + "' order by `Address`, id desc, messageBody) x group by `Address`";
                if (Convert.ToInt32(Session["userType"]) == 2)
                {
                    qry = "select * from (select * from messages order by `Address`, id desc, messageBody) x group by `Address`";
                }
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(qry, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string btn;
                    string address = rdr["Address"].ToString();
                    string contentb = rdr["messageBody"].ToString();
                    string start = "<tr>";
                    string phnum = "<td>" + address + "</td>";
                    string content = "<td>" + contentb + "</td>";
                    if (CompareLatestMessage(address) == true)
                    {
                        btn = "<td style=\"width:20%;\"><a href=\"EditMessage.aspx?Address=" + address + "\" class=\"btn btn-default\">View</a>&nbsp<i class=\"fa fa-exclamation-circle\" style=\"font - size:64px; color: red\"></i></td>";
                    }
                    else
                    {
                        btn = "<td style=\"width:20%;\"><a href=\"EditMessage.aspx?Address=" + address + "\" class=\"btn btn-default\">View</a></td>";
                    }
                    string end = "</tr>";
                    messageList.InnerHtml += start + phnum + content + btn + end;

                }

                //close Data Reader
                rdr.Close();

                //close Connection
                conn.Close();

            }

            //add addresses to drop down list
            if (!this.IsPostBack)
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                conn.Open();
                string checkShowing = "select distinct PropertyName from table4";
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
                if (Convert.ToInt32(Session["userType"]) == 2)
                {
                    AddressDropDownList.Items.Insert(1, new ListItem("Send To All Addresses", "1"));
                }
            }
            tbMessage.Attributes.Add("maxlength", "1500");
        }

        private bool CompareLatestMessage(string address)
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();
            string checkShowing = "select * from table4 where PropertyName = @Address";
            MySqlCommand comd = new MySqlCommand(checkShowing, conn);
            comd.Parameters.AddWithValue("Address", address);
            MySqlDataReader dr = comd.ExecuteReader();

            DataTable convo = new DataTable();
            convo.Columns.Add("Message:", System.Type.GetType("System.String"));
            convo.Columns.Add("Time:", System.Type.GetType("System.DateTime"));

            while (dr.Read())
            {
                const string accountSid = "AC81311ed7d5aa3a5b8debc7306abbb0ee";
                const string authToken = "17d80aa7c2ad0c26a45b8607fba63dda";
                TwilioClient.Init(accountSid, authToken);
                try
                {
                    var messages = MessageResource.Read(to: new PhoneNumber(dr["Mobile"].ToString()), from: Session["PhoneNumber"].ToString());
                    foreach (var message in messages)
                    {
                        DataRow text = convo.NewRow();
                        text["Message:"] = message.Body;
                        if (message.DateSent == null)
                        {
                            text["Time:"] = DateTime.Now;
                        }
                        else
                        {
                            text["Time:"] = message.DateSent;
                        }
                        convo.Rows.Add(text);
                    }
                    var messages1 = MessageResource.Read(to: Session["PhoneNumber"].ToString(), from: new PhoneNumber(dr["Mobile"].ToString()));
                    foreach (var message in messages1)
                    {
                        DataRow text = convo.NewRow();
                        text["Message:"] = message.Body;
                        if (message.DateSent == null)
                        {
                            text["Time:"] = DateTime.Now;
                        }
                        else
                        {
                            text["Time:"] = message.DateSent;
                        }
                        convo.Rows.Add(text);
                    }
                }
                catch (Exception ex) { }
            }
            dr.Close();
            conn.Close();

            convo.DefaultView.Sort = "Time: ASC";
            convo = convo.DefaultView.ToTable();
            try
            {
                DataRow lastRow = convo.Rows[convo.Rows.Count - 1];
                string lastmessage = lastRow["Message:"].ToString();

                string qry2 = "select * from messages where phoneNumber = '" + Session["PhoneNumber"].ToString() + "' and Address = '" + address + "'";

                MySqlConnection conn2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                conn2.Open();

                MySqlCommand cmd2 = new MySqlCommand(qry2, conn2);
                MySqlDataReader rdr2 = cmd2.ExecuteReader();

                while (rdr2.Read())
                {
                    if (rdr2["messageBody"].ToString() != lastmessage)
                    {
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
                        comdi.Parameters.AddWithValue("@MessageBody", lastmessage);
                        comdi.Parameters.AddWithValue("@PhoneNumber", Session["PhoneNumber"].ToString());
                        comdi.ExecuteNonQuery();
                        conni.Close();

                        return true;
                    }
                }
                rdr2.Close();
                conn2.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.OnClientClick = "this.disabled = true; this.value = 'Uploading...';";
            string sbody = tbMessage.Text;
            string address = AddressDropDownList.SelectedValue;
            if (address != "Send To All Addresses")
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                conn.Open();
                string checkShowing = "select * from table4 where PropertyName = @Address";
                MySqlCommand comd = new MySqlCommand(checkShowing, conn);
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
                        Label4.Visible = true;
                    }
                }
                dr.Close();
                conn.Close();
            }
            else
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                conn.Open();
                string checkShowing = "select * from table4";
                MySqlCommand comd = new MySqlCommand(checkShowing, conn);
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
                        Label4.Visible = true;
                    }
                }
                dr.Close();
                conn.Close();

            }

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

            lblResponse.Text = "Your message has been sent!";

        }


    }
}
