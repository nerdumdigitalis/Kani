namespace Kani
{
    partial class PlayingTableView
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
            this.lblPlayer2Say = new System.Windows.Forms.Label();
            this.lblPlayer3Say = new System.Windows.Forms.Label();
            this.lblPlayer4Say = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPlayer2Say
            // 
            this.lblPlayer2Say.AutoSize = true;
            this.lblPlayer2Say.Font = new System.Drawing.Font("Viner Hand ITC", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2Say.Location = new System.Drawing.Point(930, 540);
            this.lblPlayer2Say.Name = "lblPlayer2Say";
            this.lblPlayer2Say.Size = new System.Drawing.Size(0, 44);
            this.lblPlayer2Say.TabIndex = 22;
            // 
            // lblPlayer3Say
            // 
            this.lblPlayer3Say.AutoSize = true;
            this.lblPlayer3Say.Font = new System.Drawing.Font("Viner Hand ITC", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer3Say.Location = new System.Drawing.Point(930, 584);
            this.lblPlayer3Say.Name = "lblPlayer3Say";
            this.lblPlayer3Say.Size = new System.Drawing.Size(0, 44);
            this.lblPlayer3Say.TabIndex = 23;
            // 
            // lblPlayer4Say
            // 
            this.lblPlayer4Say.AutoSize = true;
            this.lblPlayer4Say.Font = new System.Drawing.Font("Viner Hand ITC", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer4Say.Location = new System.Drawing.Point(930, 628);
            this.lblPlayer4Say.Name = "lblPlayer4Say";
            this.lblPlayer4Say.Size = new System.Drawing.Size(0, 44);
            this.lblPlayer4Say.TabIndex = 24;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(941, 24);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(123, 37);
            this.btnPlay.TabIndex = 25;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.Play);
            // 
            // PlayingTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1216, 685);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblPlayer4Say);
            this.Controls.Add(this.lblPlayer3Say);
            this.Controls.Add(this.lblPlayer2Say);
            this.Name = "PlayingTableView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kani";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayer2Say;
        private System.Windows.Forms.Label lblPlayer3Say;
        private System.Windows.Forms.Label lblPlayer4Say;
        private System.Windows.Forms.Button btnPlay;
    }
}

