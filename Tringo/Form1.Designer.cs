namespace Tringo
{
    partial class TringoApp
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
            this.bLoading = new System.Windows.Forms.Button();
            this.bCreateMovements = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bMeanComputation = new System.Windows.Forms.Button();
            this.bVariationStatistics = new System.Windows.Forms.Button();
            this.lName = new System.Windows.Forms.Label();
            this.bClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bLoading
            // 
            this.bLoading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLoading.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLoading.ForeColor = System.Drawing.Color.Gray;
            this.bLoading.Location = new System.Drawing.Point(108, 160);
            this.bLoading.Name = "bLoading";
            this.bLoading.Size = new System.Drawing.Size(186, 59);
            this.bLoading.TabIndex = 1;
            this.bLoading.Text = "Načíst data";
            this.bLoading.UseVisualStyleBackColor = true;
            this.bLoading.Click += new System.EventHandler(this.bLoading_Click);
            // 
            // bCreateMovements
            // 
            this.bCreateMovements.Enabled = false;
            this.bCreateMovements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCreateMovements.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCreateMovements.ForeColor = System.Drawing.Color.Gray;
            this.bCreateMovements.Location = new System.Drawing.Point(108, 225);
            this.bCreateMovements.Name = "bCreateMovements";
            this.bCreateMovements.Size = new System.Drawing.Size(186, 59);
            this.bCreateMovements.TabIndex = 3;
            this.bCreateMovements.Text = "Vytvořit pohyby";
            this.bCreateMovements.UseVisualStyleBackColor = true;
            this.bCreateMovements.Click += new System.EventHandler(this.bCreateMovements_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bMeanComputation
            // 
            this.bMeanComputation.Enabled = false;
            this.bMeanComputation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMeanComputation.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMeanComputation.ForeColor = System.Drawing.Color.Gray;
            this.bMeanComputation.Location = new System.Drawing.Point(12, 312);
            this.bMeanComputation.Name = "bMeanComputation";
            this.bMeanComputation.Size = new System.Drawing.Size(186, 59);
            this.bMeanComputation.TabIndex = 4;
            this.bMeanComputation.Text = "Zobrazit průměr";
            this.bMeanComputation.UseVisualStyleBackColor = true;
            this.bMeanComputation.Click += new System.EventHandler(this.bMeanComputation_Click);
            // 
            // bVariationStatistics
            // 
            this.bVariationStatistics.Enabled = false;
            this.bVariationStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bVariationStatistics.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bVariationStatistics.ForeColor = System.Drawing.Color.Gray;
            this.bVariationStatistics.Location = new System.Drawing.Point(204, 312);
            this.bVariationStatistics.Name = "bVariationStatistics";
            this.bVariationStatistics.Size = new System.Drawing.Size(186, 59);
            this.bVariationStatistics.TabIndex = 5;
            this.bVariationStatistics.Text = "Základní statistika";
            this.bVariationStatistics.UseVisualStyleBackColor = true;
            this.bVariationStatistics.Click += new System.EventHandler(this.bVariationStatistics_Click);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Bahnschrift SemiBold", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.ForeColor = System.Drawing.Color.Silver;
            this.lName.Location = new System.Drawing.Point(76, 50);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(262, 81);
            this.lName.TabIndex = 6;
            this.lName.Text = "TRINGO";
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.Maroon;
            this.bClose.FlatAppearance.BorderSize = 0;
            this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClose.ForeColor = System.Drawing.Color.Transparent;
            this.bClose.Location = new System.Drawing.Point(380, 12);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(20, 20);
            this.bClose.TabIndex = 7;
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // TringoApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(412, 501);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.bVariationStatistics);
            this.Controls.Add(this.bMeanComputation);
            this.Controls.Add(this.bCreateMovements);
            this.Controls.Add(this.bLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TringoApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TringoApp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bLoading;
        private System.Windows.Forms.Button bCreateMovements;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bMeanComputation;
        private System.Windows.Forms.Button bVariationStatistics;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Button bClose;
    }
}

