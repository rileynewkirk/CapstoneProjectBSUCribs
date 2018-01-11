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
                bcp1.TableName = "properties";
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
        }
}