using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportAppServer;
using CrystalDecisions.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        private int totalSum = 0; // Variable to store the total sum

        public Form7()
        {
            InitializeComponent();
            DisplayDateTime();
            InitializeDataGridView(); // Initialize DataGridView columns
            SetLastInvoiceID(); // Set the last invoice ID when the form starts
        }

        private void DisplayDateTime()
        {
            // Display today's date and time in labels
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd"); // Format as YYYY-MM-DD
            label3.Text = DateTime.Now.ToString("HH:mm:ss");  // Format as HH:MM:SS
        }

        private void InitializeDataGridView()
        {
            // Adding columns to the DataGridView
            dataGridView1.Columns.Add("Type", "Type");
            dataGridView1.Columns.Add("Price", "Price");
            dataGridView1.Columns.Add("Discount", "Discount");
            dataGridView1.Columns.Add("NetTotal", "Net Total");

            // Increase the width of DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetLastInvoiceID()
        {
            string cs = @"Data Source=DESKTOP-RJARFIA;Initial Catalog=salon_system;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string sqlGetMaxID = "SELECT ISNULL(MAX(InvoiceID), 0) FROM Invoice1";
                SqlCommand cmdGetMaxID = new SqlCommand(sqlGetMaxID, con);

                // Use Convert.ToInt32 to handle potential DBNull values safely
                int lastID = Convert.ToInt32(cmdGetMaxID.ExecuteScalar());

                textBox1.Text = lastID.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cs1 = @"Data Source=DESKTOP-RJARFIA;Initial Catalog=salon_system;Integrated Security=True";

            string selectedType = comboBox1.SelectedItem.ToString();

            using (SqlConnection con = new SqlConnection(cs1))
            {
                con.Open();

                string sqlSearch = "SELECT Price FROM Price WHERE Type = @AppoinmentType";
                SqlCommand com = new SqlCommand(sqlSearch, con);
                com.Parameters.AddWithValue("@AppoinmentType", selectedType);

                using (SqlDataReader reader = com.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int price = reader.GetInt32(0); // Assuming Price is the first column
                        textBox4AppID.Text = price.ToString(); // Convert the int to string for display

                        int discount = 0; // No discount applied yet

                        int netTotal = price - discount;

                        // Add the details to the DataGridView
                        dataGridView1.Rows.Add(selectedType, price, discount, netTotal);

                        // Update total sum
                        totalSum += price;
                        ApplyDiscountAndCalculateNetTotal();
                    }
                    else
                    {
                        textBox4AppID.Text = "Price not found";
                    }
                }
            }
        }

        private void ApplyDiscountAndCalculateNetTotal()
        {
            int discount = 0;
            int netTotal = 0;

            // Calculate the discount if the total sum exceeds 15,000
            if (totalSum > 15000)
            {
                discount = (int)(totalSum * 0.15); // Calculate 15% discount
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int price = Convert.ToInt32(row.Cells["Price"].Value);

                // Adjust discount for this row proportionally based on the price
                int rowDiscount = (int)(price * discount / totalSum);
                int rowNetTotal = price - rowDiscount;

                row.Cells["Discount"].Value = rowDiscount;
                row.Cells["NetTotal"].Value = rowNetTotal;

                netTotal += rowNetTotal;
            }

            // Update text boxes with the calculated values
            textBox2.Text = totalSum.ToString();
            textBox3.Text = discount.ToString();
            textBox4.Text = netTotal.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=DESKTOP-RJARFIA;Initial Catalog=salon_system;Integrated Security=True";

            if (!int.TryParse(textBox2.Text, out int total))
            {
                MessageBox.Show("Please enter a valid number for Total.");
                return;
            }

            if (!int.TryParse(textBox3.Text, out int discount))
            {
                MessageBox.Show("Please enter a valid number for Discount.");
                return;
            }

            int netTotal = total - discount;

            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string currentTime = DateTime.Now.ToString("HH:mm:ss");

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string sqlGetMaxID = "SELECT ISNULL(MAX(InvoiceID), 0) + 1 FROM Invoice1";
                SqlCommand cmdGetMaxID = new SqlCommand(sqlGetMaxID, con);
                int newID = Convert.ToInt32(cmdGetMaxID.ExecuteScalar());

                textBox1.Text = newID.ToString();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Type"].Value != null && row.Cells["Price"].Value != null)
                    {
                        string sqlInsert = "INSERT INTO Invoice1 (InvoiceID, Type, Price, Total, Discount, NetTotal, Date, Time) " +
                                           "VALUES (@InvoiceID, @Type, @Price, @Total, @Discount, @NetTotal, @Date, @Time)";
                        SqlCommand cmdInsert = new SqlCommand(sqlInsert, con);
                        cmdInsert.Parameters.AddWithValue("@InvoiceID", newID);
                        cmdInsert.Parameters.AddWithValue("@Type", row.Cells["Type"].Value.ToString());
                        cmdInsert.Parameters.AddWithValue("@Price", row.Cells["Price"].Value.ToString());
                        cmdInsert.Parameters.AddWithValue("@Total", row.Cells["Price"].Value.ToString());
                        cmdInsert.Parameters.AddWithValue("@Discount", row.Cells["Discount"].Value.ToString());
                        cmdInsert.Parameters.AddWithValue("@NetTotal", row.Cells["NetTotal"].Value.ToString());
                        cmdInsert.Parameters.AddWithValue("@Date", currentDate);
                        cmdInsert.Parameters.AddWithValue("@Time", currentTime);
                        cmdInsert.ExecuteNonQuery();

                        Form9 crys_report = new Form9(newID);
                        crys_report.Show();
                    }
                }

                MessageBox.Show("Data saved successfully!");

                try
                {
                    // Create and load the report
                    ReportDocument reportDocument = new ReportDocument();
                    reportDocument.Load(@"C:\Users\sadin\Downloads\WindowsFormsApp1\WindowsFormsApp1\InvoiceReport.rpt");

                    // Create a DataTable from the DataGridView
                    DataTable dt = CreateDataTableFromDataGridView();

                    // Set the report's data source
                    reportDocument.SetDataSource(dt);

                    // Create and setup the CrystalReportViewer
                    CrystalReportViewer reportViewer = new CrystalReportViewer
                    {
                        Dock = DockStyle.Fill,
                        ReportSource = reportDocument
                    };

                    // Add the viewer to the form
                    this.Controls.Add(reportViewer);
                    reportViewer.BringToFront();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                // Reset DataGridView and total sum
                dataGridView1.Rows.Clear();
                totalSum = 0;
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }

       

        private DataTable CreateDataTableFromDataGridView()
        {
            DataTable dt = new DataTable();

            // Add columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                dt.Columns.Add(column.HeaderText);
            }

            // Add rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                DataRow dr = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dr[cell.OwningColumn.HeaderText] = cell.Value;
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }

        // Other event handlers
        private void label9_Click(object sender, EventArgs e) { }

        private void label7_Click(object sender, EventArgs e) { }

        private void label8_Click(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 employeeForm = new Form4();
            employeeForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 employeeForm = new Form1();
            employeeForm.Show();
            this.Hide();
        }
    }
}
