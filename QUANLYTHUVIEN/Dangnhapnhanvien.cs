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
    
    public partial class Dangnhapnhanvien : Form
    {
        ThuvienDBContext db = new ThuvienDBContext();
        public Dangnhapnhanvien()
        {
            InitializeComponent();
            List<TAIKHOAN> taikhoan = db.TAIKHOAN.ToList();
        }
        private bool Dangnhap()
        {
            string Tendangnhap = txttendangnhap.Text;
            string Matkhau = MD5Encrypt(txtmatkhau.Text);
            if(Tendangnhap !="" && Matkhau != "")
            {
                using (var dbcontext = new ThuvienDBContext())
                {
                    if(dbcontext.TAIKHOAN.Any(tk => tk.TENDANGNHAP == Tendangnhap && tk.MATKHAU ==Matkhau && tk.MALOAI == "Nhân viên"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool Dangnhapquanly()
        {
            string Tendangnhap = txttendangnhap.Text;
            string Matkhau = MD5Encrypt(txtmatkhau.Text);
            if (Tendangnhap != "" && Matkhau != "")
            {
                using (var dbcontext = new ThuvienDBContext())
                {
                    if (dbcontext.TAIKHOAN.Any(tk => tk.TENDANGNHAP == Tendangnhap && tk.MATKHAU == Matkhau && tk.MALOAI == "Admin"))
                    {
                        //if (dbcontext.LOAITAIKHOAN.Any( ml => ml.MALOAI == "Admin" ))
                       // {
                            return true;
                       // }
                    }
                }
            }
            return false;
        }
        public static string TENDANGNHAP1 = "";
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
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (Dangnhap())
            {
                Cacchucnang c = new Cacchucnang();
                this.Hide();
                c.ShowDialog();
                this.Show();
                this.Close();
            }
            else if (Dangnhapquanly())
            {
                Quanly q = new Quanly();
                this.Hide();
                q.ShowDialog();
                this.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!. Vui lòng kiểm tra lại tên đăng nhập hay mật khẩu!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtmatkhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
