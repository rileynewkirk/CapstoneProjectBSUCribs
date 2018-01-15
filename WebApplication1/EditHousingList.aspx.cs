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


namespace WebApplication1
{
    public partial class EditHousingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

            string deleteString = "DELETE FROM `properties`";
            MySqlCommand comd = new MySqlCommand(deleteString, conn1);

            comd.ExecuteNonQuery();
            conn1.Close();

            string csvPath = Server.MapPath("~/csvTemp/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(csvPath);
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);

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
        }

        protected void AddressDropDownList_TextChanged(object sender, EventArgs e)
        {
            string address = AddressDropDownList.Text;
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TestCapstone"].ConnectionString);
            conn.Open();
            string checkShowing = "select FirstName, LastName, Mobile from table4 where PropertyName = '"+address+"';";
            MySqlCommand comd = new MySqlCommand(checkShowing, conn);
            MySqlDataReader dr = comd.ExecuteReader();
            int i = 0;
           

            while (dr.Read())
            {
                i++;
                TableRow tr = new TableRow();
                Table1.Rows.Add(tr);
                TableCell tableCell = new TableCell();
                TextBox tbname = new TextBox();
                tbname.Attributes.Add("placeholder", dr["FirstName"].ToString());
                tr.Controls.Add(tableCell);
                tableCell.Controls.Add(tbname);
                TableCell tableLast = new TableCell();
                TextBox tblname = new TextBox();
                tblname.Attributes.Add("placeholder", dr["LastName"].ToString());
                tr.Controls.Add(tableLast);
                tableLast.Controls.Add(tblname);
                TableCell tablemobile = new TableCell();
                TextBox tbmobile = new TextBox();
                tbmobile.Attributes.Add("placeholder", dr["Mobile"].ToString());
                tr.Controls.Add(tablemobile);
                tablemobile.Controls.Add(tbmobile);
                TableCell tabledel = new TableCell();
                Button btn = new Button();
                btn.Text = "Delete";
                btn.ID = "btn_click" + i;
                btn.OnClientClick = "return confirm('Are you sure you want to submit ?')";
                btn.Click += new EventHandler(btnevent_Click);
                tr.Controls.Add(tabledel);
                tabledel.Controls.Add(btn);

            }
            dr.Close();
            conn.Close();

            
        }
        protected void btnevent_Click(object sender, EventArgs e)
        {
            try
            {
                //place your code here
                Response.Write("Hello World");
            }
            catch (Exception)
            { }
        }
    }
}