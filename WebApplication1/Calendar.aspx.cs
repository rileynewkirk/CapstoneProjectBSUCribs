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
<<<<<<< HEAD

            string qry = "SELECT Showing_ID, Address, Client_Name, Agent_ID FROM calendar WHERE Showing_DateTime  like '%" + date.ToString("yyyy-MM-dd") +"%'";
=======
            string qry = "SELECT Showing_ID, Agent_ID,Client_Name,Address FROM calendar WHERE Showing_DateTime  = '" + date.ToString("yyyy-MM-dd") + "'";

            //string qry = "SELECT Showing_ID, Address, Client_Name, Agent_ID FROM calendar WHERE Showing_DateTime  = '" + date.ToString("yyyy-MM-dd") +"'";
>>>>>>> a902aa8775db4158cc7cb1b482b6c588111a4d95

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
<<<<<<< HEAD

                    var showingDate = date.ToString(); //.ToString("yyyy-MM-dd");
=======

                    var showingDate = date.ToString("yyyy-MM-dd");
                    var dateCreated = date.ToString("yyyy-MM-dd"); //date from calendar, chagned for testing 
                    //var dateCreated = rdr["Created_DateTime"].ToString();

                    Showing showing = new Showing(showingID,leasingAgent,client,address,showingDate, dateCreated);

                    //var showingDate = date.ToString(); //.ToString("yyyy-MM-dd");
>>>>>>> a902aa8775db4158cc7cb1b482b6c588111a4d95
            

<<<<<<< HEAD
                    Showing showing = new Showing(showingID, leasingAgent, client, address, showingDate);
=======
                   // Showing showing = new Showing(showingID, leasingAgent, client, address, showingDate);
>>>>>>> a902aa8775db4158cc7cb1b482b6c588111a4d95

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
<<<<<<< HEAD
                string btnEdit = "<td style=\"width:5%;\"><a href=\"EditShowing.aspx?showingID=" + showings[i].getID() + "\" class=\"btn btn-default\">Edit</a></td>";
                string btnDelete = "<td style=\"width:5%;\"><a href=\"DeleteShowing.aspx?showingID=" + showings[i].getID() + "\" class=\"btn btn-danger\">Delete</a></td>";
=======
                //string dateCreated = "<td> " + showings[i].getDateCreated() + "</td>";
                //string btnEdit = "<td style=\"width:10%;\"><a href=\"EditShowing.aspx?showingID=" + showings[i].getID() + "\" class=\"btn btn-default\">Edit</a></td>";
                string btnEdit = "<td style=\"width:10%;\"><a href=\"EditShowing.aspx?showingID=" + showings[i].getID() + "&showingDate="+Calendar1.SelectedDate.ToString("yyyy-MM-dd")+"\" class=\"btn btn-default\">Edit</a></td>";
                string btnDelete = "<td style=\"width:10%;\"><a href=\"EditShowing.aspx?showingID=" + showings[i].getID() + "\" class=\"btn btn-default\">Delete</a></td>";

                //string btnEdit = "<td style=\"width:5%;\"><a href=\"EditShowing.aspx?showingID=" + showings[i].getID() + "\" class=\"btn btn-default\">Edit</a></td>";
                //string btnDelete = "<td style=\"width:5%;\"><a href=\"DeleteShowing.aspx?showingID=" + showings[i].getID() + "\" class=\"btn btn-danger\">Delete</a></td>";
                //string btnDelete = "<asp:Button ID = \"btnRemove\" CssClass = \"btn btn-danger\" Text = \"Delete\" OnClientClick = \"return confirm('Are you sure you want to delete?')\"  OnClick = \"deleteRow_OnClick()\" /></ div >";               
                //string btnDelete = "<td style=\"width:5%;\"><input type=\"button\" value=\"Delete\" class=\"btn btn-default\" onclick=\"deleteRow_OnClick(showingDate, address)\"></td>";
                //string btnDelete = "<td>< asp:LinkButton ID = \"lnkDelete\" Text = \"Delete\" runat = \"server\" OnClientClick = \"return confirm('Do you want to delete this Customer?');\" OnClick = \"DeleteCustomer\" /></ td > ";
                //string btnDelete = "<td style=\"width:5%;\"><input type=\"button\" value=\"Delete\" class=\"btn btn-default\" onclick=\"deleteRow_OnClick(" + showings[i].getID() +")\"></td>";

>>>>>>> a902aa8775db4158cc7cb1b482b6c588111a4d95
                string end = "</tr>";

                string showing = start  + leasingAgent + client + address + showingDate + btnEdit + btnDelete + end;

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
        

<<<<<<< HEAD
=======

>>>>>>> a902aa8775db4158cc7cb1b482b6c588111a4d95

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            displayDateLabel.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            getShowingsFromDate(Calendar1.SelectedDate.Date);

        }
    }   
}