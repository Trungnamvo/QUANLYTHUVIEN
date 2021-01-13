using QUANLYTHUVIEN.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYTHUVIEN
{
    public partial class Cacchucnang : Form
    {
        ThuvienDBContext db = new ThuvienDBContext();
        public Cacchucnang()
        {
            InitializeComponent();
            xoasach();
            suathongtinsach();
            xoadocgia();
            suathongtindocgia();
            suathongtinmuonsach();
            trasachtheomasach();
            tracuu();
        }
        private void btndoimatkhautk_Click(object sender, EventArgs e)
        {
            Thongtintaikhoan t = new Thongtintaikhoan();
            this.Hide();
            t.ShowDialog();
            this.Show();
        }
        void xuatcombobox(List<SACH> listmasach, List<NHANVIEN> listnhanvien, List<DOCGIA> listdocgia, List<LOAITAIKHOAN> listloaitaikhoan, List<TAIKHOAN> listaikhoan)
        {
            this.cmmasach.DataSource = listmasach;
            this.cmmasach.ValueMember = "MASACH";
            this.cmmanhanvien.DataSource = listnhanvien;
            this.cmmanhanvien.ValueMember = "MANHANVIEN";
            this.cmmadocgia.DataSource = listdocgia;
            this.cmmadocgia.ValueMember = "MADOCGIA";
            this.cmtypetaikhoan.DataSource = listloaitaikhoan;
            this.cmtypetaikhoan.ValueMember = "MALOAI";
        }
        private void btnthoatchinhsuasach_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //combobox
        private void Cacchucnang_Load(object sender, EventArgs e)
        {

            cmgioitinh.Items.Add("Nam");
            cmgioitinh.Items.Add("Nữ");
            cmgioitinh.Items.Add("Khác");
            List<SACH> listmasach = db.SACH.ToList();
            List<NHANVIEN> listnhanvien = db.NHANVIEN.ToList();
            List<DOCGIA> listdocgia = db.DOCGIA.ToList();
            List<TAIKHOAN> listtaikhoan = db.TAIKHOAN.ToList();
            List<LOAITAIKHOAN> listloaitaikhoan = db.LOAITAIKHOAN.ToList();
            List<PHIEUMUONSACH> listPMS = db.PHIEUMUONSACH.ToList();
            xuatcombobox(listmasach, listnhanvien, listdocgia, listloaitaikhoan, listtaikhoan);
            Danhsachtaikhoan(listtaikhoan);
            danhsachmuon(listPMS);
        }
        //MƯỢN SÁCH
        private void danhsachmuon(List<PHIEUMUONSACH> listmuon)
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
            dtgvmuonsach.DataSource = tbmuon;
            dtgvsachtra.DataSource = tbmuon;
        }
        void muonsach()
        {
            try
            {
                PHIEUMUONSACH p = new PHIEUMUONSACH();
                DateTime dt = DateTime.Now;
                DateTime dtreturn = DateTime.Now.AddDays(15);
                p.MADOCGIA = cmmadocgia.Text;
                p.MASACH = cmmasach.Text;
                p.NGAYMUONSACH = DateTime.Now;
                p.NGAYTRA = Convert.ToDateTime(dateTimetrasach.Text);
                p.SOLUONGMUON = Convert.ToInt32(txtsoluongmuon.Text);
                p.MANHANVIEN = cmmanhanvien.Text;
                db.PHIEUMUONSACH.Add(p);
                db.SaveChanges();
                danhsachmuon(db.PHIEUMUONSACH.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btndongy1_Click(object sender, EventArgs e)
        {
            muonsach();
        }
        //-------------------------Sửa mượn sách------------------------------
        void suathongtinmuonsach()
        {
            PHIEUMUONSACH p1 = db.PHIEUMUONSACH.FirstOrDefault(a => a.MADOCGIA == cmmadocgia.Text);
            if (p1 != null)
            {
                p1.MADOCGIA = cmmadocgia.Text;
                p1.MASACH = cmmasach.Text;
                p1.NGAYMUONSACH = Convert.ToDateTime(dateTimemuon.Text);
                p1.NGAYTRA = Convert.ToDateTime(dateTimetrasach.Text);
                p1.SOLUONGMUON = Convert.ToInt32(txtsoluongmuon.Text);
                p1.MANHANVIEN = cmmanhanvien.Text;
                db.SaveChanges();
            }
            danhsachmuon(db.PHIEUMUONSACH.ToList());
        }
        //---------------------------------Tra sach theo ma-------------------------------------------------
        void trasachtheomasach()
        {
            PHIEUMUONSACH p3 = db.PHIEUMUONSACH.FirstOrDefault(a => a.MADOCGIA == txtmadocgiatra.Text);
            if (p3 != null)
            {
                string Madocgia = txtmadocgiatra.Text;
                string Masachtra = txtmasachtra.Text;
                using (var dbcontext = new ThuvienDBContext())
                {
                    if(dbcontext.PHIEUMUONSACH.Any(pm => pm.MADOCGIA == Madocgia && pm.MASACH == Masachtra))
                    {
                        db.PHIEUMUONSACH.Remove(p3);
                        db.SaveChanges();
                        MessageBox.Show("Đã xóa thành công!");
                        danhsachmuon(db.PHIEUMUONSACH.ToList());
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
            }

        }
        private void btntratheomasach_Click(object sender, EventArgs e)
        {
            trasachtheomasach();
        }
        //QUẢN LÝ SÁCH
        //Chỉnh sửa sách
        private void DanhsachSach(List<SACH> listSachs)
        {
            DataTable t1 = new DataTable();
            t1.Columns.Add("Mã sách");
            t1.Columns.Add("Tên sách");
            t1.Columns.Add("Tên tác giả");
            t1.Columns.Add("Giá(VNĐ)");
            t1.Columns.Add("Năm xuất bản");
            t1.Columns.Add("Nhà xuất bản");
            t1.Columns.Add("Tình trạng sách");
            t1.Columns.Add("Ngày nhập sách");
            t1.Columns.Add("Số lượng");
            for (int i = 0; i < listSachs.Count; i++)
            {
                SACH sach1 = listSachs[i];
                t1.Rows.Add(new String[]
                {
                    sach1.MASACH, sach1.TENSACH, sach1.TENTACGIA,sach1.GIA.ToString(), sach1.NAMXUATBAN.ToString(), sach1.NHAXUATBAN, sach1.TINHTRANGSACH, sach1.NGAYNHAPSACH.ToString(), sach1.SOLUONG.ToString()
                });
            }
            dtgvchinhsuasach.DataSource = t1;
        }
        //-----------------------------------Them sach------------------------------------
        void themsach()
        {
            try
            {
                SACH s1 = new SACH();
                s1.MASACH = txtmasach.Text;
                s1.TENSACH = txttensach.Text;
                s1.TENTACGIA = txttentacgia.Text;
                s1.GIA = Int32.Parse(txtgia.Text);
                s1.NAMXUATBAN = Convert.ToInt32(txtnamxb.Text);
                s1.NHAXUATBAN = txtnhaxuatban.Text;
                s1.TINHTRANGSACH = txttinhtrangsach.Text;
                s1.NGAYNHAPSACH = Convert.ToDateTime(dateTimengaynhapsach.Text);
                s1.SOLUONG = Convert.ToInt32(txtsoluong.Text);
                db.SACH.Add(s1);
                db.SaveChanges();
                DanhsachSach(db.SACH.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnthemnhap_Click(object sender, EventArgs e)
        {
            themsach();
        }
        //------------------------------------sưasach-------------------------------------------
        void suathongtinsach()
        {
            SACH s3 = db.SACH.FirstOrDefault(a => a.MASACH == txtmasach.Text);
            if (s3 != null)
            {
                s3.TENSACH = txttensach.Text;
                s3.TENTACGIA = txttentacgia.Text;
                s3.GIA = Convert.ToInt32(txtgia.Text);
                s3.NAMXUATBAN = Convert.ToInt32(txtnamxb.Text);
                s3.NHAXUATBAN = txtnhaxuatban.Text;
                s3.TINHTRANGSACH = txttinhtrangsach.Text;
                s3.NGAYNHAPSACH = Convert.ToDateTime(dateTimengaynhapsach.Text);
                s3.SOLUONG = Convert.ToInt32(txtsoluong.Text);
                db.SaveChanges();
            }
            DanhsachSach(db.SACH.ToList());
        }
        private void button3_Click(object sender, EventArgs e)
        {
            suathongtinsach();
        }
        //--Xoasach
        void xoasach()
        {
            SACH s2 = db.SACH.FirstOrDefault(a => a.MASACH == txtmasach.Text);
            if (s2 != null)
            {
                db.SACH.Remove(s2);
                db.SaveChanges();
            }
            DanhsachSach(db.SACH.ToList());
        }
        private void button4_Click(object sender, EventArgs e)
        {
            xoasach();
        }
        //QUẢN LÝ ĐỘC GIẢ
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
                       docgia.MADOCGIA, docgia.TENDOCGIA, docgia.NGAYSINH.ToString("dd/MM/yyyy"),
                       docgia.NGAYLAPTHE.ToString(), docgia.NGAYHETHAN.ToString(), docgia.DIACHI, docgia.EMAIL, docgia.GIOITINH, docgia.PHIGIAHANTHE.ToString()
                   });
            }
            dtgvDocgia.DataSource = table1;
        }
        //----------------------------------Thêm độc giả--------------------------------
        void themdocgia()
        {
            try
            {
                DOCGIA d1 = new DOCGIA();
                DateTime dt = DateTime.Now;
                DateTime dtreturn = DateTime.Now.AddDays(30);
                d1.MADOCGIA = txtmadocgia.Text;
                d1.TENDOCGIA = txttendocgia.Text;
                d1.NGAYSINH = Convert.ToDateTime(dateTimengaysinh.Text);
                d1.NGAYLAPTHE = DateTime.Now;
                d1.NGAYHETHAN = Convert.ToDateTime(dateTimengayhethan.Text);
                d1.DIACHI = txtdiachi.Text;
                d1.EMAIL = txtemail.Text;
                d1.GIOITINH = cmgioitinh.Text;
                d1.PHIGIAHANTHE = Convert.ToInt64(txtphigiahan.Text);
                db.DOCGIA.Add(d1);
                db.SaveChanges();
                Danhsachdocgia(db.DOCGIA.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDangky4_Click(object sender, EventArgs e)
        {
            themdocgia();
        }
        //----------------------------------Sửa độc giả---------------------------------
        void suathongtindocgia()
        {
            DOCGIA d2 = db.DOCGIA.FirstOrDefault(b => b.MADOCGIA == txtmadocgia.Text);
            if (d2 != null)
            {
                try
                {
                    d2.TENDOCGIA = txttendocgia.Text;
                    d2.NGAYSINH = Convert.ToDateTime(dateTimengaysinh.Text);
                    d2.NGAYLAPTHE = Convert.ToDateTime(dateTimengaydangky.Text);
                    d2.NGAYHETHAN = Convert.ToDateTime(dateTimengayhethan.Text);
                    d2.DIACHI = txtdiachi.Text;
                    d2.EMAIL = txtemail.Text;
                    d2.GIOITINH = cmgioitinh.Text;
                    d2.PHIGIAHANTHE = Convert.ToInt64(txtphigiahan.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                db.SaveChanges();
                
            }
            Danhsachdocgia(db.DOCGIA.ToList());
        }
        private void btnsua4_Click(object sender, EventArgs e)
        {
            suathongtindocgia();
        }

        //----------------------------------Xóa độc giả---------------------------------
        void xoadocgia()
        {
            DOCGIA d3 = db.DOCGIA.FirstOrDefault(c => c.MADOCGIA == txtmadocgia.Text);
            if (d3 != null)
            {
                db.DOCGIA.Remove(d3);
                db.SaveChanges();
            }
            Danhsachdocgia(db.DOCGIA.ToList());
        }
        private void btnxoa4_Click(object sender, EventArgs e)
        {
            xoadocgia();
        }
        //Tracuusach
        private void Tracuunhanvien(List<SACH> listSachs)
        {
            DataTable t2 = new DataTable();
            t2.Columns.Add("Mã sách");
            t2.Columns.Add("Tên sách");
            t2.Columns.Add("Tên tác giả");
            t2.Columns.Add("Giá(VNĐ)");
            t2.Columns.Add("Năm xuất bản");
            t2.Columns.Add("Nhà xuất bản");
            t2.Columns.Add("Tình trạng sách");
            t2.Columns.Add("Ngày nhập sách");
            t2.Columns.Add("Số lượng");
            for (int i = 0; i < listSachs.Count; i++)
            {
                SACH sach2 = listSachs[i];
                t2.Rows.Add(new String[]
                {
                    sach2.MASACH, sach2.TENSACH, sach2.TENTACGIA,sach2.GIA.ToString(), sach2.NAMXUATBAN.ToString(),
                    sach2.NHAXUATBAN, sach2.TINHTRANGSACH, sach2.NGAYNHAPSACH.ToString(), sach2.SOLUONG.ToString()
                });
            }
            dtgvtimsachnhanvien.DataSource = t2;
        }
        void tracuu()
        {
            try
            {
                List<SACH> listsach = db.SACH.ToList();
                List<SACH> list = new List<SACH>();
                for (int i = 0; i < listsach.Count; i++)
                {
                    SACH sach = listsach[i];
                    if (sach.TENSACH.ToLower().Contains(txtTimsachchonhanvien.Text) || sach.TENTACGIA.ToLower().Contains(txtTimsachchonhanvien.Text))
                    {
                        list.Add(sach);
                    }
                }
                Tracuunhanvien(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnTimsach_Click(object sender, EventArgs e)
        {
            tracuu();
        }
        private void thoattrasach_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //THÔNG TIN TÀI KHOẢN
        //----------------------------------Xem-----------------------------------
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
            dtgvtaikhoan.DataSource = taikhoan1;
        }
        //----------------------------------Thêm----------------------------------
        void themtaikhoan()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnthemtk_Click(object sender, EventArgs e)
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
        private void btnxoatk_Click(object sender, EventArgs e)
        {
            Xoataikhoan xoa = new Xoataikhoan();
            this.Hide();
            xoa.ShowDialog();
            this.Show();
        }
        //----------------------------------Sửa-----------------------------------
        void suataikhoan()
        {
            TAIKHOAN t3 = db.TAIKHOAN.FirstOrDefault(t => t.TENDANGNHAP == txttendangnhap.Text);
            if (t3 != null)
            {
                db.TAIKHOAN.Remove(t3);
                db.SaveChanges();
            }
        }
        //------------------------------------------------------------------------
        private void btnxem_Click(object sender, EventArgs e)
        {
            Danhsachtaikhoan(db.TAIKHOAN.ToList());
        }
        //----------------------------------Sửa-----------------------------------
        private void btnthoatmuonsach_Click(object sender, EventArgs e)
        {
            giaodienchinh g = new giaodienchinh();
            this.Hide();
            g.ShowDialog();
            this.Show();

            
        }

        private void thoatchucnang_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Thoattracuu5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnthoatquanlythe4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnthoatsachnhap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thoatsachquahan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnthoatsachmuon_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabtracuu_Click(object sender, EventArgs e)
        {

        }
    }
}
