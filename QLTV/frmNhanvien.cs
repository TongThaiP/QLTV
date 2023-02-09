using Intercom.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLTV
{
    public partial class frmNhanvien : Form
    {
        public frmNhanvien()
        {
            InitializeComponent();
        }
        public void getdata()
        {
            String con_str = "Data Source = MSI\\SQLEXPRESS; Initial catalog = CNPM; User ID = sa; Password = sa123";
            String sql = "select * from NhanVien order by MaNV";
            try
            {
                SqlConnection conn = new SqlConnection(con_str);
                //khởi tạo data set lưu dữ liệu
                DataSet rs = new DataSet();
                // tự quản lí mở kết nối
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(rs, "NhanVien");
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Close();
                dgvNhanVien.DataSource = rs.Tables["Nhanvien"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnThem.Enabled = false;
                txtmanv.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvNhanVien.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txtmanv.Text = row.Cells[0].Value.ToString();
                txttennv.Text = row.Cells[1].Value.ToString();
                txtsdt.Text = row.Cells[2].Value.ToString();
                txtemail.Text = row.Cells[3].Value.ToString();
                txtdiachi.Text = row.Cells[4].Value.ToString();
                txtquequan.Text = row.Cells[5].Value.ToString();
                datengaysinh.Text = row.Cells[6].Value.ToString();
                cbbgioitinh.Text = row.Cells[7].Value.ToString();
                txtdantoc.Text = row.Cells[8].Value.ToString();
                txtchucvu.Text = row.Cells[9].Value.ToString();
                txtluong.Text = row.Cells[10].Value.ToString();
                dtpngayvaocty.Text = row.Cells[11].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            String con_str = "Data Source = MSI\\SQLEXPRESS; Initial catalog = CNPM; User ID = sa; Password = sa123";
            String sql = "select * from NhanVien order by MaNV";
            try
            {
                SqlConnection conn = new SqlConnection(con_str);
                //khởi tạo data set lưu dữ liệu
                DataSet rs = new DataSet();
                // tự quản lí mở kết nối
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(rs, "NhanVien");
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Close();
                dgvNhanVien.DataSource = rs.Tables["Nhanvien"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try 
            { 
                String con_str = "Data Source = MSI\\SQLEXPRESS; Initial catalog = CNPM; User ID = sa; Password = sa123";              
                SqlConnection conn = new SqlConnection(con_str);
                conn.Open();
                // Bước 3: Tạo truy vấn
                string MaNV = txtmanv.Text;
                string TenNV = txttennv.Text;
                string SDT = txtsdt.Text;
                string Email = txtemail.Text;
                string DiaChi = txtdiachi.Text;
                string QueQuan = txtquequan.Text;
                DateTime NgaySinh = datengaysinh.Value;
                string GioiTinh = cbbgioitinh.Text;
                string DanToc = txtdantoc.Text;
                string ChucVu = txtchucvu.Text;
                string Luong = txtluong.Text;
                DateTime NgayVao = dtpngayvaocty.Value;
                string query = "update NhanVien set SDT=@SDT, NgayVaoCongty=@NgayVao, Luong=@Luong, ChucVu=@ChucVu, TenNV=@TenNV, Email=@Email, DanToc=@DanToc, DiaChi=@DiaChi, QueQuan=@QueQuan, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh where MaNV=@MaNV";
                SqlCommand cmd = new SqlCommand(query, conn); 
                // Bước 4: Thực thi truy vấn )
                cmd.Parameters.Add(new SqlParameter("@MaNV", MaNV));
                cmd.Parameters.Add(new SqlParameter("@TenNV", TenNV));
                cmd.Parameters.Add(new SqlParameter("@SDT", SDT));
                cmd.Parameters.Add(new SqlParameter("@Email", Email));
                cmd.Parameters.Add(new SqlParameter("@DiaChi", DiaChi));
                cmd.Parameters.Add(new SqlParameter("@QueQuan", QueQuan));
                cmd.Parameters.Add(new SqlParameter("@NgaySinh", NgaySinh));
                cmd.Parameters.Add(new SqlParameter("@GioiTinh", GioiTinh));
                cmd.Parameters.Add(new SqlParameter("@DanToc", DanToc));
                cmd.Parameters.Add(new SqlParameter("@ChucVu", ChucVu));
                cmd.Parameters.Add(new SqlParameter("@Luong", Luong));
                cmd.Parameters.Add(new SqlParameter("@NgayVao", NgayVao));
                cmd.ExecuteNonQuery();
                // Bước 5: Đóng kết nối
                conn.Close();
                MessageBox.Show("Sửa thông tin sản phẩm thành công!");
                // Load lại dữ liệu trên GridView
                getdata();
                cleartext();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string con_str = "Data Source=MSI\\SQLEXPRESS; Initial Catalog=CNPM; User ID=sa; Password=sa123;";
                SqlConnection conn = new SqlConnection(con_str);
                // Bước 2: Mở kết nối
                conn.Open();
                // Bước 3: Tạo truy vấn
                string MaNV = txtmanv.Text;
                string query = "DELETE NhanVien where MaNV=@MaNV";
                // Bước 4: Thực thi truy vấn )
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@MaNV", MaNV));
                cmd.ExecuteNonQuery();
                // Bước 5: Đóng kết nối
                conn.Close();
                MessageBox.Show("Xóa sản phẩm thành công!");
                // Load lại dữ liệu trên GridView
                getdata();
                cleartext();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            getdata();
        }
        public void cleartext()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtmanv.Enabled = true;
            txtmanv.Text = "";
            txttennv.Text = "";
            txtdiachi.Text = "";
            txtquequan.Text = "";
            datengaysinh.Text = "";
            txtdantoc.Text = "";
            txtemail.Text = "";
            txtluong.Text = "";
            txtsdt.Text = "";
            txtchucvu.Text = "";
            dtpngayvaocty.Text = "";
            cbbgioitinh.Text = "";
        }
    }
}
