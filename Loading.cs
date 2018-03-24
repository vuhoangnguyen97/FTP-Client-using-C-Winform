using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FTP
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            loadingBar.Increment(1);
            if (loadingBar.Value == 100)
            {
                timer1.Stop();
                this.Hide();
            }
                

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
