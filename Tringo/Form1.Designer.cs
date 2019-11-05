namespace Tringo
{
    partial class Form1
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
            this.SuspendLayout();
            // 
            // bLoading
            // 
            this.bLoading.Location = new System.Drawing.Point(12, 196);
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
            this.bCreateMovements.Location = new System.Drawing.Point(12, 274);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 810);
            this.Controls.Add(this.bCreateMovements);
            this.Controls.Add(this.bLoading);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bLoading;
        private System.Windows.Forms.Button bCreateMovements;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

