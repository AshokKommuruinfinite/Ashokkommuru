using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ProductsAssignment
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.Items.Add(new ListItem("Select Product", "0"));
                DropDownList1.Items.Add(new ListItem("Bat", "Bat"));
                DropDownList1.Items.Add(new ListItem("Ball", "Ball"));
                DropDownList1.Items.Add(new ListItem("LBW", "LBW"));
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Bat")
            {
                Image1.ImageUrl = "https://static.vecteezy.com/system/resources/thumbnails/016/283/763/small/cricket-bat-cartoon-style-vector.jpg";
            }
            else if (DropDownList1.SelectedValue == "Ball")
            {
                Image1.ImageUrl = "https://png.pngtree.com/png-vector/20211006/ourmid/pngtree-cricket-ball-png-image_3971675.png";
            }
            else if (DropDownList1.SelectedValue == "LBW")
            {
                Image1.ImageUrl = "https://images-eu.ssl-images-amazon.com/images/I/71+i1jztNcL._AC_UL495_SR435,495_.jpg";
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Bat")
            {
                Label1.Text = "Price: ₹10,000";
            }
            else if (DropDownList1.SelectedValue == "Ball")
            {
                Label1.Text = "Price: ₹100";
            }
            else if (DropDownList1.SelectedValue == "LBW")
            {
                Label1.Text = "Price: ₹5,000";
            }
            else
            {
                Label1.Text = "Please select a product";
            }
        }
    }
}
