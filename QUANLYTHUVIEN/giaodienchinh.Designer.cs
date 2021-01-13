namespace QUANLYTHUVIEN
{
    partial class giaodienchinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dtgvtracuuchinh = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.đăngNhậpAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTracuu = new System.Windows.Forms.Label();
            this.btnThoatgiaodienchinh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btntim = new System.Windows.Forms.Button();
            this.lblTensach = new System.Windows.Forms.Label();
            this.texttracuuthongtinsach = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvtracuuchinh)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dtgvtracuuchinh
            // 
            this.dtgvtracuuchinh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvtracuuchinh.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtgvtracuuchinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvtracuuchinh.Location = new System.Drawing.Point(38, 101);
            this.dtgvtracuuchinh.Name = "dtgvtracuuchinh";
            this.dtgvtracuuchinh.Size = new System.Drawing.Size(831, 289);
            this.dtgvtracuuchinh.TabIndex = 39;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngNhậpAdminToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(910, 24);
            this.menuStrip1.TabIndex = 38;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // đăngNhậpAdminToolStripMenuItem
            // 
            this.đăngNhậpAdminToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.đăngNhậpAdminToolStripMenuItem.ForeColor = System.Drawing.Color.Crimson;
            this.đăngNhậpAdminToolStripMenuItem.Name = "đăngNhậpAdminToolStripMenuItem";
            this.đăngNhậpAdminToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.đăngNhậpAdminToolStripMenuItem.Text = "Đăng Nhập Admin";
            this.đăngNhậpAdminToolStripMenuItem.Click += new System.EventHandler(this.đăngNhậpAdminToolStripMenuItem_Click);
            // 
            // lblTracuu
            // 
            this.lblTracuu.AutoSize = true;
            this.lblTracuu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTracuu.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTracuu.ForeColor = System.Drawing.Color.Green;
            this.lblTracuu.Location = new System.Drawing.Point(338, 51);
            this.lblTracuu.Name = "lblTracuu";
            this.lblTracuu.Size = new System.Drawing.Size(220, 31);
            this.lblTracuu.TabIndex = 37;
            this.lblTracuu.Text = "TRA CỨU SÁCH";
            // 
            // btnThoatgiaodienchinh
            // 
            this.btnThoatgiaodienchinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoatgiaodienchinh.BackColor = System.Drawing.Color.DarkOrange;
            this.btnThoatgiaodienchinh.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoatgiaodienchinh.Location = new System.Drawing.Point(812, 503);
            this.btnThoatgiaodienchinh.Name = "btnThoatgiaodienchinh";
            this.btnThoatgiaodienchinh.Size = new System.Drawing.Size(91, 33);
            this.btnThoatgiaodienchinh.TabIndex = 43;
            this.btnThoatgiaodienchinh.Text = "Thoát";
            this.btnThoatgiaodienchinh.UseVisualStyleBackColor = false;
            this.btnThoatgiaodienchinh.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btntim);
            this.panel1.Controls.Add(this.lblTensach);
            this.panel1.Controls.Add(this.texttracuuthongtinsach);
            this.panel1.Location = new System.Drawing.Point(169, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 68);
            this.panel1.TabIndex = 45;
            // 
            // btntim
            // 
            this.btntim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btntim.BackColor = System.Drawing.Color.MistyRose;
            this.btntim.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntim.Location = new System.Drawing.Point(396, 13);
            this.btntim.Name = "btntim";
            this.btntim.Size = new System.Drawing.Size(122, 41);
            this.btntim.TabIndex = 2;
            this.btntim.Text = "Tìm";
            this.btntim.UseVisualStyleBackColor = false;
            this.btntim.Click += new System.EventHandler(this.btntim_Click);
            // 
            // lblTensach
            // 
            this.lblTensach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTensach.AutoSize = true;
            this.lblTensach.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTensach.ForeColor = System.Drawing.Color.Red;
            this.lblTensach.Location = new System.Drawing.Point(13, 25);
            this.lblTensach.Name = "lblTensach";
            this.lblTensach.Size = new System.Drawing.Size(97, 22);
            this.lblTensach.TabIndex = 1;
            this.lblTensach.Text = "Tên Sách: ";
            // 
            // texttracuuthongtinsach
            // 
            this.texttracuuthongtinsach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.texttracuuthongtinsach.BackColor = System.Drawing.Color.White;
            this.texttracuuthongtinsach.Location = new System.Drawing.Point(116, 26);
            this.texttracuuthongtinsach.Name = "texttracuuthongtinsach";
            this.texttracuuthongtinsach.Size = new System.Drawing.Size(251, 21);
            this.texttracuuthongtinsach.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.DarkGreen;
            this.groupBox2.BackgroundImage = global::QUANLYTHUVIEN.Properties.Resources.hinh_nen_dang_yeu_nhat_cho_may_tinh_1;
            this.groupBox2.Controls.Add(this.dtgvtracuuchinh);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(0, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(910, 396);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            // 
            // giaodienchinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QUANLYTHUVIEN.Properties.Resources.romantic_stylish_art_drawing_40_1920x1200_767121;
            this.ClientSize = new System.Drawing.Size(910, 537);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblTracuu);
            this.Controls.Add(this.btnThoatgiaodienchinh);
            this.Name = "giaodienchinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ THƯ VIỆN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.giaodienchinh_FormClosing);
            this.Load += new System.EventHandler(this.giaodienchinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvtracuuchinh)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dtgvtracuuchinh;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lblTracuu;
        private System.Windows.Forms.Button btnThoatgiaodienchinh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btntim;
        private System.Windows.Forms.Label lblTensach;
        private System.Windows.Forms.TextBox texttracuuthongtinsach;
        private System.Windows.Forms.ToolStripMenuItem đăngNhậpAdminToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

