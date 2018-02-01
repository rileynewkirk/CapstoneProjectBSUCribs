using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.App_Code;

namespace WebApplication1
{
    public partial class Calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void goToCreateShowing(object sender, EventArgs e)
        {
            Response.Redirect("CreateShowing.aspx");
        }

        private void getShowingsFromDate(DateTime date)
        {
            List<Showing> showings = new List<Showing>();

            string qry = "SELECT Showing_ID, Address, Client_Name, Agent_ID FROM calendar WHERE Showing_DateTime  like '%" + date.ToString("yyyy-MM-dd") + "%'";

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

                    var showingDate = date.ToString(); //.ToString("yyyy-MM-dd");


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
            showingList.InnerHtml = "";
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
            }
        }


        protected void deleteRow_OnClick(object sender, EventArgs e)
        {
            string showing_ID = Request.QueryString["showingID"];
            string qry = "DELETE FROM calendar WHERE Showing_ID = " + showing_ID;
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

            }
            rdr.Close();
            conn.Close();
            Response.Redirect("Calendar.aspx");
        }



        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            displayDateLabel.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            getShowingsFromDate(Calendar1.SelectedDate.Date);

        }
    }
}