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
            this.components = new System.ComponentModel.Container();
            this.bAddBorder = new System.Windows.Forms.Button();
            this.bRemoveLastBorder = new System.Windows.Forms.Button();
            this.bModifyMovement = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cbListOfGraphs = new System.Windows.Forms.ComboBox();
            this.lGraphsList = new System.Windows.Forms.Label();
            this.bFinish = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.graphWidh = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphWidh)).BeginInit();
            this.SuspendLayout();
            // 
            // bAddBorder
            // 
            this.bAddBorder.Enabled = false;
            this.bAddBorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddBorder.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAddBorder.ForeColor = System.Drawing.Color.Silver;
            this.bAddBorder.Location = new System.Drawing.Point(12, 151);
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
            this.bRemoveLastBorder.Location = new System.Drawing.Point(11, 200);
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
            this.bModifyMovement.Location = new System.Drawing.Point(11, 297);
            this.bModifyMovement.Name = "bModifyMovement";
            this.bModifyMovement.Size = new System.Drawing.Size(224, 43);
            this.bModifyMovement.TabIndex = 4;
            this.bModifyMovement.Text = "Označit úsek";
            this.bModifyMovement.UseVisualStyleBackColor = true;
            this.bModifyMovement.Click += new System.EventHandler(this.bModifyMovement_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel.Controls.Add(this.dateTimePicker1);
            this.flowLayoutPanel.Location = new System.Drawing.Point(242, 12);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(854, 578);
            this.flowLayoutPanel.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(8, 21);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // cbListOfGraphs
            // 
            this.cbListOfGraphs.FormattingEnabled = true;
            this.cbListOfGraphs.Location = new System.Drawing.Point(12, 77);
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
            this.lGraphsList.Location = new System.Drawing.Point(8, 50);
            this.lGraphsList.Name = "lGraphsList";
            this.lGraphsList.Size = new System.Drawing.Size(229, 23);
            this.lGraphsList.TabIndex = 8;
            this.lGraphsList.Text = "Jméno prohlíženého grafu";
            // 
            // bFinish
            // 
            this.bFinish.Enabled = false;
            this.bFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bFinish.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bFinish.ForeColor = System.Drawing.Color.Silver;
            this.bFinish.Location = new System.Drawing.Point(11, 511);
            this.bFinish.Name = "bFinish";
            this.bFinish.Size = new System.Drawing.Size(224, 79);
            this.bFinish.TabIndex = 9;
            this.bFinish.Text = "Hotovo";
            this.bFinish.UseVisualStyleBackColor = true;
            this.bFinish.Click += new System.EventHandler(this.bFinish_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // graphWidh
            // 
            this.graphWidh.DecimalPlaces = 2;
            this.graphWidh.Location = new System.Drawing.Point(13, 399);
            this.graphWidh.Name = "graphWidh";
            this.graphWidh.Size = new System.Drawing.Size(224, 21);
            this.graphWidh.TabIndex = 1;
            this.graphWidh.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.graphWidh.ValueChanged += new System.EventHandler(this.graphWidh_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10F);
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(9, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Šířka grafu (relativní k šířce okna)";
            // 
            // MovementCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1108, 602);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bFinish);
            this.Controls.Add(this.graphWidh);
            this.Controls.Add(this.lGraphsList);
            this.Controls.Add(this.cbListOfGraphs);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.bModifyMovement);
            this.Controls.Add(this.bRemoveLastBorder);
            this.Controls.Add(this.bAddBorder);
            this.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MovementCreatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MovementCreatorForm";
            this.SizeChanged += new System.EventHandler(this.MovementCreatorForm_SizeChanged);
            this.flowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphWidh)).EndInit();
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.NumericUpDown graphWidh;
        private System.Windows.Forms.Label label1;
    }
}