using Limilabs.FTP.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FTP
{
    public partial class Rename : Form
    {
        public Rename()
        {
            InitializeComponent();
        }

        // tạo các giá trị để nhận từ main_ftp truyền qua
        private string _type, _filename, _ip, _username, _password;
        
        // sự kiện nhấn nút enter
        private void txtNewName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                // thực thi phương thức của nút rename
                button2_Click(sender, e);

        }

        private void Rename_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn thoát không?", "FTP CLIENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;

            }
            else
            {
                this.Hide();
                Main_FTP m = new Main_FTP(_username, _ip, _port, _password);
                m.Show();
            }
        }

        // sự kiện nhấn nút trở lại trang chính
        private void button1_Click(object sender, EventArgs e)
        {
            // câu thông báo
            if (MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Tắt toàn bộ
                this.Hide();
                // hiện lại trang chính
                Main_FTP trangchinh = new Main_FTP(_username, _ip, _port, _password);
                trangchinh.Show();

            }
            else
            {
                // nếu nhấn nút không thì quay lại
                return;
            }

        }

        private int _port;

        // phương thức khởi tạo có đối số để gán các giá trị nhận được từ main ftp truyền qua vào các biến trên
        public Rename(string ip, int port, string username, string password, string type, string filename):this()
        {
            _ip = ip;
            _port = port;
            _username = username;
            _password = password;
            _type = type;
            _filename = filename;
            txtOldName.Text = _filename; // in ra tên thư mục/tập tin muốn đổi tên
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // khi nhấn nút rename
            string newName = txtNewName.Text;
            using (Ftp client = new Ftp())
            {
                // kết nối đến server FTP
                client.Connect(_ip, _port);
                client.Login(_username, _password);

                // nếu là tập tin 
                if(_type == "Là tập tin")
                {
                    // lấy tên tập tin
                    string oldName = txtOldName.Text;
                    var name = oldName.Split('.'); // thực thi phương thức split cắt ra ở dấu . đuôi mở rộng
                    string duoiMoRong = name[1]; // lấy phần mở rộng để lát gán lại ở giá trị mới

                    client.Rename(oldName, newName + "."+ duoiMoRong); // thực thi phương thức rename

                }
                // nếu là thư mục thì đổi tên thẳng không cần split
                else if (_type =="Là thư mục")
                {
                    client.Rename(txtOldName.Text, newName);
                }
                // in câu thông báo hoàn tất
                MessageBox.Show("Đổi tên hoàn tất.");
                txtOldName.Text = "";
                txtNewName.Text = "";
                client.Close();
            }
        }
    }
}
