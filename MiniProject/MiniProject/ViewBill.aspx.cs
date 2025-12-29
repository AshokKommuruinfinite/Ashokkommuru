using MiniProject.NewFolder1;
using System;
using System.Collections.Generic;
namespace MiniProject
{
    public partial class ViewBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnViewBills_Click(object sender, EventArgs e)
        {
            try
            {
                int n;
                if (!int.TryParse(txtN.Text.Trim(), out n) || n <= 0)
                {
                    Label1.Text = "Please enter a valid number greater than 0.";
                    gvBills.DataSource = null;
                    gvBills.DataBind();
                    return;
                }
                ElectricityBoard board = new ElectricityBoard();
                List<ElectriccityBill> bills = board.Generate_N_BillDetails(n);
                if (bills.Count == 0)
                {
                    Label1.Text = "No bills found in the database.";
                }
                gvBills.DataSource = bills;
                gvBills.DataBind();
                gvBills.Visible = true;
            }
            catch (Exception ex)
            {
                Label1.Text = "Error: " + ex.Message;
            }
        }
    }
}