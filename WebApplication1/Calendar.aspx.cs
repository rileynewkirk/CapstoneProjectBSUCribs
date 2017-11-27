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
            string qry = "SELECT Address, Client_Name, Agent_ID FROM calendar WHERE Showing_DateTime  = '" + date.ToString("yyyy-MM-dd") +"'";
            //string qry = "SELECT Agent_ID, Showing_DateTime, Client_Name, Address, Created_DateTime FROM calendar WHERE Showing_DateTime = '" + date.ToString("yyyy-MM-dd")+ "'";
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            conn.Open();
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {                
                while (rdr.Read())
                {
                    //var showingID = rdr["Showing_ID"].ToString();
                    var leasingAgent = rdr["Agent_ID"].ToString();
                    //var showingDate = rdr["Showing_DateTime"].ToString();
                    var client = rdr["Client_Name"].ToString();
                    var address = rdr["Address"].ToString();
                    var showingDate = date.ToString("yyyy-MM-dd");
                    //var dateCreated = rdr["Created_DateTime"].ToString();

                    //Response.Write(address+" " + client+" "+leasingAgent+"\n");

                    Showing showing = new Showing(leasingAgent, client, address, showingDate);
                    showings.Add(showing);
                }
                rdr.Close();
                conn.Close();
                postIntoList(showings);
            }
        }

        private void findShowingByID()
        {

        }

        private void postIntoList(List<Showing> showings)
        {
            for (int i = 0; i <= showings.Count - 1; i++)
            {
                string start = "<tr id=\"" + showings[i].getID() + "\">";
                //string img = "<td style=\"text-align: left\"><img src=\"" + showings[i].getProfileImage() + "\" class=\"img-responsive profile-thumbnail\" alt=\"\" /></td>";
                string leasingAgent = "<td> " + showings[i].getLeasingAgent() + "</td>";
                //string showingDate = "<td> " + showings[i].getShowingDate() + "</td>"; //"<td><a href=\"EditUser.aspx" + showings[i].getShowingDate() + "\" class=\"profile-text\">" + users[i].getFirstname() + " " + users[i].getLastname() + "</a></td>";
                //string label = getLabel(showings[i].getUsertype());
                string client = "<td> " + showings[i].getClient() + "</td>";
                string address = "<td>" + showings[i].getAddress()+ "</td>";
                string showingDate = "<td>" + showings[i].getShowingDate() + "</td>";
                //string dateCreated = "<td> " + showings[i].getDateCreated() + "</td>";
                string btnEdit = "<td style=\"width:10%;\"><a href=\"EditShowing.aspx?showingID=" + showings[i].getID() + "\" class=\"btn btn-default\">Edit</a></td>";
                string btnDelete = "<td style=\"width:10%;\"><a href=\"EditShowing.aspx?showingID=" + showings[i].getID() + "\" class=\"btn btn-default\">Delete</a></td>";
                string end = "</tr>";

                string showing = start + leasingAgent + client + address + showingDate + btnEdit + btnDelete + end;

                showingList.InnerHtml = showingList.InnerHtml + showing;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            getShowingsFromDate(Calendar1.SelectedDate.Date);
        }
    }
}