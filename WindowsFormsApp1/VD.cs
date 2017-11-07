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
            label1.Location = new Point(ClientRectangle.Width / 5 + 15, ClientRectangle.Height / 48);
            label1.AutoSize = true;
            poster.Location = new Point(ClientRectangle.Width / 5 + 45, ClientRectangle.Height *2/ 12);
            poster.Size = new Size(ClientRectangle.Width *4/ 5 - 50, (ClientRectangle.Width * 4 / 5 - 135) * 470 / 1024);
            des.Location = new Point(ClientRectangle.Width / 5 + 15, (ClientRectangle.Height / 12 )+ 20+((ClientRectangle.Width * 4 / 5 - 135) * 470 / 1024));
            label2.Location = new Point(ClientRectangle.Width / 5 + 15, ClientRectangle.Height*22 / 24);
            label3.Location = new Point(ClientRectangle.Width / 5 + 15, 20 + ClientRectangle.Height*22 / 24);
            button3.Location = new Point(ClientRectangle.Width / 5 + 15, ClientRectangle.Height * 23 / 24); //back button
            button1.Location = new Point(ClientRectangle.Width *3/ 10 + 15, ClientRectangle.Height*23/ 24);
            button2.Location = new Point(ClientRectangle.Width *4/ 10 + 15, ClientRectangle.Height*23 / 24);

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
                            button2.Tag = xReader.Value;
                            string processed = xReader.Value.Replace("\n", "");
                            button2.Click += (sender1, EventArgs) => { v_Click(sender1, EventArgs, processed); };
                            if (File.Exists(@"C:\Users\VIA RAIL\Desktop\Videos\seville\" + Form1.rm.GetString("lan") + "\\" + processed.Replace(".mp4", "_preview.mp4")))
                            {
                                button1.Visible = true;
                                button1.Tag = processed.Replace(".mp4", "_preview.mp4");
                                button1.Click += (sender1, EventArgs) => { v_Click(sender1, EventArgs, processed.Replace(".mp4", "_preview.mp4")); };
                            }
                            else
                            {
                                button1.Visible = false;
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
                            label2.Text = "Publish Date: "+ processed;
                        }
                        else if (xReader.Name == "category")
                        {
                            xReader.Read();
                            string processed = xReader.Value.Replace("\n", "");
                            label3.Text = "Category: "+ processed;
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
    }
}
