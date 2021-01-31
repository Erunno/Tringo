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
            this.lName = new System.Windows.Forms.Label();
            this.bClose = new System.Windows.Forms.Button();
            this.lAuthor = new System.Windows.Forms.Label();
            this.cbSelectedExperiment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bCreateExperiment = new System.Windows.Forms.Button();
            this.tbNewNameOfExperiment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lwSensorsInfo = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bLoading
            // 
            this.bLoading.Enabled = false;
            this.bLoading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLoading.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLoading.ForeColor = System.Drawing.Color.Gray;
            this.bLoading.Location = new System.Drawing.Point(12, 347);
            this.bLoading.Name = "bLoading";
            this.bLoading.Size = new System.Drawing.Size(272, 85);
            this.bLoading.TabIndex = 1;
            this.bLoading.Text = "Přidat data do vybraného experimentu";
            this.bLoading.UseVisualStyleBackColor = true;
            this.bLoading.Click += new System.EventHandler(this.bLoading_Click);
            // 
            // bCreateMovements
            // 
            this.bCreateMovements.Enabled = false;
            this.bCreateMovements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCreateMovements.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCreateMovements.ForeColor = System.Drawing.Color.Gray;
            this.bCreateMovements.Location = new System.Drawing.Point(12, 438);
            this.bCreateMovements.Name = "bCreateMovements";
            this.bCreateMovements.Size = new System.Drawing.Size(272, 85);
            this.bCreateMovements.TabIndex = 3;
            this.bCreateMovements.Text = "Vytvořit pohyby pro vybraný experiment";
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
            this.bMeanComputation.Location = new System.Drawing.Point(12, 649);
            this.bMeanComputation.Name = "bMeanComputation";
            this.bMeanComputation.Size = new System.Drawing.Size(272, 97);
            this.bMeanComputation.TabIndex = 4;
            this.bMeanComputation.Text = "Zobrazit průměr";
            this.bMeanComputation.UseVisualStyleBackColor = true;
            this.bMeanComputation.Click += new System.EventHandler(this.bMeanComputation_Click);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Bahnschrift SemiBold", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.ForeColor = System.Drawing.Color.Silver;
            this.lName.Location = new System.Drawing.Point(164, 60);
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
            this.bClose.Location = new System.Drawing.Point(568, 12);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(20, 20);
            this.bClose.TabIndex = 7;
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // lAuthor
            // 
            this.lAuthor.AutoSize = true;
            this.lAuthor.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAuthor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lAuthor.Location = new System.Drawing.Point(473, 749);
            this.lAuthor.Name = "lAuthor";
            this.lAuthor.Size = new System.Drawing.Size(116, 19);
            this.lAuthor.TabIndex = 8;
            this.lAuthor.Text = "Matyáš Brabec";
            // 
            // cbSelectedExperiment
            // 
            this.cbSelectedExperiment.FormattingEnabled = true;
            this.cbSelectedExperiment.Location = new System.Drawing.Point(307, 215);
            this.cbSelectedExperiment.Name = "cbSelectedExperiment";
            this.cbSelectedExperiment.Size = new System.Drawing.Size(279, 21);
            this.cbSelectedExperiment.TabIndex = 9;
            this.cbSelectedExperiment.SelectedIndexChanged += new System.EventHandler(this.cbSelectedExperiment_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(303, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Vybraný experiment";
            // 
            // bCreateExperiment
            // 
            this.bCreateExperiment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCreateExperiment.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCreateExperiment.ForeColor = System.Drawing.Color.Gray;
            this.bCreateExperiment.Location = new System.Drawing.Point(12, 237);
            this.bCreateExperiment.Name = "bCreateExperiment";
            this.bCreateExperiment.Size = new System.Drawing.Size(186, 37);
            this.bCreateExperiment.TabIndex = 11;
            this.bCreateExperiment.Text = "Vytvořit nový experiment";
            this.bCreateExperiment.UseVisualStyleBackColor = true;
            this.bCreateExperiment.Click += new System.EventHandler(this.bCreateExperiment_Click);
            // 
            // tbNewNameOfExperiment
            // 
            this.tbNewNameOfExperiment.Location = new System.Drawing.Point(12, 211);
            this.tbNewNameOfExperiment.Name = "tbNewNameOfExperiment";
            this.tbNewNameOfExperiment.Size = new System.Drawing.Size(186, 20);
            this.tbNewNameOfExperiment.TabIndex = 12;
            this.tbNewNameOfExperiment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNewNameOfExperiment_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(9, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Jméno nového experimentu";
            // 
            // lwSensorsInfo
            // 
            this.lwSensorsInfo.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lwSensorsInfo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lwSensorsInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lwSensorsInfo.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lwSensorsInfo.FullRowSelect = true;
            this.lwSensorsInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lwSensorsInfo.HideSelection = false;
            this.lwSensorsInfo.Location = new System.Drawing.Point(309, 273);
            this.lwSensorsInfo.Name = "lwSensorsInfo";
            this.lwSensorsInfo.Size = new System.Drawing.Size(279, 309);
            this.lwSensorsInfo.TabIndex = 15;
            this.lwSensorsInfo.UseCompatibleStateImageBehavior = false;
            this.lwSensorsInfo.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(309, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Senzory vybraného experimentu";
            // 
            // TringoApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(601, 777);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lwSensorsInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNewNameOfExperiment);
            this.Controls.Add(this.bCreateExperiment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSelectedExperiment);
            this.Controls.Add(this.lAuthor);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.lName);
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
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Label lAuthor;
        private System.Windows.Forms.ComboBox cbSelectedExperiment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bCreateExperiment;
        private System.Windows.Forms.TextBox tbNewNameOfExperiment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lwSensorsInfo;
        private System.Windows.Forms.Label label3;
    }
}

