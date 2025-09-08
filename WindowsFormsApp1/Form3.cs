using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1Register_Click(object sender, EventArgs e)
        {
            // Step 1: Validate input fields
            if (string.IsNullOrWhiteSpace(textBox1Name.Text))
            {
                MessageBox.Show("Please enter a valid name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2NIC.Text) || textBox2NIC.Text.Length != 10)
            {
                MessageBox.Show("Please enter a valid NIC number.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox3Tele.Text) || textBox3Tele.Text.Length < 10)
            {
                MessageBox.Show("Please enter a valid telephone number.");
                return;
            }

            if (!IsValidEmail(textBox4Mail.Text))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            string cs = @"Data Source=DESKTOP-RJARFIA;Initial Catalog=salon_system;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                // Step 2: Retrieve the next available Customer ID
                string sqlGetMaxID = "SELECT ISNULL(MAX([Customer ID]), 0) + 1 FROM Customer";
                SqlCommand cmdGetMaxID = new SqlCommand(sqlGetMaxID, con);
                int nextCustomerID = (int)cmdGetMaxID.ExecuteScalar();

                // Step 3: Display the next Customer ID in the textbox
                textBox1.Text = nextCustomerID.ToString();

                // Step 4: Insert the new customer record
                string sqlInsert = "INSERT INTO Customer(Name, NIC, Telephone, Email, [Customer ID]) VALUES(@Name, @NIC, @Telephone, @Email, @CustomerID)";
                SqlCommand com = new SqlCommand(sqlInsert, con);
                com.Parameters.AddWithValue("@Name", this.textBox1Name.Text);
                com.Parameters.AddWithValue("@NIC", this.textBox2NIC.Text);
                com.Parameters.AddWithValue("@Telephone", this.textBox3Tele.Text);
                com.Parameters.AddWithValue("@Email", this.textBox4Mail.Text);
                com.Parameters.AddWithValue("@CustomerID", nextCustomerID);

                // Step 5: Execute the command to insert data
                int ret = com.ExecuteNonQuery();
                MessageBox.Show("No of records inserted: " + ret);

                // Step 6: Retrieve and display the next available Customer ID for the next entry
                nextCustomerID++;
                textBox1.Text = nextCustomerID.ToString();
            }
        }

        private void button2Me_Click(object sender, EventArgs e)
        {
            // Create an instance of Form1
            Form2 adForm = new Form2();
            adForm.Show();
            this.Hide();
        }

        // Helper method to validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
