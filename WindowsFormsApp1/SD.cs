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
    public partial class SD : Form
    {
        string xmlPaths;
        string parking, hour, transportation;
        public SD()
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        public SD(string xml)
        {
            xmlPaths = xml;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }


        private void SD_Load(object sender, EventArgs e)
        {
            bannerleft.Size = new Size(ClientRectangle.Width / 5, ClientRectangle.Height);
            label1.Location = new Point(20, ClientRectangle.Height / 14 * 1);
            label1.Text = Form1.rm.GetString("hour");
            label2.Location = new Point(20, ClientRectangle.Height / 14 * 2);
            label2.Text = Form1.rm.GetString("parking");
            label3.Location = new Point(20, ClientRectangle.Height / 14 * 3);
            label3.Text = Form1.rm.GetString("transportation");
            //right panel layout
            stationname.Location = new Point(ClientRectangle.Width / 5 + 20, 20);
            locationbox.Location = new Point(ClientRectangle.Width / 5 + 20, 60);
            locationbox.Size = new Size(ClientRectangle.Width * 3 / 10, ClientRectangle.Height / 10);
            label5.Location = new Point(ClientRectangle.Width / 5 + 20, 80 + (ClientRectangle.Height / 10));
            label5.Text = Form1.rm.GetString("contact");
            contactbox.Location = new Point(ClientRectangle.Width / 5 + 20, 110 + (ClientRectangle.Height / 10));
            contactbox.Size = new Size(ClientRectangle.Width * 3 / 10, ClientRectangle.Height / 10);
            displaycap.Location = new Point(ClientRectangle.Width / 5 + 20, 110 + (ClientRectangle.Height / 5));
            display.Location = new Point(ClientRectangle.Width / 5 + 20, 140 + (ClientRectangle.Height / 5));
            display.Size = new Size(ClientRectangle.Width * 3 / 10, -140 + (ClientRectangle.Height*4 / 5));
            displayright.Location = new Point(ClientRectangle.Width * 3 / 5, ClientRectangle.Height /2 + 50);
            displayright.Size = new Size(ClientRectangle.Width * 2 / 5 - 30, ClientRectangle.Height / 2);
            backbutton.Text = Form1.rm.GetString("back");
            backbutton.Location = new Point(20, ClientRectangle.Height / 14 * 13);
            poster.Location = new Point(ClientRectangle.Width*3 / 5, 20);
            poster.Size = new Size(ClientRectangle.Width * 2 / 5 - 30, ClientRectangle.Height / 2);
            using (Stream bmpStream = System.IO.File.Open(xmlPaths.Replace(".xml", ".jpg"),FileMode.Open))
            {
                Image image = Image.FromStream(bmpStream);
                poster.Image = image;
            }
            XmlReader xReader = XmlReader.Create(new StringReader(File.ReadAllText(xmlPaths)));

            //reading xml

            while (xReader.Read())
            {
                switch (xReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (xReader.Name == "title")
                        {
                            xReader.Read();
                            string processed = xReader.Value.Replace("\n", "");
                            stationname.Text = processed;
                        }
                        else if (xReader.Name == "location")
                        {
                            xReader.Read();
                            string processed = xReader.Value.Replace("\n", "\r\n");
                            locationbox.Text = processed;
                        }
                        else if (xReader.Name == "contact")
                        {
                            xReader.Read();
                            string processed = xReader.Value.Replace("\n", "\r\n");
                            contactbox.Text = processed;
                        }
                        else if (xReader.Name == "description")
                        {
                            xReader.Read();
                            string processed = xReader.Value.Replace("\n", "\r\n");
                            hour = processed;
                        }
                        else if (xReader.Name == "parking")
                        {
                            xReader.Read();
                            string processed = xReader.Value.Replace("\n", "\r\n");
                            parking = processed;
                        }
                        else if (xReader.Name == "public")
                        {
                            xReader.Read();
                            string processed = xReader.Value.Replace("\n", "\r\n");
                            transportation = processed;
                        }
                        break;
                    case XmlNodeType.Text:
                        break;
                    case XmlNodeType.EndElement:
                        break;
                }
            }
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //hour
            displaycap.Text = Form1.rm.GetString("hour");
            display.Text = hour;
            displayright.Text = "";
            if(TextRenderer.MeasureText(display.Text,display.Font).Width/display.Width * display.Font.Height > display.Height)
            {

            }
            if (display.Lines.Count()  > 26)
            {
                string[] lines = display.Lines;
                int i = 0;
                foreach (string li in lines)
                {
                    i++;
                    if (i > 26)
                    {
                        displayright.AppendText(li);
                        displayright.AppendText(Environment.NewLine);
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //parking
            displayright.Text = "";
            displaycap.Text = Form1.rm.GetString("parking");
            display.Text = parking;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //transportation
            displayright.Text = "";
            displaycap.Text = Form1.rm.GetString("transportation");
            display.Text = transportation;
        }
    }
}
