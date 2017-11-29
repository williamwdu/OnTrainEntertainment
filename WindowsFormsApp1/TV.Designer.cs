namespace WindowsFormsApp1
{
    partial class TV
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
            this.bannerleft = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.des = new System.Windows.Forms.TextBox();
            this.poster = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.bannerleft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poster)).BeginInit();
            this.SuspendLayout();
            // 
            // bannerleft
            // 
            this.bannerleft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(6)))));
            this.bannerleft.Location = new System.Drawing.Point(0, 0);
            this.bannerleft.Name = "bannerleft";
            this.bannerleft.Size = new System.Drawing.Size(128, 544);
            this.bannerleft.TabIndex = 2;
            this.bannerleft.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(167, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(907, 51);
            this.label1.TabIndex = 3;
            this.label1.Text = "name_of_video";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(6)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 510);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 29);
            this.label5.TabIndex = 11;
            this.label5.Text = "Back";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // des
            // 
            this.des.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.des.Enabled = false;
            this.des.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.des.Location = new System.Drawing.Point(214, 297);
            this.des.Multiline = true;
            this.des.Name = "des";
            this.des.Size = new System.Drawing.Size(527, 195);
            this.des.TabIndex = 13;
            // 
            // poster
            // 
            this.poster.Location = new System.Drawing.Point(875, 97);
            this.poster.Name = "poster";
            this.poster.Size = new System.Drawing.Size(436, 196);
            this.poster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.poster.TabIndex = 12;
            this.poster.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(6)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 29);
            this.label6.TabIndex = 16;
            this.label6.Text = "cat";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(214, 97);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 17;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // TV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 583);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.des);
            this.Controls.Add(this.poster);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bannerleft);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TV";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TV";
            this.Load += new System.EventHandler(this.TV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bannerleft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox bannerleft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox des;
        private System.Windows.Forms.PictureBox poster;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox1;
    }
}