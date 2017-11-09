using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                TemplateField property = new TemplateField();
                property.HeaderText = "Property";
                GVShowing.Columns.Add(property);

                TemplateField leasingAgent = new TemplateField();
                leasingAgent.HeaderText = "Leasing Agent";
                GVShowing.Columns.Add(leasingAgent);

                TemplateField date = new TemplateField();
                date.HeaderText = "Date";
                GVShowing.Columns.Add(date);

                TemplateField time = new TemplateField();
                time.HeaderText = "Time";
                GVShowing.Columns.Add(time);

                CommandField delete = new CommandField();
                delete.ShowDeleteButton = true;
                GVShowing.Columns.Add(delete);

                CommandField edit = new CommandField();
                edit.ShowEditButton = true;
                GVShowing.Columns.Add(edit);

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Property", typeof(string)),
                        new DataColumn("Leasing Agent", typeof(string)),
                        new DataColumn("Date",typeof(string)),
                        new DataColumn("Time", typeof(string)),
                        new DataColumn("Edit", typeof(CommandField)),
                        new DataColumn("Delete", typeof(CommandField))});

                dt.Rows.Add("1500 w university ave apt 102", "Riley Newkirk", DateTime.Today.ToString(), DateTime.Now.TimeOfDay.ToString(), edit, delete);
                dt.Rows.Add("115 s dicks st", "Jacob Little", DateTime.Today.ToString(), DateTime.Now.TimeOfDay.ToString(), edit, delete);
                dt.Rows.Add("1428 w Gilbert", "Nicole Porten", DateTime.Today.ToString(), DateTime.Now.TimeOfDay.ToString(), edit, delete);
                GVShowing.DataSource = dt;
                GVShowing.DataBind();

                //CommandField delete = new CommandField();
                //delete.ShowDeleteButton = true;
                //GVShowing.Columns.Add(delete);

                //CommandField edit = new CommandField();
                //edit.ShowEditButton = true;
                //GVShowing.Columns.Add(edit);

                //DataTable dt = new DataTable();
                //dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Property"), new DataColumn("Leasing Agent"), new DataColumn("Date"), new DataColumn("Time") });
                //dt.Rows.Add("115 N Dicks", "JacobLittle", DateTime.Today, DateTime.Now.TimeOfDay);
                //dt.Rows.Add("1500 W University Ave", "RileyNewkirk", DateTime.Today, DateTime.Now.TimeOfDay);
                //GVShowing.DataSource = dt;

                /*
                                    < Columns >
                        < asp:TemplateField AccessibleHeaderText = "Property" HeaderText = "Property" ></ asp:TemplateField >
      
                               < asp:TemplateField AccessibleHeaderText = "Leasing Agent" HeaderText = "Leasing Agent" ></ asp:TemplateField >
             
                                      < asp:TemplateField AccessibleHeaderText = "Date" HeaderText = "Date" ></ asp:TemplateField >
                    
                                             < asp:TemplateField AccessibleHeaderText = "Time" HeaderText = "Time" ></ asp:TemplateField >
                           
                                                    < asp:CommandField ShowEditButton = "True" AccessibleHeaderText = "Edit" />
                              
                                                       < asp:CommandField ShowDeleteButton = "True" AccessibleHeaderText = "Delete" />
                                 
                                                      </ Columns >
                  */
            }
            //this.BindGrid();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

        }
    }
}