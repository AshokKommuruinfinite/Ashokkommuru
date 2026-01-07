using MiniProject.NewFolder1;
using System;
namespace MiniProject
{
    public partial class ADDBILL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblBillOutput.Text = "";
        }
        protected void btnAddBill_Click(object sender, EventArgs e)
        {
            try
            {
                ElectriccityBill ebill = new ElectriccityBill()
                {
                    ConsumerNumber = txtConsumerNumber.Text.Trim(),
                    ConsumerName = txtConsumerName.Text.Trim(),
                    UnitsConsumed = int.Parse(txtUnitsConsumed.Text.Trim())
                };
                Billvaildator validator = new Billvaildator();
                string valid = validator.ValidateUnitsConsumed(ebill.UnitsConsumed);
                if (valid != "Valid")
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = valid;
                    return;
                }
                ElectricityBoard board = new ElectricityBoard();
                board.CalculateBill(ebill);
                board.AddBill(ebill);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Bill successfully added!";
                lblBillOutput.Text = $"{ebill.ConsumerNumber} {ebill.ConsumerName} {ebill.UnitsConsumed} Units, Bill Amount: {ebill.BillAmount}";
            }
            catch (FormatException ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}


