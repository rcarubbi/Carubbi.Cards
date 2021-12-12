namespace Carubbi.Cards.Test.UI
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.GameNumberLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.buttonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ShuffleButton = new System.Windows.Forms.Button();
            this.TopToBottomButton = new System.Windows.Forms.Button();
            this.BottomToBottomButton = new System.Windows.Forms.Button();
            this.GetRandomButton = new System.Windows.Forms.Button();
            this.GetFromPanel = new System.Windows.Forms.Panel();
            this.GetFromIndexTextBox = new System.Windows.Forms.NumericUpDown();
            this.GetFrom = new System.Windows.Forms.Button();
            this.PutToTopButton = new System.Windows.Forms.Button();
            this.PutToBottomButton = new System.Windows.Forms.Button();
            this.PutToRandomButton = new System.Windows.Forms.Button();
            this.PutToPanel = new System.Windows.Forms.Panel();
            this.PutToIndexTextBox = new System.Windows.Forms.NumericUpDown();
            this.PutToButton = new System.Windows.Forms.Button();
            this.HandPanel = new Carubbi.Cards.WinForms.CardSetPanel();
            this.DeckPanel = new Carubbi.Cards.WinForms.CardSetPanel();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.GetFromPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GetFromIndexTextBox)).BeginInit();
            this.PutToPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PutToIndexTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // QuitButton
            // 
            this.QuitButton.FlatAppearance.BorderSize = 0;
            this.QuitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.QuitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.QuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuitButton.ForeColor = System.Drawing.Color.White;
            this.QuitButton.Location = new System.Drawing.Point(3, 788);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(192, 46);
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
            this.StartButton.Location = new System.Drawing.Point(3, 736);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(192, 46);
            this.StartButton.TabIndex = 0;
            this.StartButton.Tag = "Stopped";
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(155)))), ((int)(((byte)(118)))));
            this.headerPanel.Controls.Add(this.TitleLabel);
            this.headerPanel.Controls.Add(this.iconPictureBox);
            this.headerPanel.Controls.Add(this.GameNumberLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(201, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1227, 94);
            this.headerPanel.TabIndex = 1;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(17, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(747, 48);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Carubbi Cards Deck Test";
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBox.BackgroundImage = global::Carubbi.Cards.Test.UI.Properties.Resources.cards_icon;
            this.iconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconPictureBox.Location = new System.Drawing.Point(1124, 0);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(103, 94);
            this.iconPictureBox.TabIndex = 0;
            this.iconPictureBox.TabStop = false;
            // 
            // GameNumberLabel
            // 
            this.GameNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GameNumberLabel.BackColor = System.Drawing.Color.Transparent;
            this.GameNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameNumberLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GameNumberLabel.Location = new System.Drawing.Point(951, 47);
            this.GameNumberLabel.Name = "GameNumberLabel";
            this.GameNumberLabel.Size = new System.Drawing.Size(167, 44);
            this.GameNumberLabel.TabIndex = 3;
            this.GameNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            this.mainPanel.BackgroundImage = global::Carubbi.Cards.Test.UI.Properties.Resources.bg;
            this.mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPanel.Controls.Add(this.DeckPanel);
            this.mainPanel.Controls.Add(this.HandPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(201, 94);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1227, 743);
            this.mainPanel.TabIndex = 2;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.buttonsPanel.Controls.Add(this.QuitButton);
            this.buttonsPanel.Controls.Add(this.StartButton);
            this.buttonsPanel.Controls.Add(this.ShuffleButton);
            this.buttonsPanel.Controls.Add(this.TopToBottomButton);
            this.buttonsPanel.Controls.Add(this.BottomToBottomButton);
            this.buttonsPanel.Controls.Add(this.GetRandomButton);
            this.buttonsPanel.Controls.Add(this.GetFromPanel);
            this.buttonsPanel.Controls.Add(this.PutToTopButton);
            this.buttonsPanel.Controls.Add(this.PutToBottomButton);
            this.buttonsPanel.Controls.Add(this.PutToRandomButton);
            this.buttonsPanel.Controls.Add(this.PutToPanel);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.buttonsPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(201, 837);
            this.buttonsPanel.TabIndex = 3;
            // 
            // ShuffleButton
            // 
            this.ShuffleButton.FlatAppearance.BorderSize = 0;
            this.ShuffleButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ShuffleButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.ShuffleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShuffleButton.ForeColor = System.Drawing.Color.White;
            this.ShuffleButton.Location = new System.Drawing.Point(3, 684);
            this.ShuffleButton.Name = "ShuffleButton";
            this.ShuffleButton.Size = new System.Drawing.Size(192, 46);
            this.ShuffleButton.TabIndex = 2;
            this.ShuffleButton.Tag = "Started";
            this.ShuffleButton.Text = "Shuffle";
            this.ShuffleButton.UseVisualStyleBackColor = true;
            this.ShuffleButton.Click += new System.EventHandler(this.ShuffleButton_Click);
            // 
            // TopToBottomButton
            // 
            this.TopToBottomButton.FlatAppearance.BorderSize = 0;
            this.TopToBottomButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.TopToBottomButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TopToBottomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TopToBottomButton.ForeColor = System.Drawing.Color.White;
            this.TopToBottomButton.Location = new System.Drawing.Point(3, 632);
            this.TopToBottomButton.Name = "TopToBottomButton";
            this.TopToBottomButton.Size = new System.Drawing.Size(192, 46);
            this.TopToBottomButton.TabIndex = 3;
            this.TopToBottomButton.Tag = "Started";
            this.TopToBottomButton.Text = "Get From Top";
            this.TopToBottomButton.UseVisualStyleBackColor = true;
            this.TopToBottomButton.Click += new System.EventHandler(this.TopToBottomButton_Click);
            // 
            // BottomToBottomButton
            // 
            this.BottomToBottomButton.FlatAppearance.BorderSize = 0;
            this.BottomToBottomButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BottomToBottomButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BottomToBottomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BottomToBottomButton.ForeColor = System.Drawing.Color.White;
            this.BottomToBottomButton.Location = new System.Drawing.Point(3, 580);
            this.BottomToBottomButton.Name = "BottomToBottomButton";
            this.BottomToBottomButton.Size = new System.Drawing.Size(192, 46);
            this.BottomToBottomButton.TabIndex = 4;
            this.BottomToBottomButton.Tag = "Started";
            this.BottomToBottomButton.Text = "Get From Bottom";
            this.BottomToBottomButton.UseVisualStyleBackColor = true;
            this.BottomToBottomButton.Click += new System.EventHandler(this.BottomToBottomButton_Click);
            // 
            // GetRandomButton
            // 
            this.GetRandomButton.FlatAppearance.BorderSize = 0;
            this.GetRandomButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.GetRandomButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.GetRandomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GetRandomButton.ForeColor = System.Drawing.Color.White;
            this.GetRandomButton.Location = new System.Drawing.Point(3, 528);
            this.GetRandomButton.Name = "GetRandomButton";
            this.GetRandomButton.Size = new System.Drawing.Size(192, 46);
            this.GetRandomButton.TabIndex = 5;
            this.GetRandomButton.Tag = "Started";
            this.GetRandomButton.Text = "Get Random";
            this.GetRandomButton.UseVisualStyleBackColor = true;
            this.GetRandomButton.Click += new System.EventHandler(this.GetRandomButton_Click);
            // 
            // GetFromPanel
            // 
            this.GetFromPanel.Controls.Add(this.GetFromIndexTextBox);
            this.GetFromPanel.Controls.Add(this.GetFrom);
            this.GetFromPanel.Location = new System.Drawing.Point(3, 476);
            this.GetFromPanel.Name = "GetFromPanel";
            this.GetFromPanel.Size = new System.Drawing.Size(192, 46);
            this.GetFromPanel.TabIndex = 7;
            // 
            // GetFromIndexTextBox
            // 
            this.GetFromIndexTextBox.Location = new System.Drawing.Point(97, 13);
            this.GetFromIndexTextBox.Name = "GetFromIndexTextBox";
            this.GetFromIndexTextBox.Size = new System.Drawing.Size(46, 22);
            this.GetFromIndexTextBox.TabIndex = 7;
            // 
            // GetFrom
            // 
            this.GetFrom.FlatAppearance.BorderSize = 0;
            this.GetFrom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.GetFrom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.GetFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GetFrom.ForeColor = System.Drawing.Color.White;
            this.GetFrom.Location = new System.Drawing.Point(3, 3);
            this.GetFrom.Name = "GetFrom";
            this.GetFrom.Size = new System.Drawing.Size(88, 41);
            this.GetFrom.TabIndex = 6;
            this.GetFrom.Tag = "Started";
            this.GetFrom.Text = "Get From";
            this.GetFrom.UseVisualStyleBackColor = true;
            this.GetFrom.Click += new System.EventHandler(this.GetFrom_Click);
            // 
            // PutToTopButton
            // 
            this.PutToTopButton.FlatAppearance.BorderSize = 0;
            this.PutToTopButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.PutToTopButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.PutToTopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PutToTopButton.ForeColor = System.Drawing.Color.White;
            this.PutToTopButton.Location = new System.Drawing.Point(3, 424);
            this.PutToTopButton.Name = "PutToTopButton";
            this.PutToTopButton.Size = new System.Drawing.Size(192, 46);
            this.PutToTopButton.TabIndex = 8;
            this.PutToTopButton.Tag = "Started";
            this.PutToTopButton.Text = "Put to top";
            this.PutToTopButton.UseVisualStyleBackColor = true;
            this.PutToTopButton.Click += new System.EventHandler(this.PutToTopButton_Click);
            // 
            // PutToBottomButton
            // 
            this.PutToBottomButton.FlatAppearance.BorderSize = 0;
            this.PutToBottomButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.PutToBottomButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.PutToBottomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PutToBottomButton.ForeColor = System.Drawing.Color.White;
            this.PutToBottomButton.Location = new System.Drawing.Point(3, 372);
            this.PutToBottomButton.Name = "PutToBottomButton";
            this.PutToBottomButton.Size = new System.Drawing.Size(192, 46);
            this.PutToBottomButton.TabIndex = 9;
            this.PutToBottomButton.Tag = "Started";
            this.PutToBottomButton.Text = "Put To Bottom";
            this.PutToBottomButton.UseVisualStyleBackColor = true;
            this.PutToBottomButton.Click += new System.EventHandler(this.PutToBottomButton_Click);
            // 
            // PutToRandomButton
            // 
            this.PutToRandomButton.FlatAppearance.BorderSize = 0;
            this.PutToRandomButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.PutToRandomButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.PutToRandomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PutToRandomButton.ForeColor = System.Drawing.Color.White;
            this.PutToRandomButton.Location = new System.Drawing.Point(3, 320);
            this.PutToRandomButton.Name = "PutToRandomButton";
            this.PutToRandomButton.Size = new System.Drawing.Size(192, 46);
            this.PutToRandomButton.TabIndex = 10;
            this.PutToRandomButton.Tag = "Started";
            this.PutToRandomButton.Text = "Put To Random";
            this.PutToRandomButton.UseVisualStyleBackColor = true;
            this.PutToRandomButton.Click += new System.EventHandler(this.PutToRandomButton_Click);
            // 
            // PutToPanel
            // 
            this.PutToPanel.Controls.Add(this.PutToIndexTextBox);
            this.PutToPanel.Controls.Add(this.PutToButton);
            this.PutToPanel.Location = new System.Drawing.Point(3, 268);
            this.PutToPanel.Name = "PutToPanel";
            this.PutToPanel.Size = new System.Drawing.Size(192, 46);
            this.PutToPanel.TabIndex = 8;
            // 
            // PutToIndexTextBox
            // 
            this.PutToIndexTextBox.Location = new System.Drawing.Point(97, 13);
            this.PutToIndexTextBox.Name = "PutToIndexTextBox";
            this.PutToIndexTextBox.Size = new System.Drawing.Size(46, 22);
            this.PutToIndexTextBox.TabIndex = 7;
            // 
            // PutToButton
            // 
            this.PutToButton.FlatAppearance.BorderSize = 0;
            this.PutToButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.PutToButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.PutToButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PutToButton.ForeColor = System.Drawing.Color.White;
            this.PutToButton.Location = new System.Drawing.Point(3, 3);
            this.PutToButton.Name = "PutToButton";
            this.PutToButton.Size = new System.Drawing.Size(88, 41);
            this.PutToButton.TabIndex = 6;
            this.PutToButton.Tag = "Started";
            this.PutToButton.Text = "Put to";
            this.PutToButton.UseVisualStyleBackColor = true;
            this.PutToButton.Click += new System.EventHandler(this.PutToButton_Click);
            // 
            // HandPanel
            // 
            this.HandPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HandPanel.BackColor = System.Drawing.Color.Transparent;
            this.HandPanel.CardPadding = 0;
            this.HandPanel.CardSet = null;
            this.HandPanel.Location = new System.Drawing.Point(635, 31);
            this.HandPanel.Name = "HandPanel";
            this.HandPanel.Size = new System.Drawing.Size(563, 684);
            this.HandPanel.TabIndex = 5;
            // 
            // DeckPanel
            // 
            this.DeckPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DeckPanel.AutoScroll = true;
            this.DeckPanel.BackColor = System.Drawing.Color.Transparent;
            this.DeckPanel.CardPadding = 0;
            this.DeckPanel.CardSet = null;
            this.DeckPanel.Location = new System.Drawing.Point(22, 31);
            this.DeckPanel.Name = "DeckPanel";
            this.DeckPanel.Size = new System.Drawing.Size(584, 684);
            this.DeckPanel.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1428, 837);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.buttonsPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.buttonsPanel.ResumeLayout(false);
            this.GetFromPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GetFromIndexTextBox)).EndInit();
            this.PutToPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PutToIndexTextBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.FlowLayoutPanel buttonsPanel;
        private System.Windows.Forms.Button ShuffleButton;
        private System.Windows.Forms.Button TopToBottomButton;
        private System.Windows.Forms.Button BottomToBottomButton;
        private System.Windows.Forms.Button GetRandomButton;
        private System.Windows.Forms.Label GameNumberLabel;
        private System.Windows.Forms.Panel GetFromPanel;
        private System.Windows.Forms.NumericUpDown GetFromIndexTextBox;
        private System.Windows.Forms.Button GetFrom;
        private System.Windows.Forms.Button PutToTopButton;
        private System.Windows.Forms.Button PutToBottomButton;
        private System.Windows.Forms.Button PutToRandomButton;
        private System.Windows.Forms.Panel PutToPanel;
        private System.Windows.Forms.NumericUpDown PutToIndexTextBox;
        private System.Windows.Forms.Button PutToButton;
        private WinForms.CardSetPanel DeckPanel;
        private WinForms.CardSetPanel HandPanel;
    }
}

