using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLTV
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTK.Text == "" && txtMK.Text == "")
            {
                MessageBox.Show("Hãy nhập thông tin đăng nhập.");
            }
            else
            {
                if (txtTK.Text == "")
                {
                    MessageBox.Show("Hãy nhập tài khoản.");
                }
                if (txtMK.Text == "")
                {
                    MessageBox.Show("Hãy nhập Mật khẩu.");
                }
            }
            // chuỗi kết nối với sql
            String con_str = "Data Source = MSI\\SQLEXPRESS; Initial catalog = CNPM; User ID = sa; Password = sa123";
            String tk = txtTK.Text;
            String mk = txtMK.Text;
            // truy vấn
            String sql = "select count(*) from NguoiDung where TenDangNhap = @tk and Matkhau = @mk";
            string Doituong;
            int rs = 0;
            try
            {
                // kết nối
                 SqlConnection conn = new SqlConnection(con_str);
                // mở kế nối
                conn.Open();
                // tạo command đẻ thực hiện truy vấn 
                SqlCommand cmd = new SqlCommand(sql, conn);
                // tạo biến trong sql
                cmd.Parameters.Add(new SqlParameter("@tk", tk));
                cmd.Parameters.Add(new SqlParameter("@mk", mk));
                // lựa chọn kiểu thực thi truy vấn
                rs = (int)cmd.ExecuteScalar();
                conn.Close();

                if (rs == 1)
                {
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Đăng Nhập thành công! ");
                }
                else
                {
                    MessageBox.Show("Đăng Nhập Không thành công! ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("err : " + ex.Message);
            }
        }
    }
}
