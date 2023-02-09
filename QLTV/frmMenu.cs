using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            DialogResult rs = frm.ShowDialog();
            if (rs != DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSanpham sp = new frmSanpham();
            sp.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanvien nv = new frmNhanvien();
            nv.ShowDialog();
        }

        private void ngàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTKNgay tkn = new frmTKNgay();
            tkn.ShowDialog();
        }

        private void thángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTKThang tkt = new frmTKThang();
            tkt.ShowDialog();
        }

        private void nămToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTKNam tknam = new frmTKNam();
            tknam.ShowDialog();
        }

        private void tTXưởngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXuong ttx = new frmXuong();
            ttx.ShowDialog();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDon hd = new frmHoaDon();
            hd.ShowDialog();
        }
    }
}
