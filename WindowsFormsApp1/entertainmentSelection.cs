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

namespace WindowsFormsApp1
{
    public partial class entertainmentSelection : Form
    {
        List<Item> movies = new List<Item>();
        List<PictureBox> active = new List<PictureBox>();
        List<Label> activelabel = new List<Label>();
        List<Movie> Eonemovies = new List<Movie>();
        int scrollcounter = 0;
        int scrollmax = 0;
        public entertainmentSelection()
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void entertainmentSelection_Load(object sender, EventArgs e)
        {
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            Size formSize = new Size(ClientRectangle.Width, resolution.Height);
            bannerleft.Size = new Size(this.Width / 5, ClientRectangle.Height);
            label1.Location = new Point(20, ClientRectangle.Height / 14 * 1);
            label2.Location = new Point(20, ClientRectangle.Height / 14 * 2);
            label3.Location = new Point(20, ClientRectangle.Height / 14 * 3);
            label4.Location = new Point(20, ClientRectangle.Height / 14 * 4);
            label5.Location = new Point(20, ClientRectangle.Height / 14 * 13);
            label1.Text = Form1.rm.GetString("movie");
            label2.Text = Form1.rm.GetString("eone");
            label3.Text = Form1.rm.GetString("tvshow");
            label4.Text = Form1.rm.GetString("cityguide");
            label5.Text = Form1.rm.GetString("back");
        }

