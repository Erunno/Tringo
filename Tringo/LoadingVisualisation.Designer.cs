namespace Tringo
{
    partial class LoadingVisualisation
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lProgress = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.DarkRed;
            this.progressBar.ForeColor = System.Drawing.Color.Black;
            this.progressBar.Location = new System.Drawing.Point(12, 72);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(427, 10);
            this.progressBar.TabIndex = 0;
            // 
            // lProgress
            // 
            this.lProgress.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lProgress.AutoSize = true;
            this.lProgress.Font = new System.Drawing.Font("Bahnschrift SemiLight", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProgress.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lProgress.Location = new System.Drawing.Point(6, 27);
            this.lProgress.Name = "lProgress";
            this.lProgress.Size = new System.Drawing.Size(131, 33);
            this.lProgress.TabIndex = 1;
            this.lProgress.Text = "Načítání...";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.Maroon;
            this.bClose.FlatAppearance.BorderSize = 0;
            this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClose.ForeColor = System.Drawing.Color.Transparent;
            this.bClose.Location = new System.Drawing.Point(419, 12);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(20, 20);
            this.bClose.TabIndex = 9;
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // LoadingVisualisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(451, 109);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.lProgress);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingVisualisation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadingVisualisation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lProgress;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bClose;
    }
}