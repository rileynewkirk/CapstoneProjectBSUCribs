using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Collections;

namespace WebApplication1
{
    public partial class EditHousingList : System.Web.UI.Page
    {
        public static int i;
        public static int k;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("<script language=javascript> var agree; agree=confirm('You have to log in first'); window.location='Login.aspx';</script>");
            }
            else if (Convert.ToInt32(Session["usertype"]) != 2)
            {
                Response.Write("<script language=javascript> var agree; agree=confirm('You are not allowed access to this page'); window.location='Login.aspx';</script>");
            }
            if (Session["PhoneNumber"] == null)
            {
                Response.Write("<script language=javascript> var agree; agree=confirm('You have to log in first'); window.location='Login.aspx';</script>");
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
            }

        }

        protected void Upload(object sender, EventArgs e)
        {
            MySqlConnection conn1 = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn1.Open();

            string deleteString = "DELETE FROM `table4`";
            MySqlCommand comd = new MySqlCommand(deleteString, conn1);

            comd.ExecuteNonQuery();
            conn1.Close();

            string csvPath = Server.MapPath("~/csvTemp/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(csvPath);
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            string text = File.ReadAllText(csvPath);
            text = text.Replace("\"", "");
            File.WriteAllText(csvPath, text);

            using (conn)
            {
                conn.Open();
                MySqlBulkLoader bcp1 = new MySqlBulkLoader(conn);
                bcp1.TableName = "table4";
                bcp1.FieldTerminator = ",";

                bcp1.LineTerminator = "\r\n";
                bcp1.FileName = csvPath;
                bcp1.NumberOfLinesToSkip = 0;
                bcp1.Load();

                //Once data write into db then delete file..
                try
                {
                    File.Delete(Server.MapPath(csvPath));
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }
            }

            ArrayList listofhouses = new ArrayList();
            ArrayList listofmessages = new ArrayList();

            conn.Open();
            string gethouses = "select distinct PropertyName from table4";
            MySqlCommand comdget = new MySqlCommand(gethouses, conn);
            MySqlDataReader dr = comdget.ExecuteReader();
            while (dr.Read())
            {
                listofhouses.Add(dr["PropertyName"].ToString());
            }
            dr.Close();
            conn.Close();

            string getmessages = "select Address from messages";
            MySqlCommand comdmes = new MySqlCommand(getmessages, conn);
            MySqlDataReader dr2 = comdmes.ExecuteReader();
            while (dr2.Read())
            {
                listofmessages.Add(dr2["Address"].ToString());
            }
            dr2.Close();
            conn.Close();

            for(int i = 0; i < listofmessages.Count; i++)
            {
                if (!listofhouses.Contains(listofmessages[i]))
                {
                    string deleteString2 = "DELETE FROM messages where Address = '"+ listofmessages[i] + "';";
                    MySqlCommand comd3 = new MySqlCommand(deleteString2, conn);
                    comd3.ExecuteNonQuery();
                    conn.Close();

                }
            }

        }

            protected void AddressDropDownList_TextChanged(object sender, EventArgs e)
        {
            resetrows();
            string address = AddressDropDownList.Text;
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();
            string checkShowing = "select FirstName, LastName, Mobile from table4 where PropertyName = '" + address + "';";
            MySqlCommand comd = new MySqlCommand(checkShowing, conn);
            MySqlDataReader dr = comd.ExecuteReader();
            i = 0;

            while (dr.Read())
            {
                if (i < 10)
                {
                    i++;
                }           
                TableRow rw = (TableRow)FindControl("row" + i);
                rw.Visible = true;
                TextBox tbfn = (TextBox)FindControl("fn" + i);
                tbfn.Attributes.Add("placeholder", dr["FirstName"].ToString());
                TextBox tbln = (TextBox)FindControl("ln" + i);
                tbln.Attributes.Add("placeholder", dr["LastName"].ToString());
                TextBox tbm = (TextBox)FindControl("m" + i);
                tbm.Attributes.Add("placeholder", dr["Mobile"].ToString());
            }
            dr.Close();
            conn.Close();
        }

        private void resetrows()
        {
            for (int j =1; j <= 10; j++)
            {
                TableRow rw = (TableRow)FindControl("row" + j);
                rw.Visible = false;
                Button del = (Button)FindControl("btn" + j);
                del.Enabled = true;
            }

        }

        private void resetrows2()
        {
            for (int j = 1; j <= 10; j++)
            {
                TableRow rw = (TableRow)FindControl("row1" + j);
                rw.Visible = false;
            }

        }

        protected void btnevent_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int deletebtn = Convert.ToInt32(button.CommandArgument);
            // get mobile textbox where deletebtn equals mobile + i
            TextBox tbm = (TextBox)FindControl("m" + deletebtn);
            TextBox tbfn = (TextBox)FindControl("fn" + deletebtn);
            TextBox tbln = (TextBox)FindControl("ln" + deletebtn);
            string m = tbm.Attributes["placeholder"]; 
            string fn = tbfn.Attributes["placeholder"];
            string ln = tbln.Attributes["placeholder"];
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();
            string deleteString = "delete from table4 where FirstName = '"+fn+"' and LastName = '"+ln+"' and Mobile = "+m;
            MySqlCommand comd = new MySqlCommand(deleteString, conn);
            comd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("EditHousingList.aspx");
        }

        protected void DeleteListing_Click(object sender, EventArgs e)
        {
            string deladdress = AddressDropDownList.Text;
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();
            string deleteString = "delete from table4 where PropertyName = '" + deladdress + "'";
            MySqlCommand comd = new MySqlCommand(deleteString, conn);
            comd.ExecuteNonQuery();

            string deletefrommessages = "delete from messages where Address ='" + deladdress + "'";
            MySqlCommand comdDel = new MySqlCommand(deletefrommessages, conn);
            comdDel.ExecuteNonQuery();

            conn.Close();
            Response.Redirect("EditHousingList.aspx");


        }

        protected void UpdateListing_Click(object sender, EventArgs e)
        {
            string deladdress = AddressDropDownList.Text;
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();
            string deleteString = "delete from table4 where PropertyName = '" + deladdress + "'";
            MySqlCommand comd = new MySqlCommand(deleteString, conn);
            comd.ExecuteNonQuery();
            conn.Close();

            for (int j = 1; j <= i; j++)
            {
                TextBox fn = (TextBox)FindControl("fn" + j);
                TextBox ln = (TextBox)FindControl("ln" + j);
                TextBox m = (TextBox)FindControl("m" + j);

                string firstname;
                string lastname;
                string mobile;

                if(fn.Text == "")
                {
                    firstname = fn.Attributes["placeholder"];
                }
                else
                {
                    firstname = fn.Text;
                }
                if (ln.Text == "")
                {
                    lastname = ln.Attributes["placeholder"];
                }
                else
                {
                    lastname = ln.Text;
                }
                if (m.Text == "")
                {
                    mobile = m.Attributes["placeholder"];
                }
                else
                {
                    mobile = m.Text;
                }

                if(firstname == "First Name:")
                {
                    break;
                }
                if (lastname == "Last Name:")
                {
                    break;
                }
                if (mobile == "Mobile:")
                {
                    break;
                }

                MySqlConnection conni = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                conni.Open();
                string insertString = "INSERT INTO `table4`(`PropertyName`, `FirstName`, `LastName`, `Mobile`) VALUES ('"+deladdress+"', '"+firstname+"', '"+lastname+"', '"+mobile+"' );";
                MySqlCommand comdi = new MySqlCommand(insertString, conni);
                comdi.ExecuteNonQuery();
                conni.Close();
            }Response.Redirect("EditHousingList.aspx");
        }

        protected void tbNumofRes_TextChanged(object sender, EventArgs e)
        {
            resetrows2();
            k = 0;
            int numOfRes = 0;

            if (int.TryParse(tbNumofRes.Text, out numOfRes))
            {
                numOfRes = Int32.Parse(tbNumofRes.Text);
            }

            tbNewAddress.Visible = true;
            if (numOfRes <= 0)
            {
                tbNewAddress.Visible = false;
            }
            for (int j = 0; j < numOfRes; j++)
            {
                if (k < 10)
                {
                    k++;
                }
                TableRow rw = (TableRow)FindControl("row1" + k);
                rw.Visible = true;
            }
        }

        protected void btnNewListing_Click(object sender, EventArgs e)
        {
            string address = tbNewAddress.Text;
            for (int j = 1; j <= k; j++)
            {
                TextBox fn = (TextBox)FindControl("fn1" + j);
                TextBox ln = (TextBox)FindControl("ln1" + j);
                TextBox m = (TextBox)FindControl("m1" + j);

                string firstname = fn.Text;
                string lastname = ln.Text;
                string mobile = m.Text;

                try { 
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
                conn.Open();
                string insertstring = "INSERT INTO `table4`(`PropertyName`, `FirstName`, `LastName`, `Mobile`) VALUES ('" +address+ "','" + firstname + "','" + lastname + "'," + mobile + ");";
                MySqlCommand comd = new MySqlCommand(insertstring, conn);
                comd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("EditHousingList.aspx");
                }
                catch (Exception)
                {
                    Response.Write("<script language=javascript> var agree; agree=confirm('You must fill out all of the forms before hitting submit');</script>");
                }

            }
        }

        protected void AddRow(object sender, EventArgs e)
        {
            if (i < 10)
            {
                i++;
            }

            TableRow rw = (TableRow)FindControl("row" + i);
            rw.Visible = true;
            TextBox tbfn = (TextBox)FindControl("fn" + i);
            tbfn.Attributes.Add("placeholder", "First Name:");
            TextBox tbln = (TextBox)FindControl("ln" + i);
            tbln.Attributes.Add("placeholder","Last Name:");
            TextBox tbm = (TextBox)FindControl("m" + i);
            tbm.Attributes.Add("placeholder", "Mobile:");
            Button del = (Button)FindControl("btn" + i);
            del.Enabled = false;

        }

    }
}


//INSERT INTO `table4`(`PropertyName`, `FirstName`, `LastName`, `Mobile`) VALUES ("test house (the real 515 W Riverside)","Anna","Shaffer",8126062413)