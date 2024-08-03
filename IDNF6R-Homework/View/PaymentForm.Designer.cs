namespace IDNF6R_Homework
{
    partial class PaymentForm
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
            this.paymentPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // paymentPanel
            // 
            this.paymentPanel.Location = new System.Drawing.Point(0, 2);
            this.paymentPanel.Name = "paymentPanel";
            this.paymentPanel.Size = new System.Drawing.Size(475, 454);
            this.paymentPanel.TabIndex = 0;
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 457);
            this.Controls.Add(this.paymentPanel);
            this.Name = "PaymentForm";
            this.Text = "Payment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PaymentForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel paymentPanel;
    }
}