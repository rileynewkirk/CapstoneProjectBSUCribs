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
<<<<<<< HEAD
            string qry = "SELECT * FROM  WHERE Showing_DateTime=" + "'2017-11-04'";
=======
            string qry = "SELECT Address, Client_Name, Agent_ID FROM calendar WHERE Showing_DateTime  = '" + date.ToString("yyyy-MM-dd") +"'";
            //string qry = "SELECT Agent_ID, Showing_DateTime, Client_Name, Address, Created_DateTime FROM calendar WHERE Showing_DateTime = '" + date.ToString("yyyy-MM-dd")+ "'";
>>>>>>> 37d2d38fe8eb8962a78f1df3649abfbefab6fca0
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

<<<<<<< HEAD
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
=======
                    //Response.Write(address+" " + client+" "+leasingAgent+"\n");

                    Showing showing = new Showing(leasingAgent, client, address, showingDate);
                    showings.Add(showing);
                }
                rdr.Close();
                conn.Close();
                postIntoList(showings);
            }
>>>>>>> 37d2d38fe8eb8962a78f1df3649abfbefab6fca0
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

<<<<<<< HEAD
        protected void testFunction(object sender, EventArgs e)
        {
            findShowingByID();
=======
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            getShowingsFromDate(Calendar1.SelectedDate.Date);
>>>>>>> 37d2d38fe8eb8962a78f1df3649abfbefab6fca0
        }
    }
}