using WebApplication1.App_Code;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}