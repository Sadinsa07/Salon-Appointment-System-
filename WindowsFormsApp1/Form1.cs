using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1Reg_Click(object sender, EventArgs e)
        {
            // Get the values from the text boxes
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Check if any radio button is selected
            if (!radioButton1Admin.Checked && !radioButton2Emp.Checked)
            {
                MessageBox.Show("Please select Admin or Employee");
                return;
            }

            // Check if the Admin radio button is selected
            if (radioButton1Admin.Checked)
            {
                // Check if the username and password are correct for Admin
                if (username == "Admin" && password == "Admin123")
                {
                    // Navigate to Form3 for Admin
                    Form2 adminForm = new Form2();
                    adminForm.Show();
                    this.Hide(); // Hide the login form
                }
                else
                {
                    MessageBox.Show("Invalid Admin username or password");
                }
            }
            // Check if the Employee radio button is selected
            else if (radioButton2Emp.Checked)
            {
                // Connection string to your SQL Server database
                string cs = @"Data Source=DESKTOP-RJARFIA;Initial Catalog=salon_system;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    // SQL query to check the username and password in the Employee table
                    string sqlSearch = "SELECT COUNT(*) FROM Employee WHERE Username = @Username AND Password = @Password";
                    SqlCommand com = new SqlCommand(sqlSearch, con);
                    com.Parameters.AddWithValue("@Username", username);
                    com.Parameters.AddWithValue("@Password", password);

                    int count = (int)com.ExecuteScalar();

                    if (count > 0)
                    {
                        // Navigate to Form4 for Employee
                        Form4 employeeForm = new Form4();
                        employeeForm.Show();
                        this.Hide(); // Hide the login form
                    }
                    else
                    {
                        MessageBox.Show("Invalid Employee username or password");
                    }
                }
            }
        }
    }
}
