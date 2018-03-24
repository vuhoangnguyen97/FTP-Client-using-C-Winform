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
    public partial class Upload : Form
    {
        public Upload()
        {
            InitializeComponent();
        }
        // Tạo các biến để nhận giá trị bên giao diện chính gởi qua
        private string _username, _password, _ip;
        private int _port;
        private Thread t;
        // tạo phương thức khởi tạo có đối số để truyền vào các giá trị bên giao diện main form truyền qua
        public Upload(string Ip,int port, string username, string password) : this()
        {
            // gán các giá trị bên giao diện chính truyền qua
            _username = username;
            _ip = Ip;
            _password = password;
            _port = port;
        }


        // nhấn nút browse
        private void button2_Click(object sender, EventArgs e)
        {
            chonFile();
        }

        private void chonFile()
        {
            // tạo mới đối tượng OpenFileDialog, ý nghĩa: mở cửa sở chọn tập tin file
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Ở mặc định cửa sở này mở ra là C:\
            openFileDialog1.InitialDirectory = "c:\\";

            // Nếu nhấn nút ok thì lấy tên file và đường dẫn
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // lấy đường dấn tới file đó
                // Ví dụ: C:\test.txt
                string path = openFileDialog1.FileName;

                // lấy tên của file đó
                // Ví dụ: test.txt 
                string filename = System.IO.Path.GetFileName(path);

                // in ra txtPath và txtFileName
                txtPath.Text = path;
                txtFileName.Text = filename;
            }
        }


        // khi nhấn nút quay trở về trang chủ
        private void button3_Click(object sender, EventArgs e)
        {
            // tắt trang upload
            this.Hide();
            // mở lại trang chính có truyền lại các giá trị liên quan tới server
            Main_FTP m = new Main_FTP(_username, _ip, _port, _password);
            m.Show();
        }

        private void Upload_Load(object sender, EventArgs e)
        {
            uploading.Hide();
        }

       

        // khi nhấn nút upload
        private void button1_Click(object sender, EventArgs e)
        {
            // tạo 1 thread để thực thi phương thức upload_data để tránh việc đứng phần mềm            
            t = new Thread(new ThreadStart(Upload_data));
            t.IsBackground = true;
            t.Start();

            Thread t2 = new Thread(new ThreadStart(AnTieuDe));
            t2.Start();

            t.Join();
            t2.Abort();
            MessageBox.Show("Upload thành công!");
            HienTieuDe();
        }

        private void HienTieuDe()
        {
            label1.Show();
            label2.Show();
            txtFileName.Show();
            txtPath.Show();
            button1.Show();
            button2.Show();
            button3.Show();
            uploading.Hide();
        }

        private void Upload_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn thoát upload không?", "Upload", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
        private void AnTieuDe()
        {
            CheckForIllegalCrossThreadCalls = false;
            label1.Hide();
            label2.Hide();
            txtFileName.Hide();
            txtPath.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            uploading.Show();
        }
        // phương thức upload data
        private void Upload_data()
        {
            // using ở đây để khai báo Namespace của thư viện Ftp.dll sử dụng
            using (Ftp client = new Ftp())
            {                
                client.Connect(_ip, _port);  // thực thi phương thức connect(Ip, port, false/true ( nếu Server có SSL thì là true, còn không có thì mặc định sẽ là False)
                client.Login(_username, _password);// username login vào Sever thông qua phương thức Login(username, password)

                client.Upload(txtFileName.Text, txtPath.Text); // thực thi phương thức upload( tên file cần upload, đường dẫn tuyệt đối tới file đó)

                client.Close();
            }

        }
    }
}
