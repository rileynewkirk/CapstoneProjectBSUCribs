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

namespace WebApplication1
{
    public partial class EditMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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

            while (rdr.Read())
            {

                var messages = MessageResource.Read(to: new PhoneNumber(rdr["Mobile"].ToString()));
                foreach (var message in messages)
                {
                    form1.InnerHtml += "<div class='well well-sm col-sm-offset-3 col-sm-6'>" + message.Body + "</div><br/>";
                }
            }

            //close Data Reader
            rdr.Close();

            //close Connection
            conn.Close();



        }
    }
}