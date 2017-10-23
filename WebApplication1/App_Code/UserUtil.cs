using System;
using System.Collections.Generic;
using System.Web;

namespace WebApplication1.App_Code
{ 
    /*
        public class UserUtil
        {

            public string UserName { get; set; }
            public string password { get; set; }
            public string email { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public int UserType { get; set; }
            public int age { get; set; }
            public string profileImage { get; set; }
            public string dateJoined { get; set; }

            public UserUtil()
            {

            }

            public UserUtil(string username, string password, string email, string firstname, string lastname, int type, int age, string img, string date)
            {
                UserName = username;
                this.password = password;
                this.email = email;
                this.firstname = firstname;
                this.lastname = lastname;
                UserType = type;
                this.age = age;
                profileImage = img;
                dateJoined = date;
            }

            public void insertdata()
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["HealthDatabase"].ConnectionString);
                conn.Open();
                string insertString = "insert into users (UserName, password, email, firstname, lastname, UserType, age, profileImage) " +
                    "values (@UserName, @password, @Email, @firstname, @lastname, @UserType, @Age, @profileImage) ";
                MySqlCommand comd = new MySqlCommand(insertString, conn);
                comd.Parameters.AddWithValue("@UserName", UserName);
                comd.Parameters.AddWithValue("@password", EncryptPassword.encryptString(password));
                comd.Parameters.AddWithValue("@Email", email);
                comd.Parameters.AddWithValue("@firstname", firstname);
                comd.Parameters.AddWithValue("@Lastname", lastname);
                comd.Parameters.AddWithValue("@UserType", UserType);
                comd.Parameters.AddWithValue("@Age", Convert.ToInt32(age));
                comd.Parameters.AddWithValue("@profileImage", profileImage);

                comd.ExecuteNonQuery();
                conn.Close();
            }

            public bool checkUserExist()
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["HealthDatabase"].ConnectionString);
                string checkUser = "select * from Users where UserName = @UserName";
                conn.Open();

                MySqlCommand comd = new MySqlCommand(checkUser, conn);
                comd.Parameters.AddWithValue("@UserName", UserName);
                MySqlDataReader dr = comd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    conn.Close();
                    return true;

                }
                dr.Close();
                conn.Close();
                return false;
            }

            public bool checkPassword()
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["HealthDatabase"].ConnectionString);
                conn.Open();
                string checkUser = "select * from Users where UserName = @UserName";
                MySqlCommand comd = new MySqlCommand(checkUser, conn);
                comd.Parameters.AddWithValue("@UserName", UserName);
                MySqlDataReader dr = comd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    if (dr["Password"].ToString().Equals(EncryptPassword.encryptString(password)))
                    {
                        dr.Close();
                        conn.Close();
                        return true;
                    }
                }

                return false;
            }

            public UserUtil getUser(string UserName)
            {
                UserUtil customer = new UserUtil();
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["HealthDatabase"].ConnectionString);
                conn.Open();
                string checkUser = "select UserName, Email, firstname, lastname, [Password], UserType, age from Users where UserName=@userName";
                MySqlCommand comd = new MySqlCommand(checkUser, conn);
                comd.Parameters.AddWithValue("@UserName", UserName);
                MySqlDataReader dr = comd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    customer.UserName = dr[0].ToString();
                    customer.email = dr[3].ToString();
                    customer.firstname = dr[1].ToString();
                    customer.lastname = dr[2].ToString();
                    customer.password = dr[5].ToString();
                    customer.UserType = dr[6].ToString().ToCharArray()[0];
                    customer.age = dr[7].ToString().ToCharArray()[0];
                }
                dr.Close();
                conn.Close();
                return customer;
            }

            public void resetPassword(string newpwd)
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["HealthDatabase"].ConnectionString);
                conn.Open();
                string checkUser = "update Users set Users.Password = @password where Users.UserName = @userName";
                MySqlCommand comd = new MySqlCommand(checkUser, conn);
                comd.Parameters.AddWithValue("@UserName", UserName);
                comd.Parameters.AddWithValue("@password", EncryptPassword.encryptString(newpwd));
                comd.ExecuteNonQuery();
                conn.Close();
            }

            public string getUsername()
            {
                return this.UserName;
            }

            public string getFirstname()
            {
                return this.firstname;
            }

            public string getLastname()
            {
                return this.lastname;
            }

            public string getEmail()
            {
                return this.email;
            }

            public int getUsertype()
            {
                return this.UserType;
            }

            public int getAge()
            {
                return this.age;
            }

            public string getProfileImage()
            {
                return this.profileImage;
            }

            public string getDateJoined()
            {
                return this.dateJoined;
            }
        }
        */
    }