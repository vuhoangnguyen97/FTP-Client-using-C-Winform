namespace FTP
{
    partial class Main_FTP
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
            this.lblHello = new System.Windows.Forms.Label();
            this.lstFTP = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.detail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tenMoRong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnBackToHome = new System.Windows.Forms.Button();
            this.lblDownload = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameSelectedFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kiểmTraTốcĐộMạngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rename = new System.Windows.Forms.ToolStripMenuItem();
            this.delete = new System.Windows.Forms.ToolStripMenuItem();
            this.download = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblSpeed = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHello
            // 
            this.lblHello.AutoSize = true;
            this.lblHello.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHello.Location = new System.Drawing.Point(36, 28);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(126, 32);
            this.lblHello.TabIndex = 0;
            this.lblHello.Text = "Xin chào";
            // 
            // lstFTP
            // 
            this.lstFTP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.date,
            this.size,
            this.detail,
            this.tenMoRong});
            this.lstFTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFTP.LabelEdit = true;
            this.lstFTP.Location = new System.Drawing.Point(64, 85);
            this.lstFTP.Name = "lstFTP";
            this.lstFTP.Size = new System.Drawing.Size(1288, 306);
            this.lstFTP.TabIndex = 1;
            this.lstFTP.UseCompatibleStateImageBehavior = false;
            this.lstFTP.View = System.Windows.Forms.View.Details;
            this.lstFTP.ItemActivate += new System.EventHandler(this.lstFTP_ItemActivate);
            this.lstFTP.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstFTP_MouseClick);
            // 
            // name
            // 
            this.name.Text = "Tên file";
            this.name.Width = 191;
            // 
            // date
            // 
            this.date.Text = "Ngày tạo";
            this.date.Width = 166;
            // 
            // size
            // 
            this.size.Text = "Dung lượng";
            this.size.Width = 180;
            // 
            // detail
            // 
            this.detail.Text = "Chi tiết";
            this.detail.Width = 148;
            // 
            // tenMoRong
            // 
            this.tenMoRong.Text = "Kiểu file";
            this.tenMoRong.Width = 166;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkRed;
            this.button1.Location = new System.Drawing.Point(53, 417);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 56);
            this.button1.TabIndex = 2;
            this.button1.Text = "Upload file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DarkRed;
            this.button2.Location = new System.Drawing.Point(290, 417);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(236, 56);
            this.button2.TabIndex = 3;
            this.button2.Text = "Download File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.DarkRed;
            this.button3.Location = new System.Drawing.Point(1191, 417);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(193, 56);
            this.button3.TabIndex = 4;
            this.button3.Text = "Đăng xuất";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnBackToHome
            // 
            this.btnBackToHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToHome.ForeColor = System.Drawing.Color.DarkRed;
            this.btnBackToHome.Location = new System.Drawing.Point(891, 417);
            this.btnBackToHome.Name = "btnBackToHome";
            this.btnBackToHome.Size = new System.Drawing.Size(272, 56);
            this.btnBackToHome.TabIndex = 5;
            this.btnBackToHome.Text = "Trở về trang chính";
            this.btnBackToHome.UseVisualStyleBackColor = true;
            this.btnBackToHome.Click += new System.EventHandler(this.btnBackToHome_Click);
            // 
            // lblDownload
            // 
            this.lblDownload.AutoSize = true;
            this.lblDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownload.ForeColor = System.Drawing.Color.Maroon;
            this.lblDownload.Location = new System.Drawing.Point(223, 206);
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Size = new System.Drawing.Size(762, 91);
            this.lblDownload.TabIndex = 6;
            this.lblDownload.Text = "ĐANG DOWNLOAD";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1431, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFolderToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.renameSelectedFolderToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // newFolderToolStripMenuItem
            // 
            this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.newFolderToolStripMenuItem.Text = "New folder";
            this.newFolderToolStripMenuItem.Click += new System.EventHandler(this.newFolderToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.deleteToolStripMenuItem.Text = "Delete Selected Folder";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // renameSelectedFolderToolStripMenuItem
            // 
            this.renameSelectedFolderToolStripMenuItem.Name = "renameSelectedFolderToolStripMenuItem";
            this.renameSelectedFolderToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.renameSelectedFolderToolStripMenuItem.Text = "Rename Selected Folder";
            this.renameSelectedFolderToolStripMenuItem.Click += new System.EventHandler(this.renameSelectedFolderToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kiểmTraTốcĐộMạngToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // kiểmTraTốcĐộMạngToolStripMenuItem
            // 
            this.kiểmTraTốcĐộMạngToolStripMenuItem.Name = "kiểmTraTốcĐộMạngToolStripMenuItem";
            this.kiểmTraTốcĐộMạngToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.kiểmTraTốcĐộMạngToolStripMenuItem.Text = "Kiểm tra tốc độ mạng";
            this.kiểmTraTốcĐộMạngToolStripMenuItem.Click += new System.EventHandler(this.kiểmTraTốcĐộMạngToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rename,
            this.delete,
            this.download});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 76);
            // 
            // rename
            // 
            this.rename.Name = "rename";
            this.rename.Size = new System.Drawing.Size(127, 24);
            this.rename.Text = "Đổi tên";
            this.rename.Click += new System.EventHandler(this.rename_Click);
            // 
            // delete
            // 
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(127, 24);
            this.delete.Text = "Xóa";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // download
            // 
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(127, 24);
            this.download.Text = "Tải về";
            this.download.Click += new System.EventHandler(this.download_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.DarkRed;
            this.button4.Location = new System.Drawing.Point(581, 417);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(265, 56);
            this.button4.TabIndex = 8;
            this.button4.Text = "TẢI LẠI TRANG";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(1056, 488);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(205, 25);
            this.lblSpeed.TabIndex = 9;
            this.lblSpeed.Text = "Tốc độ mạng hiện tại :";
            // 
            // Main_FTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1431, 522);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lblDownload);
            this.Controls.Add(this.btnBackToHome);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstFTP);
            this.Controls.Add(this.lblHello);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main_FTP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTP Client ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FTP_FormClosing);
            this.Load += new System.EventHandler(this.Main_FTP_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.ListView lstFTP;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader size;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColumnHeader detail;
        private System.Windows.Forms.Button btnBackToHome;
        private System.Windows.Forms.Label lblDownload;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameSelectedFolderToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rename;
        private System.Windows.Forms.ToolStripMenuItem delete;
        private System.Windows.Forms.ToolStripMenuItem download;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ColumnHeader tenMoRong;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kiểmTraTốcĐộMạngToolStripMenuItem;
    }
}