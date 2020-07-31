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
            this.nEnvelopWinSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bApply = new System.Windows.Forms.Button();
            this.cbAutosize = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nWidth = new System.Windows.Forms.NumericUpDown();
            this.nHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nEnvelopWinSize)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSensorSelection
            // 
            this.cbSensorSelection.FormattingEnabled = true;
            this.cbSensorSelection.Location = new System.Drawing.Point(14, 54);
            this.cbSensorSelection.Name = "cbSensorSelection";
            this.cbSensorSelection.Size = new System.Drawing.Size(295, 21);
            this.cbSensorSelection.TabIndex = 0;
            this.cbSensorSelection.SelectedIndexChanged += new System.EventHandler(this.cbSensorSelection_SelectedIndexChanged);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel.Location = new System.Drawing.Point(13, 101);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1460, 654);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // lGraphsList
            // 
            this.lGraphsList.AutoSize = true;
            this.lGraphsList.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGraphsList.ForeColor = System.Drawing.Color.Silver;
            this.lGraphsList.Location = new System.Drawing.Point(10, 28);
            this.lGraphsList.Name = "lGraphsList";
            this.lGraphsList.Size = new System.Drawing.Size(253, 23);
            this.lGraphsList.TabIndex = 9;
            this.lGraphsList.Text = "Jméno prohlíženého senzoru";
            // 
            // cbExperiments
            // 
            this.cbExperiments.FormattingEnabled = true;
            this.cbExperiments.Location = new System.Drawing.Point(341, 53);
            this.cbExperiments.Name = "cbExperiments";
            this.cbExperiments.Size = new System.Drawing.Size(204, 21);
            this.cbExperiments.TabIndex = 13;
            this.cbExperiments.SelectedIndexChanged += new System.EventHandler(this.cbExperiments_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(337, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Experiment";
            // 
            // bChangeColor
            // 
            this.bChangeColor.Enabled = false;
            this.bChangeColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bChangeColor.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bChangeColor.ForeColor = System.Drawing.Color.Gray;
            this.bChangeColor.Location = new System.Drawing.Point(551, 30);
            this.bChangeColor.Name = "bChangeColor";
            this.bChangeColor.Size = new System.Drawing.Size(103, 43);
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
            this.bShowExperiment.Location = new System.Drawing.Point(660, 30);
            this.bShowExperiment.Name = "bShowExperiment";
            this.bShowExperiment.Size = new System.Drawing.Size(103, 43);
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
            this.bExportInOne.Location = new System.Drawing.Point(1302, 34);
            this.bExportInOne.Name = "bExportInOne";
            this.bExportInOne.Size = new System.Drawing.Size(171, 43);
            this.bExportInOne.TabIndex = 18;
            this.bExportInOne.Text = "Exportovat jako PNG";
            this.bExportInOne.UseVisualStyleBackColor = true;
            this.bExportInOne.Click += new System.EventHandler(this.bExportInOne_Click);
            // 
            // nEnvelopWinSize
            // 
            this.nEnvelopWinSize.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nEnvelopWinSize.Location = new System.Drawing.Point(183, 36);
            this.nEnvelopWinSize.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nEnvelopWinSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nEnvelopWinSize.Name = "nEnvelopWinSize";
            this.nEnvelopWinSize.Size = new System.Drawing.Size(70, 20);
            this.nEnvelopWinSize.TabIndex = 19;
            this.nEnvelopWinSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(180, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Velikost okna obálky (ms)";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bApply);
            this.panel1.Controls.Add(this.cbAutosize);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.nWidth);
            this.panel1.Controls.Add(this.nHeight);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nEnvelopWinSize);
            this.panel1.Location = new System.Drawing.Point(808, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 83);
            this.panel1.TabIndex = 21;
            // 
            // bApply
            // 
            this.bApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bApply.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bApply.ForeColor = System.Drawing.Color.Gray;
            this.bApply.Location = new System.Drawing.Point(328, 21);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(74, 43);
            this.bApply.TabIndex = 22;
            this.bApply.Text = "Aplikovat";
            this.bApply.UseVisualStyleBackColor = true;
            this.bApply.Click += new System.EventHandler(this.bApply_Click);
            // 
            // cbAutosize
            // 
            this.cbAutosize.AutoSize = true;
            this.cbAutosize.Checked = true;
            this.cbAutosize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutosize.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.cbAutosize.Location = new System.Drawing.Point(15, 14);
            this.cbAutosize.Name = "cbAutosize";
            this.cbAutosize.Size = new System.Drawing.Size(87, 17);
            this.cbAutosize.TabIndex = 26;
            this.cbAutosize.Text = "Auto velikost";
            this.cbAutosize.UseVisualStyleBackColor = true;
            this.cbAutosize.CheckedChanged += new System.EventHandler(this.cbAutosize_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(88, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Šířka (px)";
            // 
            // nWidth
            // 
            this.nWidth.Enabled = false;
            this.nWidth.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nWidth.Location = new System.Drawing.Point(91, 51);
            this.nWidth.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nWidth.Name = "nWidth";
            this.nWidth.Size = new System.Drawing.Size(70, 20);
            this.nWidth.TabIndex = 24;
            this.nWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nHeight
            // 
            this.nHeight.Enabled = false;
            this.nHeight.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nHeight.Location = new System.Drawing.Point(15, 52);
            this.nHeight.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nHeight.Name = "nHeight";
            this.nHeight.Size = new System.Drawing.Size(70, 20);
            this.nHeight.TabIndex = 23;
            this.nHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(12, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Výška (px)";
            // 
            // cbChangeColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1485, 765);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bExportInOne);
            this.Controls.Add(this.bShowExperiment);
            this.Controls.Add(this.bChangeColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbExperiments);
            this.Controls.Add(this.lGraphsList);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.cbSensorSelection);
            this.Name = "cbChangeColor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MeanGraphView";
            this.Resize += new System.EventHandler(this.cbChangeColor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.nEnvelopWinSize)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHeight)).EndInit();
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
        private System.Windows.Forms.NumericUpDown nEnvelopWinSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nWidth;
        private System.Windows.Forms.NumericUpDown nHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbAutosize;
        private System.Windows.Forms.Button bApply;
    }
}