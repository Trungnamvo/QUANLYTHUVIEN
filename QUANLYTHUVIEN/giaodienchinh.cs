using QUANLYTHUVIEN.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYTHUVIEN
{
    public partial class giaodienchinh : Form
    {
        ThuvienDBContext db = new ThuvienDBContext();
        public giaodienchinh()
        {
            InitializeComponent();
            ThuvienDBContext db = new ThuvienDBContext();
            Timkiem();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void giaodienchinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void đăngNhậpAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dangnhapnhanvien n = new Dangnhapnhanvien();
            this.Hide();
            n.ShowDialog();
            this.Show();
        }

        private void giaodienchinh_Load(object sender, EventArgs e)
        {

        }
        private void danhsach(List<SACH> listSach)
        {
            
            DataTable table = new DataTable();
            table.Columns.Add("Mã sách");
            table.Columns.Add("Tên sách");
            table.Columns.Add("Tác giả");
            table.Columns.Add("Năm xuất bản");
            table.Columns.Add("Nhà xuất bản");
            table.Columns.Add("Số lượng");
            table.Columns.Add("Tình trạng sách");
            table.Columns.Add("Ngày nhập sách");
            for (int i = 0; i < listSach.Count; i++)
            {
                SACH s = listSach[i];
                table.Rows.Add(new String[]
                {
                    s.MASACH,s.TENSACH,s.TENTACGIA, s.NAMXUATBAN.ToString(),s.NHAXUATBAN,s.SOLUONG.ToString(),s.TINHTRANGSACH,s.NGAYNHAPSACH.ToString()
                });
            }
            dtgvtracuuchinh.DataSource = table;
        }
        void Timkiem()
        {
            try { 
            List<SACH> listsach = db.SACH.ToList();
            List<SACH> list = new List<SACH>();
                for (int i = 0; i < listsach.Count; i++)
                {
                    SACH sach = listsach[i];
                    if (sach.TENSACH.ToLower().Contains(texttracuuthongtinsach.Text) || sach.TENTACGIA.ToLower().Contains(texttracuuthongtinsach.Text))
                    {
                        list.Add(sach);
                    }
                }
                danhsach(list);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            Timkiem();
        }
    }
}
