using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class TV : Form
    {
        List<TVitem> cbbbbbbbc = new List<TVitem>();
        string folderPath;
        public TV()
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }
        public TV(String xml)
        {
            folderPath = xml;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }
        private void TV_Load(object sender, EventArgs e)
        {
            bannerleft.Size = new Size(ClientRectangle.Width / 5, ClientRectangle.Height);
            label1.Location = new Point(ClientRectangle.Width / 5 + 15, ClientRectangle.Height / 48);
            label1.AutoSize = true;
            label1.BringToFront();
            int tmp = (ClientRectangle.Height / 48);
            poster.Location = new Point(ClientRectangle.Width / 5 + 15, tmp);
            poster.Size = new Size(ClientRectangle.Width * 4 / 5 - 50, (ClientRectangle.Width * 4 / 5 - 135) * 470 / 1024);
            using (Stream bmpStream = System.IO.File.Open(folderPath+"\\poster.jpg", FileMode.Open))
            {
                Image image = Image.FromStream(bmpStream);
                poster.Image = image;
            }
            des.Location = new Point(ClientRectangle.Width / 5 + 415, (ClientRectangle.Height / 48) + 45 + ((ClientRectangle.Width * 4 / 5 - 135) * 470 / 1024));
            des.Size = new Size(ClientRectangle.Width * 4 / 5 -400, ClientRectangle.Height - 20 - ((ClientRectangle.Height / 48) + 45 + ((ClientRectangle.Width * 4 / 5 - 135) * 470 / 1024)));
            listBox1.Location = new Point(ClientRectangle.Width / 5 + 15, (ClientRectangle.Height / 48) + 45 + ((ClientRectangle.Width * 4 / 5 - 135) * 470 / 1024));
            listBox1.Size = new Size(400, ClientRectangle.Height - 20 - ((ClientRectangle.Height / 48) + 45 + ((ClientRectangle.Width * 4 / 5 - 135) * 470 / 1024)));
            label6.Location = new Point(20, ClientRectangle.Height / 14 * 2);
            label6.Text = Form1.rm.GetString("play");
            label5.Location = new Point(20, ClientRectangle.Height / 14 * 13);
            label5.Text = Form1.rm.GetString("back");
            string[] videoPaths;
            videoPaths = Directory.GetFiles(folderPath, "*.mp4");
            if (videoPaths != null)
            {
                foreach (string path in videoPaths)
                {
                    XmlReader xReader = XmlReader.Create(new StringReader(File.ReadAllText(path.Replace(".mp4",".xml"))));
                    TVitem tmp1 = new TVitem(){ name = "", directory = path, des = "" };
                    while (xReader.Read())
                    {
                        switch (xReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (xReader.Name == "title")
                                {
                                    xReader.Read();
                                    tmp1.name = xReader.Value;
                                    label1.Text = xReader.Value;
                                }
                                else if(xReader.Name == "description")
                                {
                                    xReader.Read();
                                    tmp1.des = xReader.Value;
                                }
                                break;
                            case XmlNodeType.Text:

                                break;
                            case XmlNodeType.EndElement:

                                break;

                        }
                    }
                    cbbbbbbbc.Add(tmp1);
                }
                listBox1.DataSource = cbbbbbbbc;
                listBox1.DisplayMember = "name";
                listBox1.ValueMember = "directory";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Player m = new Player(listBox1.SelectedValue.ToString());
            m.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (TVitem abc in cbbbbbbbc)
            {
                if(abc.directory == listBox1.SelectedValue.ToString())
                {
                    des.Text = abc.des;
                }
            }
            
        }
    }

    public class TVitem
    {
        public String name { get; set; }
        public String directory { get; set; }
        public String des { get; set; }
    }
}

