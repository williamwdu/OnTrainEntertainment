using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class VD : Form
    {
        private string videoPaths;

        public VD()
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }
        public VD(String xml)
        {
            videoPaths = xml;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }
        private void v_Click(object sender, EventArgs e, string link)
        {
            string folderPath = @"C:\Users\VIA RAIL\Desktop\Videos\seville\" + Form1.rm.GetString("lan") + "\\";
            //string folderPath = @"C:\Users\Inno3\Desktop\Videos\seville\en\";
            Player m = new Player(folderPath+link);
            m.Show();
        }
        private void VD_Load(object sender, EventArgs e)
        {
            bannerleft.Size = new Size(ClientRectangle.Width / 5, ClientRectangle.Height);
            XmlReader xReader = XmlReader.Create(new StringReader(File.ReadAllText(videoPaths)));
            label1.Location = new Point(ClientRectangle.Width / 5 + 15, ClientRectangle.Height/48);
            label1.AutoSize = true;
            label1.BringToFront();
            int tmp = (ClientRectangle.Height / 48);
            poster.Location = new Point(ClientRectangle.Width / 5 + 15, tmp);
            poster.Size = new Size(ClientRectangle.Width *4/ 5 - 50, (ClientRectangle.Width * 4 / 5 - 135) * 470 / 1024);
            des.Location = new Point(ClientRectangle.Width / 5 + 15, (ClientRectangle.Height / 48 )+ 45+((ClientRectangle.Width * 4 / 5 - 135) * 470 / 1024));
            des.Size = new Size(ClientRectangle.Width * 4 / 5 - 50, ClientRectangle.Height - 20 - ((ClientRectangle.Height / 48) + 45 + ((ClientRectangle.Width * 4 / 5 - 135) * 470 / 1024)));
            label2.Location = new Point(ClientRectangle.Width / 5 + 15, ClientRectangle.Height*22 / 24);
            label3.Location = new Point(ClientRectangle.Width / 5 + 15, 20 + ClientRectangle.Height*22 / 24);
            label4.Location = new Point(20, ClientRectangle.Height / 14 * 1);
            label4.Text = Form1.rm.GetString("trailer");
            label6.Location = new Point(20, ClientRectangle.Height / 14 * 2);
            label6.Text = Form1.rm.GetString("play");
            label5.Location = new Point(20, ClientRectangle.Height / 14 * 13);
            label5.Text = Form1.rm.GetString("back");
            while (xReader.Read())
            {
                switch (xReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (xReader.Name == "title")
                        {
                            xReader.Read();
                            label1.Text = xReader.Value;
                        }
                        else if (xReader.Name == "link")
                        {
                            xReader.Read();
                            string processed = xReader.Value.Replace("\n", "");
                            label6.Click += (sender1, EventArgs) => { v_Click(sender1, EventArgs, processed); };
                            if (File.Exists(@"C:\Users\VIA RAIL\Desktop\Videos\seville\" + Form1.rm.GetString("lan") + "\\" + processed.Replace(".mp4", "_preview.mp4")))
                            {
                               
                                label4.Visible = true;
                                label4.Click += (sender1, EventArgs) => { v_Click(sender1, EventArgs, processed.Replace(".mp4", "_preview.mp4")); };

                            }
                            else
                            {
                                label4.Visible = false;
                            }
                            using (Stream bmpStream = System.IO.File.Open(@"C:\Users\VIA RAIL\Desktop\Videos\seville\"+Form1.rm.GetString("lan")+"\\" + processed.Replace(".mp4", "_thumb.jpg"), System.IO.FileMode.Open))
                            {
                                Image image = Image.FromStream(bmpStream);
                                poster.Image = image;
                            }
                        }
                        else if (xReader.Name == "description")
                        {
                            xReader.Read();
                            string processed = xReader.Value.Replace("\n", "");
                            des.Text = processed;
                        }
                        else if (xReader.Name == "pubDate")
                        {
                            xReader.Read();
                            string processed = xReader.Value.Replace("\n", "");
                            label2.Text = Form1.rm.GetString("pubdate")+": "+ processed;
                        }
                        else if (xReader.Name == "category")
                        {
                            xReader.Read();
                            string processed = xReader.Value.Replace("\n", "");
                            label3.Text = Form1.rm.GetString("cat") + ": " + processed;
                        }
                        break;
                    case XmlNodeType.Text:

                        break;
                    case XmlNodeType.EndElement:

                        break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void poster_Click(object sender, EventArgs e)
        {

        }

        private void des_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
