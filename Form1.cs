using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }


        private void start_Click(object sender, EventArgs e)
        {
            Coordinate coor;
            GPS gps = new GPS();
            coor = gps.receiveGPSMsg();


            try
            {
                
                this.webBrowser.Navigate("https://hujubnara1.cafe24.com/kjs/map.php");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();

        }

        private void timer_tick(object sender, System.EventArgs e)
        {
            this.webBrowser.Refresh();
        }
    }
}
