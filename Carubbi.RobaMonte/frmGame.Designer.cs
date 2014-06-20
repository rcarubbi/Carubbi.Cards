namespace Carubbi.RobaMonte
{
    partial class frmGame
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
            this.picPlayer1 = new System.Windows.Forms.PictureBox();
            this.picPlayer2 = new System.Windows.Forms.PictureBox();
            this.btnDesce = new System.Windows.Forms.Button();
            this.lblPlacarP1 = new System.Windows.Forms.Label();
            this.lblPlacarP2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2)).BeginInit();
            this.SuspendLayout();
            // 
            // picPlayer1
            // 
            this.picPlayer1.Location = new System.Drawing.Point(57, 119);
            this.picPlayer1.Name = "picPlayer1";
            this.picPlayer1.Size = new System.Drawing.Size(126, 196);
            this.picPlayer1.TabIndex = 0;
            this.picPlayer1.TabStop = false;
            // 
            // picPlayer2
            // 
            this.picPlayer2.Location = new System.Drawing.Point(596, 119);
            this.picPlayer2.Name = "picPlayer2";
            this.picPlayer2.Size = new System.Drawing.Size(126, 205);
            this.picPlayer2.TabIndex = 1;
            this.picPlayer2.TabStop = false;
            // 
            // btnDesce
            // 
            this.btnDesce.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesce.Location = new System.Drawing.Point(304, 431);
            this.btnDesce.Name = "btnDesce";
            this.btnDesce.Size = new System.Drawing.Size(170, 48);
            this.btnDesce.TabIndex = 2;
            this.btnDesce.Text = "DESCE!";
            this.btnDesce.UseVisualStyleBackColor = true;
            this.btnDesce.Click += new System.EventHandler(this.btnDesce_Click);
            // 
            // lblPlacarP1
            // 
            this.lblPlacarP1.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblPlacarP1.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlacarP1.ForeColor = System.Drawing.Color.White;
            this.lblPlacarP1.Location = new System.Drawing.Point(57, 394);
            this.lblPlacarP1.Name = "lblPlacarP1";
            this.lblPlacarP1.Size = new System.Drawing.Size(124, 118);
            this.lblPlacarP1.TabIndex = 3;
            this.lblPlacarP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlacarP2
            // 
            this.lblPlacarP2.BackColor = System.Drawing.Color.Red;
            this.lblPlacarP2.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlacarP2.ForeColor = System.Drawing.Color.White;
            this.lblPlacarP2.Location = new System.Drawing.Point(593, 394);
            this.lblPlacarP2.Name = "lblPlacarP2";
            this.lblPlacarP2.Size = new System.Drawing.Size(124, 118);
            this.lblPlacarP2.TabIndex = 4;
            this.lblPlacarP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(798, 579);
            this.Controls.Add(this.lblPlacarP2);
            this.Controls.Add(this.lblPlacarP1);
            this.Controls.Add(this.btnDesce);
            this.Controls.Add(this.picPlayer2);
            this.Controls.Add(this.picPlayer1);
            this.Name = "frmGame";
            this.Text = "Roba Monte";
            this.Load += new System.EventHandler(this.frmGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPlayer1;
        private System.Windows.Forms.PictureBox picPlayer2;
        private System.Windows.Forms.Button btnDesce;
        private System.Windows.Forms.Label lblPlacarP1;
        private System.Windows.Forms.Label lblPlacarP2;
    }
}

