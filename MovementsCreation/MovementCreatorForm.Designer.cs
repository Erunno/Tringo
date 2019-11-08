namespace MovementsCreation
{
    partial class MovementCreatorForm
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
            this.bAddBorder = new System.Windows.Forms.Button();
            this.bRemoveLastBorder = new System.Windows.Forms.Button();
            this.bModifyMovement = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cbListOfGraphs = new System.Windows.Forms.ComboBox();
            this.lGraphsList = new System.Windows.Forms.Label();
            this.bFinish = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bAddBorder
            // 
            this.bAddBorder.Enabled = false;
            this.bAddBorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddBorder.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAddBorder.ForeColor = System.Drawing.Color.Silver;
            this.bAddBorder.Location = new System.Drawing.Point(12, 226);
            this.bAddBorder.Name = "bAddBorder";
            this.bAddBorder.Size = new System.Drawing.Size(224, 43);
            this.bAddBorder.TabIndex = 2;
            this.bAddBorder.Text = "Přidávat hranice";
            this.bAddBorder.UseVisualStyleBackColor = true;
            this.bAddBorder.Click += new System.EventHandler(this.bAddBorder_Click);
            // 
            // bRemoveLastBorder
            // 
            this.bRemoveLastBorder.Enabled = false;
            this.bRemoveLastBorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRemoveLastBorder.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRemoveLastBorder.ForeColor = System.Drawing.Color.Silver;
            this.bRemoveLastBorder.Location = new System.Drawing.Point(12, 275);
            this.bRemoveLastBorder.Name = "bRemoveLastBorder";
            this.bRemoveLastBorder.Size = new System.Drawing.Size(224, 43);
            this.bRemoveLastBorder.TabIndex = 3;
            this.bRemoveLastBorder.Text = "Odebrat poslední hranci";
            this.bRemoveLastBorder.UseVisualStyleBackColor = true;
            this.bRemoveLastBorder.Click += new System.EventHandler(this.bRemoveLastBorder_Click);
            // 
            // bModifyMovement
            // 
            this.bModifyMovement.Enabled = false;
            this.bModifyMovement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bModifyMovement.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bModifyMovement.ForeColor = System.Drawing.Color.Silver;
            this.bModifyMovement.Location = new System.Drawing.Point(12, 368);
            this.bModifyMovement.Name = "bModifyMovement";
            this.bModifyMovement.Size = new System.Drawing.Size(224, 43);
            this.bModifyMovement.TabIndex = 4;
            this.bModifyMovement.Text = "Modifikovat pohyby";
            this.bModifyMovement.UseVisualStyleBackColor = true;
            this.bModifyMovement.Click += new System.EventHandler(this.bModifyMovement_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel.Location = new System.Drawing.Point(242, 38);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(2048, 1247);
            this.flowLayoutPanel.TabIndex = 6;
            // 
            // cbListOfGraphs
            // 
            this.cbListOfGraphs.FormattingEnabled = true;
            this.cbListOfGraphs.Location = new System.Drawing.Point(12, 103);
            this.cbListOfGraphs.Name = "cbListOfGraphs";
            this.cbListOfGraphs.Size = new System.Drawing.Size(224, 21);
            this.cbListOfGraphs.TabIndex = 7;
            this.cbListOfGraphs.SelectedIndexChanged += new System.EventHandler(this.cbListOfGraphs_SelectedIndexChanged);
            // 
            // lGraphsList
            // 
            this.lGraphsList.AutoSize = true;
            this.lGraphsList.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGraphsList.ForeColor = System.Drawing.Color.Silver;
            this.lGraphsList.Location = new System.Drawing.Point(8, 76);
            this.lGraphsList.Name = "lGraphsList";
            this.lGraphsList.Size = new System.Drawing.Size(233, 23);
            this.lGraphsList.TabIndex = 8;
            this.lGraphsList.Text = "Jméno prohlíženého grafu";
            // 
            // bFinish
            // 
            this.bFinish.Enabled = false;
            this.bFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bFinish.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bFinish.ForeColor = System.Drawing.Color.Silver;
            this.bFinish.Location = new System.Drawing.Point(12, 1206);
            this.bFinish.Name = "bFinish";
            this.bFinish.Size = new System.Drawing.Size(224, 79);
            this.bFinish.TabIndex = 9;
            this.bFinish.Text = "Hotovo";
            this.bFinish.UseVisualStyleBackColor = true;
            this.bFinish.Click += new System.EventHandler(this.bFinish_Click);
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.Maroon;
            this.bClose.FlatAppearance.BorderSize = 0;
            this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClose.ForeColor = System.Drawing.Color.Transparent;
            this.bClose.Location = new System.Drawing.Point(2270, 12);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(20, 20);
            this.bClose.TabIndex = 8;
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // MovementCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(2302, 1297);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.bFinish);
            this.Controls.Add(this.lGraphsList);
            this.Controls.Add(this.cbListOfGraphs);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.bModifyMovement);
            this.Controls.Add(this.bRemoveLastBorder);
            this.Controls.Add(this.bAddBorder);
            this.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MovementCreatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MovementCreatorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bAddBorder;
        private System.Windows.Forms.Button bRemoveLastBorder;
        private System.Windows.Forms.Button bModifyMovement;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.ComboBox cbListOfGraphs;
        private System.Windows.Forms.Label lGraphsList;
        private System.Windows.Forms.Button bFinish;
        private System.Windows.Forms.Button bClose;
    }
}