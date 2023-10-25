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

namespace bai1
{
    public partial class Form1 : Form
    {
        Ketnoi kn = new Ketnoi();
        SqlConnection connsql;
        public Form1()
        {
            InitializeComponent();
            connsql = kn.connect;
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed )
                {
                    connsql.Open();
                }
                string insertString;
                insertString = "insert into SinhVien values('" + txtMasv.Text + "', N'" + txtTensv.Text + "')";
                SqlCommand cmd = new SqlCommand(insertString, connsql);
                cmd.ExecuteNonQuery();
                if(connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                MessageBox.Show("Thanh cong");
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string updateString;
                updateString = "update SinhVien set tenSV = '" + txtTensv.Text +"' where maSV = '" + txtMasv.Text + "'";
                SqlCommand cmd = new SqlCommand(updateString, connsql);
                cmd.ExecuteNonQuery();
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                MessageBox.Show("Thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void LoadSV()
        {
            connsql.Open();
            string selectString = "select * from SinhVien";
            SqlCommand cmd = new SqlCommand(selectString, connsql);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd["maSV"].ToString());
                comboBox1.Items.Add(rd["tenSV"].ToString());
            }
            rd.Close();
            connsql.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string deleteString;
                deleteString = "delete SinhVien where maSV = '" + txtMasv.Text + "'";
                SqlCommand cmd = new SqlCommand(deleteString, connsql);
                cmd.ExecuteNonQuery();
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                MessageBox.Show("Thanh cong");
                Form1_Load(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
