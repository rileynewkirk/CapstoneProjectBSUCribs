using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.Mvc;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using System.Data;
using System.IO;

namespace WebApplication1
{
    public partial class EditMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("<script language=javascript> var agree; agree=confirm('You have to log in first'); window.location='Login.aspx';</script>");
            }
            if (Convert.ToInt32(Session["userType"]) == 2)
            {
                getAgentsConvos();
                LiteralControl nav = new LiteralControl();
                nav.Text = "<a href=\"Registration.aspx\">Users</a>";
                navADD.Controls.Add(nav);
            }
            if (Session["PhoneNumber"] == null)
            {
                Response.Write("<script language=javascript> var agree; agree=confirm('You have to log in first'); window.location='Login.aspx';</script>");
            }


            int i = 0;
            string address = Request.QueryString["Address"];
            Labelnum.Text = "Messages sent to " + address;
            const string accountSid = "AC81311ed7d5aa3a5b8debc7306abbb0ee";
            const string authToken = "17d80aa7c2ad0c26a45b8607fba63dda";
            TwilioClient.Init(accountSid, authToken);

            string qry = "select * from table4 where PropertyName = @PropertyName";
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("PropertyName", address);
            MySqlDataReader rdr = cmd.ExecuteReader();
            LiteralControl literalControl = new LiteralControl();
            literalControl.Text = "<div class=\"panel-group\" id=\"accordion\">";
            test.Controls.Add(literalControl);
            while (rdr.Read())
            {
                i++;
                LiteralControl literalControlHeader = new LiteralControl();
                literalControlHeader.Text += "<div class=\"panel panel-default\">" +
                    "<div class=\"panel-heading\">" + "<h4 class=\"panel-title\">" +
                    "<a data-toggle=\"collapse\" data-parent=\"#accordion\" href=\"#collapse" + i + "\">" +
                    rdr["FirstName"].ToString() + " " + rdr["LastName"].ToString() + " - " + rdr["Mobile"].ToString() + "</a>" +
                    "</h4>" + "</div>" + "<div id=\"collapse" + i + "\" class=\"panel-collapse collapse\">" + "<div class=\"panel-body\">" +
                    "<div id=\"scrolld" + i + "\" style=\"width:100%; max-height:400px; overflow: auto; text-align:center\">";
                test.Controls.Add(literalControlHeader);
                //Response.Write("<script language=javascript>$(\"#scrolld" + i + "\").scrollTop($(\"#scrolld" + i +"\")[0].scrollHeight); ");
                //litscript.Text += "";

                GridView GridView1 = new GridView();
                test.Controls.Add(GridView1);
                DataTable convo = new DataTable();
                convo.Columns.Add("From:", System.Type.GetType("System.String"));
                convo.Columns.Add("Message:", System.Type.GetType("System.String"));
                convo.Columns.Add("Time:", System.Type.GetType("System.DateTime"));
                var messages = MessageResource.Read(to: new PhoneNumber(rdr["Mobile"].ToString()), from: Session["PhoneNumber"].ToString());
                foreach (var message in messages)
                {
                    DataRow text = convo.NewRow();
                    text["From:"] = "You";
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
                var messages1 = MessageResource.Read(to: Session["PhoneNumber"].ToString(), from: new PhoneNumber(rdr["Mobile"].ToString()));
                foreach (var message in messages1)
                {
                    DataRow text = convo.NewRow();
                    text["From:"] = rdr["FirstName"].ToString();
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
                convo.DefaultView.Sort = "Time: ASC";
                GridView1.Width = Unit.Percentage(100);
                GridView1.DataSource = convo;
                GridView1.Style["width"] = "100%";
                GridView1.DataBind();
                
                LiteralControl literalControlrespond = new LiteralControl();
                literalControlrespond.Text += "</div><br/><div style=\"text-align: center;\">";
                test.Controls.Add(literalControlrespond);

                TextBox tb = new TextBox();
                tb.Rows = 5;
                tb.Columns = 60;
                tb.Attributes.Add("maxlength", "1500");
                tb.TextMode = TextBoxMode.MultiLine;
                tb.ID = rdr["Mobile"].ToString();
                test.Controls.Add(tb);

                LiteralControl literalControlbtn = new LiteralControl();
                literalControlbtn.Text += "</div><br/><div style=\"text-align: center;\">";
                test.Controls.Add(literalControlbtn);

                Button btnsend = new Button();
                btnsend.OnClientClick = "this.disabled = true; this.value = 'Sending...';";
                btnsend.UseSubmitBehavior = false;
                btnsend.Text = "Send";
                btnsend.Click += new EventHandler(btnevent_Click);
                btnsend.CommandArgument = rdr["Mobile"].ToString();
                btnsend.CssClass = "btn btn-success";
                test.Controls.Add(btnsend);



                LiteralControl literalControlBody = new LiteralControl();
                literalControlBody.Text += "</div></div></div></div>";
                test.Controls.Add(literalControlBody);

            }

            LiteralControl literalControlEnd = new LiteralControl();
            literalControlEnd.Text += "</div>";
            test.Controls.Add(literalControlEnd);

            //close Data Reader
            rdr.Close();

            //close Connection
            conn.Close();
            tbMessage.Attributes.Add("maxlength", "1500");


        }

        private void getAgentsConvos()
        {
            int i = 0;
            string address = Request.QueryString["Address"];
            const string accountSid = "AC81311ed7d5aa3a5b8debc7306abbb0ee";
            const string authToken = "17d80aa7c2ad0c26a45b8607fba63dda";
            TwilioClient.Init(accountSid, authToken);

            LiteralControl literalControl = new LiteralControl();
            literalControl.Text = "<div class=\"panel-group\" id=\"accordion1\">";
            Div1.Controls.Add(literalControl);

            string qry = "select * from messages where Address = @PropertyName";
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("PropertyName", address);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string phoneNumber = rdr["phoneNumber"].ToString();
                string qry2 = "select * from users where PhoneNumber = @PhoneNumber";
                MySqlConnection conn2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                conn2.Open();
                MySqlCommand cmd2 = new MySqlCommand(qry2, conn2);
                cmd2.Parameters.AddWithValue("PhoneNumber", phoneNumber);
                MySqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    if (rdr2["PhoneNumber"].ToString() == Session["PhoneNumber"].ToString())
                    {

                    }
                    else
                    {
                        i++;
                        LiteralControl literalControlHeader = new LiteralControl();
                        literalControlHeader.Text += "<div class=\"panel panel-default\">" +
                            "<div class=\"panel-heading\">" + "<h4 class=\"panel-title\">" +
                            "<a data-toggle=\"collapse\" data-parent=\"#accordion1\" href=\"#collapse1" + i + "\">" +
                            rdr2["Firstname"].ToString() + " " + rdr2["Lastname"].ToString() + " - " + rdr2["PhoneNumber"].ToString() + "</a>" +
                            "</h4>" + "</div>" + "<div id=\"collapse1" + i + "\" class=\"panel-collapse collapse\">" + "<div class=\"panel-body\">";
                        Div1.Controls.Add(literalControlHeader);
                        // here we make inner accordian for messages sent to tenants from whatever agent
                        LiteralControl literalControlInner = new LiteralControl();
                        literalControlInner.Text = "<div class=\"panel-group\" id=\"accordion2\">";
                        Div1.Controls.Add(literalControlInner);

                        string qry3 = "select * from table4 where PropertyName = @PropertyName";
                        MySqlConnection conn3 = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                        conn3.Open();
                        MySqlCommand cmd3 = new MySqlCommand(qry3, conn3);
                        cmd3.Parameters.AddWithValue("PropertyName", address);
                        MySqlDataReader rdr3 = cmd3.ExecuteReader();
                        while (rdr3.Read())
                        {
                            i++;
                            LiteralControl literalControlHeaderInner = new LiteralControl();
                            literalControlHeaderInner.Text += "<div class=\"panel panel-default\">" +
                                "<div class=\"panel-heading\">" + "<h4 class=\"panel-title\">" +
                                "<a data-toggle=\"collapse\" data-parent=\"#accordion2\" href=\"#collapseInner" + i + "\">" +
                                rdr3["FirstName"].ToString() + " " + rdr3["LastName"].ToString() + " - " + rdr3["Mobile"].ToString() + "</a>" +
                                "</h4>" + "</div>" + "<div id=\"collapseInner" + i + "\" class=\"panel-collapse collapse\">" + "<div class=\"panel-body\">" +
                                "<div id=\"scrollb"+i+ "\" style=\"width:100%; max-height:400px; overflow: auto; text-align:center\">";
                            Div1.Controls.Add(literalControlHeaderInner);

                            //Response.Write("<script language=javascript>$(\"#scrollb"+i+ "\").scrollTop($(\"#scrollb" + i +"\")[0].scrollHeight); ");
                            //litscript.Text += "<script language=javascript>$(\"#scrollb" + i + "\").scrollTop($(\"#scrollb" + i + "\")[0].scrollHeight);</script>";

                            GridView GridView1 = new GridView();
                            Div1.Controls.Add(GridView1);
                            DataTable convo = new DataTable();
                            convo.Columns.Add("From:", System.Type.GetType("System.String"));
                            convo.Columns.Add("Message:", System.Type.GetType("System.String"));
                            convo.Columns.Add("Time:", System.Type.GetType("System.DateTime"));
                            var messages = MessageResource.Read(to: new PhoneNumber(rdr3["Mobile"].ToString()), from: rdr2["PhoneNumber"].ToString());
                            foreach (var message in messages)
                            {
                                DataRow text = convo.NewRow();
                                text["From:"] = rdr2["Firstname"].ToString() + " " + rdr2["Lastname"].ToString();
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
                            var messages1 = MessageResource.Read(to: rdr2["PhoneNumber"].ToString(), from: new PhoneNumber(rdr3["Mobile"].ToString()));
                            foreach (var message in messages1)
                            {
                                DataRow text = convo.NewRow();
                                text["From:"] = rdr3["FirstName"].ToString();
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
                            convo.DefaultView.Sort = "Time: ASC";
                            GridView1.Width = Unit.Percentage(100);
                            GridView1.DataSource = convo;
                            GridView1.Style["width"] = "100%";
                            GridView1.DataBind();

                            LiteralControl literalControlrespondInner = new LiteralControl();
                            literalControlrespondInner.Text += "</div></div></div></div>";
                            Div1.Controls.Add(literalControlrespondInner);
                        }
                        //close Data Reader
                        rdr3.Close();

                        //close Connection
                        conn3.Close();

                        LiteralControl literalControlBody = new LiteralControl();
                        literalControlBody.Text += "</div></div></div></div>";
                        Div1.Controls.Add(literalControlBody);
                    }
                }

                //close Data Reader
                rdr2.Close();

                //close Connection
                conn2.Close();

            }

            LiteralControl literalControlEnd = new LiteralControl();
            literalControlEnd.Text += "</div><hr/>";
            Div1.Controls.Add(literalControlEnd);
            //close Data Reader
            rdr.Close();
            //close Connection
            conn.Close();

        }

        private void btnevent_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.OnClientClick = "this.disabled = true; this.value = 'Sending...';";
            string id = btn.CommandArgument;
            TextBox txt = (TextBox)test.FindControl(id);
            string sms = txt.Text;

            const string accountSid = "AC81311ed7d5aa3a5b8debc7306abbb0ee";
            const string authToken = "17d80aa7c2ad0c26a45b8607fba63dda";
            TwilioClient.Init(accountSid, authToken);
            var to = new PhoneNumber(id);
            try
            {
            var message = MessageResource.Create(
                to,
                from: new PhoneNumber(Session["PhoneNumber"].ToString()),
                body: sms);
            }
            catch (Exception ex)
            {
                Response.Write("<script language=javascript>agree=confirm('The phone number for this user is not a viable twilio phone number, AND THE MESSAGE DID NOT ACTUALLY SEND'); window.location='MassText.aspx';</script>");
            }

            MySqlConnection connd = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            connd.Open();
            string address = Request.QueryString["Address"];
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
            comdi.Parameters.AddWithValue("@MessageBody", sms);
            comdi.Parameters.AddWithValue("@PhoneNumber", Session["PhoneNumber"].ToString());
            comdi.ExecuteNonQuery();
            conni.Close();

            Response.Redirect(Request.RawUrl);


        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.OnClientClick = "this.disabled = true; this.value = 'Sending...';";

            string sbody = tbMessage.Text;
            string address = Request.QueryString["Address"];
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();
            string checkShowing = "select * from table4 where PropertyName = @Address";
            MySqlCommand comd = new MySqlCommand(checkShowing, conn);
            comd.Parameters.AddWithValue("Address", address);
            MySqlDataReader dr = comd.ExecuteReader();

            while (dr.Read())
            {
                try
                {
                    const string accountSid = "AC81311ed7d5aa3a5b8debc7306abbb0ee";
                    const string authToken = "17d80aa7c2ad0c26a45b8607fba63dda";
                    TwilioClient.Init(accountSid, authToken);
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

            Response.Redirect(Request.RawUrl);

        }

        protected void Buttondel_Click(object sender, EventArgs e)
        {
            string address = Request.QueryString["Address"];
            MySqlConnection connd = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            connd.Open();

            string deleteString = "delete from messages where address = @address and phoneNumber = @PhoneNumber";
            MySqlCommand comdd = new MySqlCommand(deleteString, connd);

            comdd.Parameters.AddWithValue("@address", address);
            comdd.Parameters.AddWithValue("@PhoneNumber", Session["PhoneNumber"].ToString());
            comdd.ExecuteNonQuery();
            connd.Close();

            Response.Redirect("MassText.aspx");


        }
    }
}