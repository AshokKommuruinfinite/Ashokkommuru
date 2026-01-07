using System;
using System.Web.UI;
namespace ValidationsAssignment
{
    public partial class Validator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {

        }
        protected void Button1_Click(object sender, EventArgs e)

        {
            if (Page.IsValid)
            {
                Response.Write("Welcome to profile");
            }
            else
            {
                Response.Write("Enter correct details before submitting");
            }
        }
    }
}




