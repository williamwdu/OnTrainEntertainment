using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WMPLib;
using AxWMPLib;

namespace WindowsFormsApp1
{
    public partial class Player : Form
    {
        private string state = "";
        private int x = 1;
        private int y = 1;
        private string videoPaths;
        private Size formSize;
        private int globalcounter,cusorcount = 1;
        public Player()
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }
        public Player(string passed)
        {
            videoPaths = passed;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }
        private void Player_Load(object sender, EventArgs e)
        {
            Font _normalFont = new Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Color _fore = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            button1.Font = _normalFont;
            button2.Font = _normalFont;
            button1.BackColor = Color.Black;
            button2.BackColor = Color.Black;
            button2.Text = Form1.rm.GetString("playbutton");
            button1.Text = Form1.rm.GetString("stopbutton");
            button1.ForeColor = _fore;
            button2.ForeColor = _fore;
            //button1.FlatAppearance.BorderColor = _back;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            formSize = new Size(this.Width, this.Height);
            axWindowsMediaPlayer1.Size = formSize;
            axWindowsMediaPlayer1.enableContextMenu = false;
            axWindowsMediaPlayer1.Ctlenabled = false;
            axWindowsMediaPlayer1.uiMode = "none";      
            axWindowsMediaPlayer1.URL = videoPaths;
            axWindowsMediaPlayer1.windowlessVideo = true;
            axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(axWindowsMediaPlayer1_PlayStateChange);
            axWindowsMediaPlayer1.stretchToFit = true;
            trackBar1.Location = new Point(this.Size.Width / 10, this.Size.Height / 10*9);
            label3.Location = new Point(this.Size.Width / 10, this.Size.Height / 10 * 9 +30);
            button2.Location = new Point(this.Size.Width / 10, this.Size.Height / 10 * 9 +45); //first button
            button1.Location = new Point(this.Size.Width / 10 +200, this.Size.Height / 10 * 9 +45);
        }
        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            switch (e.newState)
            {
                case 0:    // Undefined
                    state = "Undefined";
                    break;

                case 1:    // Stopped
                    state = "Stopped";
                    this.Close();
                    break;

                case 2:    // Paused
                    state = "Paused";
                    timer1.Stop();

                    break;

                case 3:    // Playing
                    state = "Playing";
                    trackBar1.Maximum = (int)axWindowsMediaPlayer1.Ctlcontrols.currentItem.duration;
                    timer1.Start();
                    break;

                case 4:    // ScanForward
                    state = "ScanForward";
                    break;

                case 5:    // ScanReverse
                    state = "ScanReverse";
                    break;

                case 6:    // Buffering
                    state = "Buffering";
                    break;

                case 7:    // Waiting
                    state = "Waiting";
                    break;

                case 8:    // MediaEnded
                    state = "MediaEnded";
                    Cursor.Show();
                    this.Close();
                    break;

                case 9:    // Transitioning
                    state = "Transitioning";
                    break;

                case 10:   // Ready
                    state = "Ready";
                    break;

                case 11:   // Reconnecting
                    state = "Reconnecting";
                    break;

                case 12:   // Last
                    state = "Last";
                    break;

                default:
                    state = ("Unknown State: " + e.newState.ToString());
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void wakeup(object sender, _WMPOCXEvents_MouseMoveEvent e)
        {
            if (x != e.fX || y != e.fY)
            {
                globalcounter = 0;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                trackBar1.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                x = e.fX;
                y = e.fY;
                if (cusorcount < 1)
                {
                    cusorcount++;
                    Cursor.Show();
                }
                else
                {

                }
            }
        }
        private void wakeup1(object sender, _WMPOCXEvents_MouseDownEvent e)
        {

                globalcounter = 0;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                trackBar1.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                cusorcount++;
                Cursor.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            globalcounter++;
            if (state == "Playing")
            {
                trackBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
                if(globalcounter >= 1000)
                {
                    label1.Visible = true;
                    label2.Visible = true;
                    globalcounter = 0;
                }
                if(globalcounter == 50)
                {
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    trackBar1.Visible = false;
                    button1.Visible = false;
                    button2.Visible = false;
                    if (cusorcount>0)
                    {
                        Cursor.Hide();
                        cusorcount=0;
                    }
                }
            }
            label1.Text = Form1.rm.GetString("nextstop") + ": " + Program.NerCity;
            label2.Text = Form1.rm.GetString("time") + ": " + Program.locatime;
            label3.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = trackBar1.Value;
            
        }
        private void trackBar1_MouseDown(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }
        private void trackBar1_MouseUp(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(state == "Playing")
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }
    }


}
