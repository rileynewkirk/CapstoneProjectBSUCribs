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
            string name = Request.QueryString["username"];
            getUserInfo(name);

        }

        private void getUserInfo(string name)
        {
            string qry = "Select firstname, lastname, profileImage from Users WHERE UserName=\"" + name + "\"";
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                string firstname = rdr["firstname"].ToString();
                string lastname = rdr["lastname"].ToString();
                string img = rdr["profileImage"].ToString();

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

            if (type == "Basic")
            {
                newType = 1;
            }
            else if (type == "Writer")
            {
                newType = 2;
            }
            else if (type == "Admin")
            {
                newType = 3;
            }

            string name = Request.QueryString["username"];
            string qry = "UPDATE users SET UserType=\"" + newType + "\" WHERE UserName=\"" + name + "\"";

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

        protected void btnUpdateEmail_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();

            String Username = Request.QueryString["username"];
            String email = tbEmail.Text;

            string updateString = "update users set email = @email where Username = @Username";
            MySqlCommand comd = new MySqlCommand(updateString, conn);

            comd.Parameters.AddWithValue("@UserName", Username);
            comd.Parameters.AddWithValue("@email", email);
            comd.ExecuteNonQuery();
            conn.Close();

            Response.Write("<script language=javascript>window.location='Registration.aspx';</script>");
        }

        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();

            String Username = Request.QueryString["username"];
            String password = tbPassword.Text;

            string updateString = "update users set password = @password where Username = @Username";
            MySqlCommand comd = new MySqlCommand(updateString, conn);

            comd.Parameters.AddWithValue("@UserName", Username);
            comd.Parameters.AddWithValue("@password", EncryptPassword.encryptString(password));
            comd.ExecuteNonQuery();
            conn.Close();

            Response.Write("<script language=javascript>window.location='Registration.aspx';</script>");
        }

        protected void btnUpdatePhone_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();

            String Username = Request.QueryString["username"];
            String phone = tbPhoneNumber.Text;

            string updateString = "update users set PhoneNumber = @PhoneNumber where Username = @Username";
            MySqlCommand comd = new MySqlCommand(updateString, conn);

            comd.Parameters.AddWithValue("@UserName", Username);
            comd.Parameters.AddWithValue("@PhoneNumber", phone);
            comd.ExecuteNonQuery();
            conn.Close();

            Response.Write("<script language=javascript>window.location='Registration.aspx';</script>");
        }
    }
}