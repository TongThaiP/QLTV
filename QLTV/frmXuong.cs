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
    public partial class frmXuong : Form
    {
        public frmXuong()
        {
            InitializeComponent();
        }
        private void frmXuong_Load(object sender, EventArgs e)
        {
            getdata();
            cleartext();
        }
        public void getdata()
        {
            String con_str = "Data Source = MSI\\SQLEXPRESS; Initial catalog = CNPM; User ID = sa; Password = sa123";
            String sql = "select * from Xuong order by TenXuongCheTac";
            try
            {
                SqlConnection conn = new SqlConnection(con_str);
                //khởi tạo data set lưu dữ liệu
                DataSet rs = new DataSet();
                // tự quản lí mở kết nối
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(rs, "Xuong");
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Close();
                dgvXuong.DataSource = rs.Tables["Xuong"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string con_str = "Data Source=MSI\\SQLEXPRESS; Initial Catalog=CNPM; User ID=sa; Password=sa123;";
                SqlConnection conn = new SqlConnection(con_str);
                conn.Open();
                string tk = txtTK.Text;
                string sql = "select * from Xuong where TenXuongCheTac LIKE '%' + @tk + '%' or  TenChuXuong LIKE '%' + @tk + '%' or  SDT LIKE '%' + @tk + '%' or  DiaChi LIKE '%' + @tk + '%'";
                DataSet rs = new DataSet();                                             
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.Add(new SqlParameter("@tk", tk));
                da.Fill(rs, "TKXuong");
                dgvXuong.DataSource = rs.Tables["TKXuong"];
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
                txtTenXuong.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvXuong.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txtTenXuong.Text = row.Cells[0].Value.ToString();
                txtTenChuXuong.Text = row.Cells[1].Value.ToString();
                txtSDT.Text = row.Cells[2].Value.ToString();
                txtDiaChi.Text = row.Cells[3].Value.ToString();
            }
        }
        public void cleartext()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtTenXuong.Enabled = true;
            txtTenXuong.Text = "";
            txtTenChuXuong.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtTK.Text = "";
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            cleartext();
            getdata();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (txtTenXuong.Text.Length == 0)
            {
                MessageBox.Show("Hãy điền mã sản phẩm.");
            }
            else if (txtTenXuong.Text.Length != 0)
            {
                try
                {
                    // Bước 1: Khởi tạo kết nối
                    string con_str = "Data Source=MSI\\SQLEXPRESS; Initial Catalog=CNPM; User ID=sa; Password=sa123;";
                    SqlConnection conn = new SqlConnection(con_str);
                    // Bước 2: Mở kết nối
                    conn.Open();
                    // Bước 3: Tạo truy vấn
                    string TenXuong = txtTenXuong.Text;
                    string TenChuXuong = txtTenChuXuong.Text;
                    string SDT = txtSDT.Text;
                    string DiaChi = txtDiaChi.Text;
                    string query = "Insert into Xuong (TenXuongCheTac, TenChuXuong, SDT, DiaChi)VALUES(@TenXuong, @TenChuXuong, @SDT, @DiaChi)";
                    // Bước 4: Thực thi truy vấn 
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add(new SqlParameter("@TenXuong", TenXuong));
                    cmd.Parameters.Add(new SqlParameter("@TenChuXuong", TenChuXuong));
                    cmd.Parameters.Add(new SqlParameter("@SDT", SDT));
                    cmd.Parameters.Add(new SqlParameter("@DiaChi", DiaChi));
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

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Bước 1: Khởi tạo kết nối
                string con_str = "Data Source=MSI\\SQLEXPRESS; Initial Catalog=CNPM; User ID=sa; Password=sa123;";
                SqlConnection conn = new SqlConnection(con_str);
                // Bước 2: Mở kết nối
                conn.Open();
                // Bước 3: Tạo truy vấn
                string TenXuong = txtTenXuong.Text;
                string query = "DELETE Xuong where TenXuongCheTac=@TenXuong";
                // Bước 4: Thực thi truy vấn )
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@TenXuong", TenXuong));
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

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Bước 1: Khởi tạo kết nối
                string con_str = "Data Source=MSI\\SQLEXPRESS; Initial Catalog=CNPM; User ID=sa; Password=sa123;";
                SqlConnection conn = new SqlConnection(con_str);
                // Bước 2: Mở kết nối
                conn.Open();
                // Bước 3: Tạo truy vấn
                string TenXuong = txtTenXuong.Text;
                string TenChuXuong = txtTenChuXuong.Text;
                string SDT = txtSDT.Text;
                string DiaChi = txtDiaChi.Text;
                string query = "update Xuong set TenChuXuong=@TenChuXuong, SDT=@SDT, DiaChi=@DiaChi where TenXuongCheTac=@TenXuong";
                // Bước 4: Thực thi truy vấn )
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@TenXuong", TenXuong));
                cmd.Parameters.Add(new SqlParameter("@TenChuXuong", TenChuXuong));
                cmd.Parameters.Add(new SqlParameter("@SDT", SDT));
                cmd.Parameters.Add(new SqlParameter("@DiaChi", DiaChi));
                cmd.ExecuteNonQuery();
                // Bước 5: Đóng kết nối
                conn.Close();
                MessageBox.Show("Sửa thông tin xưởng thành công!");
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
}
