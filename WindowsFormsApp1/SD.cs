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
            label1.Text = Form1.rm.GetString("trailer");
            label2.Location = new Point(20, ClientRectangle.Height / 14 * 2);
            label2.Text = Form1.rm.GetString("trailer");
            backbutton.Text = Form1.rm.GetString("back");
            backbutton.Location = new Point(20, ClientRectangle.Height / 14 * 13);
            XmlReader xReader = XmlReader.Create(new StringReader(File.ReadAllText(xmlPaths)));
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
