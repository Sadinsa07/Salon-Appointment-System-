using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the selected item is null to avoid NullReferenceException
            if (comboBox1.SelectedItem == null)
            {
                textBox1.Text = "No selection";
                return;
            }

            // Get the selected appointment type
            string selectedType = comboBox1.SelectedItem.ToString();
            string cs = @"Data Source=DESKTOP-RJARFIA;Initial Catalog=salon_system;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                // SQL query to get the price based on the selected appointment type
                string sqlSearch = "SELECT Price FROM Price WHERE Type = @AppoinmentType";
                SqlCommand com = new SqlCommand(sqlSearch, con);
                com.Parameters.AddWithValue("@AppoinmentType", selectedType);

                using (SqlDataReader reader = com.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Display the price in the TextBox
                        int price = reader.GetInt32(0); // Assuming Price is the first column
                        textBox1.Text = price.ToString(); // Convert the int to string for display
                    }
                    else
                    {
                        // Handle the case where no data is found
                        textBox1.Text = "Price not found";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=DESKTOP-RJARFIA;Initial Catalog=salon_system;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                // SQL query to update the price based on the selected appointment type
                string sqlUpdate = "UPDATE Price SET Price=@price WHERE Type=@type";
                SqlCommand com = new SqlCommand(sqlUpdate, con);
                com.Parameters.AddWithValue("@price", this.textBox2.Text);
                com.Parameters.AddWithValue("@type", this.comboBox1.Text);

                int ret = com.ExecuteNonQuery();
                if (ret > 0)
                {
                    MessageBox.Show("Record updated successfully!");
                }
                else
                {
                    MessageBox.Show("No records found with the entered Appointment ID.");
                }

                // Clear the input fields
                textBox2.Clear();
                comboBox1.SelectedIndex = -1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 employeeForm = new Form2();
            employeeForm.Show();
            this.Hide();
        }
    }
}
