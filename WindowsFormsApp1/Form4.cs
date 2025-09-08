using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            dateTimePicker1.ShowUpDown = true;

            dateTimePicker1.Value = DateTime.Now;

            DateTime adjustedTime = dateTimePicker1.Value.AddHours(2);
            dateTimePicker1.Value = adjustedTime;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string cs = @"Data Source=DESKTOP-RJARFIA;Initial Catalog=salon_system;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    con.Open();

                    string sqlSelect = "SELECT AppinmentId, Name, Tele, DateTime, AppoinmentType FROM Appoinment";
                    SqlDataAdapter da = new SqlDataAdapter(sqlSelect, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Debugging: Check if the DataTable has rows
                    MessageBox.Show("Number of rows retrieved: " + dt.Rows.Count.ToString());

                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=DESKTOP-RJARFIA;Initial Catalog=salon_system;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string sqlInsert = "INSERT INTO Appoinment(AppinmentId, Name, Tele, DateTime, AppoinmentType) VALUES(@Id, @Name, @Tele, @DateTime, @AppoinmentType)";
                SqlCommand com = new SqlCommand(sqlInsert, con);
                com.Parameters.AddWithValue("@Id", this.textBox4AppID.Text);
                com.Parameters.AddWithValue("@Name", this.textBox3CusName.Text);
                com.Parameters.AddWithValue("@Tele", this.textBox2Tele.Text);
                com.Parameters.AddWithValue("@DateTime", this.dateTimePicker1.Value);
                com.Parameters.AddWithValue("@AppoinmentType", this.comboBox1.Text);

                int ret = com.ExecuteNonQuery();
                MessageBox.Show("No of records inserted: " + ret);

                LoadDataGridView();

                textBox4AppID.Clear();
                textBox3CusName.Clear();
                textBox2Tele.Clear();
                comboBox1.SelectedIndex = -1;
                dateTimePicker1.Value = DateTime.Now;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=DESKTOP-RJARFIA;Initial Catalog=salon_system;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string sqlUpdate = "UPDATE Appoinment SET Name = @Name, Tele = @Tele, DateTime = @DateTime, AppoinmentType = @AppoinmentType WHERE AppinmentId = @Id";
                SqlCommand com = new SqlCommand(sqlUpdate, con);
                com.Parameters.AddWithValue("@Id", this.textBox4AppID.Text);
                com.Parameters.AddWithValue("@Name", this.textBox3CusName.Text);
                com.Parameters.AddWithValue("@Tele", this.textBox2Tele.Text);
                com.Parameters.AddWithValue("@DateTime", this.dateTimePicker1.Value);
                com.Parameters.AddWithValue("@AppoinmentType", this.comboBox1.Text);

                int ret = com.ExecuteNonQuery();
                if (ret > 0)
                {
                    MessageBox.Show("Record updated successfully!");
                    LoadDataGridView(); // Refresh the grid view
                }
                else
                {
                    MessageBox.Show("No records found with the entered Appointment ID.");
                }

                textBox4AppID.Clear();
                textBox3CusName.Clear();
                textBox2Tele.Clear();
                comboBox1.SelectedIndex = -1;
                dateTimePicker1.Value = DateTime.Now;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=DESKTOP-RJARFIA;Initial Catalog=salon_system;Integrated Security=True";

            if (string.IsNullOrEmpty(textBox4AppID.Text))
            {
                MessageBox.Show("Please enter the Appointment ID to delete the record.");
                return;
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string sqlDelete = "DELETE FROM Appoinment WHERE AppinmentId = @Id";
                SqlCommand com = new SqlCommand(sqlDelete, con);
                com.Parameters.AddWithValue("@Id", this.textBox4AppID.Text);

                int ret = com.ExecuteNonQuery();
                if (ret > 0)
                {
                    MessageBox.Show("Record deleted successfully!");
                    LoadDataGridView(); // Refresh the grid view
                }
                else
                {
                    MessageBox.Show("No records found with the entered Appointment ID.");
                }

                textBox4AppID.Clear();
                textBox3CusName.Clear();
                textBox2Tele.Clear();
                comboBox1.SelectedIndex = -1;
                dateTimePicker1.Value = DateTime.Now;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=DESKTOP-RJARFIA;Initial Catalog=salon_system;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string sqlSearch = "SELECT AppinmentId, Name, Tele, DateTime, AppoinmentType FROM Appoinment WHERE Tele = @Tele";
                SqlCommand com = new SqlCommand(sqlSearch, con);
                com.Parameters.AddWithValue("@Tele", this.textBox1.Text);

                using (SqlDataReader reader = com.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBox4AppID.Text = reader["AppinmentId"].ToString();
                        textBox3CusName.Text = reader["Name"].ToString();
                        textBox2Tele.Text = reader["Tele"].ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(reader["DateTime"]);
                        comboBox1.Text = reader["AppoinmentType"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No records found for the entered telephone number.");
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 employeeForm = new Form7();
            employeeForm.Show();
            this.Hide();
        }
    }
}
