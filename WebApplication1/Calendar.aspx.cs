﻿using WebApplication1.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication1
{
    public partial class Calendar : System.Web.UI.Page
    {
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Showing newShowing = new Showing();

            newShowing.Showing_ID = "DIFFERENT DATE ";//needs dynamically created
            newShowing.LeasingAgent = "current agents name";//should come from user logged in
            newShowing.ShowingDate = Calendar1.SelectedDate.ToShortDateString();//set by selected calendar date
            newShowing.Client = clientTxtBx.Text; // typed in by user
            newShowing.Address = propertyTxtBx.Text; //selected by user 
            newShowing.DateCreated = DateTime.Now.ToLongDateString();// auto generated by current time stamp

            newShowing.addShowings();

            Label1.Text = Calendar1.SelectedDate.ToShortDateString();

            if (newShowing.checkShowingExist())
            {
                
                System.Diagnostics.Debug.WriteLine(newShowing.Showing_ID);
                System.Diagnostics.Debug.WriteLine(newShowing.LeasingAgent);
                System.Diagnostics.Debug.WriteLine(newShowing.ShowingDate);
                System.Diagnostics.Debug.WriteLine(newShowing.Client);
                System.Diagnostics.Debug.WriteLine(newShowing.Address);
                System.Diagnostics.Debug.WriteLine(newShowing.DateCreated);
                
                ListBox1.Items.Add(newShowing.Showing_ID + newShowing.LeasingAgent + newShowing.ShowingDate + newShowing.Client + newShowing.Address + newShowing.DateCreated);
            }

            Showing showingForSelectedDay = new Showing();
            showingForSelectedDay.findShowing(Calendar1.SelectedDate.ToShortDateString());
            ListBox1.Items.Add(showingForSelectedDay.Showing_ID + " " + showingForSelectedDay.ShowingDate);//doesnt work yet

            

        }
    }
}