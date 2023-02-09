using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace QLTV.Data
{
    class SanPham
    {
        private string _MaSanPham;
        private string _LoaiSanPham;
        private string _TenSanPham;
        private string _TrongLuongVang;
        private string _TrongLuongBac;
        private string _TrongLuongDa;
        private string _TongTrongLuong;
        private string _GiaNhap;
        private string _GiaBan;
        private string _TenXuongCheTac;
        private string _GhiChu;

        public SanPham()
        {
        }

        public SanPham(string MaSanPham, string LoaiSanPham, string TenSanPham, string TrongLuongVang, string TrongLuongBac, string TrongLuongDa, string TongTrongLuong, string GiaNhap, string GiaBan, string TenXuongCheTac, string GhiChu)
        {
            _MaSanPham = MaSanPham;
            _LoaiSanPham = LoaiSanPham;
            _TenSanPham = TenSanPham;
            _TrongLuongVang = TrongLuongVang;
            _TrongLuongBac = TrongLuongBac;
            _TrongLuongDa = TrongLuongDa;
            _TongTrongLuong = TongTrongLuong;
            _GiaNhap = GiaNhap;
            _GiaBan = GiaBan;
            _TenXuongCheTac = TenXuongCheTac;
            _GhiChu = GhiChu;
        }
        public SanPham(SqlDataReader rd)
        {
            _MaSanPham = rd["MaSanPham"].ToString();
            _LoaiSanPham = rd["LoaiSanPham"].ToString();
            _TenSanPham = rd["TenSanPham"].ToString();
            _TrongLuongVang = rd["TrongLuongVang"].ToString();
            _TrongLuongBac = rd["TrongLuongBac"].ToString();
            _TrongLuongDa = rd["TrongLuongDa"].ToString();
            _TongTrongLuong = rd["TongTrongLuong"].ToString();
            _GiaNhap = rd["GiaNhap"].ToString();
            _GiaBan = rd["GiaBan"].ToString();
            _TenXuongCheTac = rd["TenXuongCheTac"].ToString();
            _GhiChu = rd["GhiChu"].ToString();
        }
        public string MaSanPham { get => _MaSanPham; set => _MaSanPham = value; }
        public string LoaiSanPham { get => _LoaiSanPham; set => _LoaiSanPham = value; }
        public string TenSanPham { get => _TenSanPham; set => _TenSanPham = value; }
        public string TrongLuongVang { get => _TrongLuongVang; set => _TrongLuongVang = value; }
        public string TrongLuongBac { get => _TrongLuongBac; set => _TrongLuongBac = value; }
        public string TrongLuongDa { get => _TrongLuongDa; set => _TrongLuongDa = value; }
        public string TongTrongLuong { get => _TongTrongLuong; set => _TongTrongLuong = value; }
        public string GiaNhap { get => _GiaNhap; set => _GiaNhap = value; }
        public string GiaBan { get => _GiaBan; set => _GiaBan = value; }
        public string TenXuongCheTac { get => _TenXuongCheTac; set => _TenXuongCheTac = value; }
        public string GhiChu { get => _GhiChu; set => _GhiChu = value; }
    }   
}
