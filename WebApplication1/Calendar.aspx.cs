using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    public partial class Calendar : System.Web.UI.Page
    {
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
        DateTime selectedDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["user"] = "ds";
            Session["userType"] = 2;
            Session["PhoneNumber"] = "3179975301";

            if (!IsPostBack)
            {
                Calendar1.SelectedDate = selectedDate;
                getShowingsFromDate(selectedDate);
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
            getShowingsForMobile();
         
        }
          
        private void getShowingsForMobile()
        {

            String csname1 = "PopupScript";
            String csname2 = "ButtonClickScript";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            String csstart = "var d = new Date();var output = d.getFullYear() + '-' + (d.getMonth()+1);$(document).ready(function() {$(\".responsive-calendar\").responsiveCalendar({ time: output,events:{ ";
            //\"2018-04-30\": { \"number\": 5 },\"2018-04-26\": { \"number\": 1 },\"2018-05-03\": { \"number\": 1 },\"2018-06-12\": { }
            string qry = "SELECT DATE_FORMAT(Showing_DateTime,'%Y-%m-%d') FROM calendar";
            int showingCount = 0;
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            ArrayList dates = new ArrayList();
            conn.Open();
            string csevents = "";
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    dates.Add(rdr["DATE_FORMAT(Showing_DateTime,'%Y-%m-%d')"].ToString());
                }
                rdr.Close();
                conn.Close();
            }

            Dictionary<string, int> distinctItems = new Dictionary<string, int>();

            foreach (string item in dates)
            {
                if (!distinctItems.ContainsKey(item))
                {
                    distinctItems.Add(item, 0);
                }
                distinctItems[item] += 1;
            }
            foreach (KeyValuePair<string, int> distinctItem in distinctItems)
            {
                //System.Diagnostics.Debug.WriteLine("\"{0}\" occurs {1} time(s).", distinctItem.Key, distinctItem.Value);
                csevents += "\"" + distinctItem.Key + "\":{\"number\":" + distinctItem.Value + "},";
            }

            String csend = "}, onDayClick: function(events) { alert('Day was clicked') },});});";
            String csall = csstart + csevents + csend;
            cs.RegisterStartupScript(cstype, csname1, csall, true);

        }

        protected void goToCreateShowing(object sender, EventArgs e)
        {
            Response.Redirect("CreateShowing.aspx");
        }

        private void getShowingsFromDate(DateTime date)
        {
            List<Showing> showings = new List<Showing>();
            string qry = @"SELECT Showing_ID, date_format(Showing_DateTime, '%Y-%m-%d %h:%i'), Agent_ID, Client_Name, Address FROM calendar WHERE Showing_DateTime like '" + date.ToString("yyyy-MM-dd") + "%'";

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            conn.Open();
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    var showingID = rdr["Showing_ID"].ToString();
                    var leasingAgent = rdr["Agent_ID"].ToString();
                    var client = rdr["Client_Name"].ToString();
                    var address = rdr["Address"].ToString();
                    var showingDate = rdr["date_format(Showing_DateTime, '%Y-%m-%d %h:%i')"].ToString();
                    DateTime shdate = Convert.ToDateTime(showingDate);
                    string dt = shdate.ToString("g");
                    showingDate = dt;
                    
                    Showing showing = new Showing(showingID, leasingAgent, client, address, showingDate);

                    showings.Add(showing);

                }
                rdr.Close();
                conn.Close();
                postIntoList(showings);
            }
        }

        private void postIntoList(List<Showing> showings)
        {
            #region TEST
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Showing_ID"), new DataColumn("Leasing_Agent"), new DataColumn("Client"), new DataColumn("Address"), new DataColumn("ShowingDate") });
            foreach (Showing s in showings)
            {
                dt.Rows.Add(s.Showing_ID, s.LeasingAgent, s.Client, s.Address, s.ShowingDate);
            }
            ViewState["dt"] = dt;
            BindGrid();


            #endregion


            /*showingList.InnerHtml = "";
            for (int i = 0; i <= showings.Count - 1; i++)
            {
                string start = "<tr id=\"" + showings[i].getID() + "\">";
                string leasingAgent = "<td> " + showings[i].getLeasingAgent() + "</td>";
                // string showingID = "<td> " + showings[i].getID() + "</td>";
                string client = "<td> " + showings[i].getClient() + "</td>";
                string address = "<td>" + showings[i].getAddress() + "</td>";
                string showingDate = "<td>" + showings[i].getShowingDate() + "</td>";
                string btnEdit = "<td style=\"width:5%;\"><a href=\"EditShowing.aspx?showingID=" + showings[i].getID() + "\" class=\"btn btn-default\">Edit</a></td>";
                string btnDelete = "<td style=\"width:5%;\"><a href=\"DeleteShowing.aspx?showingID=" + showings[i].getID() + "\" class=\"btn btn-danger\">Delete</a></td>";
                string end = "</tr>";

                string showing = start + leasingAgent + client + address + showingDate + btnEdit + btnDelete + end;

                showingList.InnerHtml = showingList.InnerHtml + showing;
            }*/
        }


        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            selectedDate = Calendar1.SelectedDate;
            //displayDateLabel.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            getShowingsFromDate(Calendar1.SelectedDate.Date);
        }


        protected void BindGrid()
        {
            GridView1.DataSource = ViewState["dt"] as DataTable;
            GridView1.DataBind();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (Button button in e.Row.Cells[5].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; }";
                    }

                    if (button.CommandName == "Edit")
                    {
                        button.Attributes["onclick"] = "EditRow_OnClick()";
                    }
                }
            }
        }

        protected void EditRow_OnClick(object sender, GridViewRowEventArgs e)
        {
            string url = "EditShowing.aspx?ShowingID=" + e.Row.Cells[0].Text + "/";
            Response.Redirect(url);
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DateTime t = new DateTime();
            string house = "";
            Label showingID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblShowingID");
            Label address = (Label)GridView1.Rows[e.RowIndex].FindControl("lblAddress");
            Label time = (Label)GridView1.Rows[e.RowIndex].FindControl("lblShowingDate");
            t = Convert.ToDateTime(time.Text);
            house = address.Text;
            house += "%";

            string sbody = "C&M Property Management: A house showing that was scheduled for your residence on " + t.ToString("g") + " has now been cancelled.";

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();
            string checkShowing = "select * from table4 where PropertyName like @Address";
            MySqlCommand comd = new MySqlCommand(checkShowing, conn);
            comd.Parameters.AddWithValue("Address", house);
            MySqlDataReader dr = comd.ExecuteReader();

            while (dr.Read())
            {
                house = dr["PropertyName"].ToString();
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

            string qry4 = "DELETE FROM calendar WHERE Showing_ID = " + showingID.Text;
            MySqlConnection conn4 = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            MySqlCommand cmd4 = new MySqlCommand(qry4, conn4);
            conn4.Open();
            cmd4.ExecuteNonQuery();
            conn4.Close();

            DataTable dt = ViewState["dt"] as DataTable;
            dt.Rows[e.RowIndex].Delete();
            ViewState["dt"] = dt;
            BindGrid();
        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lblShowingID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblShowingID");
            TextBox txtEditClient = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditClient");
            TextBox txtEditAddress = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditAddress");
            TextBox txtEditLeasingAgent = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditLeasingAgent");
            TextBox txtEditShowingDateTime = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditShowingDate");

            conn.Open();

            string cmdstr = "update calendar set client=@client,address=@address,leasingAgent=@leasingAgent, showingDate=@showingDate where showingID=@showingID";

            MySqlCommand cmd = new MySqlCommand(cmdstr, conn);

            cmd.Parameters.AddWithValue("@showingID", lblShowingID);
            cmd.Parameters.AddWithValue("@client", txtEditClient.Text);
            cmd.Parameters.AddWithValue("@address", txtEditAddress.Text);
            cmd.Parameters.AddWithValue("@leasingAgent", txtEditLeasingAgent.Text);
            cmd.Parameters.AddWithValue("@showingDate", txtEditShowingDateTime.Text);
            cmd.ExecuteNonQuery();

            conn.Close();

            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            getShowingsFromDate(Calendar1.SelectedDate);
            GridView1.EditIndex = -1;
            BindGrid();
        }
        
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Label lblShowingID = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblShowingID");
            string showingID = GridView1.Rows[e.NewEditIndex].Cells[0].Text;
            string url = "EditShowing.aspx?ShowingID=" + lblShowingID.Text;
            Response.Redirect(url);
            getShowingsFromDate(Calendar1.SelectedDate);
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        public int checkMonthForShowings(DateTime date)
        {
            string qry = "SELECT Agent_ID FROM calendar WHERE Showing_DateTime  like '%" + date.ToString("yyyy-MM-dd") + "%'";
            int showingCount = 0;
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            conn.Open();
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    showingCount++;
                }
                rdr.Close();
                conn.Close();
            }

            return showingCount;
        }


        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime currentRenderDate = e.Day.Date;
            int numberOfShowings = checkMonthForShowings(currentRenderDate);

            e.Cell.HorizontalAlign = HorizontalAlign.Left;
            e.Cell.VerticalAlign = VerticalAlign.Top;
            e.Cell.BorderWidth = 1;
            e.Cell.Controls.Add(new LiteralControl("<br /><center>"));
            e.Cell.Attributes.Add("OnClick", e.SelectUrl);

            Label aLabel = new Label();
            aLabel.Text = numberOfShowings.ToString();
            aLabel.Font.Size = 20;
            aLabel.ForeColor = System.Drawing.Color.DarkGray;
            e.Cell.Controls.Add(aLabel);

            if (numberOfShowings < 1)
            {
                aLabel.ForeColor = System.Drawing.Color.White;
            }

        }

        protected void tbmobileDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                selectedDate = Convert.ToDateTime(tbmobileDate.Text);
                getShowingsFromDate(Convert.ToDateTime(tbmobileDate.Text).Date);
            }
            catch
            {

            }
        }
    }
}