        private void v_Click(object sender, EventArgs e)
        {
            string folderPath = @"C:\Users\VIA RAIL\Desktop\Videos\";
            //string folderPath = @"C:\Users\Inno3\Desktop\Videos\";
            PictureBox movieselected = (PictureBox)sender;
            folderPath = folderPath + movieselected.Name + ".mp4";
            Player m = new Player(folderPath);
            m.Show();
        }
        private void v_Click_d(object sender, EventArgs e)
        {
            string folderPath = @"C:\Users\VIA RAIL\Desktop\Videos\seville\"+Form1.rm.GetString("lan")+"\\";
            //string folderPath = @"C:\Users\Inno3\Desktop\Videos\seville\en\";
            PictureBox movieselected = (PictureBox)sender;
            folderPath = folderPath + movieselected.Name.Replace(" ","_") + ".xml";
            VD m = new VD(folderPath);
            m.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            scrollmax = 0;
            scrollcounter = 0;
            foreach (PictureBox tmp in active)
            {
                this.Controls.Remove(tmp);
                tmp.Dispose();
            }
            foreach(Label tmp in activelabel)
            {
                this.Controls.Remove(tmp);
                tmp.Dispose();
            }
            active.Clear();
            activelabel.Clear();
            movies.Clear();
            Eonemovies.Clear();
            string[] videoPaths;
            string folderPath = @"C:\Users\VIA RAIL\Desktop\Videos\";
         //string folderPath = @"C:\Users\Inno3\Desktop\Videos\";
            videoPaths = Directory.GetFiles(folderPath, "*.mp4");
            if (videoPaths != null)
            {
                foreach (string path in videoPaths)
                {
                    string vid = path.Replace(folderPath, string.Empty);
                    vid = vid.Replace(".mp4", string.Empty);
                    Item tmp = new Item(){ name = vid, directory = path, image = path.Replace(".mp4",string.Empty) + ".jpg" };
                    movies.Add(tmp);
                }
            }
            int counter = 1;
            int row = 0;
            foreach (Item tmp1 in movies)
            {
                double tmppp = ((ClientRectangle.Width / 5) - 20) * 755 / 483;
                if (counter >= 5)
                {
                    counter = 1;
                    scrollmax += (int)tmppp/20 +1;
                    row++;
                }
                Bitmap bitmap;
                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.Location = new System.Drawing.Point(ClientRectangle.Width / 5 * counter +10, ClientRectangle.Height / 14 + row*(Int32)(tmppp+10));
                pictureBox1.Name = tmp1.name;
                //pictureBox1.Size = new System.Drawing.Size(254, 377);
                pictureBox1.Size = new System.Drawing.Size((ClientRectangle.Width / 5) -20, (Int32)tmppp);
                using (Stream bmpStream = System.IO.File.Open(tmp1.image, System.IO.FileMode.Open)) { 
                Image image = Image.FromStream(bmpStream);
                bitmap = new Bitmap(image);
                }
                pictureBox1.Image = bitmap;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.MouseClick += new MouseEventHandler(v_Click); 
                this.Controls.Add(pictureBox1);
                active.Add(pictureBox1);
                counter++;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            scrollmax = 0;
            scrollcounter = 0;
            foreach (PictureBox tmp in active)
            {
                this.Controls.Remove(tmp);
                tmp.Dispose();
            }
            foreach (Label tmp in activelabel)
            {
                this.Controls.Remove(tmp);
                tmp.Dispose();
            }
            active.Clear();
            activelabel.Clear();
            movies.Clear();
            Eonemovies.Clear();
            string[] videoPaths;
            string folderPath = @"C:\Users\VIA RAIL\Desktop\Videos\seville\"+Form1.rm.GetString("lan")+"\\";;
            //string folderPath = @"C:\Users\Inno3\Desktop\Videos\seville\en\";
            videoPaths = Directory.GetFiles(folderPath, "*.mp4");
            if (videoPaths != null)
            {
                foreach (string path in videoPaths)
                {
                    if (!path.Contains("preview"))
                    { 
                        string vid = path.Replace(folderPath, string.Empty);
                        vid = vid.Replace(".mp4", string.Empty);
                        Movie tmp = new Movie() { name = vid.Replace("_"," "),des= path.Replace(".mp4", ".xml"), tralier= path.Replace(".mp4", string.Empty)+"_preview.mp4", directory = path, image = path.Replace(".mp4", string.Empty) + "_thumb.jpg" };
                        Eonemovies.Add(tmp);
                    }
                }
            }
            int counter = 0;
            int row = 0;
            foreach (Movie tmp1 in Eonemovies)
            {
                double tmppp = ((ClientRectangle.Width / 5 * 2) - 20) * 470 / 1024;
                if (counter > 1)
                {
                    counter = 0;
                    scrollmax += (Int32)(tmppp+20)/20 ;
                    row++;
                }
                Bitmap bitmap;
                Label caption = new Label();
                caption.Text = tmp1.name;
                caption.Location = new System.Drawing.Point((ClientRectangle.Width / 5) +  (ClientRectangle.Width*2* counter / 5) + 10, (ClientRectangle.Height / 14) + (row * ((Int32)tmppp + 20)));
                caption.AutoSize = true;
                Font _normalFont = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                caption.Font = _normalFont;
                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.Location = new System.Drawing.Point((ClientRectangle.Width / 5) + (ClientRectangle.Width * 2 * counter / 5) + 10, (ClientRectangle.Height / 14) + (row * ((Int32)tmppp +20)));
                pictureBox1.Name = tmp1.name;
                pictureBox1.Size = new System.Drawing.Size((ClientRectangle.Width/5*2)-20, (Int32)tmppp);
                using (Stream bmpStream = System.IO.File.Open(tmp1.image, System.IO.FileMode.Open))
                {
                    Image image = Image.FromStream(bmpStream);
                    bitmap = new Bitmap(image);
                }
                pictureBox1.Image = bitmap;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.MouseClick += new MouseEventHandler(v_Click_d);
                this.Controls.Add(pictureBox1);
                this.Controls.Add(caption);
                caption.BringToFront();
                active.Add(pictureBox1);
                activelabel.Add(caption);
                counter++;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.Location = new System.Drawing.Point(79, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(100, 50);
            pictureBox1.BackColor = Color.Black;
            this.Controls.Add(pictureBox1);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.Location = new System.Drawing.Point(79, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(100, 50);
            pictureBox1.BackColor = Color.Black;
            this.Controls.Add(pictureBox1);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabhold(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (scrollcounter == 0)
                {
                    //do nothing
                }
                else
                {
                    scrollcounter--;
                    foreach (PictureBox tmp in active)
                    {
                        //up
                        tmp.Top += 20;
                    }
                    foreach (Label tmp in activelabel)
                    {
                        //up
                        tmp.Top += 20;
                    }
                }
                
            }
            else
            {
                if (scrollcounter <= scrollmax)
                {
                    scrollcounter++;
                    foreach (PictureBox tmp in active)
                    {
                        //down
                        tmp.Top -= 20;
                    }
                    foreach (Label tmp in activelabel)
                    {
                        //down
                        tmp.Top -= 20;
                    }
                }
                else
                {
                    //donothing
                }
            }
        }
    }

    public class Item
    {
        public String name { get; set; }
        public String directory { get; set; }
        public String image { get; set; }
    }

    public class Movie
    {
        public String name { get; set; }
        public String directory { get; set; }
        public String des { get; set; }
        public String tralier { get; set; }
        public String image { get; set; }
    }
}
