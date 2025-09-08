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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            // TODO: This line of code loads data into the 'salon_systemDataSet1.Employee' table. You can move, or remove it, as needed.
            //.employeeTableAdapter.Fill(this.salon_systemDataSet1.Employee);

        }
        private void LoadDataGridView()
        {
            string cs = @"Data Source=DESKTOP-RJARFIA;Initial Catalog=salon_system;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    con.Open();

                    string sqlSelect = "SELECT Id, Name,Address, Tele, Email, Salary, Username, Password FROM Employee";
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

        private void button2_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=DESKTOP-RJARFIA;Initial Catalog=salon_system;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string sqlInsert = "INSERT INTO Employee(Id, Name,Address, Tele, Email, Salary, Username, Password) VALUES(@Id, @Name, @Address, @Tele, @Email, @Salary, @Username, @Password)";
                SqlCommand com = new SqlCommand(sqlInsert, con);
                com.Parameters.AddWithValue("@Id", this.textBox1.Text);
                com.Parameters.AddWithValue("@Name", this.textBox2.Text);
                com.Parameters.AddWithValue("@Address", this.textBox3.Text);
                com.Parameters.AddWithValue("@Tele", this.textBox4.Text); // Use the correct parameter name and value
                com.Parameters.AddWithValue("@Email", this.textBox5.Text);
                com.Parameters.AddWithValue("@Salary", this.textBox6.Text);
                com.Parameters.AddWithValue("@Username", this.textBox7.Text);
                com.Parameters.AddWithValue("@Password", this.textBox8.Text);
                int ret = com.ExecuteNonQuery();
                MessageBox.Show("No of records inserted: " + ret);
                LoadDataGridView();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=DESKTOP-RJARFIA;Initial Catalog=salon_system;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string sqlSearch = "SELECT Id, Name, Address, Tele, Email, Salary, Username, Password FROM Employee WHERE Id = @Id";
                SqlCommand com = new SqlCommand(sqlSearch, con);
                com.Parameters.AddWithValue("@Id", this.textBox9.Text);

                using (SqlDataReader reader = com.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Populate the text boxes with the data retrieved from the database
                        textBox1.Text = reader["Id"].ToString();
                        textBox2.Text = reader["Name"].ToString();
                        textBox3.Text = reader["Address"].ToString();
                        textBox4.Text = reader["Tele"].ToString();
                        textBox5.Text = reader["Email"].ToString();

                        // Handle salary as int
                        textBox6.Text = reader["Salary"].ToString();

                        textBox7.Text = reader["Username"].ToString();
                        textBox8.Text = reader["Password"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No records found for the entered ID.");
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

                string sqlUpdate = "UPDATE Employee SET Name = @Name, Address = @Address, Tele = @Tele, Email = @Email, Salary = @Salary, Username = @Username, Password = @Password WHERE Id = @Id";
                SqlCommand com = new SqlCommand(sqlUpdate, con);

                com.Parameters.AddWithValue("@Id", this.textBox1.Text);
                com.Parameters.AddWithValue("@Name", this.textBox2.Text);
                com.Parameters.AddWithValue("@Address", this.textBox3.Text);
                com.Parameters.AddWithValue("@Tele", this.textBox4.Text);
                com.Parameters.AddWithValue("@Email", this.textBox5.Text);

                // Convert the salary to int
                int salary = int.Parse(this.textBox6.Text);
                com.Parameters.AddWithValue("@Salary", salary);

                com.Parameters.AddWithValue("@Username", this.textBox7.Text);
                com.Parameters.AddWithValue("@Password", this.textBox8.Text);

                int ret = com.ExecuteNonQuery();
                MessageBox.Show("No of records updated: " + ret);
                LoadDataGridView();

                // Clear the text boxes after updating the data
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=DESKTOP-RJARFIA;Initial Catalog=salon_system;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string sqlDelete = "DELETE FROM Employee WHERE Id = @Id";
                SqlCommand com = new SqlCommand(sqlDelete, con);
                com.Parameters.AddWithValue("@Id", this.textBox9.Text);

                int ret = com.ExecuteNonQuery();
                MessageBox.Show("No of records deleted: " + ret);
                LoadDataGridView();

                // Clear the text boxes after deleting the data
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 employeeForm = new Form2();
            employeeForm.Show();
            this.Hide();
        }
    }
    
}
