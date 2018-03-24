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
    public partial class Login : Form
    {
        public Login()
        {
            Thread t = new Thread(new ThreadStart(loading));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        private void loading()
        {
            Application.Run(new Loading());
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = txtIP.Text;             // Lấy giá trị từ txtIP
                string password = txtPassword.Text; // Lấy giá trị từ txtPassword
                string username = txtUsername.Text; // Lấy giá trị từ txtUsername
                int port = int.Parse(txtPort.Text); // Lấy giá trị từ txtPort

                /* Xét giá trị port nhập vào, nếu bé hơn 0 hoặc lớn hơn 65535 thì
                     thông báo lỗi */
                if (port<=0 || port>= 65535)
                {
                    MessageBox.Show("Port phải lớn hơn 0 và bé hơn 65535");
                    return;
                }

                // using ở đây để khai báo Namespace của thư viện Ftp.dll sử dụng                
                using (Ftp client = new Ftp()) // Tạo mới 1 đối tượng Ftp tên client, để sử dụng các phương thức có trong thư viện Ftp
                {
                    try // thực hiện try catch để bắt các exception như sai mật khẩu/ username/ sai IP
                    {
                        client.Connect(ip, port); // thực thi phương thức connect(Ip, port, false/true ( nếu Server có SSL thì là true, còn không có thì mặc định sẽ là False)
                        client.Login(username, password);// username login vào Sever thông qua phương thức Login(username, password)

                        // nếu như đăng nhập thành công, thì đối tượng client sẽ không bằng null
                        if (client == null)
                        {
                            // khi đăng nhập không thành công thì thông báo lỗi
                            MessageBox.Show("Error");
                            return;
                        }
                        else
                        {
                            // đăng nhập thành công, thông báo cho người dùng biết là thành công
                            MessageBox.Show("Success");
                            this.Hide(); // tắt cửa sổ đăng nhập

                            /* Hiện form giao diện chính khi đăng nhập thành công, và có đính kèm 
                                các giá trị username, password, ip, port để xử lý về sau.*/
                            Main_FTP m = new Main_FTP(txtUsername.Text, txtIP.Text, int.Parse(txtPort.Text), txtPassword.Text);
                            m.Show();

                        }


                    }
                    // bắt ngoại lệ khi không đúng usernam, password hay ip
                    catch (FtpException)
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu \n Hoặc sai IP");
                    }

                }
            }
            // bắt ngoại lệ khi người dùng không nhập liệu
            catch (ArgumentException)
            {
                MessageBox.Show("Không được để trống");
            }
            // bắt ngoại lệ khi người dùng nhập port không phải là số
            catch (FormatException)
            {
                MessageBox.Show("Port phải là số");
            }

            
        }

        // khi nhấn nút enter thì thực thi nút kết nối
        private void txtIP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnKetNoi_Click(sender, e);
        }

        private void txtPort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnKetNoi_Click(sender, e);
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnKetNoi_Click(sender, e);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnKetNoi_Click(sender, e);
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn thoát không?", "FTP CLIENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }
    }
}
