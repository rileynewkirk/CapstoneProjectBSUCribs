using WebApplication1.App_Code;
using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Collections.Generic;


namespace WebApplication1
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getAllUsers();
            }
           
        }
        protected void clear(object sender, EventArgs e)
        {
            tbUsername.Text = "";
            tbPassword2.Text = "";
            tbPassword.Text = "";
            tbLastName.Text = "";
            tbFirstName.Text = "";
            tbEmail.Text = "";
            tbPhoneNumber.Text = "";
        }

        protected void addUser(object sender, EventArgs e)
        {
            UserUtil user = new UserUtil();
            DateTime dt = DateTime.Now;

            user.UserName = tbUsername.Text;
            user.firstname = tbFirstName.Text;
            user.lastname = tbLastName.Text;
            user.email = tbEmail.Text;
            user.password = tbPassword.Text;
            user.phoneNumber =tbPhoneNumber.Text;
            user.UserType = 1;



            if (!user.checkUserExist())
            {
                user.insertdata();
                lblResponse.Text = "You have registered successfully! You will be redirect to the Login page momentarily";
                lblResponse.ForeColor = Color.Green;
                Response.AddHeader("refresh", "3;url=Login.aspx");

            }
            else
            {
                lblResponse.Text = "The username already exists";
                lblResponse.ForeColor = Color.Red;
                tbPassword2.Text = "";
                tbPassword.Text = "";
            }

        }

                    
    

    private void getAllUsers()
    {
        List<UserUtil> users = new List<UserUtil>();
        string qry = "Select * from Users";
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
        conn.Open();

        MySqlCommand cmd = new MySqlCommand(qry, conn);
        MySqlDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            string username = rdr["Username"].ToString();
            string password = "Password";
            string email = rdr["email"].ToString();
            string firstname = rdr["firstname"].ToString();
            string lastname = rdr["lastname"].ToString();
            int type = Convert.ToInt32(rdr["UserType"].ToString());
            string phonenumber = rdr["PhoneNumber"].ToString();
            string profileImage = rdr["profileImage"].ToString();
            

            UserUtil user = new UserUtil(username, password, email, firstname, lastname, type, phonenumber, profileImage);
            users.Add(user);
           

            }

            //close Data Reader
            rdr.Close();

        //close Connection
        conn.Close();

        postIntoList(users);

    }

    private void postIntoList(List<UserUtil> users)
    {
        for (int i = 0; i <= users.Count - 1; i++)
        {

            string start = "<tr id=\"" + users[i].getUsername() + "\">";
            string img = "<td style=\"text-align: left\"><img src=\"" + users[i].getProfileImage() + "\" class=\"img-responsive profile-thumbnail\" alt=\"\" /></td>";
            string username = "<td> " + users[i].getUsername() + "</td>";
            string name = "<td><a href=\"EditUser.aspx" + users[i].getUsername() + "\" class=\"profile-text\">" + users[i].getFirstname() + " " + users[i].getLastname() + "</a></td>";
            string label = getLabel(users[i].getUsertype());
            string email = "<td> " + users[i].getEmail() + "</td>";
            string phonenumber = "<td>" + users[i].getphoneNumber() + "</td>";
            string btn = "<td style=\"width:20%;\"><a href=\"EditUser.aspx?username=" + users[i].getUsername() + "\" class=\"btn btn-default\">Edit User</a></td>";
            string end = "</tr>";

            string user = start + img + username + name + label + email + phonenumber + btn + end;
        
            userList.InnerHtml = userList.InnerHtml + user;
        }
    }

    private string getLabel(int v)
    {
        string label = "";

        if (v == 2)
        {
            label = "<td class=\"text-center\"><span class=\"label label-primary\">Writer</span></td>";
        }
        else if (v == 3)
        {+
            label = "<td class=\"text-center\"><span class=\"label label-danger\">Admin</span></td>";
        }
        else
        {
            label = "<td class=\"text-center\"><span class=\"label label-default\">Basic</span></td>";
        }

        return label;
    }

}
}