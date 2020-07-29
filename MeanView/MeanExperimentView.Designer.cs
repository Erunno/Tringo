namespace MeanView
{
    partial class cbChangeColor
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
            this.cbSensorSelection = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lGraphsList = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.cbExperiments = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bChangeColor = new System.Windows.Forms.Button();
            this.bShowExperiment = new System.Windows.Forms.Button();
            this.bExportInOne = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // cbSensorSelection
            // 
            this.cbSensorSelection.FormattingEnabled = true;
            this.cbSensorSelection.Location = new System.Drawing.Point(18, 66);
            this.cbSensorSelection.Margin = new System.Windows.Forms.Padding(4);
            this.cbSensorSelection.Name = "cbSensorSelection";
            this.cbSensorSelection.Size = new System.Drawing.Size(455, 24);
            this.cbSensorSelection.TabIndex = 0;
            this.cbSensorSelection.SelectedIndexChanged += new System.EventHandler(this.cbSensorSelection_SelectedIndexChanged);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel.Location = new System.Drawing.Point(17, 124);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1845, 804);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // lGraphsList
            // 
            this.lGraphsList.AutoSize = true;
            this.lGraphsList.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGraphsList.ForeColor = System.Drawing.Color.Silver;
            this.lGraphsList.Location = new System.Drawing.Point(13, 34);
            this.lGraphsList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lGraphsList.Name = "lGraphsList";
            this.lGraphsList.Size = new System.Drawing.Size(318, 29);
            this.lGraphsList.TabIndex = 9;
            this.lGraphsList.Text = "Jméno prohlíženého senzoru";
            // 
            // cbExperiments
            // 
            this.cbExperiments.FormattingEnabled = true;
            this.cbExperiments.Location = new System.Drawing.Point(563, 66);
            this.cbExperiments.Margin = new System.Windows.Forms.Padding(4);
            this.cbExperiments.Name = "cbExperiments";
            this.cbExperiments.Size = new System.Drawing.Size(392, 24);
            this.cbExperiments.TabIndex = 13;
            this.cbExperiments.SelectedIndexChanged += new System.EventHandler(this.cbExperiments_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(557, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "Experiment";
            // 
            // bChangeColor
            // 
            this.bChangeColor.Enabled = false;
            this.bChangeColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bChangeColor.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bChangeColor.ForeColor = System.Drawing.Color.Gray;
            this.bChangeColor.Location = new System.Drawing.Point(981, 39);
            this.bChangeColor.Margin = new System.Windows.Forms.Padding(4);
            this.bChangeColor.Name = "bChangeColor";
            this.bChangeColor.Size = new System.Drawing.Size(137, 53);
            this.bChangeColor.TabIndex = 15;
            this.bChangeColor.Text = "Změnit barvu";
            this.bChangeColor.UseVisualStyleBackColor = true;
            this.bChangeColor.Click += new System.EventHandler(this.bChangeColor_Click);
            // 
            // bShowExperiment
            // 
            this.bShowExperiment.Enabled = false;
            this.bShowExperiment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bShowExperiment.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bShowExperiment.ForeColor = System.Drawing.Color.Gray;
            this.bShowExperiment.Location = new System.Drawing.Point(1127, 39);
            this.bShowExperiment.Margin = new System.Windows.Forms.Padding(4);
            this.bShowExperiment.Name = "bShowExperiment";
            this.bShowExperiment.Size = new System.Drawing.Size(137, 53);
            this.bShowExperiment.TabIndex = 17;
            this.bShowExperiment.Text = "Zobrazit/Nezobrozovat";
            this.bShowExperiment.UseVisualStyleBackColor = true;
            this.bShowExperiment.Click += new System.EventHandler(this.bShowExperiment_Click);
            // 
            // bExportInOne
            // 
            this.bExportInOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bExportInOne.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExportInOne.ForeColor = System.Drawing.Color.Gray;
            this.bExportInOne.Location = new System.Drawing.Point(1367, 39);
            this.bExportInOne.Margin = new System.Windows.Forms.Padding(4);
            this.bExportInOne.Name = "bExportInOne";
            this.bExportInOne.Size = new System.Drawing.Size(228, 53);
            this.bExportInOne.TabIndex = 18;
            this.bExportInOne.Text = "Exportovat jako PNG";
            this.bExportInOne.UseVisualStyleBackColor = true;
            this.bExportInOne.Click += new System.EventHandler(this.bExportInOne_Click);
            // 
            // cbChangeColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1875, 941);
            this.Controls.Add(this.bExportInOne);
            this.Controls.Add(this.bShowExperiment);
            this.Controls.Add(this.bChangeColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbExperiments);
            this.Controls.Add(this.lGraphsList);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.cbSensorSelection);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "cbChangeColor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MeanGraphView";
            this.Resize += new System.EventHandler(this.cbChangeColor_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSensorSelection;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label lGraphsList;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ComboBox cbExperiments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bChangeColor;
        private System.Windows.Forms.Button bShowExperiment;
        private System.Windows.Forms.Button bExportInOne;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}