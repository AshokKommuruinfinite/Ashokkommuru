using MiniProject.NewFolder1;
using System;
using System.Data.SqlClient;
namespace MiniProject
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DBHandler.GetConnection();
                con.Open();
                Button1.Text = "✅ Database connection successful";
                Button1.ForeColor = System.Drawing.Color.Green;
                con.Close();
            }
            catch (Exception ex)
            {
                Button1.Text = "❌ Database connection failed<br/>" + ex.Message;
                Button1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}