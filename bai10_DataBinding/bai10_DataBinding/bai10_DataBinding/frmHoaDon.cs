using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace bai10_DataBinding
{
    public partial class frmHoaDon : Form
    {
        string cnStr = "";
        //string ins = "";
        

        SqlConnection cn;
        DataSet ds;
        DataTable orders;
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
           
            cnStr = ConfigurationManager.ConnectionStrings["cnStr"].ConnectionString;
            cn = new SqlConnection(cnStr);
            //string sql = "SELECT * FROM CTHD WHERE MaHD ='" +comboBox1.Text+"'";
           // dataGridView1.DataSource = GetHoaDonDataset(sql).Tables[0];            

            //hien thi thong tin hoa don tren textbox bang cach chon 1 combobox
            string sql = "SELECT * FROM HoaDon";
            orders = GetHoaDonDataset(sql).Tables[0];

            cboHoaDon.DataSource = orders;
            cboHoaDon.DisplayMember = "MaHD";
            cboHoaDon.ValueMember = "MaHD";

            txtMaKH.DataBindings.Add("Text",orders, "MaKH");
            txtMaNV.DataBindings.Add("Text",orders, "MaNV");

             
            dtpNgayLapHD.DataBindings.Add("Text",orders, "NgayLapHD");
            dtpNgayGiaoHang.DataBindings.Add("Text",orders, "NgayGiaoHang");
        }
        private DataSet GetHoaDonDataset(string sql)
        {
            try
            {
               // string sql = "SELECT * FROM CTHD";
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                ds = new DataSet();
                da.Fill(ds);
                //dataGridView1.DataSource = ds.Tables[2];
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
                //throw;
            }
            finally
            {
                cn.Close();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
           /*string ins = @"INSERT INTO HoaDon (MaHD, MaKH, MaNV, NgayLapHD, NgayGiaoHang) ";
           
           SqlDataAdapter da = new SqlDataAdapter();
           SqlCommand cmd = new SqlCommand(ins, cn);

           cmd.Parameters.Add("@MaHD", comboBox1.Text);
           cmd.Parameters.Add("@MaKH", txtMaKH.Text);
           cmd.Parameters.Add("@MaNV", txtMaNV);
           

           da.DeleteCommand = cmd;
           da.Update(ds);

           MessageBox.Show("xoa thanh cong ");*/
        }

        private void cboHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql1 = "SELECT * FROM CTHD WHERE MaHD='" + cboHoaDon.Text + "'";
            dataGridView1.DataSource = GetHoaDonDataset(sql1).Tables[0];
        }

        
    }
}
