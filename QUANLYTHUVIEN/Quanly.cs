using QUANLYTHUVIEN.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYTHUVIEN
{
    public partial class Quanly : Form
    {
        ThuvienDBContext db = new ThuvienDBContext();
        public Quanly()
        {
            InitializeComponent();
            Timkiemsach();
            Timkiem();
            suanhanvien();
            xoanhanvien();
            Timkiemnhanvien();
        }
        //combobox gioitinh
        private void Quanly_Load(object sender, EventArgs e)
        {
            cmgioitinh.Items.Add("Nam");
            cmgioitinh.Items.Add("Nữ");
            cmgioitinh.Items.Add("Khác");
            List<LOAITAIKHOAN> listloaitaikhoan = db.LOAITAIKHOAN.ToList();
            xuatcombobox(listloaitaikhoan);
            List<TAIKHOAN> listtaikhoan = db.TAIKHOAN.ToList();
            Danhsachtaikhoan(listtaikhoan);
            List<PHIEUMUONSACH> listmuon = db.PHIEUMUONSACH.ToList();
            danhsachmuon(listmuon);
        }
        void xuatcombobox( List<LOAITAIKHOAN> listloaitaikhoan)
        {
            this.cmtypetaikhoan.DataSource = listloaitaikhoan;
            this.cmtypetaikhoan.ValueMember = "MALOAI";
        }
        //Tra cứu/ thống kê sách
        private void danhsach(List<SACH> listSach)
        {

            DataTable table = new DataTable();
            table.Columns.Add("Mã sách");
            table.Columns.Add("Tên sách");
            table.Columns.Add("Tên tác giả");
            table.Columns.Add("Giá(VNĐ)");
            table.Columns.Add("Năm xuất bản");
            table.Columns.Add("Nhà xuất bản");
            table.Columns.Add("Tình trạng sách");
            table.Columns.Add("Ngày nhập sách");
            table.Columns.Add("Số lượng");
            for (int i = 0; i < listSach.Count; i++)
            {
                SACH sach1 = listSach[i];
                table.Rows.Add(new String[]
                {
                    sach1.MASACH, sach1.TENSACH, sach1.TENTACGIA,sach1.GIA.ToString(), sach1.NAMXUATBAN.ToString(), sach1.NHAXUATBAN, sach1.TINHTRANGSACH, sach1.NGAYNHAPSACH.ToString(), sach1.SOLUONG.ToString()
                });
            }
            dtgvsach.DataSource = table;
        }
        void Timkiemsach()
        {
            try
            {
                List<SACH> listsach = db.SACH.ToList();
                List<SACH> list = new List<SACH>();
                for (int i = 0; i < listsach.Count; i++)
                {
                    SACH sach = listsach[i];
                    if (sach.TENSACH.ToLower().Contains(txttimsach.Text) || sach.MASACH.ToLower().Contains(txttimsach.Text))
                    {
                        list.Add(sach);
                    }
                }
                danhsach(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btntimsach_Click(object sender, EventArgs e)
        {
            Timkiemsach();
        }
        //Sách đã mượn
         void danhsachmuon(List<PHIEUMUONSACH> listmuon)
        {
            DataTable tbmuon = new DataTable();
            tbmuon.Columns.Add("STT");
            tbmuon.Columns.Add("Mã độc giả");
            tbmuon.Columns.Add("Mã sách");
            tbmuon.Columns.Add("Ngày mượn sách");
            tbmuon.Columns.Add("Ngày trả");
            tbmuon.Columns.Add("Số lượng");
            tbmuon.Columns.Add("Mã nhân viên");
            int STT = 1;
            for (int i = 0; i < listmuon.Count; i++, STT++)
            {
                PHIEUMUONSACH phieumuon = listmuon[i];
                tbmuon.Rows.Add(new String[]
                {
                    STT.ToString(), phieumuon.MADOCGIA, phieumuon.MASACH, phieumuon.NGAYMUONSACH.ToString(), phieumuon.NGAYTRA.ToString(), phieumuon.SOLUONGMUON.ToString(), phieumuon.MANHANVIEN
                });
            }
            dtgvsachmuon.DataSource = tbmuon;
        }
        //Sách quá hạn
        //Thông tin độc giả
        private void Danhsachdocgia(List<DOCGIA> listdocgia)
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("Mã độc giả");
            table1.Columns.Add("Tên độc giả");
            table1.Columns.Add("Ngày sinh");
            table1.Columns.Add("Ngày lập thẻ");
            table1.Columns.Add("Ngày hết hạn");
            table1.Columns.Add("Địa chỉ");
            table1.Columns.Add("Email");
            table1.Columns.Add("Giới tính");
            table1.Columns.Add("Phí gia hạn thẻ");
            for (int i = 0; i < listdocgia.Count; i++)
            {
                DOCGIA docgia = listdocgia[i];
                table1.Rows.Add(new String[]
                   {
                       docgia.MADOCGIA, docgia.TENDOCGIA, docgia.NGAYSINH.ToString(),
                       docgia.NGAYLAPTHE.ToString(), docgia.NGAYHETHAN.ToString(), docgia.DIACHI, docgia.EMAIL, docgia.GIOITINH, docgia.PHIGIAHANTHE.ToString()
                   });
            }
            dtgvthongtindocgia.DataSource = table1;
        }
        //timkiem
        void Timkiem()
        {
            try
            {
                List<DOCGIA> dsdocgia = db.DOCGIA.ToList();
                List<DOCGIA> list = new List<DOCGIA>();
                for (int i = 0; i < dsdocgia.Count; i++)
                {
                    DOCGIA dg = dsdocgia[i];
                    if (dg.MADOCGIA.ToLower().Contains(txttracuudocgia.Text) || dg.TENDOCGIA.ToLower().Contains(txttracuudocgia.Text))
                    {
                        list.Add(dg);
                    }
                }
                Danhsachdocgia(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            Timkiem();
        }
        //Quản lý nhân viên
            private void danhsachnhanvien(List<NHANVIEN> listnhanvien)
        {
            DataTable n = new DataTable();
            n.Columns.Add("Mã nhân viên");
            n.Columns.Add("Họ và tên");
            n.Columns.Add("Chức vụ");
            n.Columns.Add("Ngày vào làm");
            n.Columns.Add("Ngày sinh");
            n.Columns.Add("Giới tính");
            n.Columns.Add("Địa chỉ");
            n.Columns.Add("Số ĐT");
            for (int i = 0; i <listnhanvien.Count; i++)
            {
                NHANVIEN nv = listnhanvien[i];
                n.Rows.Add(new String[]
                {
                    nv.MANHANVIEN, nv.TENNHANVIEN, nv.CHUCVU, nv.NGAYVAOLAM.ToString(), nv.NGAYSINH.ToString("dd/MM/yyy"), nv.GIOITINH, nv.DIACHI, nv.SDT.ToString()
                });
            }
            dtgvnhanvien.DataSource = n;
        }
        //---------------------------------Thêm nhân viên--------------------------------------
        void themnhanvien()
        {
            NHANVIEN n1 = new NHANVIEN();
            DateTime dt = DateTime.Now;
            n1.MANHANVIEN = txtmanhanvien.Text;
            n1.TENNHANVIEN = txttennhanvien.Text;
            n1.CHUCVU = txtchucvu.Text;
            n1.NGAYVAOLAM = DateTime.Now;
            n1.NGAYSINH = Convert.ToDateTime(dateTimengaysinh.Text);
            n1.GIOITINH = cmgioitinh.Text;
            n1.DIACHI = txtdiachinv.Text;
            n1.SDT = Convert.ToInt32(txtsdt.Text);
            db.NHANVIEN.Add(n1);
            db.SaveChanges();
            danhsachnhanvien(db.NHANVIEN.ToList());
        }
        private void btnthemnhanvien_Click(object sender, EventArgs e)
        {
            themnhanvien();
        }
        //---------------------------------Sửa nhân viên---------------------------------------
        void suanhanvien()
        {
            NHANVIEN n2 = db.NHANVIEN.FirstOrDefault(a => a.MANHANVIEN == txtmanhanvien.Text);
            if (n2 != null)
            {
                n2.TENNHANVIEN = txttennhanvien.Text;
                n2.CHUCVU = txtchucvu.Text;
                n2.NGAYVAOLAM = Convert.ToDateTime(dateTimengayvaolam.Text);
                n2.NGAYSINH = Convert.ToDateTime(dateTimengaysinh.Text);
                n2.GIOITINH = cmgioitinh.Text;
                n2.DIACHI = txtdiachinv.Text;
                n2.SDT = Convert.ToInt32(txtsdt.Text);
                db.SaveChanges();
            }
            danhsachnhanvien(db.NHANVIEN.ToList());
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            suanhanvien();
        }
        //---------------------------------Xoa nhân viên---------------------------------------

        void xoanhanvien()
        {
            NHANVIEN n3 = db.NHANVIEN.FirstOrDefault(a => a.MANHANVIEN == txtmanhanvien.Text);
            if (n3 != null)
            {
                db.NHANVIEN.Remove(n3);
                db.SaveChanges();
            }
            danhsachnhanvien(db.NHANVIEN.ToList());
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            xoanhanvien();
        }
        //Tìm kiếm nhân viên
        void Timkiemnhanvien()
        {
            try
            {
                List<NHANVIEN> dsnhanvien = db.NHANVIEN.ToList();
                List<NHANVIEN> list = new List<NHANVIEN>();
                for (int i = 0; i < dsnhanvien.Count; i++)
                {
                    NHANVIEN nv1 = dsnhanvien[i];
                    if (nv1.MANHANVIEN.ToLower().Contains(txttim.Text) || nv1.TENNHANVIEN.ToLower().Contains(txttim.Text))
                    {
                        list.Add(nv1);
                    }
                }
                danhsachnhanvien(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            Timkiemnhanvien();
        }
        //Thông tin tài khoản
        void Danhsachtaikhoan(List<TAIKHOAN> listtaikhoan)
        {
            DataTable taikhoan1 = new DataTable();
            taikhoan1.Columns.Add("Tên đăng nhập");
            taikhoan1.Columns.Add("Tên hiển thị");
            taikhoan1.Columns.Add("Loại tài khoản");
            for (int i = 0; i < listtaikhoan.Count; i++)
            {
                TAIKHOAN taikhoan = listtaikhoan[i];
                taikhoan1.Rows.Add(new String[]
                   {
                       taikhoan.TENDANGNHAP, taikhoan.TENHIENTHI, taikhoan.MALOAI
                   });
            }
            dtgvTAIKHOAN.DataSource = taikhoan1;
        }
        //----------------------------------Thêm----------------------------------
        void themtaikhoan()
        {
            TAIKHOAN t2 = new TAIKHOAN();
            t2.TENHIENTHI = txttenhienthi.Text;
            t2.TENDANGNHAP = txttendangnhap.Text;
            t2.MALOAI = cmtypetaikhoan.Text;
            t2.MATKHAU = MD5Encrypt(txtmatkhaumoi.Text);
            t2.XACNHANMATKHAU = MD5Encrypt(txtxacnhanmatkhau.Text);
            db.TAIKHOAN.Add(t2);
            db.SaveChanges();
            Danhsachtaikhoan(db.TAIKHOAN.ToList());
        }
        private void btnthemtk_Click(object sender, EventArgs e)
        {

        }
        private string MD5Encrypt(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; ++i)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }

        private void btnthemtk_Click_1(object sender, EventArgs e)
        {
            if (txtmatkhaumoi.ToString() == txtxacnhanmatkhau.ToString())
            {
                themtaikhoan();
                MessageBox.Show("Thêm tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng xác nhận lại mật khẩu!");
            }
        }

        private void btnxoatk_Click(object sender, EventArgs e)
        {
            Xoataikhoan xoa = new Xoataikhoan();
            this.Hide();
            xoa.ShowDialog();
            this.Show();
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            Danhsachtaikhoan(db.TAIKHOAN.ToList());
        }

        private void btndoimatkhautk_Click(object sender, EventArgs e)
        {
            Thongtintaikhoan t = new Thongtintaikhoan();
            this.Hide();
            t.ShowDialog();
            this.Show();
        }

        private void btnthoatchinhsuasach_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnthoatquanlythe4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thoatthongtintk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

