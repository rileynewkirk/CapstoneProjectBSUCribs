using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
//using System.Linq;
using System.Web;

namespace WebApplication1.App_Code
{
    public class Showing
    {
        public string Showing_ID { get; set; }
        public string LeasingAgent { get; set; }
        public string ShowingDate { get; set; }
        public string Client { get; set; }
        public string Address { get; set; }
        public string DateCreated { get; set; }

        public Showing()
        {
        
        }

        /*
        public Showing(string showing_ID,string LeasingAgent, string Client, string Address, string ShowingDate)
        {
            this.Showing_ID = Showing_ID;
            this.LeasingAgent = LeasingAgent;
            this.Client = Client;
            this.Address = Address;
            this.ShowingDate = ShowingDate;
        }
        */
        public Showing(string Showing_ID, string LeasingAgent, string ShowingDate,string Client, string Address, string DateCreated)
        {
            this.Showing_ID = Showing_ID;
            this.LeasingAgent = LeasingAgent;
            this.ShowingDate = ShowingDate;
            this.Client = Client;
            this.Address = Address;
            this.DateCreated = DateCreated;

        }

        public void addShowings()
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();

            string insertString = "insert into calendar (Showing_ID, Agent_ID, Showing_DateTime, Client_Name, Address, Created_DateTime) " +
               "values (@ID, @LeasingAgent, @ShowingDate, @Client, @Address, @DateCreated) ";

            MySqlCommand comd = new MySqlCommand(insertString, conn);

            comd.Parameters.AddWithValue("@ID", Showing_ID);
            comd.Parameters.AddWithValue("@LeasingAgent",LeasingAgent);
            comd.Parameters.AddWithValue("@ShowingDate", ShowingDate);
            comd.Parameters.AddWithValue("@Client", Client);
            comd.Parameters.AddWithValue("@Address", Address);
            comd.Parameters.AddWithValue("@DateCreated", DateCreated);

            comd.ExecuteNonQuery();
            conn.Close();

        }
        /*
        public Showing findShowingByDate(string showingDate)
        {
            Showing showing = new Showing();
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();
            string checkShowing = "select Showing_ID, Agent_ID, Showing_DateTime, Client_Name, Address, Created_DateTime from  calendar where Showing_DateTime=@ShowingDate";
            MySqlCommand comd = new MySqlCommand(checkShowing, conn);
            comd.Parameters.AddWithValue("@ShowingDate", showingDate);
            MySqlDataReader dr = comd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                showing.Showing_ID = dr[0].ToString();//need to figure out casting issues.
                showing.LeasingAgent = dr[1].ToString();
                //showing.ShowingDate = Convert.ToDateTime(dr[2]);
                showing.ShowingDate = dr[2].ToString();
                showing.Client = dr[3].ToString();
                showing.Address = dr[4].ToString();
                //showing.DateCreated = Convert.ToDateTime(dr[5]);
                showing.ShowingDate = dr[5].ToString();
            }
            dr.Close();
            conn.Close();
            return showing;
        }
        */
        public bool checkShowingExist()
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            string checkCalendar = "select * from Calendar where Showing_ID = @Showing_ID";
            conn.Open();

            MySqlCommand comd = new MySqlCommand(checkCalendar, conn);
            comd.Parameters.AddWithValue("@Showing_ID", Showing_ID);
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

        public void incrimentShoiwng()
        {

        }

        public string getID()
        {
            return this.Showing_ID;
        }

        public string getLeasingAgent()
        {
            return this.LeasingAgent;
        }

        public string getShowingDate()
        {
            return this.ShowingDate;
        }

        public string getAddress()
        {
            return this.Address;
        }

        public string getClient()
        {
            return this.Client;
        }

        public string getDateCreated()
        {
            return this.DateCreated;
        }
    }
}