using Limilabs.FTP.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FTP
{
    public partial class Main_FTP : Form
    {
        public Main_FTP()
        {
            InitializeComponent();
        }

        // tạo các biến để lấy dữ liệu từ form đăng nhập gửi qua form này rồi lưu vào các biến đó.
        private string _username;
        private string _ip;
        private string _password;
        private int _port;

        public Main_FTP(string username, string Ip, int port, string password) : this()
        {
            // gán giá trị dữ liệu của form login gửi qua vào các biến trên.
            _username = username;
            _ip = Ip;
            _password = password;
            _port = port;
            // in ra câu chào.
            lblHello.Text = "Xin chào " + _username + " đến với FTP Server IP là : " + _ip + " Port số : " + _port;


        }

        // Sự kiện form_load
        private void Main_FTP_Load(object sender, EventArgs e)
        {
            // bỏ qua check crossthread khi gọi thread truyền main_load ở mục xóa tập tin/ thư mục
            CheckForIllegalCrossThreadCalls = false;
            timer1.Start();
            timer1.Enabled = true;
            SpeedTest st = new SpeedTest();
            lblSpeed.Text = "Tốc độ mạng hiện tại : " + st.CheckInternetSpeed() + "Kb/s";
            btnBackToHome.Hide(); // ẩn đi nút quay về trang chính
            lstFTP.Items.Clear(); // xóa hết toàn bộ dữ liệu trong listview
            lblDownload.Hide(); // ẩn đi thông báo download
            // using ở đây để khai báo Namespace của thư viện Ftp.dll sử dụng
            using (Ftp client = new Ftp())
            {           
                
                // kết nối với Server ip với các giá trị bên form login truyền qua
                client.Connect(_ip, _port);
                client.Login(_username, _password);

                /* Khai báo 1 list danh sách các tập tin hiện có trên server
                     thông qua phương thức getList() */
                List<FtpItem> items = client.GetList();

                // duyệt qua các đối tượng FtpItem có trong list
                // rồi in ra trong ListView
                foreach (FtpItem item in items)
                {                           
                    // thêm từng tập tin vào listview 
                    ListViewItem ds = new ListViewItem(item.Name);
                    ds.SubItems.Add(item.ModifyDate.ToShortDateString());
                    ds.SubItems.Add(GetFileSize(Convert.ToInt64(item.Size)));
                    if (item.IsFile == true)
                        ds.SubItems.Add("Là tập tin");
                    if (item.IsFolder == true)
                        ds.SubItems.Add("Là thư mục");
                    
                    try
                    {
                        string filename = item.Name; // lấy toàn bộ tên file ( tên + phần mở rộng)
                        var split = filename.Split('.'); // thực thi phương thức split cắt ra ở dấu . đuôi mở rộng
                        string duoiMoRong = split[1]; // lấy phần mở rộng để gán cột thông tin
                        ds.SubItems.Add(duoiMoRong + " file ");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        // nếu không phải là file thì là thư mục
                        ds.SubItems.Add("Thư mục");
                    }
                    

                    lstFTP.Items.Add(ds);

                }

                client.Close();
            }
        }
        
        // Hàm chuyển đổi dung lượng file thành byte, Kb, Mb, Gb, Tb.
         private string GetFileSize(double byteCount)
         {
            string size = "0 Bytes"; // cho giá trị ban đầu là 0 byte
            if(byteCount >= 1099511627776.0)
                size = String.Format("{0:##.##}", byteCount / 1099511627776.0) + " Tb";
            else if (byteCount >= 1073741824.0) // nếu >=1Gb ( là Gb)
                size = String.Format("{0:##.##}", byteCount / 1073741824.0) + " Gb";
            else if (byteCount >= 1048576.0) // nếu >=1Mb ( là Mb)
                size = String.Format("{0:##.##}", byteCount / 1048576.0) + " Mb";
            else if (byteCount >= 1024.0)   // nếu >=1Kb ( là Kb)
                size = String.Format("{0:##.##}", byteCount / 1024.0) + " Kb";
            else if (byteCount > 0 && byteCount < 1024.0) // nếu <1Kb ( là Byte)
                size = byteCount.ToString() + " Bytes";

            return size;
         }

        // khi nhấn nút đăng xuất
        private void button3_Click(object sender, EventArgs e)
        {
            // câu thông báo
            if (MessageBox.Show("Bạn có muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Tắt toàn bộ
                this.Close();
                // hiện lại trang login
                Login l = new Login();
                l.Show();
            }
            else
            {
                // nếu nhấn nút không thì quay lại trang chủ
                return;
            }

        }

        // nhấn nút upload thì chuyển sang trang upload tập tin
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // tắt trang chủ, mở trang upload
            // truyền các dữ liệu ip, username, password sang trang upload
            Upload upload = new Upload(_ip, _port, _username, _password);
            upload.Show();
        }
        
        // nhấn nút download ( đã fix lỗi access denied)
        private void button2_Click(object sender, EventArgs e)
        {
            string path = "";
            try
            {
                // tạo 1 biến string tên filename lấy tên file được chọn.
                string filename = lstFTP.SelectedItems[0].Text; // chọn file trong listbox

                // mở hộp thoại để chọn đường dẫn để tải tập tin
                using (var folderDialog = new FolderBrowserDialog())
                {
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        path = folderDialog.SelectedPath; // lưu đường dẫn vào biến path             
                    }
                    else if(folderDialog.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                // xử lý download

                // using ở đây để khai báo Namespace của thư viện Ftp.dll sử dụng
                using (Ftp client = new Ftp())
                {
                    // Tạo thread t1 thực hiện phương thức Download file
                    Thread t1 = new Thread(() => DownloadFile(client, filename, path));
                    t1.IsBackground = true;
                    t1.Start();

                    // Tạo thread t2 thực hiện việc hiện thông báo đang download
                    Thread t2 = new Thread(() => HienThongBao("ĐANG DOWNLOAD"));
                    t2.Start();

                    // khi download hoàn tất thì stop 2 thread lại
                    t1.Join();
                    t2.Abort();

                    // In câu thông báo
                    MessageBox.Show("DOWNLOAD HOÀN TẤT!!!");
                    AnThongBao(); // Ẩn đi dòng thông báo đang download
                    
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Phải chọn 1 file để download.");
            }
            

        }

        // Phương thức download file truyền vào đối tượng client và tên tập tin muốn download
        private void DownloadFile(Ftp client, string filename, string path)
        {
            // Bỏ qua kiểm tra crossthread
            CheckForIllegalCrossThreadCalls = false;
            client.Connect(_ip, _port); // kết nối đến server FTP
            client.Login(_username, _password);

            // thực thi phương thức download(tên tập tin muốn download, vị trí lưu)
            // vị trí lưu ở đây là folder được chọn từ user.
            client.Download(filename, path +"\\"+ filename); // thực thi phương thức download(tên file muốn download, vị trí lưu)


            client.Close();
        }

        // sự kiện nhấn 2 lần vào item trong listview
        private void lstFTP_ItemActivate(object sender, EventArgs e)
        {
            // khi đã vào thư mục con thì hiện nút quay trở lại trang chính
            btnBackToHome.Show();
            String text = lstFTP.SelectedItems[0].Text; // lấy giá trị double click item đó

            using (Ftp client = new Ftp())
            {
                // kết nối đến server FTP
                client.Connect(_ip, _port);
                client.Login(_username, _password);

                // tạo 1 thread thực thi phương thức openFolder
                Thread t = new Thread(() => openFolder(client, text));
                t.IsBackground = true;
                t.Start();

                t.Join();


            }
        }
        
        // phương thức mở thư mục con truyền vào đối tượng client và tên thư mục
        private void openFolder(Ftp client, string text)
        {
            // bỏ qua kiểm tra crossthread
            CheckForIllegalCrossThreadCalls = false;
            try
            {
                // thực thi phương thức getList(truyền vào tên thư mục)
                // phương thức này sẽ return lại ở dạng là List
                List<FtpItem> file_in_folder = client.GetList(text);

                // duyệt qua từng đối tượng ftpitem và in ra trong listview
                foreach (FtpItem item in file_in_folder)
                {
                    // thêm từng tập tin vào listview
                    lstFTP.Items.Clear();
                    ListViewItem ds = new ListViewItem(item.Name);
                    ds.SubItems.Add(item.ModifyDate.ToShortDateString());
                    ds.SubItems.Add(item.Size.ToString());

                    lstFTP.Items.Add(ds);

                }
            }
            catch (FtpResponseException)
            {
                // nếu thư mục được chọn rỗng thì in ra câu thông báo!
                MessageBox.Show("Thư mục trống !!");
            }

        }

        // sự kiện nhấn nút quay về trang chính
        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            // gọi lại hàm main_load
            Main_FTP_Load(sender, e);
            btnBackToHome.Hide();
        }

        // phương thức hiện thông báo
        private void HienThongBao(string download)
        {
            // ẩn đi toàn bộ các textbox, button chỉ hiện label đang download
            CheckForIllegalCrossThreadCalls = false;
            lblHello.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            lstFTP.Hide();
            lblDownload.Show();
            lblDownload.Text = download;
        }

        // phương thức ẩn thông báo
        private void AnThongBao()
        {
            // hiện lại các label textbox như ban đầu và ẩn đi thông báo đang download
            lblHello.Show();
            lstFTP.Show();
            button1.Show();
            button2.Show();
            button3.Show();

            lblDownload.Hide();
        }

        // Khi nhấn nút close trong thanh menu bar
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // hiện câu thông báo xác thực thoát
            if (MessageBox.Show("Bạn có muốn thoát?", "Thoát ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Tắt toàn bộ
                this.Close();
                // hiện lại trang login
                Login l = new Login();
                l.Show();
            }
            else
            {
                // nếu nhấn nút không thì quay lại trang chủ
                return;
            }
        }

        // sự kiện nhấn nút xóa file hoặc folder trong thanh menu bar
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa khong?", "XÓA ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (Ftp client = new Ftp())
                {
                    try
                    {
                        // kết nối đến server FTP
                        client.Connect(_ip, _port);
                        client.Login(_username, _password);

                        // lấy giá trị tên file hoặc tập tin được chọn ở listview
                        string filename = lstFTP.SelectedItems[0].Text;
                        // nếu giá trị này là tập tin.
                        if (lstFTP.SelectedItems[0].SubItems[3].Text == "Là tập tin")
                        {
                            // thực thi phương thức DeleteFile(tên tập tin muốn xóa)
                            client.DeleteFile(filename);
                            // sau đó gọi lại hàm main_load để cập nhật lại danh sách file
                            Thread t = new Thread(() => button4_Click(sender, e));
                            t.IsBackground = true;
                            t.Start();
                        }
                        // nếu giá trị này là thư mục
                        else if (lstFTP.SelectedItems[0].SubItems[3].Text == "Là thư mục")
                        {
                            // thực thi phương thức DeleteFolder(tên thư mục muốn xóa)
                            client.DeleteFolder(filename);
                            // sau đó gọi lại hàm main_load để cập nhật lại danh sách file
                            Thread t = new Thread(() => Main_FTP_Load(sender, e));
                            t.IsBackground = true;
                            t.Start();
                        }

                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        // nếu không chọn gì cả thì hiện câu thông báo lỗi
                        MessageBox.Show("Phải chọn tập tin để xóa");
                    }

                }
            }
            else
            {
                return;
            }
            
        }

        // khi nhấn nút tạo thư mục mới
        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide(); // tắt trang chủ, mở trang upload
            // truyền các dữ liệu ip, username, password sang trang CreateFolder
            CreateFolder create = new CreateFolder(_ip, _port, _username, _password);
            create.Show();
        }

        // khi nhấn nút rename
        private void renameSelectedFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa khong?", "XÓA ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (Ftp client = new Ftp())
                {
                    try
                    {
                        // kết nối đến Server FTP
                        client.Connect(_ip, _port);
                        client.Login(_username, _password);

                        // lấy tên file được chọn trong listview
                        string filename = lstFTP.SelectedItems[0].Text;
                        // kiểu file là tập tin hay thư mục
                        string type = lstFTP.SelectedItems[0].SubItems[3].Text;

                        // sau đó truyền các dữ liệu này sang form rename.
                        if (lstFTP.SelectedItems[0].SubItems[3].Text == "Là tập tin")
                        {
                            this.Hide();
                            Rename r = new Rename(_ip, _port, _username, _password, type, filename);
                            r.Show();
                        }
                        else if (lstFTP.SelectedItems[0].SubItems[3].Text == "Là thư mục")
                        {
                            this.Hide();
                            Rename r = new Rename(_ip, _port, _username, _password, type, filename);
                            r.Show();
                        }

                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        MessageBox.Show("Phải chọn tập tin để đối tên");
                    }
                }
            }
            else
            {
                return;
            }
            
        }

        // sự kiện chuột phải vào tập tin/ thư mục trong listview
        private void lstFTP_MouseClick(object sender, MouseEventArgs e)
        {
            // nếu nhấn chuột phải thì hiện mini menu ở ngay vị trị nhấn chuọt
            if (e.Button == MouseButtons.Right)
            {
                // hiện thanh menu mini ở ngay vị trí nhấn chuột phải 
                if (lstFTP.FocusedItem.Bounds.Contains(e.Location) == true)
                {                   
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        // gọi lời sự kiện đổi tên có trong menu bar đối với mini menu khi nhấn chuột phải
        private void rename_Click(object sender, EventArgs e)
        {
            renameSelectedFolderToolStripMenuItem_Click(sender, e);            
        }

        // gọi lời sự kiện xóa có trong menu bar đối với mini menu khi nhấn chuột phải
        private void delete_Click(object sender, EventArgs e)
        {
            deleteToolStripMenuItem_Click(sender, e);
        }

        // gọi lời sự kiện tải về  đối với mini menu khi nhấn chuột phải
        private void download_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        // khi nhấn nút tải lại trang.
        private void button4_Click(object sender, EventArgs e)
        {
            // bỏ qua kiểm tra crossthread
            CheckForIllegalCrossThreadCalls = false;
            // gọi lại hàm main_load bằng thread, và cho thread này là background
            Thread t = new Thread(() => Main_FTP_Load(sender, e));
            t.IsBackground = true;
            t.Start();

            // hiện câu thông báo trong quá trình thread trên đang tải lại trang
            Thread t2 = new Thread(() => HienThongBao("ĐANG TẢI LẠI TRANG"));
            t2.Start();

            // khi tải lại trang hoàn tất thì stop 2 thread lại
            t.Join();
            t2.Abort();

            // In câu thông báo
            MessageBox.Show("TẢI LẠI HOÀN TẤT!!!");
            AnThongBao(); // Ẩn đi dòng thông báo đang download
        }


        // sự kiện xác thực lại khi đóng form.
        private void Main_FTP_FormClosing(object sender, FormClosingEventArgs e)
        {
            // khi nhấn nút cancel, thì quay lại trang hiện tại.
            if (MessageBox.Show("Bạn có chắc là muốn thoát không?", "FTP CLIENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                
            }
            // khi nhấn đồng ý thì kill hết tất cả thread đang chạy của chương trình
            // đồng thời thoát hẳn chương trình.
            else
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

        // Hiệu ứng đổi màu chữ câu Xin chào user mỗi 3s
        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random(); // tạo 1 hàm random để lấy mã màu ngẫu nhiên
            // khai báo 4 biến ứng với 4 giá trị màu argb ( từ 0 đến 255) 
            int a = random.Next(0, 255);
            int r = random.Next(0, 255);
            int g = random.Next(0, 255);
            int b = random.Next(0, 255);

            // sau đó đổi thuộc tính màu chữ
            lblHello.ForeColor = Color.FromArgb(a, r, g, b);
        }

        private void kiểmTraTốcĐộMạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Speed s = new Speed();
            s.Show();
        }
    }
}   
