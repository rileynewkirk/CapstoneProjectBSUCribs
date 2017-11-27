using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class MassText : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string qry = "select * from (select * from messages order by `Address`, id desc, messageBody) x group by `Address`";
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(qry, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string address = rdr["Address"].ToString();
                    string contentb = rdr["messageBody"].ToString();
                    string start = "<tr>";
                    string phnum = "<td>" + address + "</td>";
                    string content = "<td>" + contentb + "</td>";
                    string btn = "<td style=\"width:20%;\"><a href=\"EditMessage.aspx?Address=" + address + "\" class=\"btn btn-default\">View</a></td>";
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
                AddressDropDownList.Items.Insert(1, new ListItem("Send To All Address"));
            }




        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            string sbody = tbMessage.Text;
            string address = AddressDropDownList.SelectedValue;
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();
            string checkShowing = "select * from table4 where PropertyName = @Address";
            MySqlCommand comd = new MySqlCommand(checkShowing, conn);
            comd.Parameters.AddWithValue("Address", address);
            MySqlDataReader dr = comd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                /*
                const string accountSid = "AC81311ed7d5aa3a5b8debc7306abbb0ee";
                const string authToken = "17d80aa7c2ad0c26a45b8607fba63dda";
                TwilioClient.Init(accountSid, authToken);
                var to = new PhoneNumber(dr["Mobile"].ToString());
                var message = MessageResource.Create(
                    to,
                    from: new PhoneNumber("17653454144"),
                    body: sbody);

    */

            }
            dr.Close();
            conn.Close();

            MySqlConnection conni = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conni.Open();
            string insertString = "insert into messages (Address, MessageBody) " +
                "values (@Address, @MessageBody) ";
            MySqlCommand comdi = new MySqlCommand(insertString, conni);
            comdi.Parameters.AddWithValue("@Address", address);
            comdi.Parameters.AddWithValue("@MessageBody", sbody);
            comdi.ExecuteNonQuery();
            conni.Close();
           

            lblResponse.Text = "Your message has been sent!";
            Response.Redirect("MassText.aspx");
        }


    }
}




//const string accountsid = "acfea5d37bf26506dc28eec82b31753b4b";
//const string authtoken = "064e3b6440e1172673fdc210a3f3b1cd";
//TwilioClient.Init(accountsid, authtoken);

//var to = new PhoneNumber(phoneNumber);
//var message = MessageResource.Create(
//    to,
//    from: new PhoneNumber("(317)-961-7486"),
//    body: sbody);
//Console.Write(message.Sid);