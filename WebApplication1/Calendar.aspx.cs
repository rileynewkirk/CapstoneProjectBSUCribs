using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.App_Code;

namespace WebApplication1
{
    public partial class Calendar : System.Web.UI.Page
    {
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
        DateTime selectedDate;

        protected void Page_Load(object sender, EventArgs e)
        {
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
            }
            if (Session["user"] == null)
            {
                Response.Write("<script language=javascript> var agree; agree=confirm('You have to log in first'); window.location='Login.aspx';</script>");
            }
            if (Session["PhoneNumber"] == null)
            {
                Response.Write("<script language=javascript> var agree; agree=confirm('You have to log in first'); window.location='Login.aspx';</script>");
            }

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
            Label showingID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblShowingID");
            string qry = "DELETE FROM calendar WHERE Showing_ID = " + showingID.Text;
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            DataTable dt = ViewState["dt"] as DataTable;
            dt.Rows[e.RowIndex].Delete();
            ViewState["dt"] = dt;
            BindGrid();
        }

        public void deleteRow_OnClick(string ShowingID)
        {
            string qry = "DELETE FROM calendar WHERE Showing_ID = " + ShowingID;
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Calendar.aspx");
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
            //DataBind();
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Cell.HorizontalAlign = HorizontalAlign.Left;
            e.Cell.VerticalAlign= VerticalAlign.Top;
            e.Cell.Font.Size = FontUnit.Point(12);
        }
    }
}