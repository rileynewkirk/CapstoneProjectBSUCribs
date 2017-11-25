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

        private void getShowingsFromDate()
        {
            List<Showing> showings = new List<Showing>();
            string qry = "SELECT * FROM  WHERE Showing_DateTime=" + "'2017-11-04'";
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                //string showingID = rdr["Showing_ID"].ToString();
                string leasingAgent = rdr["Agent_ID"].ToString();
                string showingDate = rdr["Showing_DateTime"].ToString();
                string client = rdr["Client_Name"].ToString();
                string address = rdr["Address"].ToString();
                string dateCreated = rdr["Created_DateTime"].ToString();
                System.Diagnostics.Debug.WriteLine("00000 " + leasingAgent + " " + address + " 0000000000");
                //Showing showing = new Showing(showingID, leasingAgent, showingDate, client, address, dateCreated);
                //showings.Add(showing);
            }
            rdr.Close();
            conn.Close();
           // postIntoList(showings);
        }

        private void findShowingByID()
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();
            string checkShowing = "select Agent_Name from  calendar WHERE showing_DateTime= '2017-11-17'";
            MySqlCommand comd = new MySqlCommand(checkShowing, conn);
            MySqlDataReader dr = comd.ExecuteReader();
            while (dr.Read())
            {
                string name = dr["Agent_Name"].ToString();
                System.Diagnostics.Debug.WriteLine("00000000000000000  "+name+"  00000000000");
            }
            dr.Close();
            conn.Close();
        }

        private void postIntoList(List<Showing> showings)
        {
            for (int i = 0; i <= showings.Count - 1; i++)
            {
                string start = "<tr id=\"" + showings[i].getID() + "\">";
                //string img = "<td style=\"text-align: left\"><img src=\"" + showings[i].getProfileImage() + "\" class=\"img-responsive profile-thumbnail\" alt=\"\" /></td>";
                string leasingAgent = "<td> " + showings[i].getLeasingAgent() + "</td>";
                string showingDate = "<td> " + showings[i].getShowingDate() + "</td>"; //"<td><a href=\"EditUser.aspx" + showings[i].getShowingDate() + "\" class=\"profile-text\">" + users[i].getFirstname() + " " + users[i].getLastname() + "</a></td>";
                //string label = getLabel(showings[i].getUsertype());
                string client = "<td> " + showings[i].getClient() + "</td>";
                string address = "<td>" + showings[i].getAddress()+ "</td>";
                string dateCreated = "<td> " + showings[i].getDateCreated() + "</td>";
                //string btn = "<td style=\"width:20%;\"><a href=\"EditUser.aspx?username=" + showings[i].getUsername() + "\" class=\"btn btn-default\">Edit User</a></td>";
                string end = "</tr>";

                string showing = start + leasingAgent + showingDate + client + address + dateCreated + end;

                showingList.InnerHtml = showingList.InnerHtml + showing;
            }
        }

        protected void testFunction(object sender, EventArgs e)
        {
            findShowingByID();
        }
    }
}