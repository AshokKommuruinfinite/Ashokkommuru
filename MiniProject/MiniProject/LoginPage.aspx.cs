using System;
namespace MiniProject
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();
            // Validation 1: Empty fields
            if (username == "" || password == "")
            {
                lblMsg.Text = "Username and Password cannot be empty";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            // Validation 2: Admin authentication
            if (username.Equals("Rohit@45") && password.Equals("Ashok123"))
            {
                // Store admin session
                Session["Admin"] = username;
                // Redirect to Home page
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                // Invalid credentials
                lblMsg.Text = "Invalid Username or Password";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
