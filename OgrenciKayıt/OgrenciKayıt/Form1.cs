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
namespace OgrenciKayıt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-STVK19P4\\SQLEXPRESS;Initial Catalog=ogrenci;Integrated Security=True");
        private void verilerigöster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From ogrencikayit", baglan);
            SqlDataReader oku= komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();            
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["soyad"].ToString());
                ekle.SubItems.Add(oku["okulno"].ToString());
                ekle.SubItems.Add(oku["tc"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into ogrencikayit (id,ad,soyad,okulno,tc) values ('"+textBox5.Text.ToString()+"','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString()+"')",baglan);
           komut.ExecuteNonQuery();
            baglan.Close();
            verilerigöster();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }
        int id = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete From ogrencikayit where id = ("+ id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigöster();
        
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox5.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[4].Text;

        }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglan.Open();
   
            SqlCommand komut= new SqlCommand("select *from ogrencikayit where ad like'%" + textBox6.Text + "%' ", baglan);
            //like ->aradığım nesneye benzeyenler
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["soyad"].ToString());
                ekle.SubItems.Add(oku["okulno"].ToString());
                ekle.SubItems.Add(oku["tc"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Update ogrencikayit set id='"+textBox5.Text.ToString()+"',ad='"+textBox1.Text.ToString()+"',soyad='" +textBox2.Text.ToString()+ "',okulno='" + textBox3.Text.ToString() + "',tc='" + textBox4.Text.ToString()+"'where id=" + id +"",baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigöster();
        }
    }
}
