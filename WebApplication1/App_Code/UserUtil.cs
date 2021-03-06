﻿using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace WebApplication1.App_Code
{
    public class UserUtil
    {
        public string UserName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int UserType { get; set; }
        public string phoneNumber { get; set; }
        public string profileImage { get; set; }

        public UserUtil()
        {

        }

        public UserUtil(string username, string password, string email, string firstname, string lastname, int type, string phoneNumber, string img)
        {
            this.UserName = username;
            this.password = password;
            this.email = email;
            this.firstname = firstname;
            this.lastname = lastname;
            this.UserType = type;
            this.phoneNumber = phoneNumber;
            this.profileImage = img;
        }

        public void insertdata()
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();
            string insertString = "insert into users (UserName, password, email, firstname, lastname, UserType, phoneNumber, profileImage) " +
                "values (@UserName, @password, @Email, @firstname, @lastname, @UserType, @phoneNumber, @profileImage) ";
            MySqlCommand comd = new MySqlCommand(insertString, conn);
            comd.Parameters.AddWithValue("@UserName", UserName);
            comd.Parameters.AddWithValue("@password", EncryptPassword.encryptString(password));
            comd.Parameters.AddWithValue("@Email", email);
            comd.Parameters.AddWithValue("@firstname", firstname);
            comd.Parameters.AddWithValue("@Lastname", lastname);
            comd.Parameters.AddWithValue("@UserType", UserType);
            comd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            comd.Parameters.AddWithValue("@profileImage", profileImage);

            comd.ExecuteNonQuery();
            conn.Close();
        }

        public bool checkUserExist()
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
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
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();
            string checkUser = "select * from Users where UserName = @UserName";
            MySqlCommand comd = new MySqlCommand(checkUser, conn);
            comd.Parameters.AddWithValue("@UserName", UserName);
            MySqlDataReader dr = comd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
#pragma warning disable CS0436 // Type conflicts with imported type
                if (dr["Password"].ToString().Equals(value: EncryptPassword.encryptString(password)))
#pragma warning restore CS0436 // Type conflicts with imported type
                {
                    dr.Close();
                    conn.Close();
                    return true;

                }
                else
                {
                    return false;
                }


            }
            else
            {
                return false;
            }






        }

        public UserUtil getUser(string UserName)
        {
            UserUtil customer = new UserUtil();
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();
            string checkUser = "select UserName, Password, Email, Firstname, Lastname, UserType, PhoneNumber from Users where UserName=@UserName";
            MySqlCommand comd = new MySqlCommand(checkUser, conn);
            comd.Parameters.AddWithValue("@UserName", UserName);
            MySqlDataReader dr = comd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                customer.UserName = dr[0].ToString();
                customer.email = dr[2].ToString();
                customer.firstname = dr[3].ToString();
                customer.lastname = dr[4].ToString();
                customer.password = dr[1].ToString();
                customer.UserType = dr[6].ToString().ToCharArray()[0];
                customer.phoneNumber = dr[7].ToString();
            }
            dr.Close();
            conn.Close();
            return customer;
        }

        public void resetPassword(string newpwd)
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
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

        public string getphoneNumber()
        {
            return this.phoneNumber;
        }

        public string getProfileImage()
        {
            return this.profileImage;
        }

    }
}