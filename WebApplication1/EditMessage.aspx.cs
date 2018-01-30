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
<<<<<<< HEAD
            
=======
            int i = 0;
>>>>>>> a902aa8775db4158cc7cb1b482b6c588111a4d95
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
                    rdr["FirstName"].ToString() + " " + rdr["LastName"].ToString()+ " - " + rdr["Mobile"].ToString() + "</a>"+
                    "</h4>" + "</div>" + "<div id=\"collapse" + i + "\" class=\"panel-collapse collapse\">" + "<div class=\"panel-body\">" +
                    "<div style=\"max-width:100%; max-height:400px; overflow: auto; text-align:center\">";
                test.Controls.Add(literalControlHeader);
                //add id to panel body and write gridview and all that to that id

                GridView GridView1 = new GridView();
                test.Controls.Add(GridView1);
                DataTable convo = new DataTable();
                convo.Columns.Add("From:", System.Type.GetType("System.String"));
                convo.Columns.Add("Message:", System.Type.GetType("System.String"));
                convo.Columns.Add("Time:", System.Type.GetType("System.DateTime"));
                var messages = MessageResource.Read(to: new PhoneNumber(rdr["Mobile"].ToString()));
                foreach (var message in messages)
                {
                    DataRow text = convo.NewRow();
                    text["From:"] = "You";
                    text["Message:"] = message.Body;
                    text["Time:"] = message.DateSent;
                    convo.Rows.Add(text);

                }
                var messages1 = MessageResource.Read(to: "(765) 345 - 4144", from: new PhoneNumber(rdr["Mobile"].ToString()));
                foreach (var message in messages1)
                {
                    DataRow text = convo.NewRow();
                    text["From:"] = rdr["FirstName"].ToString();
                    text["Message:"] = message.Body;
                    text["Time:"] = message.DateSent;
                    convo.Rows.Add(text);
                }
                convo.DefaultView.Sort = "Time: ASC";
                GridView1.DataSource = convo;
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

        private void btnevent_Click(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;
            string id = btn.CommandArgument;
            TextBox txt = (TextBox)test.FindControl(id);
            string sms = txt.Text;

            const string accountSid = "AC81311ed7d5aa3a5b8debc7306abbb0ee";
            const string authToken = "17d80aa7c2ad0c26a45b8607fba63dda";
            TwilioClient.Init(accountSid, authToken);
            var to = new PhoneNumber(id);

                var message = MessageResource.Create(
                    to,
                    from: new PhoneNumber("17653454144"),
                    body: sms);


            Response.Redirect(Request.RawUrl);
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
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

                const string accountSid = "AC81311ed7d5aa3a5b8debc7306abbb0ee";
                const string authToken = "17d80aa7c2ad0c26a45b8607fba63dda";
                TwilioClient.Init(accountSid, authToken);
                var to = new PhoneNumber(dr["Mobile"].ToString());
                var message = MessageResource.Create(
                    to,
                    from: new PhoneNumber("17653454144"),
                    body: sbody);



            }
            dr.Close();
            conn.Close();


            MySqlConnection connd = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            connd.Open();

            string deleteString = "delete from messages where address = @address";
            MySqlCommand comdd = new MySqlCommand(deleteString, connd);

            comdd.Parameters.AddWithValue("@address", address);

            comdd.ExecuteNonQuery();
            connd.Close();



            MySqlConnection conni = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conni.Open();
            string insertString = "insert into messages (Address, MessageBody) " +
                "values (@Address, @MessageBody) ";
            MySqlCommand comdi = new MySqlCommand(insertString, conni);
            comdi.Parameters.AddWithValue("@Address", address);
            comdi.Parameters.AddWithValue("@MessageBody", sbody);
            comdi.ExecuteNonQuery();
            conni.Close();
            Response.Redirect(Request.RawUrl);

        }

        protected void Buttondel_Click(object sender, EventArgs e)
        {
            string address = Request.QueryString["Address"];

            MySqlConnection connd = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            connd.Open();

            string deleteString = "delete from messages where address = @address";
            MySqlCommand comdd = new MySqlCommand(deleteString, connd);

            comdd.Parameters.AddWithValue("@address", address);

            comdd.ExecuteNonQuery();
            connd.Close();
            Response.Redirect("MassText.aspx");


        }
    }
}