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
                AddressDropDownList.Items.Insert(1, new ListItem("Send To All Addresses"));
            }


            tbMessage.Attributes.Add("maxlength", "1500");

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
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
                    var to = new PhoneNumber(dr["Mobile"].ToString());
                    var message = MessageResource.Create(
                        to,
                        from: new PhoneNumber("17653454144"),
                        body: sbody);



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

            }



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


            lblResponse.Text = "Your message has been sent!";
            Response.Redirect("MassText.aspx");
        }


    }
}
