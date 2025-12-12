using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackDBApp
{
    internal class Enrollments
    {
        internal class DisconnectedArchitechture
        {
            static void Main(string[] args)
            {
                DisconnectedArchitechture AB = new DisconnectedArchitechture();
                //AB.Load_Data();
                AB.Modify_Credits();
                //AB.Insert_Course();
                //AB.Delete_Student();
                //AB.Call_StoredProcedure();
                Console.ReadLine();
            }
            public void Load_Data()
            {
                SqlConnection con = new SqlConnection("Integrated security=true;database=TrackDB;server=(localdb)\\MSSQLLocalDB");
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter daStudents = new SqlDataAdapter("SELECT * FROM Students", con);
                daStudents.Fill(ds, "Students");
                SqlDataAdapter daCourses = new SqlDataAdapter("SELECT * FROM Courses", con);
                daCourses.Fill(ds, "Courses");
                Console.WriteLine("------Students Table-----");
                foreach (DataRow row in ds.Tables["Students"].Rows)
                {
                    Console.WriteLine(
                        row["StudentId"] + " | " +
                        row["FullName"] + " | " +
                        row["Email"] + " | " +
                        row["Department"] + " | " +
                        row["YearOfStudy"]);
                }
                Console.WriteLine("-----Courses Table-----");
                foreach (DataRow row in ds.Tables["Courses"].Rows)
                {
                    Console.WriteLine(row["CourseId"] + " | " + row["CourseName"] + " | " + row["Credits"] + " | " + row["Semester"]);
                }
                con.Close();
            }
            public void Modify_Credits()
            {
                SqlConnection con = new SqlConnection("Integrated security=true;database=TrackDB;server=(localdb)\\MSSQLLocalDB");
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Courses", con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Fill(ds, "Courses");
                Console.Write("Enter CourseId: ");
                int courseId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter new Credits: ");
                int newCredits = Convert.ToInt32(Console.ReadLine());
                DataRow[] rows = ds.Tables["Courses"].Select("CourseId = " + courseId);
                if (rows.Length > 0)
                {
                    rows[0]["Credits"] = newCredits;
                    da.Update(ds, "Courses");
                    Console.WriteLine("Credits updated successfully!");
                }
                else
                {
                    Console.WriteLine("Course not found.");
                }
                con.Close();
            }
            public void Insert_Course()
            {
                SqlConnection con = new SqlConnection("Integrated security=true;database=TrackDB;server=(localdb)\\MSSQLLocalDB");
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Courses", con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Fill(ds, "Courses");
                DataRow newRow = ds.Tables["Courses"].NewRow();
                Console.Write("Enter Course Name: ");
                newRow["CourseName"] = Console.ReadLine();
                Console.Write("Enter Credits: ");
                newRow["Credits"] = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Semester: ");
                newRow["Semester"] = Console.ReadLine();
                ds.Tables["Courses"].Rows.Add(newRow);
                da.Update(ds, "Courses");
                Console.WriteLine("Course inserted successfully");
                con.Close();
            }
            public void Delete_Student()
            {
                SqlConnection con = new SqlConnection("Integrated Security = true;database = TrackDB;server =(localdb)\\MSSQLLocalDB");
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Students", con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Fill(ds, "Students");
                Console.Write("Enter StudentId : ");
                int studentId = Convert.ToInt32(Console.ReadLine());
                DataRow[] row = ds.Tables["Students"].Select("StudentID = " + studentId);
                if (row.Length > 0)
                {
                    row[0].Delete();
                    da.Update(ds, "Students");
                }
                else
                {
                    Console.Write("Data Not Found");
                }
                con.Close();
            }
            public void Call_StoredProcedure()
            {
                SqlConnection con = new SqlConnection("Integrated security=true;database=TrackDB;server=(localdb)\\MSSQLLocalDB");
                con.Open();
                Console.Write("Enter Semester: ");
                string semester = Console.ReadLine();
                SqlCommand cmd = new SqlCommand("usp_GetCoursesBySemester", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@semester", semester);
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("Course Name | Credits | Semester");
                Console.WriteLine("-----------------------------------");
                while (reader.Read())
                {
                    Console.WriteLine(reader["CourseName"] + " | " + reader["Credits"] + " | " + reader["Semester"]);
                }
                con.Close();

            }
        }
    }
}


 