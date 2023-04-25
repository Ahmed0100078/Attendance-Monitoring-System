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

namespace Military_Info
{
    public partial class RECInstitute : Form
    {
        public RECInstitute()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-868PQUK6\SQLEXPRESS;Initial Catalog=Military;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Mili values (@ID,@Name,@Rank,@Course,@CourseID,@date)", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Rank", textBox3.Text);
            cmd.Parameters.AddWithValue("@Course", textBox4.Text);
            cmd.Parameters.AddWithValue("@CourseID", textBox5.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToString());


            cmd.ExecuteNonQuery();


            con.Close();
            MessageBox.Show("Inserted Sucessfully");
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-868PQUK6\SQLEXPRESS;Initial Catalog=Military;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Mili set Name=@Name where ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Rank", textBox3.Text);
            cmd.Parameters.AddWithValue("@Course", textBox4.Text);
            cmd.Parameters.AddWithValue("@CourseID", textBox5.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToString());

            cmd.ExecuteNonQuery();


            con.Close();
            MessageBox.Show("Updated Sucessfully");
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-868PQUK6\SQLEXPRESS;Initial Catalog=Military;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Mili where ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();


            con.Close();
            MessageBox.Show("Item deleted Sucessfully");
            refresh();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-868PQUK6\SQLEXPRESS;Initial Catalog=Military;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Mili where ID=@ID", con);
            cmd.Parameters.AddWithValue("ID", int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-868PQUK6\SQLEXPRESS;Initial Catalog=Military;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Mili where CourseID=@CourseID", con);
            cmd.Parameters.AddWithValue("CourseID", int.Parse(textBox5.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void refresh()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-868PQUK6\SQLEXPRESS;Initial Catalog=Military;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Mili", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
