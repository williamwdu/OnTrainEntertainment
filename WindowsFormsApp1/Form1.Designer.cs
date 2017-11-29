namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.status = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.Nextstation = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LocalTimecell = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.upperlogo = new System.Windows.Forms.PictureBox();
            this.logobottom = new System.Windows.Forms.PictureBox();
            this.statusimage = new System.Windows.Forms.PictureBox();
            this.bottonbanner = new System.Windows.Forms.PictureBox();
            this.bannerTop = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lanchange = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.upperlogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logobottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottonbanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bannerTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanchange)).BeginInit();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.AutoSize = true;
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(2, -1);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 20;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(1412, 669);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 2D;
            this.gmap.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(288, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome Aboard";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(2, 644);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(191, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(200, 654);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 13);
            this.status.TabIndex = 5;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(34)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1030, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Next Station:";
            // 
            // Nextstation
            // 
            this.Nextstation.AutoSize = true;
            this.Nextstation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(34)))));
            this.Nextstation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nextstation.Location = new System.Drawing.Point(1168, 9);
            this.Nextstation.Name = "Nextstation";
            this.Nextstation.Size = new System.Drawing.Size(0, 20);
            this.Nextstation.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(34)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1030, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Local Time:";
            // 
            // LocalTimecell
            // 
            this.LocalTimecell.AutoSize = true;
            this.LocalTimecell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(34)))));
            this.LocalTimecell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocalTimecell.Location = new System.Drawing.Point(1168, 49);
            this.LocalTimecell.Name = "LocalTimecell";
            this.LocalTimecell.Size = new System.Drawing.Size(0, 20);
            this.LocalTimecell.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1178, 602);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Altitude:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // upperlogo
            // 
            this.upperlogo.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.VIA_Rail_Canada_Logo;
            this.upperlogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.upperlogo.Location = new System.Drawing.Point(1, -1);
            this.upperlogo.Name = "upperlogo";
            this.upperlogo.Size = new System.Drawing.Size(100, 50);
            this.upperlogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.upperlogo.TabIndex = 14;
            this.upperlogo.TabStop = false;
            // 
            // logobottom
            // 
            this.logobottom.BackColor = System.Drawing.SystemColors.Control;
            this.logobottom.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.OceanLogo3;
            this.logobottom.Location = new System.Drawing.Point(1, 602);
            this.logobottom.Name = "logobottom";
            this.logobottom.Size = new System.Drawing.Size(199, 57);
            this.logobottom.TabIndex = 13;
            this.logobottom.TabStop = false;
            // 
            // statusimage
            // 
            this.statusimage.BackColor = System.Drawing.Color.Transparent;
            this.statusimage.Location = new System.Drawing.Point(2, 602);
            this.statusimage.Name = "statusimage";
            this.statusimage.Size = new System.Drawing.Size(1080, 130);
            this.statusimage.TabIndex = 11;
            this.statusimage.TabStop = false;
            // 
            // bottonbanner
            // 
            this.bottonbanner.InitialImage = ((System.Drawing.Image)(resources.GetObject("bottonbanner.InitialImage")));
            this.bottonbanner.Location = new System.Drawing.Point(2, 602);
            this.bottonbanner.Name = "bottonbanner";
            this.bottonbanner.Size = new System.Drawing.Size(1412, 65);
            this.bottonbanner.TabIndex = 10;
            this.bottonbanner.TabStop = false;
            // 
            // bannerTop
            // 
            this.bannerTop.InitialImage = ((System.Drawing.Image)(resources.GetObject("bannerTop.InitialImage")));
            this.bannerTop.Location = new System.Drawing.Point(2, -1);
            this.bannerTop.Name = "bannerTop";
            this.bannerTop.Size = new System.Drawing.Size(1412, 65);
            this.bannerTop.TabIndex = 3;
            this.bannerTop.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1178, 622);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Speed:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(665, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Entertainment";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(34)))));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1053, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(361, 65);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // lanchange
            // 
            this.lanchange.Location = new System.Drawing.Point(781, 70);
            this.lanchange.Name = "lanchange";
            this.lanchange.Size = new System.Drawing.Size(116, 40);
            this.lanchange.TabIndex = 19;
            this.lanchange.TabStop = false;
            this.lanchange.Click += new System.EventHandler(this.lanchange_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 665);
            this.Controls.Add(this.lanchange);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Nextstation);
            this.Controls.Add(this.LocalTimecell);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.upperlogo);
            this.Controls.Add(this.logobottom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusimage);
            this.Controls.Add(this.bottonbanner);
            this.Controls.Add(this.status);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bannerTop);
            this.Controls.Add(this.gmap);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.upperlogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logobottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottonbanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bannerTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanchange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox bannerTop;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Nextstation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LocalTimecell;
        private System.Windows.Forms.PictureBox bottonbanner;
        private System.Windows.Forms.PictureBox statusimage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox logobottom;
        private System.Windows.Forms.PictureBox upperlogo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox lanchange;
    }
}

