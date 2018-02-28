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

namespace Emlak
{
    public partial class Form2 : Form
    {
        SqlConnection conn;
        public Form2()
        {
            InitializeComponent();
        }
        //when form loaded,Sql connection will start.

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("Server = .; Database = HOTEL; Trusted_Connection = TRUE;");
            

        }
        //Button 1 will show database.
        private void button1_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Müsteri", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Müsteri");
            dataGridView1.DataSource = ds.Tables["Müsteri"];
            conn.Close();

        }
        //Button 2 will edit table.
        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("INSERT INTO Müsteri (id,Ad,Soyad,OdaNo,GirisTarih,Telefon,Hesap,CikisTarih)" +
                "VALUES(@id,@name,@lastName,@roomNum,@enteredDate,@telephone,@bill,@releaseDate)", conn);

            command.Parameters.AddWithValue("@id", textBox1.Text);
            command.Parameters.AddWithValue("@name", textBox2.Text);
            command.Parameters.AddWithValue("@lastName", textBox3.Text);
            command.Parameters.AddWithValue("@roomNum", textBox4.Text);
            command.Parameters.AddWithValue("@enteredDate", dateTimePicker1.Value);
            command.Parameters.AddWithValue("@telephone", textBox5.Text);
            command.Parameters.AddWithValue("@bill", textBox7.Text);
            command.Parameters.AddWithValue("@releaseDate", dateTimePicker2.Value);
            command.ExecuteNonQuery();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();


            conn.Close();
        }
        // Button 3 delete Customers with "id" on database. id must select because of primary key.
        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Müsteri WHERE id = @id ", conn);
            command.Parameters.AddWithValue("@id", textBox1.Text);
            command.ExecuteNonQuery();
            textBox1.Clear();
            conn.Close();

        }
        //if you faulty, that button will changed on colums.
        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("UPDATE Müsteri SET id = @id, Ad = @name, Soyad = @lastName, OdaNo = @roomNum, GirisTarih = @enteredDate, Telefon = @telephone, Hesap = @bill,CikisTarih = @releaseDate", conn);

            command.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[8].Value);
            command.Parameters.AddWithValue("@name", dataGridView1.CurrentRow.Cells[9].Value);
            command.Parameters.AddWithValue("@lastName", dataGridView1.CurrentRow.Cells[10].Value);
            command.Parameters.AddWithValue("@roomNum", dataGridView1.CurrentRow.Cells[11].Value);
            command.Parameters.AddWithValue("@enteredDate", dataGridView1.CurrentRow.Cells[12].Value);
            command.Parameters.AddWithValue("@telephone", dataGridView1.CurrentRow.Cells[13].Value);
            command.Parameters.AddWithValue("@bill", dataGridView1.CurrentRow.Cells[14].Value);
            command.Parameters.AddWithValue("@releaseDate", dataGridView1.CurrentRow.Cells[15].Value);

            command.ExecuteNonQuery();
            conn.Close();


        }
        //Find column with Name 
        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter name", "Please enter namefor find column", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            conn.Open();
            SqlDataAdapter da= new SqlDataAdapter("SELECT * FROM Müsteri WHERE Ad LIKE '%" + textBox2.Text + "%'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Müsteri WHERE Ad LIKE '%" + textBox2.Text + "%'");
            dataGridView1.DataSource= ds.Tables["Müsteri WHERE Ad LIKE '%" + textBox2.Text + "%'"];
            conn.Close();


        }
    }
}
