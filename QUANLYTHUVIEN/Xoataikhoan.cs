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
    public partial class Xoataikhoan : Form
    {
        ThuvienDBContext db = new ThuvienDBContext();
        public Xoataikhoan()
        {
            InitializeComponent();
            xoataikhoan();

        }
        //----------------------------------Xóa-----------------------------------
        private void Danhsachtaikhoan(List<TAIKHOAN> listtaikhoan)
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
        }
        void xoataikhoan()
        {

            TAIKHOAN t3 = db.TAIKHOAN.FirstOrDefault(a => a.TENDANGNHAP == txttenxoa.Text);
            if (t3 != null)
            {
                string Tendangnhap = txttenxoa.Text;
                string Matkhau = MD5Encrypt(txtmkxoa.Text);
                using (var dbcontext = new ThuvienDBContext())
                {
                    if (dbcontext.TAIKHOAN.Any(tk => tk.TENDANGNHAP == Tendangnhap && tk.MATKHAU == Matkhau))
                    {
                        db.TAIKHOAN.Remove(t3);
                        db.SaveChanges();
                        MessageBox.Show("Đã xóa thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!. Kiểm tra tên đăng nhập và mật khẩu!");
                    }
                }
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

        private void btnxoa_Click(object sender, EventArgs e)
        {
            xoataikhoan();
            this.Close();
        }
    }
}
