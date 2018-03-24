using Limilabs.FTP.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FTP
{
    public partial class CreateFolder : Form
    {
        public CreateFolder()
        {
            InitializeComponent();
        }
        // tạo các giá trị nhận từ form main_Ftp truyền qua
        private string _username, _password, _ip;
        private int _port;

        // sự kiện nhấn nút quay về trang chủ
        private void button2_Click(object sender, EventArgs e)
        {
            // câu thông báo
            if (MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Tắt toàn bộ
                this.Hide();
                // hiện lại trang chính
                Main_FTP trangchinh = new Main_FTP(_username,_ip, _port, _password);
                trangchinh.Show();

            }
            else
            {
                // nếu nhấn nút không thì quay lại
                return;
            }

        }

        // sự kiện nhấn nút enter thì thực thi sự kiện nhấn nút tạo thư mục mới
        private void txtFolder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);

        }

        // khởi tạo có đối số gán các giá trị truyền từ form main_ftp vào các biến khai báo ở trên
        public CreateFolder(string Ip, int port, string username, string password) : this()
        {            
            _ip = Ip;
            _port = port;
            _username = username;
            _password = password;            
        }

        // sự kiện nhấn nút tạo mới thư mục
        private void button1_Click(object sender, EventArgs e)
        {            
            // kiểm tra nếu bỏ trống thì thông báo lỗi
            if (string.IsNullOrEmpty(txtFolder.Text))
                MessageBox.Show("Không được bỏ trống!");
            string folder = txtFolder.Text; // lấy tên thư mục mới
            using (Ftp client = new Ftp())
            {
                // kết nối đến server FTP 
                client.Connect(_ip, _port);
                client.Login(_username, _password);

                // thực thi phương thức tạo mới thư mục CreateFolder(tên thư mục tạo mới)
                client.CreateFolder(folder);

                // in câu thông báo
                MessageBox.Show("Đã tạo thư mục tên: " + folder);

                client.Close();
                
            }

        }
        
    }
}
