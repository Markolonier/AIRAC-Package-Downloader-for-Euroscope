//using AIRAC_Downloader.Code.Core;

using AIRAC_Downloader.Code.Core;

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

            List<string> facilities = new List<string>
            {
                "Observer",
                "Flight Service Station",
                "Clearance/Delivery",
                "Ground",
                "Tower",
                "Approach/Departure",
                "Center"
            };
            List<string> ratings = new List<string>
            {
                "Observer",
                "Ground/Delivery (STU1)",
                "Tower Controller (STU2)",
                "TMA Controller (STU3)",
                "Enroute Controller (CTR1)",
                "Controller 2(not in use)",
                "Senior controller (CTR3)",
                "Instructor 1", "Instructor 2",
                "Instructor 3",
                "Supervisor",
                "Administrator"
            };
            List<string> soundtypes = new List<string>
            {
                "Handoff Request",
                "Handoff Accept",
                "Conflict Alert",
                "Radio Message",
                "Private Message",
                "ATC Message",
                "Broadcast Message",
                "Landline request",
                "Supervisor call",
                "Connected",
                "Disconnected",
                "Ongoing coordination request",
                "Ongoing coordination accepted",
                "Ongoing coordination refused",
                "New ATIS message",
                "Handoff Refused",
                "Pointout",
                "Startup"
            };
            List<string> sound1 = new List<string>(soundtypes);
            List<string> sound2 = new List<string>(soundtypes);
            List<string> sound3 = new List<string>(soundtypes);



            components = new System.ComponentModel.Container();
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
            show_hoppie = new Button();
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
            hoppie_tb = new TextBox();
            password_tb = new TextBox();
            password_cb = new CheckBox();
            certificate_tb = new TextBox();
            certificate_cb = new CheckBox();
            realname_tb = new TextBox();
            realname_cb = new CheckBox();
            callsign_tb = new TextBox();
            callsign_cb = new CheckBox();
            sound_opendialogue = new OpenFileDialog();
            plugin_opendialogue = new OpenFileDialog();
            vccs_setup = new GroupBox();
            g2g_btn = new Button();
            g2a_btn = new Button();
            nickname_tb = new TextBox();
            playback_device_cb = new CheckBox();
            playback_mode_cb = new CheckBox();
            capture_device_cb = new CheckBox();
            capture_mode_cb = new CheckBox();
            g2g_ptt_cb = new CheckBox();
            g2a_ptt_cb = new CheckBox();
            nickname_cb = new CheckBox();
            playback_device_dd = new ComboBox();
            playback_mode_dd = new ComboBox();
            capture_device_dd = new ComboBox();
            capture_mode_dd = new ComboBox();
            aeronav_setup = new GroupBox();
            download_bar = new ProgressBar();
            pack_dd = new ComboBox();
            vacc_dd = new ComboBox();
            save_to_tb = new TextBox();
            Pack_Released = new Label();
            Pack_Version = new Label();
            Pack_AIRAC = new Label();
            download_lbl = new Label();
            pck_fold_lbl = new Label();
            package_info_lbl = new Label();
            package_lbl = new Label();
            save_data = new Button();
            Download = new Button();
            save_to_btn = new Button();
            vacc_lbl = new Label();
            toolTip1 = new ToolTip(components);
            save_folder = new FolderBrowserDialog();
            es_setup.SuspendLayout();
            vccs_setup.SuspendLayout();
            aeronav_setup.SuspendLayout();
            SuspendLayout();
            // 
            // es_setup
            // 
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
            es_setup.Controls.Add(show_hoppie);
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
            sound3_cb.Font = new Font("Segoe UI", 11F);
            sound3_cb.Location = new Point(16, 512);
            sound3_cb.Name = "sound3_cb";
            sound3_cb.Size = new Size(104, 27);
            sound3_cb.TabIndex = 34;
            sound3_cb.Text = "Sound 3";
            sound3_cb.UseVisualStyleBackColor = true;
            sound3_cb.CheckedChanged += sound3_cb_CheckedChanged;
            // 
            // plugin3_cb
            // 
            plugin3_cb.Font = new Font("Segoe UI", 11F);
            plugin3_cb.Location = new Point(16, 392);
            plugin3_cb.Name = "plugin3_cb";
            plugin3_cb.Size = new Size(104, 27);
            plugin3_cb.TabIndex = 23;
            plugin3_cb.Text = "Plugin 3";
            plugin3_cb.UseVisualStyleBackColor = true;
            plugin3_cb.CheckedChanged += plugin3_cb_CheckedChanged;
            // 
            // sound2_cb
            // 
            sound2_cb.Font = new Font("Segoe UI", 11F);
            sound2_cb.Location = new Point(16, 472);
            sound2_cb.Name = "sound2_cb";
            sound2_cb.Size = new Size(104, 27);
            sound2_cb.TabIndex = 30;
            sound2_cb.Text = "Sound 2";
            sound2_cb.UseVisualStyleBackColor = true;
            sound2_cb.CheckedChanged += sound2_cb_CheckedChanged;
            // 
            // plugin2_cb
            // 
            plugin2_cb.Font = new Font("Segoe UI", 11F);
            plugin2_cb.Location = new Point(16, 352);
            plugin2_cb.Name = "plugin2_cb";
            plugin2_cb.Size = new Size(104, 27);
            plugin2_cb.TabIndex = 20;
            plugin2_cb.Text = "Plugin 2";
            plugin2_cb.UseVisualStyleBackColor = true;
            plugin2_cb.CheckedChanged += plugin2_cb_CheckedChanged;
            // 
            // s3_open
            // 
            s3_open.Enabled = false;
            s3_open.Font = new Font("Segoe UI", 11F);
            s3_open.Location = new Point(592, 512);
            s3_open.Name = "s3_open";
            s3_open.Size = new Size(75, 28);
            s3_open.TabIndex = 37;
            s3_open.Text = "Open";
            s3_open.UseVisualStyleBackColor = true;
            s3_open.Click += s3_open_Click;
            // 
            // p3_open
            // 
            p3_open.Enabled = false;
            p3_open.Font = new Font("Segoe UI", 11F);
            p3_open.Location = new Point(592, 392);
            p3_open.Name = "p3_open";
            p3_open.Size = new Size(75, 27);
            p3_open.TabIndex = 25;
            p3_open.Text = "Open";
            p3_open.UseVisualStyleBackColor = true;
            p3_open.Click += p3_open_Click;
            // 
            // s2_open
            // 
            s2_open.Enabled = false;
            s2_open.Font = new Font("Segoe UI", 11F);
            s2_open.Location = new Point(592, 472);
            s2_open.Name = "s2_open";
            s2_open.Size = new Size(75, 28);
            s2_open.TabIndex = 33;
            s2_open.Text = "Open";
            s2_open.UseVisualStyleBackColor = true;
            s2_open.Click += s2_open_Click;
            // 
            // p2_open
            // 
            p2_open.Enabled = false;
            p2_open.Font = new Font("Segoe UI", 11F);
            p2_open.Location = new Point(592, 352);
            p2_open.Name = "p2_open";
            p2_open.Size = new Size(75, 27);
            p2_open.TabIndex = 22;
            p2_open.Text = "Open";
            p2_open.UseVisualStyleBackColor = true;
            p2_open.Click += p2_open_Click;
            // 
            // s1_open
            // 
            s1_open.Enabled = false;
            s1_open.Font = new Font("Segoe UI", 11F);
            s1_open.Location = new Point(592, 432);
            s1_open.Name = "s1_open";
            s1_open.Size = new Size(75, 28);
            s1_open.TabIndex = 29;
            s1_open.Text = "Open";
            s1_open.UseVisualStyleBackColor = true;
            s1_open.Click += s1_open_Click;
            // 
            // p1_open
            // 
            p1_open.Enabled = false;
            p1_open.Font = new Font("Segoe UI", 11F);
            p1_open.Location = new Point(592, 312);
            p1_open.Name = "p1_open";
            p1_open.Size = new Size(75, 27);
            p1_open.TabIndex = 19;
            p1_open.Text = "Open";
            p1_open.UseVisualStyleBackColor = true;
            p1_open.Click += p1_open_Click;
            // 
            // show_hoppie
            // 
            show_hoppie.BackgroundImage = (Image)resources.GetObject("show_hoppie.BackgroundImage");
            show_hoppie.BackgroundImageLayout = ImageLayout.Zoom;
            show_hoppie.Font = new Font("Segoe UI", 11F);
            show_hoppie.Location = new Point(592, 272);
            show_hoppie.Margin = new Padding(0);
            show_hoppie.Name = "show_hoppie";
            show_hoppie.Size = new Size(74, 27);
            show_hoppie.TabIndex = 16;
            show_hoppie.UseVisualStyleBackColor = true;
            show_hoppie.MouseDown += show_hoppie_MouseDown;
            show_hoppie.MouseUp += show_hoppie_MouseUp;
            // 
            // show_pwd
            // 
            show_pwd.BackgroundImage = (Image)resources.GetObject("show_pwd.BackgroundImage");
            show_pwd.BackgroundImageLayout = ImageLayout.Zoom;
            show_pwd.Font = new Font("Segoe UI", 11F);
            show_pwd.Location = new Point(592, 152);
            show_pwd.Margin = new Padding(0);
            show_pwd.Name = "show_pwd";
            show_pwd.Size = new Size(74, 27);
            show_pwd.TabIndex = 9;
            show_pwd.UseVisualStyleBackColor = true;
            show_pwd.MouseDown += show_pwd_MouseDown;
            show_pwd.MouseUp += show_pwd_MouseUp;
            // 
            // s3_tb
            // 
            s3_tb.Enabled = false;
            s3_tb.Font = new Font("Segoe UI", 11F);
            s3_tb.Location = new Point(128, 512);
            s3_tb.Name = "s3_tb";
            s3_tb.ReadOnly = true;
            s3_tb.Size = new Size(224, 27);
            s3_tb.TabIndex = 35;
            // 
            // p3_tb
            // 
            p3_tb.Enabled = false;
            p3_tb.Font = new Font("Segoe UI", 11F);
            p3_tb.Location = new Point(128, 392);
            p3_tb.Name = "p3_tb";
            p3_tb.ReadOnly = true;
            p3_tb.Size = new Size(456, 27);
            p3_tb.TabIndex = 24;
            // 
            // s2_tb
            // 
            s2_tb.Enabled = false;
            s2_tb.Font = new Font("Segoe UI", 11F);
            s2_tb.Location = new Point(128, 472);
            s2_tb.Name = "s2_tb";
            s2_tb.ReadOnly = true;
            s2_tb.Size = new Size(224, 27);
            s2_tb.TabIndex = 31;
            // 
            // p2_tb
            // 
            p2_tb.Enabled = false;
            p2_tb.Font = new Font("Segoe UI", 11F);
            p2_tb.Location = new Point(128, 352);
            p2_tb.Name = "p2_tb";
            p2_tb.ReadOnly = true;
            p2_tb.Size = new Size(456, 27);
            p2_tb.TabIndex = 21;
            // 
            // s1_tb
            // 
            s1_tb.Enabled = false;
            s1_tb.Font = new Font("Segoe UI", 11F);
            s1_tb.Location = new Point(128, 432);
            s1_tb.Name = "s1_tb";
            s1_tb.ReadOnly = true;
            s1_tb.Size = new Size(224, 27);
            s1_tb.TabIndex = 27;
            // 
            // sound1_cb
            // 
            sound1_cb.Font = new Font("Segoe UI", 11F);
            sound1_cb.Location = new Point(16, 432);
            sound1_cb.Name = "sound1_cb";
            sound1_cb.Size = new Size(104, 27);
            sound1_cb.TabIndex = 26;
            sound1_cb.Text = "Sound 1";
            sound1_cb.UseVisualStyleBackColor = true;
            sound1_cb.CheckedChanged += sound1_cb_CheckedChanged;
            // 
            // p1_tb
            // 
            p1_tb.Enabled = false;
            p1_tb.Font = new Font("Segoe UI", 11F);
            p1_tb.Location = new Point(128, 312);
            p1_tb.Name = "p1_tb";
            p1_tb.ReadOnly = true;
            p1_tb.Size = new Size(456, 27);
            p1_tb.TabIndex = 18;
            // 
            // plugin1_cb
            // 
            plugin1_cb.Font = new Font("Segoe UI", 11F);
            plugin1_cb.Location = new Point(16, 312);
            plugin1_cb.Name = "plugin1_cb";
            plugin1_cb.Size = new Size(104, 27);
            plugin1_cb.TabIndex = 17;
            plugin1_cb.Text = "Plugin 1";
            plugin1_cb.UseVisualStyleBackColor = true;
            plugin1_cb.CheckedChanged += plugin1_cb_CheckedChanged;
            // 
            // sound_dd_3
            // 
            sound_dd_3.DataSource = sound3;
            sound_dd_3.Enabled = false;
            sound_dd_3.Font = new Font("Segoe UI", 11F);
            sound_dd_3.FormattingEnabled = true;
            sound_dd_3.Location = new Point(360, 512);
            sound_dd_3.Name = "sound_dd_3";
            sound_dd_3.Size = new Size(224, 28);
            sound_dd_3.TabIndex = 36;
            // 
            // sound_dd_2
            // 
            sound_dd_2.DataSource = sound2;
            sound_dd_2.Enabled = false;
            sound_dd_2.Font = new Font("Segoe UI", 11F);
            sound_dd_2.FormattingEnabled = true;
            sound_dd_2.Location = new Point(360, 472);
            sound_dd_2.Name = "sound_dd_2";
            sound_dd_2.Size = new Size(224, 28);
            sound_dd_2.TabIndex = 32;
            // 
            // sound_dd_1
            // 
            sound_dd_1.DataSource = sound1;
            sound_dd_1.Enabled = false;
            sound_dd_1.Font = new Font("Segoe UI", 11F);
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
            hoppie_cb.Font = new Font("Segoe UI", 11F);
            hoppie_cb.Location = new Point(16, 272);
            hoppie_cb.Name = "hoppie_cb";
            hoppie_cb.Size = new Size(104, 27);
            hoppie_cb.TabIndex = 14;
            hoppie_cb.Text = "Hoppie";
            hoppie_cb.UseVisualStyleBackColor = true;
            hoppie_cb.CheckedChanged += Hoppie_cb_CheckedChanged;
            // 
            // rating_dd
            // 
            rating_dd.DataSource = ratings;
            rating_dd.Font = new Font("Segoe UI", 11F);
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
            rating_cb.Font = new Font("Segoe UI", 11F);
            rating_cb.Location = new Point(16, 232);
            rating_cb.Name = "rating_cb";
            rating_cb.Size = new Size(104, 28);
            rating_cb.TabIndex = 12;
            rating_cb.Text = "Rating";
            rating_cb.UseVisualStyleBackColor = true;
            rating_cb.CheckedChanged += Rating_cb_CheckedChanged;
            // 
            // facility_dd
            // 
            facility_dd.DataSource = facilities;
            facility_dd.Font = new Font("Segoe UI", 11F);
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
            facility_cb.Font = new Font("Segoe UI", 11F);
            facility_cb.Location = new Point(16, 192);
            facility_cb.Name = "facility_cb";
            facility_cb.Size = new Size(104, 28);
            facility_cb.TabIndex = 10;
            facility_cb.Text = "Facility";
            facility_cb.UseVisualStyleBackColor = true;
            facility_cb.CheckedChanged += Facility_cb_CheckedChanged;
            // 
            // hoppie_tb
            // 
            hoppie_tb.Font = new Font("Segoe UI", 11F);
            hoppie_tb.Location = new Point(128, 272);
            hoppie_tb.Name = "hoppie_tb";
            hoppie_tb.PlaceholderText = "******";
            hoppie_tb.Size = new Size(456, 27);
            hoppie_tb.TabIndex = 15;
            hoppie_tb.UseSystemPasswordChar = true;
            // 
            // password_tb
            // 
            password_tb.Font = new Font("Segoe UI", 11F);
            password_tb.Location = new Point(128, 152);
            password_tb.Name = "password_tb";
            password_tb.PlaceholderText = "******";
            password_tb.Size = new Size(456, 27);
            password_tb.TabIndex = 8;
            password_tb.UseSystemPasswordChar = true;
            // 
            // password_cb
            // 
            password_cb.Checked = true;
            password_cb.CheckState = CheckState.Checked;
            password_cb.Font = new Font("Segoe UI", 11F);
            password_cb.Location = new Point(16, 152);
            password_cb.Name = "password_cb";
            password_cb.Size = new Size(104, 27);
            password_cb.TabIndex = 7;
            password_cb.Text = "Password";
            password_cb.UseVisualStyleBackColor = true;
            password_cb.CheckedChanged += Password_cb_CheckedChanged;
            // 
            // certificate_tb
            // 
            certificate_tb.Font = new Font("Segoe UI", 11F);
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
            certificate_cb.Font = new Font("Segoe UI", 11F);
            certificate_cb.Location = new Point(16, 112);
            certificate_cb.Name = "certificate_cb";
            certificate_cb.Size = new Size(104, 27);
            certificate_cb.TabIndex = 5;
            certificate_cb.Text = "Certificate";
            certificate_cb.UseVisualStyleBackColor = true;
            certificate_cb.CheckedChanged += Certificate_cb_CheckedChanged;
            // 
            // realname_tb
            // 
            realname_tb.Font = new Font("Segoe UI", 11F);
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
            realname_cb.Font = new Font("Segoe UI", 11F);
            realname_cb.Location = new Point(16, 72);
            realname_cb.Name = "realname_cb";
            realname_cb.Size = new Size(104, 27);
            realname_cb.TabIndex = 3;
            realname_cb.Text = "Realname";
            realname_cb.UseVisualStyleBackColor = true;
            realname_cb.CheckedChanged += Realname_cb_CheckedChanged;
            // 
            // callsign_tb
            // 
            callsign_tb.Font = new Font("Segoe UI", 11F);
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
            callsign_cb.Font = new Font("Segoe UI", 11F);
            callsign_cb.Location = new Point(16, 32);
            callsign_cb.Name = "callsign_cb";
            callsign_cb.Size = new Size(104, 27);
            callsign_cb.TabIndex = 1;
            callsign_cb.Text = "Callsign";
            callsign_cb.UseVisualStyleBackColor = true;
            callsign_cb.CheckedChanged += Callsign_cb_CheckedChanged;
            // 
            // sound_opendialogue
            // 
            sound_opendialogue.Title = "Select Sound File";
            // 
            // plugin_opendialogue
            // 
            plugin_opendialogue.Title = "Select Euroscope Plugin File";
            // 
            // vccs_setup
            // 
            vccs_setup.Controls.Add(g2g_btn);
            vccs_setup.Controls.Add(g2a_btn);
            vccs_setup.Controls.Add(nickname_tb);
            vccs_setup.Controls.Add(playback_device_cb);
            vccs_setup.Controls.Add(playback_mode_cb);
            vccs_setup.Controls.Add(capture_device_cb);
            vccs_setup.Controls.Add(capture_mode_cb);
            vccs_setup.Controls.Add(g2g_ptt_cb);
            vccs_setup.Controls.Add(g2a_ptt_cb);
            vccs_setup.Controls.Add(nickname_cb);
            vccs_setup.Controls.Add(playback_device_dd);
            vccs_setup.Controls.Add(playback_mode_dd);
            vccs_setup.Controls.Add(capture_device_dd);
            vccs_setup.Controls.Add(capture_mode_dd);
            vccs_setup.Location = new Point(696, 8);
            vccs_setup.Name = "vccs_setup";
            vccs_setup.Size = new Size(704, 312);
            vccs_setup.TabIndex = 38;
            vccs_setup.TabStop = false;
            vccs_setup.Text = "VCCS Setup";
            // 
            // g2g_btn
            // 
            g2g_btn.Enabled = false;
            g2g_btn.Location = new Point(160, 112);
            g2g_btn.Name = "g2g_btn";
            g2g_btn.Size = new Size(536, 27);
            g2g_btn.TabIndex = 44;
            g2g_btn.Text = "Set Hotkey";
            g2g_btn.UseVisualStyleBackColor = true;
            g2g_btn.Click += G2g_btn_Click;
            // 
            // g2a_btn
            // 
            g2a_btn.Enabled = false;
            g2a_btn.Location = new Point(160, 72);
            g2a_btn.Name = "g2a_btn";
            g2a_btn.Size = new Size(536, 27);
            g2a_btn.TabIndex = 42;
            g2a_btn.Text = "Set Hotkey";
            g2a_btn.UseVisualStyleBackColor = true;
            g2a_btn.Click += G2a_btn_Click;
            // 
            // nickname_tb
            // 
            nickname_tb.Enabled = false;
            nickname_tb.Font = new Font("Segoe UI", 11F);
            nickname_tb.Location = new Point(160, 32);
            nickname_tb.Name = "nickname_tb";
            nickname_tb.PlaceholderText = "1234567";
            nickname_tb.Size = new Size(536, 27);
            nickname_tb.TabIndex = 40;
            // 
            // playback_device_cb
            // 
            playback_device_cb.Font = new Font("Segoe UI", 11F);
            playback_device_cb.Location = new Point(16, 272);
            playback_device_cb.Name = "playback_device_cb";
            playback_device_cb.Size = new Size(136, 27);
            playback_device_cb.TabIndex = 51;
            playback_device_cb.Text = "Playback Device";
            playback_device_cb.UseVisualStyleBackColor = true;
            playback_device_cb.CheckedChanged += Playback_device_cb_CheckedChanged;
            // 
            // playback_mode_cb
            // 
            playback_mode_cb.Font = new Font("Segoe UI", 11F);
            playback_mode_cb.Location = new Point(16, 232);
            playback_mode_cb.Name = "playback_mode_cb";
            playback_mode_cb.Size = new Size(136, 27);
            playback_mode_cb.TabIndex = 49;
            playback_mode_cb.Text = "Playback Mode";
            playback_mode_cb.UseVisualStyleBackColor = true;
            playback_mode_cb.CheckedChanged += Playback_mode_cb_CheckedChanged;
            // 
            // capture_device_cb
            // 
            capture_device_cb.Font = new Font("Segoe UI", 11F);
            capture_device_cb.Location = new Point(16, 192);
            capture_device_cb.Name = "capture_device_cb";
            capture_device_cb.Size = new Size(136, 27);
            capture_device_cb.TabIndex = 47;
            capture_device_cb.Text = "Capture Device";
            capture_device_cb.UseVisualStyleBackColor = true;
            capture_device_cb.CheckedChanged += Capture_device_cb_CheckedChanged;
            // 
            // capture_mode_cb
            // 
            capture_mode_cb.Font = new Font("Segoe UI", 11F);
            capture_mode_cb.Location = new Point(16, 152);
            capture_mode_cb.Name = "capture_mode_cb";
            capture_mode_cb.Size = new Size(136, 27);
            capture_mode_cb.TabIndex = 45;
            capture_mode_cb.Text = "Capture Mode";
            capture_mode_cb.UseVisualStyleBackColor = true;
            capture_mode_cb.CheckedChanged += Capture_mode_cb_CheckedChanged;
            // 
            // g2g_ptt_cb
            // 
            g2g_ptt_cb.Font = new Font("Segoe UI", 11F);
            g2g_ptt_cb.Location = new Point(16, 112);
            g2g_ptt_cb.Name = "g2g_ptt_cb";
            g2g_ptt_cb.Size = new Size(136, 27);
            g2g_ptt_cb.TabIndex = 43;
            g2g_ptt_cb.Text = "G2G PTT";
            g2g_ptt_cb.UseVisualStyleBackColor = true;
            g2g_ptt_cb.CheckedChanged += G2g_ptt_cb_CheckedChanged;
            // 
            // g2a_ptt_cb
            // 
            g2a_ptt_cb.Font = new Font("Segoe UI", 11F);
            g2a_ptt_cb.Location = new Point(16, 72);
            g2a_ptt_cb.Name = "g2a_ptt_cb";
            g2a_ptt_cb.Size = new Size(136, 27);
            g2a_ptt_cb.TabIndex = 41;
            g2a_ptt_cb.Text = "G2A PTT";
            g2a_ptt_cb.UseVisualStyleBackColor = true;
            g2a_ptt_cb.CheckedChanged += G2a_ptt_cb_CheckedChanged;
            // 
            // nickname_cb
            // 
            nickname_cb.Font = new Font("Segoe UI", 11F);
            nickname_cb.Location = new Point(16, 32);
            nickname_cb.Name = "nickname_cb";
            nickname_cb.Size = new Size(136, 27);
            nickname_cb.TabIndex = 39;
            nickname_cb.Text = "Nickname";
            nickname_cb.UseVisualStyleBackColor = true;
            nickname_cb.CheckedChanged += Nickname_cb_CheckedChanged;
            // 
            // playback_device_dd
            // 
            playback_device_dd.Enabled = false;
            playback_device_dd.Font = new Font("Segoe UI", 11F);
            playback_device_dd.FormattingEnabled = true;
            playback_device_dd.Location = new Point(160, 272);
            playback_device_dd.Name = "playback_device_dd";
            playback_device_dd.Size = new Size(536, 28);
            playback_device_dd.TabIndex = 52;
            // 
            // playback_mode_dd
            // 
            playback_mode_dd.Enabled = false;
            playback_mode_dd.Font = new Font("Segoe UI", 11F);
            playback_mode_dd.FormattingEnabled = true;
            playback_mode_dd.Location = new Point(160, 232);
            playback_mode_dd.Name = "playback_mode_dd";
            playback_mode_dd.Size = new Size(536, 28);
            playback_mode_dd.TabIndex = 50;
            // 
            // capture_device_dd
            // 
            capture_device_dd.Enabled = false;
            capture_device_dd.Font = new Font("Segoe UI", 11F);
            capture_device_dd.FormattingEnabled = true;
            capture_device_dd.Location = new Point(160, 192);
            capture_device_dd.Name = "capture_device_dd";
            capture_device_dd.Size = new Size(536, 28);
            capture_device_dd.TabIndex = 48;
            // 
            // capture_mode_dd
            // 
            capture_mode_dd.Enabled = false;
            capture_mode_dd.Font = new Font("Segoe UI", 11F);
            capture_mode_dd.FormattingEnabled = true;
            capture_mode_dd.Location = new Point(160, 152);
            capture_mode_dd.Name = "capture_mode_dd";
            capture_mode_dd.Size = new Size(536, 28);
            capture_mode_dd.TabIndex = 46;
            // 
            // aeronav_setup
            // 
            aeronav_setup.Controls.Add(download_bar);
            aeronav_setup.Controls.Add(pack_dd);
            aeronav_setup.Controls.Add(vacc_dd);
            aeronav_setup.Controls.Add(save_to_tb);
            aeronav_setup.Controls.Add(Pack_Released);
            aeronav_setup.Controls.Add(Pack_Version);
            aeronav_setup.Controls.Add(Pack_AIRAC);
            aeronav_setup.Controls.Add(download_lbl);
            aeronav_setup.Controls.Add(pck_fold_lbl);
            aeronav_setup.Controls.Add(package_info_lbl);
            aeronav_setup.Controls.Add(package_lbl);
            aeronav_setup.Controls.Add(save_data);
            aeronav_setup.Controls.Add(Download);
            aeronav_setup.Controls.Add(save_to_btn);
            aeronav_setup.Controls.Add(vacc_lbl);
            aeronav_setup.Location = new Point(696, 328);
            aeronav_setup.Name = "aeronav_setup";
            aeronav_setup.Size = new Size(704, 232);
            aeronav_setup.TabIndex = 53;
            aeronav_setup.TabStop = false;
            aeronav_setup.Text = "AeroNav Setup";
            // 
            // download_bar
            // 
            download_bar.Location = new Point(160, 192);
            download_bar.Name = "download_bar";
            download_bar.Size = new Size(344, 27);
            download_bar.TabIndex = 65;
            // 
            // pack_dd
            // 
            pack_dd.Font = new Font("Segoe UI", 11F);
            pack_dd.FormattingEnabled = true;
            pack_dd.Location = new Point(160, 72);
            pack_dd.Name = "pack_dd";
            pack_dd.Size = new Size(536, 28);
            pack_dd.TabIndex = 57;
            pack_dd.SelectedValueChanged += Pack_dd_SelectedValueChanged;
            // 
            // vacc_dd
            // 
            vacc_dd.Font = new Font("Segoe UI", 11F);
            vacc_dd.FormattingEnabled = true;
            vacc_dd.Location = new Point(160, 32);
            vacc_dd.Name = "vacc_dd";
            vacc_dd.Size = new Size(536, 28);
            vacc_dd.TabIndex = 55;
            vacc_dd.SelectedValueChanged += Vacc_dd_SelectedValueChanged;
            // 
            // save_to_tb
            // 
            save_to_tb.Font = new Font("Segoe UI", 11F);
            save_to_tb.Location = new Point(160, 152);
            save_to_tb.Name = "save_to_tb";
            save_to_tb.PlaceholderText = "Select the Folder, where all the Packages should be saved";
            save_to_tb.ReadOnly = true;
            save_to_tb.Size = new Size(344, 27);
            save_to_tb.TabIndex = 62;
            save_to_tb.TextChanged += save_to_tb_TextChanged;
            save_to_tb.MouseHover += save_vacc_MouseHover;
            // 
            // Pack_Released
            // 
            Pack_Released.Font = new Font("Segoe UI", 11F);
            Pack_Released.Location = new Point(464, 112);
            Pack_Released.Name = "Pack_Released";
            Pack_Released.Size = new Size(232, 28);
            Pack_Released.TabIndex = 60;
            Pack_Released.Text = "Released: ";
            Pack_Released.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Pack_Version
            // 
            Pack_Version.Font = new Font("Segoe UI", 11F);
            Pack_Version.Location = new Point(320, 112);
            Pack_Version.Name = "Pack_Version";
            Pack_Version.Size = new Size(136, 28);
            Pack_Version.TabIndex = 59;
            Pack_Version.Text = "Version:";
            Pack_Version.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Pack_AIRAC
            // 
            Pack_AIRAC.Font = new Font("Segoe UI", 11F);
            Pack_AIRAC.Location = new Point(160, 112);
            Pack_AIRAC.Name = "Pack_AIRAC";
            Pack_AIRAC.Size = new Size(136, 28);
            Pack_AIRAC.TabIndex = 58;
            Pack_AIRAC.Text = "AIRAC:";
            Pack_AIRAC.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // download_lbl
            // 
            download_lbl.Font = new Font("Segoe UI", 11F);
            download_lbl.Location = new Point(16, 192);
            download_lbl.Name = "download_lbl";
            download_lbl.Size = new Size(136, 28);
            download_lbl.TabIndex = 64;
            download_lbl.Text = "Download";
            download_lbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pck_fold_lbl
            // 
            pck_fold_lbl.Font = new Font("Segoe UI", 11F);
            pck_fold_lbl.Location = new Point(16, 152);
            pck_fold_lbl.Name = "pck_fold_lbl";
            pck_fold_lbl.Size = new Size(136, 28);
            pck_fold_lbl.TabIndex = 61;
            pck_fold_lbl.Text = "Packages Folder";
            pck_fold_lbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // package_info_lbl
            // 
            package_info_lbl.Font = new Font("Segoe UI", 11F);
            package_info_lbl.Location = new Point(16, 112);
            package_info_lbl.Name = "package_info_lbl";
            package_info_lbl.Size = new Size(136, 28);
            package_info_lbl.TabIndex = 56;
            package_info_lbl.Text = "Package info";
            package_info_lbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // package_lbl
            // 
            package_lbl.Font = new Font("Segoe UI", 11F);
            package_lbl.Location = new Point(16, 72);
            package_lbl.Name = "package_lbl";
            package_lbl.Size = new Size(136, 28);
            package_lbl.TabIndex = 56;
            package_lbl.Text = "Select Package";
            package_lbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // save_data
            // 
            save_data.Font = new Font("Segoe UI", 11F);
            save_data.Location = new Point(608, 152);
            save_data.Name = "save_data";
            save_data.Size = new Size(88, 72);
            save_data.TabIndex = 67;
            save_data.Text = "Save all Entries";
            save_data.UseVisualStyleBackColor = true;
            save_data.Click += Save_Data_Click;
            // 
            // Download
            // 
            Download.Enabled = false;
            Download.Font = new Font("Segoe UI", 11F);
            Download.Location = new Point(512, 192);
            Download.Name = "Download";
            Download.Size = new Size(88, 28);
            Download.TabIndex = 66;
            Download.Text = "Update";
            Download.UseVisualStyleBackColor = true;
            Download.Click += Download_Click;
            // 
            // save_to_btn
            // 
            save_to_btn.Font = new Font("Segoe UI", 11F);
            save_to_btn.Location = new Point(512, 152);
            save_to_btn.Name = "save_to_btn";
            save_to_btn.Size = new Size(88, 28);
            save_to_btn.TabIndex = 63;
            save_to_btn.Text = "Select";
            save_to_btn.UseVisualStyleBackColor = true;
            save_to_btn.Click += Save_to_btn_Click;
            // 
            // vacc_lbl
            // 
            vacc_lbl.Font = new Font("Segoe UI", 11F);
            vacc_lbl.Location = new Point(16, 32);
            vacc_lbl.Name = "vacc_lbl";
            vacc_lbl.Size = new Size(136, 28);
            vacc_lbl.TabIndex = 54;
            vacc_lbl.Text = "Select VACC";
            vacc_lbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Main_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1412, 565);
            Controls.Add(aeronav_setup);
            Controls.Add(vccs_setup);
            Controls.Add(es_setup);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Main_Form";
            Text = "AIRAC Updater for Euroscope";
            Load += Main_Form_Load;
            es_setup.ResumeLayout(false);
            es_setup.PerformLayout();
            vccs_setup.ResumeLayout(false);
            vccs_setup.PerformLayout();
            aeronav_setup.ResumeLayout(false);
            aeronav_setup.PerformLayout();
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
        public Button show_hoppie;
        public TextBox hoppie_tb;
        public OpenFileDialog sound_opendialogue;
        public OpenFileDialog plugin_opendialogue;
        public GroupBox vccs_setup;
        public CheckBox nickname_cb;
        public CheckBox g2a_ptt_cb;
        public TextBox nickname_tb;
        public Button g2g_btn;
        public Button g2a_btn;
        public CheckBox g2g_ptt_cb;
        public CheckBox capture_mode_cb;
        public CheckBox playback_device_cb;
        public CheckBox playback_mode_cb;
        public CheckBox capture_device_cb;
        public ComboBox capture_mode_dd;
        public ComboBox playback_device_dd;
        public ComboBox playback_mode_dd;
        public ComboBox capture_device_dd;
        private GroupBox aeronav_setup;
        private Label vacc_lbl;
        public ComboBox vacc_dd;
        public ComboBox pack_dd;
        private Label package_lbl;
        public Label Pack_Released;
        public Label Pack_Version;
        public Label Pack_AIRAC;
        private Label pck_fold_lbl;
        public TextBox save_to_tb;
        public Label download_lbl;
        public Button Download;
        public Button save_to_btn;
        public ProgressBar download_bar;
        public ToolTip toolTip1;
        private Label package_info_lbl;
        private FolderBrowserDialog save_folder;
        public Button save_data;
    }
}