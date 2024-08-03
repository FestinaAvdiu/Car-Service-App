namespace IDNF6R_Homework
{
    partial class WorksheetForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.registerButton = new System.Windows.Forms.Button();
            this.materialCost = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timeCost = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Material Cost:";
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.IndianRed;
            this.registerButton.Location = new System.Drawing.Point(609, 253);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(108, 40);
            this.registerButton.TabIndex = 2;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // materialCost
            // 
            this.materialCost.AutoSize = true;
            this.materialCost.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialCost.ForeColor = System.Drawing.SystemColors.Highlight;
            this.materialCost.Location = new System.Drawing.Point(181, 261);
            this.materialCost.Name = "materialCost";
            this.materialCost.Size = new System.Drawing.Size(130, 20);
            this.materialCost.TabIndex = 3;
            this.materialCost.Text = "materialCost";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total Time Cost:";
            // 
            // timeCost
            // 
            this.timeCost.AutoSize = true;
            this.timeCost.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeCost.ForeColor = System.Drawing.Color.DarkGreen;
            this.timeCost.Location = new System.Drawing.Point(435, 261);
            this.timeCost.Name = "timeCost";
            this.timeCost.Size = new System.Drawing.Size(94, 20);
            this.timeCost.TabIndex = 5;
            this.timeCost.Text = "timeCost";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(742, 244);
            this.panel1.TabIndex = 6;
            // 
            // WorksheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(746, 305);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.timeCost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.materialCost);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WorksheetForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Worksheet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label materialCost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label timeCost;
        private System.Windows.Forms.Panel panel1;
    }
}