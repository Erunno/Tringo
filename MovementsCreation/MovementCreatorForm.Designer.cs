﻿namespace MovementsCreation
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
            this.SuspendLayout();
            // 
            // bAddBorder
            // 
            this.bAddBorder.Enabled = false;
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
            this.flowLayoutPanel.Location = new System.Drawing.Point(242, 12);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1185, 683);
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
            this.lGraphsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGraphsList.Location = new System.Drawing.Point(8, 78);
            this.lGraphsList.Name = "lGraphsList";
            this.lGraphsList.Size = new System.Drawing.Size(216, 22);
            this.lGraphsList.TabIndex = 8;
            this.lGraphsList.Text = "Jméno prohlíženého grafu";
            // 
            // bFinish
            // 
            this.bFinish.Enabled = false;
            this.bFinish.Location = new System.Drawing.Point(12, 573);
            this.bFinish.Name = "bFinish";
            this.bFinish.Size = new System.Drawing.Size(224, 79);
            this.bFinish.TabIndex = 9;
            this.bFinish.Text = "Hotovo";
            this.bFinish.UseVisualStyleBackColor = true;
            this.bFinish.Click += new System.EventHandler(this.bFinish_Click);
            // 
            // MovementCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 707);
            this.Controls.Add(this.bFinish);
            this.Controls.Add(this.lGraphsList);
            this.Controls.Add(this.cbListOfGraphs);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.bModifyMovement);
            this.Controls.Add(this.bRemoveLastBorder);
            this.Controls.Add(this.bAddBorder);
            this.Name = "MovementCreatorForm";
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
    }
}