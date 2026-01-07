using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace MiniProject.NewFolder1
{
    public class ElectricityBoard
    {
        public void CalculateBill(ElectriccityBill ebill)
        {
            int units = ebill.UnitsConsumed;
            double amount = 0;
            if (units <= 100)
            {
                amount = 0;
            }
            else if (units <= 300)
            {
                amount = (units - 100) * 1.5;
            }
            else if (units <= 600)
            {
                amount = (200 * 1.5) + (units - 300) * 3.5;
            }
            else if (units <= 1000)
            {
                amount = (200 * 1.5) + (300 * 3.5) + (units - 600) * 5.5;
            }
            else
            {
                amount = (200 * 1.5) + (300 * 3.5) + (400 * 5.5) + (units - 1000) * 7.5;
            }
            ebill.BillAmount = amount;
        }
        public void AddBill(ElectriccityBill ebill)
        {
            using (SqlConnection conn = DBHandler.GetConnection())
            {
                string query = "INSERT INTO ElectricityBill(consumer_number, consumer_name, units_consumed, bill_amount) " +
                               "VALUES(@num, @name, @units, @amount)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@num", ebill.ConsumerNumber);
                cmd.Parameters.AddWithValue("@name", ebill.ConsumerName);
                cmd.Parameters.AddWithValue("@units", ebill.UnitsConsumed);
                cmd.Parameters.AddWithValue("@amount", ebill.BillAmount);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //method
        public List<ElectriccityBill> Generate_N_BillDetails(int n)
        {
            List<ElectriccityBill> bills = new List<ElectriccityBill>();
            using (SqlConnection conn = DBHandler.GetConnection())
            {
                string query = "SELECT TOP(@n) consumer_number, consumer_name, units_consumed, bill_amount " +
                               "FROM ElectricityBill ORDER BY consumer_number DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n", n);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ElectriccityBill eb = new ElectriccityBill
                    {
                        ConsumerNumber = reader["consumer_number"].ToString(),
                        ConsumerName = reader["consumer_name"].ToString(),
                        UnitsConsumed = Convert.ToInt32(reader["units_consumed"]),
                        BillAmount = Convert.ToDouble(reader["bill_amount"])
                    };
                    bills.Add(eb);
                }
            }
            return bills;
        }
    }
}