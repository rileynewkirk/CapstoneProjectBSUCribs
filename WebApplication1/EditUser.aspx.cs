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
    public partial class EditUser : System.Web.UI.Page
    {
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

            string name = Request.QueryString["username"];
            getUserInfo(name);

        }

        private void getUserInfo(string name)
        {
            string qry = "Select * from Users WHERE UserName=\"" + name + "\"";
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                string firstname = rdr["firstname"].ToString();
                string lastname = rdr["lastname"].ToString();
                string img = rdr["profileImage"].ToString();
                string phone = rdr["PhoneNumber"].ToString();
                string email = rdr["Email"].ToString();
                string password = rdr["Password"].ToString();
                int usertype = Convert.ToInt32(rdr["UserType"]);

                if(usertype == 2)
                {
                    ddlTypes.SelectedIndex = 1;
                }


                tbPhoneNumber.Attributes.Add("placeholder", phone);
                tbEmail.Attributes.Add("placeholder", email);
                tbPassword.Attributes.Add("name", password);
                tbPassword.Attributes.Add("placeholder", "Enter a new password if needed:");

                nameTitle.InnerHtml = firstname + " " + lastname;
                profilePic.Attributes.Add("src", img);
            }

            rdr.Close();
            conn.Close();
        }

        protected void updateInfo(object sender, EventArgs e)
        {
            string type = ddlTypes.SelectedValue;
            int newType = 1;

            string password;
            string email;
            string phonenumber;

            if (type == "Agent")
            {
                newType = 1;
            }
            else if (type == "Admin")
            {
                newType = 2;
            }

            if(tbPhoneNumber.Text == "")
            {
                phonenumber = tbPhoneNumber.Attributes["placeholder"];
            }
            else
            {
                phonenumber = tbPhoneNumber.Text;
            }
            if (tbEmail.Text == "")
            {
                email = tbEmail.Attributes["placeholder"];
            }
            else
            {
                email = tbEmail.Text;
            }
            if (tbPassword.Text == "")
            {
                password = tbPassword.Attributes["name"];
            }
            else
            {
                password = EncryptPassword.encryptString(tbPassword.Text);
            }




            string name = Request.QueryString["username"];
            string qry = "UPDATE users SET UserType=\"" + newType + "\", Password = '"+ password + "', Email ='"+email+
                "', PhoneNumber = '"+ phonenumber + "' WHERE UserName=\"" + name + "\"";

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            conn.Close();
            rdr.Close();

            Response.Redirect("Registration.aspx");
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();

            String Username = Request.QueryString["username"];

            string deleteString = "delete from users where Username = @Username";
            MySqlCommand comd = new MySqlCommand(deleteString, conn);

            comd.Parameters.AddWithValue("@UserName", Username);

            comd.ExecuteNonQuery();
            conn.Close();

            Response.Write("<script language=javascript>window.location='Registration.aspx';</script>");
        }

    }
}