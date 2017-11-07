using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace WindowsFormsApp1
{
 
    public partial class Form1 : Form
    {
        GMapMarker marker =
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(11, -11),
                    Properties.Resources.pin_map);
        public static ResourceManager rm = new ResourceManager("WindowsFormsApp1.en_local", Assembly.GetExecutingAssembly());

        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

            gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            GMap.NET.MapProviders.OpenStreetMapProvider.UserAgent = "IE";

            gmap.Position = new GMap.NET.PointLatLng(45.385, -74.08);
            gmap.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            GMaps.Instance.OptimizeMapDb(null);
            //dev
            //gmap.CacheLocation = @"C:\Users\Inno3\Desktop\";
            //prod
            gmap.CacheLocation = @"C:\Users\VIA RAIL\Desktop\";
            gmap.Zoom = 14;
            gmap.Size = new Size(this.Width, this.Height);
            bannerTop.Size = new Size(this.Width, this.Height / 7);
            bottonbanner.Size = new Size(this.Width, statusimage.Size.Height);
            //localization
            lanchange.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("fr");
            lanchange.Tag = "Français";
            label1.Text = rm.GetString("welcome");
            button2.Text = rm.GetString("enterbutton");
            label2.Text = rm.GetString("nextstop") + ": ";
            label3.Text = rm.GetString("time") + ": ";
            //end of localization
            label1.Location = new System.Drawing.Point(Convert.ToInt16(2.34 * (this.Height / 7) + 15), this.Height / 7 / 2 - 12); //12 is font size.
            label2.Location = new System.Drawing.Point(label2.Location.X, this.Height / 7 / 2 / 2);
            label3.Location = new System.Drawing.Point(label3.Location.X, this.Height / 7 / 2);
            label4.Location = new System.Drawing.Point((this.Width / 2) - (statusimage.Width / 2) + statusimage.Width + 20, this.Height / 14 * 13);
            label5.Location = new System.Drawing.Point((this.Width / 2) - (statusimage.Width / 2) + statusimage.Width + 20, this.Height / 14 * 12);
            Nextstation.Location = new System.Drawing.Point(Nextstation.Location.X, this.Height / 7 / 2 / 2);
            LocalTimecell.Location = new System.Drawing.Point(LocalTimecell.Location.X, this.Height / 7 / 2);
            bottonbanner.Location = new System.Drawing.Point(0, this.Height - bottonbanner.Size.Height);
            statusimage.Location = new System.Drawing.Point((this.Width / 2) - (statusimage.Width / 2), this.Height - statusimage.Size.Height - 5);
            logobottom.Location = new System.Drawing.Point(0, this.Height - 114);
            lanchange.Location = new System.Drawing.Point(0, this.Height - 114);
            //hide bottom logo for now
            logobottom.Visible = false;
            upperlogo.Size = new Size(Convert.ToInt16(2.34 * (this.Height / 7)), this.Height / 7);
            upperlogo.Location = new System.Drawing.Point(0, 0); //12 is font size.
            pictureBox1.Location = new Point(label2.Location.X, 0);
            pictureBox1.Size = new Size(this.Width-pictureBox1.Location.X, this.Height / 7);
            button1.Location = new Point(label2.Location.X - 100, 20);
            button2.Location = new Point(label2.Location.X - 100, 40);
            Program.GPSTrack();

            gmap.ShowCenter = false;

            GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");


            if (Convert.ToDouble(Program.Latitude) != 0 && Convert.ToDouble(Program.Longitude) != 0)
            {

                marker.Position = new GMap.NET.PointLatLng(Convert.ToDouble(Program.Latitude), Convert.ToDouble(Program.Longitude)); ;
                gmap.Position = new GMap.NET.PointLatLng(Convert.ToDouble(Program.Latitude), Convert.ToDouble(Program.Longitude));
            }
            gmap.Overlays.Add(markers);
            markers.Markers.Add(marker);
            foreach(Station tmp in Program.stationlist)
            {
                if(tmp.left != null) { 
                GMapMarker station =
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(Convert.ToDouble(tmp.middle.lat), Convert.ToDouble(tmp.middle.lng)),
                    Properties.Resources.stationlogo);
                markers.Markers.Add(station);
                }
            }
            InitializeBackgroundWorker();
            backgroundWorker1.RunWorkerAsync();

        }

        private System.ComponentModel.BackgroundWorker backgroundWorker1;

        // Set up the BackgroundWorker object by 
        // attaching event handlers. 
        private void InitializeBackgroundWorker()
        {

            backgroundWorker1.DoWork +=
                new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorker1_ProgressChanged);
        }
        // This event handler is where the actual,
        // potentially time-consuming work is done.
        private void backgroundWorker1_DoWork(object sender,
            DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;
            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the 
            // RunWorkerCompleted eventhandler.
            while (!worker.CancellationPending) {
            worker.ReportProgress((10));
            Program.GPSTrack();
            worker.ReportProgress((40));
            GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");
            worker.ReportProgress((60));
                if (Convert.ToDouble(Program.Latitude) != 0 && Convert.ToDouble(Program.Longitude) != 0)
            {
                    marker.Position = new GMap.NET.PointLatLng(Convert.ToDouble(Program.Latitude), Convert.ToDouble(Program.Longitude));
                    gmap.Invoke(t => t.Position = new PointLatLng(Convert.ToDouble(Program.Latitude), Convert.ToDouble(Program.Longitude)));
                    gmap.Invoke(t => t.Overlays.Add(markers));
            }

                Program.NearestCity();
            worker.ReportProgress((80));
                LocalTimecell.Invoke(t => t.Text = Program.locatime);
             Nextstation.Invoke(t => t.Text = Program.NerCity);
                label4.Invoke(t => t.Text = rm.GetString("altitude")+": " + Program.Altitude +"m");
                label5.Invoke(t => t.Text = rm.GetString("speed")+": " + Program.Speed + "km/h");
                statusimage.Invoke(t => t.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(Program.link));
            worker.ReportProgress((100));
            }

        }

        // This event handler deals with the results of the
        // background operation.
        private void backgroundWorker1_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled 
                // the operation.
                // Note that due to a race condition in 
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.
                status.Text = "Canceled";
            }
        }
        // This event handler updates the progress bar.
        private void backgroundWorker1_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader file;
            //dev
            //file = new System.IO.StreamReader(@"C:\Users\Inno3\Desktop\waypoints.csv");
            //prod
            file = new System.IO.StreamReader(@"C:\Users\VIA RAIL\Desktop\waypoints.csv");

            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] values = line.Split(',');
                gmap.Position = new GMap.NET.PointLatLng(Convert.ToDouble(values[1]), Convert.ToDouble(values[2]));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Player m = new Player();
            //m.Show();
            entertainmentSelection m = new entertainmentSelection();
            m.Show();
        }

        private void lanchange_Click_1(object sender, EventArgs e)
        {
            if ((string)lanchange.Tag == "Français")
            {//fr
                rm = new ResourceManager("WindowsFormsApp1.fr_local", Assembly.GetExecutingAssembly());
                label1.Text = rm.GetString("welcome");
                button2.Text = rm.GetString("enterbutton");
                label2.Text = rm.GetString("nextstop") + ": ";
                label3.Text = rm.GetString("time") + ": ";
                lanchange.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("gb");
                lanchange.Tag = "English";
            }
            else
            {//en
                rm = new ResourceManager("WindowsFormsApp1.en_local", Assembly.GetExecutingAssembly());
                label1.Text = rm.GetString("welcome");
                button2.Text = rm.GetString("enterbutton");
                label2.Text = rm.GetString("nextstop") + ": ";
                label3.Text = rm.GetString("time") + ": ";
                lanchange.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("fr");
                lanchange.Tag = "Français";
            }
        }
    }

    public static class Extensions
    {
        public static void Invoke<TControlType>(this TControlType control, Action<TControlType> del)
            where TControlType : Control
        {
            if (control.InvokeRequired)
                control.Invoke(new Action(() => del(control)));
            else
                del(control);
        }
    }
}
