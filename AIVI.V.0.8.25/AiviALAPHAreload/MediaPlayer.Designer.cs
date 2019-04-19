namespace AiviALAPHAreload
{
    partial class MediaPlayer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaPlayer));
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.browse = new System.Windows.Forms.Button();
            this.playbacktimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.pause = new System.Windows.Forms.Button();
            this.fullscreen = new System.Windows.Forms.Button();
            this.volume = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.previous = new System.Windows.Forms.Button();
            this.play = new System.Windows.Forms.Button();
            this.playlist = new System.Windows.Forms.ListBox();
            this.plisthide = new System.Windows.Forms.Button();
            this.plishshow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(-3, 32);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(668, 271);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            this.axWindowsMediaPlayer1.MouseMoveEvent += new AxWMPLib._WMPOCXEvents_MouseMoveEventHandler(this.axWindowsMediaPlayer1_MouseMoveEvent);
            // 
            // browse
            // 
            this.browse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("browse.BackgroundImage")));
            this.browse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browse.Location = new System.Drawing.Point(27, 8);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(33, 27);
            this.browse.TabIndex = 1;
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(-3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 32);
            this.panel1.TabIndex = 5;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(239, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Eras Bold ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(92, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Aivi Media Player";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(45, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 32);
            this.button3.TabIndex = 0;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(4, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 32);
            this.button2.TabIndex = 0;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.pause);
            this.panel2.Controls.Add(this.fullscreen);
            this.panel2.Controls.Add(this.volume);
            this.panel2.Controls.Add(this.next);
            this.panel2.Controls.Add(this.previous);
            this.panel2.Controls.Add(this.play);
            this.panel2.Controls.Add(this.browse);
            this.panel2.Location = new System.Drawing.Point(1, 308);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(676, 46);
            this.panel2.TabIndex = 6;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(407, 13);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(147, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 100;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // pause
            // 
            this.pause.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pause.BackgroundImage")));
            this.pause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pause.Location = new System.Drawing.Point(213, 7);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(32, 35);
            this.pause.TabIndex = 1;
            this.pause.UseVisualStyleBackColor = true;
            this.pause.Click += new System.EventHandler(this.pause_Click);
            // 
            // fullscreen
            // 
            this.fullscreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fullscreen.BackgroundImage")));
            this.fullscreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fullscreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fullscreen.Location = new System.Drawing.Point(611, 8);
            this.fullscreen.Name = "fullscreen";
            this.fullscreen.Size = new System.Drawing.Size(39, 35);
            this.fullscreen.TabIndex = 1;
            this.fullscreen.UseVisualStyleBackColor = true;
            this.fullscreen.Click += new System.EventHandler(this.fullscreen_Click);
            // 
            // volume
            // 
            this.volume.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("volume.BackgroundImage")));
            this.volume.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.volume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.volume.Location = new System.Drawing.Point(374, 10);
            this.volume.Name = "volume";
            this.volume.Size = new System.Drawing.Size(26, 29);
            this.volume.TabIndex = 1;
            this.volume.UseVisualStyleBackColor = true;
            // 
            // next
            // 
            this.next.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("next.BackgroundImage")));
            this.next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next.Location = new System.Drawing.Point(251, 10);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(36, 30);
            this.next.TabIndex = 1;
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // previous
            // 
            this.previous.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("previous.BackgroundImage")));
            this.previous.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previous.Location = new System.Drawing.Point(139, 10);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(38, 30);
            this.previous.TabIndex = 1;
            this.previous.UseVisualStyleBackColor = true;
            this.previous.Click += new System.EventHandler(this.previous_Click);
            // 
            // play
            // 
            this.play.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("play.BackgroundImage")));
            this.play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.play.Location = new System.Drawing.Point(183, 7);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(24, 35);
            this.play.TabIndex = 1;
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // playlist
            // 
            this.playlist.BackColor = System.Drawing.Color.Black;
            this.playlist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.playlist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playlist.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playlist.ForeColor = System.Drawing.Color.Red;
            this.playlist.FormattingEnabled = true;
            this.playlist.ItemHeight = 15;
            this.playlist.Location = new System.Drawing.Point(690, 32);
            this.playlist.Name = "playlist";
            this.playlist.Size = new System.Drawing.Size(219, 270);
            this.playlist.TabIndex = 4;
            this.playlist.SelectedIndexChanged += new System.EventHandler(this.playlist_SelectedIndexChanged);
            // 
            // plisthide
            // 
            this.plisthide.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.plisthide.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plisthide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(125)))), ((int)(((byte)(0)))));
            this.plisthide.Location = new System.Drawing.Point(908, 152);
            this.plisthide.Name = "plisthide";
            this.plisthide.Size = new System.Drawing.Size(25, 29);
            this.plisthide.TabIndex = 7;
            this.plisthide.Text = "<";
            this.plisthide.UseVisualStyleBackColor = true;
            this.plisthide.Click += new System.EventHandler(this.plisthide_MouseHover);
            this.plisthide.MouseHover += new System.EventHandler(this.plisthide_MouseHover);
            // 
            // plishshow
            // 
            this.plishshow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.plishshow.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plishshow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(125)))), ((int)(((byte)(0)))));
            this.plishshow.Location = new System.Drawing.Point(661, 149);
            this.plishshow.Name = "plishshow";
            this.plishshow.Size = new System.Drawing.Size(25, 29);
            this.plishshow.TabIndex = 8;
            this.plishshow.Text = ">";
            this.plishshow.UseVisualStyleBackColor = true;
            this.plishshow.Visible = false;
            this.plishshow.Click += new System.EventHandler(this.plishshow_MouseHover);
            this.plishshow.MouseHover += new System.EventHandler(this.plishshow_MouseHover);
            // 
            // MediaPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(927, 355);
            this.Controls.Add(this.playlist);
            this.Controls.Add(this.plishshow);
            this.Controls.Add(this.plisthide);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MediaPlayer";
            this.Opacity = 0.9D;
            this.Text = "MediaPlayer";
            this.Load += new System.EventHandler(this.MediaPlayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Timer playbacktimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.Button fullscreen;
        private System.Windows.Forms.Button volume;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button previous;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Button plisthide;
        private System.Windows.Forms.Button plishshow;
        public AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        public System.Windows.Forms.ListBox playlist;
    }
}