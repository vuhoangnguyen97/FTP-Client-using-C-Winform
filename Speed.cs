using Echevil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FTP
{
    public partial class Speed : Form
    {
        public Speed()
        {
            InitializeComponent();
        }
        // Tạo mới đối tượng NetworkAdapter và Monitor để lấy danh sách card mạng trong máy
        private NetworkAdapter[] adapters;
        private NetworkMonitor monitor;

        // sự kiện form load
        private void Speed_Load(object sender, EventArgs e)
        {
            monitor = new NetworkMonitor();
            this.adapters = monitor.Adapters;
            // lấy danh sách card mạng hiện có trong máy

            if (adapters.Length == 0)
            {
                // nếu không tìm thấy thì in câu thông báo
                this.lstCard.Enabled = false;
                MessageBox.Show("Không tìm thấy card mạng trên máy bạn.");
                return;
            }
            // nếu có thì thêm vào listbox
            this.lstCard.Items.AddRange(this.adapters);
        }

        private void lstCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            // sự kiện chọn card mạng trong listbox
            monitor.StopMonitoring(); // ngưng không phân tích để phân tích card mạng đã chọn
            monitor.StartMonitoring(adapters[this.lstCard.SelectedIndex]); 
            this.timer1.Start(); // start sự kiện bấm giờ
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // tính thời gian upload và download từ phương thức 
            NetworkAdapter adapter = this.adapters[this.lstCard.SelectedIndex];
            this.lblDownload.Text = String.Format("{0:n} kbps", adapter.DownloadSpeedKbps);
            this.lblUpload.Text = String.Format("{0:n} kbps", adapter.UploadSpeedKbps);
        }
    }
}
