//using AIRAC_Downloader.Code.Core;

namespace AIRAC_Downloader_for_Euroscope.Code.UI
{
    partial class Main_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()//ES_Events ES_Events, VCCS_Events VCCS_Events, AeroNav_Events AeroNav_Events)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            es_setup = new GroupBox();
            sound3_cb = new CheckBox();
            plugin3_cb = new CheckBox();
            sound2_cb = new CheckBox();
            plugin2_cb = new CheckBox();
            s3_open = new Button();
            p3_open = new Button();
            s2_open = new Button();
            p2_open = new Button();
            s1_open = new Button();
            p1_open = new Button();
            show_pwd = new Button();
            s3_tb = new TextBox();
            p3_tb = new TextBox();
            s2_tb = new TextBox();
            p2_tb = new TextBox();
            s1_tb = new TextBox();
            sound1_cb = new CheckBox();
            p1_tb = new TextBox();
            plugin1_cb = new CheckBox();
            sound_dd_3 = new ComboBox();
            sound_dd_2 = new ComboBox();
            sound_dd_1 = new ComboBox();
            hoppie_cb = new CheckBox();
            rating_dd = new ComboBox();
            rating_cb = new CheckBox();
            facility_dd = new ComboBox();
            facility_cb = new CheckBox();
            password_tb = new TextBox();
            password_cb = new CheckBox();
            certificate_tb = new TextBox();
            certificate_cb = new CheckBox();
            realname_tb = new TextBox();
            realname_cb = new CheckBox();
            callsign_tb = new TextBox();
            callsign_cb = new CheckBox();
            hoppie_tb = new TextBox();
            button1 = new Button();
            sound_opendialogue = new OpenFileDialog();
            plugin_opendialogue = new OpenFileDialog();
            es_setup.SuspendLayout();
            SuspendLayout();
            // 
            // es_setup
            // 
            es_setup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            es_setup.Controls.Add(sound3_cb);
            es_setup.Controls.Add(plugin3_cb);
            es_setup.Controls.Add(sound2_cb);
            es_setup.Controls.Add(plugin2_cb);
            es_setup.Controls.Add(s3_open);
            es_setup.Controls.Add(p3_open);
            es_setup.Controls.Add(s2_open);
            es_setup.Controls.Add(p2_open);
            es_setup.Controls.Add(s1_open);
            es_setup.Controls.Add(p1_open);
            es_setup.Controls.Add(button1);
            es_setup.Controls.Add(show_pwd);
            es_setup.Controls.Add(s3_tb);
            es_setup.Controls.Add(p3_tb);
            es_setup.Controls.Add(s2_tb);
            es_setup.Controls.Add(p2_tb);
            es_setup.Controls.Add(s1_tb);
            es_setup.Controls.Add(sound1_cb);
            es_setup.Controls.Add(p1_tb);
            es_setup.Controls.Add(plugin1_cb);
            es_setup.Controls.Add(sound_dd_3);
            es_setup.Controls.Add(sound_dd_2);
            es_setup.Controls.Add(sound_dd_1);
            es_setup.Controls.Add(hoppie_cb);
            es_setup.Controls.Add(rating_dd);
            es_setup.Controls.Add(rating_cb);
            es_setup.Controls.Add(facility_dd);
            es_setup.Controls.Add(facility_cb);
            es_setup.Controls.Add(hoppie_tb);
            es_setup.Controls.Add(password_tb);
            es_setup.Controls.Add(password_cb);
            es_setup.Controls.Add(certificate_tb);
            es_setup.Controls.Add(certificate_cb);
            es_setup.Controls.Add(realname_tb);
            es_setup.Controls.Add(realname_cb);
            es_setup.Controls.Add(callsign_tb);
            es_setup.Controls.Add(callsign_cb);
            es_setup.Location = new Point(8, 8);
            es_setup.Name = "es_setup";
            es_setup.Size = new Size(672, 552);
            es_setup.TabIndex = 0;
            es_setup.TabStop = false;
            es_setup.Text = "Euroscope Setup";
            // 
            // sound3_cb
            // 
            sound3_cb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            sound3_cb.Location = new Point(16, 512);
            sound3_cb.Name = "sound3_cb";
            sound3_cb.Size = new Size(104, 27);
            sound3_cb.TabIndex = 34;
            sound3_cb.Text = "Sound 3";
            sound3_cb.UseVisualStyleBackColor = true;
            // 
            // plugin3_cb
            // 
            plugin3_cb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            plugin3_cb.Location = new Point(16, 392);
            plugin3_cb.Name = "plugin3_cb";
            plugin3_cb.Size = new Size(104, 27);
            plugin3_cb.TabIndex = 23;
            plugin3_cb.Text = "Plugin 3";
            plugin3_cb.UseVisualStyleBackColor = true;
            // 
            // sound2_cb
            // 
            sound2_cb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            sound2_cb.Location = new Point(16, 472);
            sound2_cb.Name = "sound2_cb";
            sound2_cb.Size = new Size(104, 27);
            sound2_cb.TabIndex = 30;
            sound2_cb.Text = "Sound 2";
            sound2_cb.UseVisualStyleBackColor = true;
            // 
            // plugin2_cb
            // 
            plugin2_cb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            plugin2_cb.Location = new Point(16, 352);
            plugin2_cb.Name = "plugin2_cb";
            plugin2_cb.Size = new Size(104, 27);
            plugin2_cb.TabIndex = 20;
            plugin2_cb.Text = "Plugin 2";
            plugin2_cb.UseVisualStyleBackColor = true;
            // 
            // s3_open
            // 
            s3_open.Enabled = false;
            s3_open.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            s3_open.Location = new Point(592, 512);
            s3_open.Name = "s3_open";
            s3_open.Size = new Size(75, 27);
            s3_open.TabIndex = 37;
            s3_open.Text = "Open";
            s3_open.UseVisualStyleBackColor = true;
            // 
            // p3_open
            // 
            p3_open.Enabled = false;
            p3_open.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            p3_open.Location = new Point(592, 392);
            p3_open.Name = "p3_open";
            p3_open.Size = new Size(75, 27);
            p3_open.TabIndex = 25;
            p3_open.Text = "Open";
            p3_open.UseVisualStyleBackColor = true;
            // 
            // s2_open
            // 
            s2_open.Enabled = false;
            s2_open.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            s2_open.Location = new Point(592, 472);
            s2_open.Name = "s2_open";
            s2_open.Size = new Size(75, 27);
            s2_open.TabIndex = 33;
            s2_open.Text = "Open";
            s2_open.UseVisualStyleBackColor = true;
            // 
            // p2_open
            // 
            p2_open.Enabled = false;
            p2_open.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            p2_open.Location = new Point(592, 352);
            p2_open.Name = "p2_open";
            p2_open.Size = new Size(75, 27);
            p2_open.TabIndex = 22;
            p2_open.Text = "Open";
            p2_open.UseVisualStyleBackColor = true;
            // 
            // s1_open
            // 
            s1_open.Enabled = false;
            s1_open.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            s1_open.Location = new Point(592, 432);
            s1_open.Name = "s1_open";
            s1_open.Size = new Size(75, 27);
            s1_open.TabIndex = 29;
            s1_open.Text = "Open";
            s1_open.UseVisualStyleBackColor = true;
            // 
            // p1_open
            // 
            p1_open.Enabled = false;
            p1_open.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            p1_open.Location = new Point(592, 312);
            p1_open.Name = "p1_open";
            p1_open.Size = new Size(75, 27);
            p1_open.TabIndex = 19;
            p1_open.Text = "Open";
            p1_open.UseVisualStyleBackColor = true;
            // 
            // show_pwd
            // 
            show_pwd.BackgroundImage = (Image)resources.GetObject("show_pwd.BackgroundImage");
            show_pwd.BackgroundImageLayout = ImageLayout.Stretch;
            show_pwd.Location = new Point(616, 152);
            show_pwd.Margin = new Padding(0);
            show_pwd.Name = "show_pwd";
            show_pwd.Size = new Size(50, 27);
            show_pwd.TabIndex = 9;
            show_pwd.UseVisualStyleBackColor = true;
            // 
            // s3_tb
            // 
            s3_tb.Enabled = false;
            s3_tb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            s3_tb.Location = new Point(128, 512);
            s3_tb.Name = "s3_tb";
            s3_tb.ReadOnly = true;
            s3_tb.Size = new Size(224, 27);
            s3_tb.TabIndex = 35;
            // 
            // p3_tb
            // 
            p3_tb.Enabled = false;
            p3_tb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            p3_tb.Location = new Point(128, 392);
            p3_tb.Name = "p3_tb";
            p3_tb.ReadOnly = true;
            p3_tb.Size = new Size(456, 27);
            p3_tb.TabIndex = 24;
            // 
            // s2_tb
            // 
            s2_tb.Enabled = false;
            s2_tb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            s2_tb.Location = new Point(128, 472);
            s2_tb.Name = "s2_tb";
            s2_tb.ReadOnly = true;
            s2_tb.Size = new Size(224, 27);
            s2_tb.TabIndex = 31;
            // 
            // p2_tb
            // 
            p2_tb.Enabled = false;
            p2_tb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            p2_tb.Location = new Point(128, 352);
            p2_tb.Name = "p2_tb";
            p2_tb.ReadOnly = true;
            p2_tb.Size = new Size(456, 27);
            p2_tb.TabIndex = 21;
            // 
            // s1_tb
            // 
            s1_tb.Enabled = false;
            s1_tb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            s1_tb.Location = new Point(128, 432);
            s1_tb.Name = "s1_tb";
            s1_tb.ReadOnly = true;
            s1_tb.Size = new Size(224, 27);
            s1_tb.TabIndex = 27;
            // 
            // sound1_cb
            // 
            sound1_cb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            sound1_cb.Location = new Point(16, 432);
            sound1_cb.Name = "sound1_cb";
            sound1_cb.Size = new Size(104, 27);
            sound1_cb.TabIndex = 26;
            sound1_cb.Text = "Sound 1";
            sound1_cb.UseVisualStyleBackColor = true;
            // 
            // p1_tb
            // 
            p1_tb.Enabled = false;
            p1_tb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            p1_tb.Location = new Point(128, 312);
            p1_tb.Name = "p1_tb";
            p1_tb.ReadOnly = true;
            p1_tb.Size = new Size(456, 27);
            p1_tb.TabIndex = 18;
            // 
            // plugin1_cb
            // 
            plugin1_cb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            plugin1_cb.Location = new Point(16, 312);
            plugin1_cb.Name = "plugin1_cb";
            plugin1_cb.Size = new Size(104, 27);
            plugin1_cb.TabIndex = 17;
            plugin1_cb.Text = "Plugin 1";
            plugin1_cb.UseVisualStyleBackColor = true;
            // 
            // sound_dd_3
            // 
            sound_dd_3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            sound_dd_3.FormattingEnabled = true;
            sound_dd_3.Location = new Point(360, 512);
            sound_dd_3.Name = "sound_dd_3";
            sound_dd_3.Size = new Size(224, 28);
            sound_dd_3.TabIndex = 36;
            // 
            // sound_dd_2
            // 
            sound_dd_2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            sound_dd_2.FormattingEnabled = true;
            sound_dd_2.Location = new Point(360, 472);
            sound_dd_2.Name = "sound_dd_2";
            sound_dd_2.Size = new Size(224, 28);
            sound_dd_2.TabIndex = 32;
            // 
            // sound_dd_1
            // 
            sound_dd_1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            sound_dd_1.FormattingEnabled = true;
            sound_dd_1.Location = new Point(360, 432);
            sound_dd_1.Name = "sound_dd_1";
            sound_dd_1.Size = new Size(224, 28);
            sound_dd_1.TabIndex = 28;
            // 
            // hoppie_cb
            // 
            hoppie_cb.Checked = true;
            hoppie_cb.CheckState = CheckState.Checked;
            hoppie_cb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            hoppie_cb.Location = new Point(16, 272);
            hoppie_cb.Name = "hoppie_cb";
            hoppie_cb.Size = new Size(104, 27);
            hoppie_cb.TabIndex = 14;
            hoppie_cb.Text = "Hoppie";
            hoppie_cb.UseVisualStyleBackColor = true;
            // 
            // rating_dd
            // 
            rating_dd.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            rating_dd.FormattingEnabled = true;
            rating_dd.Location = new Point(128, 232);
            rating_dd.Name = "rating_dd";
            rating_dd.Size = new Size(536, 28);
            rating_dd.TabIndex = 13;
            // 
            // rating_cb
            // 
            rating_cb.Checked = true;
            rating_cb.CheckState = CheckState.Checked;
            rating_cb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            rating_cb.Location = new Point(16, 232);
            rating_cb.Name = "rating_cb";
            rating_cb.Size = new Size(104, 27);
            rating_cb.TabIndex = 12;
            rating_cb.Text = "Rating";
            rating_cb.UseVisualStyleBackColor = true;
            // 
            // facility_dd
            // 
            facility_dd.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            facility_dd.FormattingEnabled = true;
            facility_dd.Location = new Point(128, 192);
            facility_dd.Name = "facility_dd";
            facility_dd.Size = new Size(536, 28);
            facility_dd.TabIndex = 11;
            // 
            // facility_cb
            // 
            facility_cb.Checked = true;
            facility_cb.CheckState = CheckState.Checked;
            facility_cb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            facility_cb.Location = new Point(16, 192);
            facility_cb.Name = "facility_cb";
            facility_cb.Size = new Size(104, 27);
            facility_cb.TabIndex = 10;
            facility_cb.Text = "Facility";
            facility_cb.UseVisualStyleBackColor = true;
            // 
            // password_tb
            // 
            password_tb.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            password_tb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            password_tb.Location = new Point(128, 152);
            password_tb.Name = "password_tb";
            password_tb.PlaceholderText = "******";
            password_tb.Size = new Size(480, 27);
            password_tb.TabIndex = 8;
            password_tb.UseSystemPasswordChar = true;
            // 
            // password_cb
            // 
            password_cb.Checked = true;
            password_cb.CheckState = CheckState.Checked;
            password_cb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            password_cb.Location = new Point(16, 152);
            password_cb.Name = "password_cb";
            password_cb.Size = new Size(104, 27);
            password_cb.TabIndex = 7;
            password_cb.Text = "Password";
            password_cb.UseVisualStyleBackColor = true;
            // 
            // certificate_tb
            // 
            certificate_tb.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            certificate_tb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            certificate_tb.Location = new Point(128, 112);
            certificate_tb.Name = "certificate_tb";
            certificate_tb.PlaceholderText = "1234567";
            certificate_tb.Size = new Size(536, 27);
            certificate_tb.TabIndex = 6;
            // 
            // certificate_cb
            // 
            certificate_cb.Checked = true;
            certificate_cb.CheckState = CheckState.Checked;
            certificate_cb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            certificate_cb.Location = new Point(16, 112);
            certificate_cb.Name = "certificate_cb";
            certificate_cb.Size = new Size(104, 27);
            certificate_cb.TabIndex = 5;
            certificate_cb.Text = "Certificate";
            certificate_cb.UseVisualStyleBackColor = true;
            // 
            // realname_tb
            // 
            realname_tb.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            realname_tb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            realname_tb.Location = new Point(128, 72);
            realname_tb.Name = "realname_tb";
            realname_tb.PlaceholderText = "Max Mustermann";
            realname_tb.Size = new Size(536, 27);
            realname_tb.TabIndex = 4;
            // 
            // realname_cb
            // 
            realname_cb.Checked = true;
            realname_cb.CheckState = CheckState.Checked;
            realname_cb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            realname_cb.Location = new Point(16, 72);
            realname_cb.Name = "realname_cb";
            realname_cb.Size = new Size(104, 27);
            realname_cb.TabIndex = 3;
            realname_cb.Text = "Realname";
            realname_cb.UseVisualStyleBackColor = true;
            // 
            // callsign_tb
            // 
            callsign_tb.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            callsign_tb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            callsign_tb.Location = new Point(128, 32);
            callsign_tb.Name = "callsign_tb";
            callsign_tb.PlaceholderText = "%%_OBS";
            callsign_tb.Size = new Size(536, 27);
            callsign_tb.TabIndex = 2;
            // 
            // callsign_cb
            // 
            callsign_cb.Checked = true;
            callsign_cb.CheckState = CheckState.Checked;
            callsign_cb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            callsign_cb.Location = new Point(16, 32);
            callsign_cb.Name = "callsign_cb";
            callsign_cb.Size = new Size(104, 27);
            callsign_cb.TabIndex = 1;
            callsign_cb.Text = "Callsign";
            callsign_cb.UseVisualStyleBackColor = true;
            // 
            // hoppie_tb
            // 
            hoppie_tb.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            hoppie_tb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            hoppie_tb.Location = new Point(128, 272);
            hoppie_tb.Name = "hoppie_tb";
            hoppie_tb.PlaceholderText = "******";
            hoppie_tb.Size = new Size(480, 27);
            hoppie_tb.TabIndex = 15;
            hoppie_tb.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Location = new Point(616, 272);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(50, 27);
            button1.TabIndex = 16;
            button1.UseVisualStyleBackColor = true;
            // 
            // sound_opendialogue
            // 
            sound_opendialogue.Title = "Select Sound File";
            // 
            // plugin_opendialogue
            // 
            plugin_opendialogue.Title = "Select Euroscope Plugin File";
            // 
            // Main_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1646, 572);
            Controls.Add(es_setup);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Main_Form";
            Text = "AIRAC Updater for Euroscope";
            es_setup.ResumeLayout(false);
            es_setup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public GroupBox es_setup;
        public CheckBox callsign_cb;
        public TextBox callsign_tb;
        public CheckBox realname_cb;
        public TextBox realname_tb;
        public CheckBox certificate_cb;
        public TextBox certificate_tb;
        public CheckBox password_cb;
        public TextBox password_tb;
        public CheckBox facility_cb;
        public ComboBox facility_dd;
        public ComboBox rating_dd;
        public CheckBox rating_cb;
        public CheckBox plugin1_cb;
        public TextBox p1_tb;
        public Button show_pwd;
        public Button p1_open;
        public CheckBox plugin2_cb;
        public CheckBox sound3_cb;
        public CheckBox plugin3_cb;
        public CheckBox sound2_cb;
        public Button s3_open;
        public Button p3_open;
        public Button s2_open;
        public Button p2_open;
        public Button s1_open;
        public TextBox s3_tb;
        public TextBox p3_tb;
        public TextBox s2_tb;
        public TextBox p2_tb;
        public TextBox s1_tb;
        public CheckBox sound1_cb;
        public CheckBox hoppie_cb;
        public ComboBox sound_dd_3;
        public ComboBox sound_dd_2;
        public ComboBox sound_dd_1;
        public Button button1;
        public TextBox hoppie_tb;
        public OpenFileDialog sound_opendialogue;
        public OpenFileDialog plugin_opendialogue;
    }
}