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
    public partial class frmSanpham : Form
    {
        public frmSanpham()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnThem.Enabled = false;
                txtmasp.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvSanPham.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txtmasp.Text = row.Cells[0].Value.ToString();
                txtloaisp.Text = row.Cells[1].Value.ToString();
                txttensp.Text = row.Cells[2].Value.ToString();
                txttlvang.Text = row.Cells[3].Value.ToString();
                txttlbac.Text = row.Cells[4].Value.ToString();
                txttlda.Text = row.Cells[5].Value.ToString();
                txtttl.Text = row.Cells[6].Value.ToString();
                txtgianhap.Text = row.Cells[7].Value.ToString();
                txtgiaban.Text = row.Cells[8].Value.ToString();
                txtxuatxu.Text = row.Cells[9].Value.ToString();
                txtghichu.Text = row.Cells[10].Value.ToString();
            }
        }
        public void getdata()
        {
            List<Data.SanPham> lst = new List<Data.SanPham>();
            try
            {
                // Bước 1: Khởi tạo kết nối
                string con_str = "Data Source=MSI\\SQLEXPRESS; Initial Catalog=CNPM; User ID=sa; Password=sa123;";
                SqlConnection conn = new SqlConnection(con_str);
                // Bước 2: Mở kết nối
                conn.Open();
                // Bước 3: Tạo truy vấn
                string query = "select * from SanPham";
                // Bước 4: Thực thi truy vấn
                SqlCommand cmd = new SqlCommand(query, conn);
                // -- lựa chọn phương thức thực thi phù hợp
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Data.SanPham obj = new Data.SanPham(rd);
                    lst.Add(obj);
                }
                // Bước 5: Đóng kết nối
                conn.Close();
                // Hiển thị dữ liệu của List lên DataGridView
                dgvSanPham.DataSource = lst;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message);
            }
        }
        private void frmSanpham_Load(object sender, EventArgs e)
        {
            getdata();
            cleartext();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Data.SanPham> lst = new List<Data.SanPham>();
            try
            {
                // Bước 1: Khởi tạo kết nối
                string con_str = "Data Source=MSI\\SQLEXPRESS; Initial Catalog=CNPM; User ID=sa; Password=sa123;";
                SqlConnection conn = new SqlConnection(con_str);
                // Bước 2: Mở kết nối
                conn.Open();
                // Bước 3: Tạo truy vấn
                string tk = txtTK.Text;
                string query = "select * from SanPham where TenSanPham LIKE '%' + @tk + '%' or  MaSanPham LIKE '%' + @tk + '%' or  LoaiSanPham LIKE '%' + @tk + '%' or  TrongLuongVang LIKE '%' + @tk + '%' or  TrongLuongBac LIKE '%' + @tk + '%' or  TrongLuongDa LIKE '%' + @tk + '%' or  TongTrongLuong LIKE '%' + @tk + '%' or  GiaNhap LIKE '%' + @tk + '%' or  GiaBan LIKE '%' + @tk + '%' or  TenXuongCheTac LIKE '%' + @tk + '%' or  GhiChu LIKE '%' + @tk + '%'";
                // Bước 4: Thực thi truy vấn
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@tk", tk));
                // -- lựa chọn phương thức thực thi phù hợp
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Data.SanPham obj = new Data.SanPham(rd);
                    lst.Add(obj);
                }
                // Bước 5: Đóng kết nối
                conn.Close();
                // Hiển thị dữ liệu của List lên DataGridView
                dgvSanPham.DataSource = lst;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtmasp.Text.Length == 0)
            {
                MessageBox.Show("Hãy điền mã sản phẩm.");
            }
            else if(txtmasp.Text.Length != 0)
            {
                try
                {
                    // Bước 1: Khởi tạo kết nối
                    string con_str = "Data Source=MSI\\SQLEXPRESS; Initial Catalog=CNPM; User ID=sa; Password=sa123;";
                    SqlConnection conn = new SqlConnection(con_str);
                    // Bước 2: Mở kết nối
                    conn.Open();
                    // Bước 3: Tạo truy vấn
                    string MaSP = txtmasp.Text;
                    string LoaiSP = txtloaisp.Text;
                    string TenSP = txttensp.Text;
                    string TLVang = txttlvang.Text;
                    string TLBac = txttlbac.Text;
                    string TLDa = txttlda.Text;
                    string TongTL = txtttl.Text;
                    string GiaNhap = txtgianhap.Text;
                    string GiaBan = txtgiaban.Text;
                    string TenXuongCheTac = txtxuatxu.Text;
                    string GhiChu = txtghichu.Text;
                    string query = "Insert into SanPham (MaSanPham, LoaiSanPham, TenSanPham, TrongLuongVang, TrongLuongBac, TrongLuongDa, TongTrongLuong, GiaNhap, GiaBan, TenXuongCheTac, GhiChu)VALUES(@MaSP, @LoaiSP, @TenSP, @TLVang, @TLBac, @TLDa, @TongTL, @GiaNhap, @GiaBan, @TenXuongCheTac, @GhiChu)";
                    // Bước 4: Thực thi truy vấn 
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add(new SqlParameter("@MaSP", MaSP));
                    cmd.Parameters.Add(new SqlParameter("@LoaiSP", LoaiSP));
                    cmd.Parameters.Add(new SqlParameter("@TenSP", TenSP));
                    cmd.Parameters.Add(new SqlParameter("@TLVang", TLVang));
                    cmd.Parameters.Add(new SqlParameter("@TLBac", TLBac));
                    cmd.Parameters.Add(new SqlParameter("@TLDa", TLDa));
                    cmd.Parameters.Add(new SqlParameter("@TongTL", TongTL));
                    cmd.Parameters.Add(new SqlParameter("@GiaNhap", GiaNhap));
                    cmd.Parameters.Add(new SqlParameter("@GiaBan", GiaBan));
                    cmd.Parameters.Add(new SqlParameter("@TenXuongCheTac", TenXuongCheTac));
                    cmd.Parameters.Add(new SqlParameter("@GhiChu", GhiChu));
                    cmd.ExecuteNonQuery();
                    // Bước 5: Đóng kết nối
                    conn.Close();
                    MessageBox.Show("Thêm mới thành công!");
                    // Load lại dữ liệu trên GridView
                    getdata();
                    cleartext();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Bước 1: Khởi tạo kết nối
                string con_str = "Data Source=MSI\\SQLEXPRESS; Initial Catalog=CNPM; User ID=sa; Password=sa123;";
                SqlConnection conn = new SqlConnection(con_str);
                // Bước 2: Mở kết nối
                conn.Open();
                // Bước 3: Tạo truy vấn
                string MaSP = txtmasp.Text;
                string LoaiSP = txtloaisp.Text;
                string TenSP = txttensp.Text;
                string TLVang = txttlvang.Text;
                string TLBac = txttlbac.Text;
                string TLDa = txttlda.Text;
                string TongTL = txtttl.Text;
                string GiaNhap = txtgianhap.Text;
                string GiaBan = txtgiaban.Text;
                string TenXuongCheTac = txtxuatxu.Text;
                string GhiChu = txtghichu.Text;
                string query = "update SanPham set LoaiSanPham=@LoaiSP, TenSanPham=@TenSP, TrongLuongVang=@TLVang, TrongLuongBac=@TLBac, TrongLuongDa=@TLDa, TongTrongLuong=@TongTL, GiaNhap=@GiaNhap, GiaBan=@GiaBan, TenXuongCheTac=@TenXuongCheTac, GhiChu=@GhiChu where MaSanPham=@MaSP";
                // Bước 4: Thực thi truy vấn )
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@MaSP", MaSP));
                cmd.Parameters.Add(new SqlParameter("@LoaiSP", LoaiSP));
                cmd.Parameters.Add(new SqlParameter("@TenSP", TenSP));
                cmd.Parameters.Add(new SqlParameter("@TLVang", TLVang));
                cmd.Parameters.Add(new SqlParameter("@TLBac", TLBac));
                cmd.Parameters.Add(new SqlParameter("@TLDa", TLDa));
                cmd.Parameters.Add(new SqlParameter("@TongTL", TongTL));
                cmd.Parameters.Add(new SqlParameter("@GiaNhap", GiaNhap));
                cmd.Parameters.Add(new SqlParameter("@GiaBan", GiaBan));
                cmd.Parameters.Add(new SqlParameter("@TenXuongCheTac", TenXuongCheTac));
                cmd.Parameters.Add(new SqlParameter("@GhiChu", GhiChu));
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
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Bước 1: Khởi tạo kết nối
                string con_str = "Data Source=MSI\\SQLEXPRESS; Initial Catalog=CNPM; User ID=sa; Password=sa123;";
                SqlConnection conn = new SqlConnection(con_str);
                // Bước 2: Mở kết nối
                conn.Open();
                // Bước 3: Tạo truy vấn
                string MaSP = txtmasp.Text;
                string query = "DELETE SanPham where MaSanPham=@MaSP";
                // Bước 4: Thực thi truy vấn )
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@MaSP", MaSP));
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
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cleartext();
        }
        public void cleartext()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtmasp.Enabled = true;
            txtmasp.Text="";
            txtloaisp.Text="";
            txttensp.Text="";
            txttlvang.Text="";
            txttlbac.Text="";
            txttlda.Text = "";
            txtttl.Text="";
            txtgianhap.Text="";
            txtgiaban.Text="";
            txtxuatxu.Text="";
            txtghichu.Text="";
        }
    }
}
