namespace MeanView
{
    partial class MeanGraphView
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
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lGraphsList = new System.Windows.Forms.Label();
            this.bClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(17, 65);
            this.comboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(455, 24);
            this.comboBox.TabIndex = 0;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel.Location = new System.Drawing.Point(17, 124);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(2302, 1041);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // lGraphsList
            // 
            this.lGraphsList.AutoSize = true;
            this.lGraphsList.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGraphsList.ForeColor = System.Drawing.Color.Silver;
            this.lGraphsList.Location = new System.Drawing.Point(12, 33);
            this.lGraphsList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lGraphsList.Name = "lGraphsList";
            this.lGraphsList.Size = new System.Drawing.Size(318, 29);
            this.lGraphsList.TabIndex = 9;
            this.lGraphsList.Text = "Jméno prohlíženého senzoru";
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.Maroon;
            this.bClose.FlatAppearance.BorderSize = 0;
            this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClose.ForeColor = System.Drawing.Color.Transparent;
            this.bClose.Location = new System.Drawing.Point(2292, 13);
            this.bClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(27, 25);
            this.bClose.TabIndex = 10;
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // MeanGraphView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(2332, 1178);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.lGraphsList);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.comboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MeanGraphView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MeanGraphView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label lGraphsList;
        private System.Windows.Forms.Button bClose;
    }
}