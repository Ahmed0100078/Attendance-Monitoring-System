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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-868PQUK6\SQLEXPRESS;Initial Catalog=Military;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Book values (@ID,@Name,@Cat,@from,@to,@date)", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Cat", textBox2.Text);
            cmd.Parameters.AddWithValue("@from", textBox3.Text);
            cmd.Parameters.AddWithValue("@to", textBox4.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToString());


            cmd.ExecuteNonQuery();


            con.Close();
            MessageBox.Show("Inserted Sucessfully");
            refresh();
        }

        public void refresh()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-868PQUK6\SQLEXPRESS;Initial Catalog=Military;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Book", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-868PQUK6\SQLEXPRESS;Initial Catalog=Military;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Book where ID=@ID", con);
            cmd.Parameters.AddWithValue("ID", int.Parse(textBox5.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-868PQUK6\SQLEXPRESS;Initial Catalog=Military;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Book where ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox5.Text));
            cmd.ExecuteNonQuery();


            con.Close();
            MessageBox.Show("Item deleted Sucessfully");
            refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-868PQUK6\SQLEXPRESS;Initial Catalog=Military;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Book set Name=@Name where ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Cat", textBox2.Text);
            cmd.Parameters.AddWithValue("@from", textBox3.Text);
            cmd.Parameters.AddWithValue("@to", textBox4.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToString());


            cmd.ExecuteNonQuery();


            con.Close();
            MessageBox.Show("Inserted Sucessfully");
            refresh();
        }
    }
}
