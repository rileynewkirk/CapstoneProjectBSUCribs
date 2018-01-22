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

            while (rdr.Read())
            {
                i++;
                literalControl.Text += "<div class=\"panel panel-default\">" +
                    "<div class=\"panel-heading\">" + "<h4 class=\"panel-title\">" +
                    "<a data-toggle=\"collapse\" data-parent=\"#accordion\" href=\"#collapse" + i + "\">" + 
                    rdr["FirstName"].ToString() + " " + rdr["LastName"].ToString()+ " - " + rdr["Mobile"].ToString() + "</a>"+
                    "</h4>" + "</div>" + "<div id=\"collapse" + i + "\" class=\"panel-collapse collapse\">" + "<div class=\"panel-body\">";



                form1.Controls.Add(literalControl);



                GridView GridView1 = new GridView();
                form1.Controls.Add(GridView1);
                DataTable convo = new DataTable();
                convo.Columns.Add("From", System.Type.GetType("System.String"));
                convo.Columns.Add("Message", System.Type.GetType("System.String"));
                convo.Columns.Add("Time", System.Type.GetType("System.DateTime"));
                var messages = MessageResource.Read(to: new PhoneNumber(rdr["Mobile"].ToString()));
                foreach (var message in messages)
                {
                    DataRow text = convo.NewRow();
                    text["From"] = "You";
                    text["Message"] = message.Body;
                    text["Time"] = message.DateSent;
                    convo.Rows.Add(text);

                }
                var messages1 = MessageResource.Read(to: "(765) 345 - 4144", from: new PhoneNumber(rdr["Mobile"].ToString()));
                foreach (var message in messages1)
                {
                    DataRow text = convo.NewRow();
                    text["From"] = "Them";
                    text["Message"] = message.Body;
                    text["Time"] = message.DateSent;
                    convo.Rows.Add(text);
                }
                convo.DefaultView.Sort = "Time ASC";
                GridView1.DataSource = convo;
                GridView1.DataBind();
                literalControl.Text += "</div></div></div>";

            }

            literalControl.Text += "</div>";
            //close Data Reader
            rdr.Close();

            //close Connection
            conn.Close();



        }
    }
}