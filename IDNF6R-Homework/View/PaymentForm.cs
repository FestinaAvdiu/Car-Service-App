using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace IDNF6R_Homework
{
    public partial class PaymentForm : Form
    {
        private readonly WorksheetRegistrar worksheetRegistrar;

        // Defined an event to notify when the payment process is completed
        public event EventHandler PaymentCompleted;

        public PaymentForm(WorksheetRegistrar registrar)
        {
            InitializeComponent();
            this.worksheetRegistrar = registrar;
            this.Load += PaymentForm_Load;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            // Populate the data in the panel when the form loads
            PopulateData();
        }

        private void PopulateData()
        {
            // Clear existing controls from Payment Panel 
            paymentPanel.Controls.Clear();

            int labelHeight = 30; 
            int padding = 20; 
            int startY = padding; 

            // The data values
            int totalMaterialCost = worksheetRegistrar.TotalMaterialCost;
            int totalTimeCost = worksheetRegistrar.TotalTimeCost;
            int totalInvoicedTime = worksheetRegistrar.TotalInvoicedTime;
            int numberOfWorksheetsRegistered = worksheetRegistrar.NumberOfWorksheetsRegistered;
            int totalNumberOfRegisteredWorks = worksheetRegistrar.TotalNumberOfRegisteredWorks;

            WorksheetCalculator worksheetCalculator = new WorksheetCalculator();

            // Total amount to pay
            int totalAmountToPay = worksheetCalculator.CalculateTotalAmountToPay(totalMaterialCost, totalTimeCost);

            // Formatted invoiced time
            string formattedInvoicedTime = worksheetCalculator.FormatInvoicedTime(totalInvoicedTime);

            // Define the labels and their corresponding data
            var dataItems = new[]
            {
                ("Worksheet Count:", $"{numberOfWorksheetsRegistered} db"),
                ("Work Count:", $"{totalNumberOfRegisteredWorks} db"),
                ("Material Cost:", $"{totalMaterialCost} Ft"),
                ("Time Cost:", $"{totalTimeCost} Ft"),
                ("Invoiced Time:", $"{formattedInvoicedTime}"),
                ("Total Amount:", $"{totalAmountToPay} Ft")
            };

            foreach (var (labelText, dataText) in dataItems)
            {
                // Create label for the data name column
                Label nameLabel = new Label();
                nameLabel.Text = labelText;
                nameLabel.AutoSize = true;
                nameLabel.Location = new Point(50, startY); 
                nameLabel.TextAlign = ContentAlignment.MiddleRight; 
                nameLabel.Font = new Font(nameLabel.Font.FontFamily, 10, FontStyle.Bold);
                paymentPanel.Controls.Add(nameLabel);

                // Create label for the data value column
                Label dataLabel = new Label();
                dataLabel.Text = dataText;
                dataLabel.AutoSize = true;
                dataLabel.Location = new Point(200, startY); 
                dataLabel.Font = new Font(dataLabel.Font.FontFamily, 10, FontStyle.Regular); 
                dataLabel.ForeColor = Color.DarkBlue;
                paymentPanel.Controls.Add(dataLabel);

                // Increment the Y position for the next label
                startY += labelHeight + padding;
            }

            // Create the PAY button
            Button payButton = new Button();
            payButton.Text = "PAY";
            payButton.Location = new Point(125, startY);
            payButton.Size = new Size(100, 30);
            payButton.Click += PayButton_Click;
            paymentPanel.Controls.Add(payButton);
        }

        private void PayButton_Click(object sender, EventArgs e)
        {
            int totalMaterialCost = worksheetRegistrar.TotalMaterialCost;
            int totalTimeCost = worksheetRegistrar.TotalTimeCost;
            int totalAmountToPay = totalMaterialCost + totalTimeCost;

            // Check if any payment is needed
            if (totalAmountToPay == 0)
            {
                MessageBox.Show("There are no payments to be made.", "No Payment Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

                // Raise the PaymentCompleted event when the form is closing (payment process is completed even though no payment was needed to be done)
                PaymentCompleted?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                // Delete all registered worksheets from WorksheetRegistrar
                worksheetRegistrar.DeleteAllWorksheets();

                MessageBox.Show("Payment successfully done.", "Payment Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

                // Raise the PaymentCompleted event when the form is closing
                PaymentCompleted?.Invoke(this, EventArgs.Empty);
            }

        }

        private void PaymentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Calculate the total amount to pay
                int totalMaterialCost = worksheetRegistrar.TotalMaterialCost;
                int totalTimeCost = worksheetRegistrar.TotalTimeCost;
                int totalAmountToPay = totalMaterialCost + totalTimeCost;

                // Check if there is an amount to pay
                if (totalAmountToPay != 0)
                {
                    // Ask the user if they want to pay
                    DialogResult result = MessageBox.Show("Do you want to make the payment?", "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // If the user wants to pay, perform payment process
                    if (result == DialogResult.Yes)
                    {
                        worksheetRegistrar.DeleteAllWorksheets();
                        MessageBox.Show("Payment successfully done.", "Payment Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        worksheetRegistrar.DeleteAllWorksheets();
                    }

                }

                // Raise the PaymentCompleted event when the form is closing
                PaymentCompleted?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
