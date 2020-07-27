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
            this.bClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbIndexOfMovementSelection = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.cbExperiments = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bChangeColor = new System.Windows.Forms.Button();
            this.bShowExperiment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbSensorSelection
            // 
            this.cbSensorSelection.FormattingEnabled = true;
            this.cbSensorSelection.Location = new System.Drawing.Point(150, 55);
            this.cbSensorSelection.Name = "cbSensorSelection";
            this.cbSensorSelection.Size = new System.Drawing.Size(342, 21);
            this.cbSensorSelection.TabIndex = 0;
            this.cbSensorSelection.SelectedIndexChanged += new System.EventHandler(this.cbSensorSelection_SelectedIndexChanged);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel.Location = new System.Drawing.Point(13, 101);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(2435, 1169);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // lGraphsList
            // 
            this.lGraphsList.AutoSize = true;
            this.lGraphsList.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGraphsList.ForeColor = System.Drawing.Color.Silver;
            this.lGraphsList.Location = new System.Drawing.Point(146, 29);
            this.lGraphsList.Name = "lGraphsList";
            this.lGraphsList.Size = new System.Drawing.Size(257, 23);
            this.lGraphsList.TabIndex = 9;
            this.lGraphsList.Text = "Jméno prohlíženého senzoru";
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.Maroon;
            this.bClose.FlatAppearance.BorderSize = 0;
            this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClose.ForeColor = System.Drawing.Color.Transparent;
            this.bClose.Location = new System.Drawing.Point(2428, 12);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(20, 20);
            this.bClose.TabIndex = 10;
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Číslo pohybu";
            // 
            // cbIndexOfMovementSelection
            // 
            this.cbIndexOfMovementSelection.FormattingEnabled = true;
            this.cbIndexOfMovementSelection.Location = new System.Drawing.Point(16, 55);
            this.cbIndexOfMovementSelection.Name = "cbIndexOfMovementSelection";
            this.cbIndexOfMovementSelection.Size = new System.Drawing.Size(115, 21);
            this.cbIndexOfMovementSelection.TabIndex = 12;
            this.cbIndexOfMovementSelection.SelectedIndexChanged += new System.EventHandler(this.cbIndexOfMovementSelection_SelectedIndexChanged);
            // 
            // cbExperiments
            // 
            this.cbExperiments.FormattingEnabled = true;
            this.cbExperiments.Location = new System.Drawing.Point(1115, 55);
            this.cbExperiments.Name = "cbExperiments";
            this.cbExperiments.Size = new System.Drawing.Size(295, 21);
            this.cbExperiments.TabIndex = 13;
            this.cbExperiments.SelectedIndexChanged += new System.EventHandler(this.cbExperiments_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(1111, 29);
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
            this.bChangeColor.Location = new System.Drawing.Point(1429, 33);
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
            this.bShowExperiment.Location = new System.Drawing.Point(1538, 33);
            this.bShowExperiment.Name = "bShowExperiment";
            this.bShowExperiment.Size = new System.Drawing.Size(103, 43);
            this.bShowExperiment.TabIndex = 17;
            this.bShowExperiment.Text = "Zobrazit/Nezobrozovat";
            this.bShowExperiment.UseVisualStyleBackColor = true;
            this.bShowExperiment.Click += new System.EventHandler(this.bShowExperiment_Click);
            // 
            // cbChangeColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(2460, 1282);
            this.Controls.Add(this.bShowExperiment);
            this.Controls.Add(this.bChangeColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbExperiments);
            this.Controls.Add(this.cbIndexOfMovementSelection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.lGraphsList);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.cbSensorSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cbChangeColor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MeanGraphView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSensorSelection;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label lGraphsList;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbIndexOfMovementSelection;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ComboBox cbExperiments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bChangeColor;
        private System.Windows.Forms.Button bShowExperiment;
    }
}