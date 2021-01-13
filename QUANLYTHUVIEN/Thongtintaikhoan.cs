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
    public partial class Thongtintaikhoan : Form
    {
        ThuvienDBContext db = new ThuvienDBContext();
        public Thongtintaikhoan()
        {
            InitializeComponent();
        }

        private void lblthoatcapnhat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void capnhattaikhoan()
        {
            TAIKHOAN tk = db.TAIKHOAN.FirstOrDefault(a => a.TENDANGNHAP == txttencapnhat.Text);
            if (tk != null)
            {
                tk.TENHIENTHI = txttencapnhat.Text;
                tk.MATKHAU = txtmkcapnhat.Text;
                tk.MATKHAU = MD5Encrypt(txtmatkhaumoi.Text);
                tk.XACNHANMATKHAU = MD5Encrypt(txtxacnhanmatkhaumoi.Text);
                TAIKHOAN tk1 = db.TAIKHOAN.FirstOrDefault(a => a.TENDANGNHAP == txttencapnhat.Text);
                if (tk.MATKHAU.ToString() != txtmkcapnhat.Text.ToString())
                {
                    if (txtmatkhaumoi.Text.ToString() == txtxacnhanmatkhaumoi.Text.ToString())
                    {
                        db.SaveChanges();
                        MessageBox.Show("Thay đổi mật khẩu thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Đặt lại mật khẩu!");
                    }
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu!");
                }
            }
            else
            {
                MessageBox.Show("Không có tài khoản!");
            }
        }

        private void lblcapnhat_Click(object sender, EventArgs e)
        {
            capnhattaikhoan();
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
    }
}

