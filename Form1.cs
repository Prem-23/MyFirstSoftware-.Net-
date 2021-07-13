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

namespace EmployeesDatails
{
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection("Data Source = DESKTOP-LQMCU8S; Database = EmployeeDetails; Integrated Security = true");
        public Form1()
        {
            InitializeComponent();
        }

        //Add
        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand("insert into Details values('"+richTextBox1.Text+ "','" + richTextBox2.Text + "','" + richTextBox3.Text + "','" + richTextBox4.Text + "')", connect);
            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Added");
            richTextBox1.Text = " ";
            richTextBox2.Text = " ";
            richTextBox3.Text = " ";
            richTextBox4.Text = " ";
        }

        //View
        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from Details where Employee_ID = '" + richTextBox1.Text + "'", connect);
            SqlDataReader dataRead = cmd.ExecuteReader();
            if (dataRead.Read())
            {
                richTextBox2.Text = dataRead.GetString(1);
                richTextBox3.Text = dataRead.GetValue(2).ToString(); 
                richTextBox4.Text = dataRead.GetValue(3).ToString();
            }
            else
            {
                MessageBox.Show("No Data");
            }
            connect.Close();
        }

        //Update
        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand("update Details set Salary = '" + richTextBox3.Text + "' where Employee_ID = '" + richTextBox1.Text + "'", connect);
            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Updtaed");
        }

        //Overall
        private void button4_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from Details", connect);
            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
            DataTable Dt = new DataTable();
            dataAdapt.Fill(Dt);
            dataGridView1.DataSource = Dt;
            connect.Close();
        }

        //Delete
        private void button5_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand("delete from Details where Employee_ID = '" + richTextBox1.Text + "'", connect);
            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Deleted");
        }

        //Clear
        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
        }
    }
}
