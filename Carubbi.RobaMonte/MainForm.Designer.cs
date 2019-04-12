namespace Carubbi.RobaMonte
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.QuitButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.GameNumberLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.splitPanel = new System.Windows.Forms.SplitContainer();
            this.p2Panel = new System.Windows.Forms.Panel();
            this.P2CardBox = new Carubbi.Cards.WinForms.CardBox();
            this.P2ScoreLabel = new System.Windows.Forms.Label();
            this.p1Panel = new System.Windows.Forms.Panel();
            this.P1ScoreLabel = new System.Windows.Forms.Label();
            this.P1CardBox = new Carubbi.Cards.WinForms.CardBox();
            this.logPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TurnButton = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel)).BeginInit();
            this.splitPanel.Panel1.SuspendLayout();
            this.splitPanel.Panel2.SuspendLayout();
            this.splitPanel.SuspendLayout();
            this.p2Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P2CardBox)).BeginInit();
            this.p1Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P1CardBox)).BeginInit();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuitButton
            // 
            this.QuitButton.FlatAppearance.BorderSize = 0;
            this.QuitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.QuitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.QuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuitButton.ForeColor = System.Drawing.Color.White;
            this.QuitButton.Location = new System.Drawing.Point(3, 800);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(101, 34);
            this.QuitButton.TabIndex = 1;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.FlatAppearance.BorderSize = 0;
            this.StartButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.StartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.ForeColor = System.Drawing.Color.White;
            this.StartButton.Location = new System.Drawing.Point(3, 760);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(101, 34);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(155)))), ((int)(((byte)(118)))));
            this.headerPanel.Controls.Add(this.GameNumberLabel);
            this.headerPanel.Controls.Add(this.TitleLabel);
            this.headerPanel.Controls.Add(this.iconPictureBox);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(106, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1314, 94);
            this.headerPanel.TabIndex = 1;
            // 
            // GameNumberLabel
            // 
            this.GameNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GameNumberLabel.BackColor = System.Drawing.Color.Transparent;
            this.GameNumberLabel.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameNumberLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GameNumberLabel.Location = new System.Drawing.Point(1038, 47);
            this.GameNumberLabel.Name = "GameNumberLabel";
            this.GameNumberLabel.Size = new System.Drawing.Size(167, 44);
            this.GameNumberLabel.TabIndex = 2;
            this.GameNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = new System.Drawing.Font("Roboto", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(17, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(747, 48);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Roba Monte";
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBox.BackgroundImage = global::Carubbi.RobaMonte.Properties.Resources.cards_icon;
            this.iconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconPictureBox.Location = new System.Drawing.Point(1211, 0);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(103, 94);
            this.iconPictureBox.TabIndex = 0;
            this.iconPictureBox.TabStop = false;
            // 
            // mainPanel
            // 
            this.mainPanel.BackgroundImage = global::Carubbi.RobaMonte.Properties.Resources.bg;
            this.mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPanel.Controls.Add(this.splitPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(106, 94);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1314, 743);
            this.mainPanel.TabIndex = 2;
            // 
            // splitPanel
            // 
            this.splitPanel.BackColor = System.Drawing.Color.Transparent;
            this.splitPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPanel.Location = new System.Drawing.Point(0, 0);
            this.splitPanel.Name = "splitPanel";
            // 
            // splitPanel.Panel1
            // 
            this.splitPanel.Panel1.Controls.Add(this.p2Panel);
            this.splitPanel.Panel1.Controls.Add(this.p1Panel);
            // 
            // splitPanel.Panel2
            // 
            this.splitPanel.Panel2.Controls.Add(this.logPanel);
            this.splitPanel.Size = new System.Drawing.Size(1310, 739);
            this.splitPanel.SplitterDistance = 855;
            this.splitPanel.TabIndex = 7;
            // 
            // p2Panel
            // 
            this.p2Panel.Controls.Add(this.P2CardBox);
            this.p2Panel.Controls.Add(this.P2ScoreLabel);
            this.p2Panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.p2Panel.Location = new System.Drawing.Point(407, 0);
            this.p2Panel.Name = "p2Panel";
            this.p2Panel.Size = new System.Drawing.Size(448, 739);
            this.p2Panel.TabIndex = 8;
            // 
            // P2CardBox
            // 
            this.P2CardBox.BackColor = System.Drawing.Color.Transparent;
            this.P2CardBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("P2CardBox.BackgroundImage")));
            this.P2CardBox.Card = null;
            this.P2CardBox.Location = new System.Drawing.Point(182, 438);
            this.P2CardBox.Name = "P2CardBox";
            this.P2CardBox.Size = new System.Drawing.Size(85, 119);
            this.P2CardBox.TabIndex = 4;
            this.P2CardBox.TabStop = false;
            // 
            // P2ScoreLabel
            // 
            this.P2ScoreLabel.BackColor = System.Drawing.Color.Red;
            this.P2ScoreLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.P2ScoreLabel.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.P2ScoreLabel.Location = new System.Drawing.Point(0, 655);
            this.P2ScoreLabel.Name = "P2ScoreLabel";
            this.P2ScoreLabel.Size = new System.Drawing.Size(448, 84);
            this.P2ScoreLabel.TabIndex = 6;
            this.P2ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1Panel
            // 
            this.p1Panel.Controls.Add(this.P1ScoreLabel);
            this.p1Panel.Controls.Add(this.P1CardBox);
            this.p1Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.p1Panel.Location = new System.Drawing.Point(0, 0);
            this.p1Panel.Name = "p1Panel";
            this.p1Panel.Size = new System.Drawing.Size(401, 739);
            this.p1Panel.TabIndex = 7;
            // 
            // P1ScoreLabel
            // 
            this.P1ScoreLabel.BackColor = System.Drawing.Color.RoyalBlue;
            this.P1ScoreLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.P1ScoreLabel.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.P1ScoreLabel.Location = new System.Drawing.Point(0, 655);
            this.P1ScoreLabel.Name = "P1ScoreLabel";
            this.P1ScoreLabel.Size = new System.Drawing.Size(401, 84);
            this.P1ScoreLabel.TabIndex = 5;
            this.P1ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P1CardBox
            // 
            this.P1CardBox.BackColor = System.Drawing.Color.Transparent;
            this.P1CardBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("P1CardBox.BackgroundImage")));
            this.P1CardBox.Card = null;
            this.P1CardBox.Location = new System.Drawing.Point(145, 438);
            this.P1CardBox.Name = "P1CardBox";
            this.P1CardBox.Size = new System.Drawing.Size(85, 119);
            this.P1CardBox.TabIndex = 3;
            this.P1CardBox.TabStop = false;
            // 
            // logPanel
            // 
            this.logPanel.AutoScroll = true;
            this.logPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logPanel.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logPanel.ForeColor = System.Drawing.Color.White;
            this.logPanel.Location = new System.Drawing.Point(0, 0);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(451, 739);
            this.logPanel.TabIndex = 0;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.buttonsPanel.Controls.Add(this.QuitButton);
            this.buttonsPanel.Controls.Add(this.StartButton);
            this.buttonsPanel.Controls.Add(this.TurnButton);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.buttonsPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(106, 837);
            this.buttonsPanel.TabIndex = 3;
            // 
            // TurnButton
            // 
            this.TurnButton.FlatAppearance.BorderSize = 0;
            this.TurnButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.TurnButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TurnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TurnButton.ForeColor = System.Drawing.Color.White;
            this.TurnButton.Location = new System.Drawing.Point(3, 720);
            this.TurnButton.Name = "TurnButton";
            this.TurnButton.Size = new System.Drawing.Size(101, 34);
            this.TurnButton.TabIndex = 2;
            this.TurnButton.Text = "Turn";
            this.TurnButton.UseVisualStyleBackColor = true;
            this.TurnButton.Click += new System.EventHandler(this.TurnButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1420, 837);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.buttonsPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.splitPanel.Panel1.ResumeLayout(false);
            this.splitPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel)).EndInit();
            this.splitPanel.ResumeLayout(false);
            this.p2Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.P2CardBox)).EndInit();
            this.p1Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.P1CardBox)).EndInit();
            this.buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label GameNumberLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.FlowLayoutPanel buttonsPanel;
        private Carubbi.Cards.WinForms.CardBox P1CardBox;
        private Carubbi.Cards.WinForms.CardBox P2CardBox;
        private System.Windows.Forms.Button TurnButton;
        private System.Windows.Forms.Label P2ScoreLabel;
        private System.Windows.Forms.Label P1ScoreLabel;
        private System.Windows.Forms.SplitContainer splitPanel;
        private System.Windows.Forms.Panel p2Panel;
        private System.Windows.Forms.Panel p1Panel;
        private System.Windows.Forms.FlowLayoutPanel logPanel;
    }
}

