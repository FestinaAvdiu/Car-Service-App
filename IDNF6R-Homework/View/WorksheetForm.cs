using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IDNF6R_Homework
{
    public partial class WorksheetForm : Form
    {
        // Defined an event to notify when a worksheet is registered
        public event EventHandler WorksheetRegistered;

        private int totalMaterialCost = 0;
        private int totalTimeCost = 0;
        private int numberOfRegisteredWorks;
        private int totalInvoicedTime = 0;

        private readonly WorksheetRegistrar worksheetRegistrar;

        private List<Work> worksheets;
        private WorksheetCalculator worksheetCalculator;
        private bool worksheetRegistered = false;


        public WorksheetForm(List<Work> worksheets, WorksheetRegistrar registrar)
        {
            InitializeComponent();
            this.worksheets = worksheets;
            this.worksheetCalculator = new WorksheetCalculator();
            this.worksheetRegistrar = registrar;
            this.FormClosing += WorksheetForm_FormClosing;

            // Populate Panel with worksheets data
            PopulatePanel();

            // Set initial text for Total Material Cost and Total Time Cost
            materialCost.Text = "0";
            timeCost.Text = "0";
        }

        private void PopulatePanel()
        {
            try
            {
                CreateHeaders();

                // Add controls for each work item
                int y = 30; // Starting Y position below the column headers
                foreach (Work work in worksheets)
                {
                    CreateControlsForWork(work, y);
                    y += 30; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while populating Panel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void CreateHeaders()
        {
            // Add column header labels
            Label workTypeLabel = new Label();
            workTypeLabel.Text = "Work Types";
            workTypeLabel.Location = new Point(10, 0);
            workTypeLabel.Font = new Font(workTypeLabel.Font.FontFamily, 10, FontStyle.Bold);
            panel1.Controls.Add(workTypeLabel);

            Label materialCostLabel = new Label();
            materialCostLabel.Text = "Material Cost";
            materialCostLabel.Location = new Point(150, 0);
            materialCostLabel.Font = new Font(materialCostLabel.Font.FontFamily, 10, FontStyle.Bold);
            panel1.Controls.Add(materialCostLabel);

            Label timeLabel = new Label();
            timeLabel.Text = "Time";
            timeLabel.Location = new Point(300, 0);
            timeLabel.Font = new Font(timeLabel.Font.FontFamily, 10, FontStyle.Bold);
            panel1.Controls.Add(timeLabel);

            Label totalCostLabel = new Label();
            totalCostLabel.Text = "Total Cost";
            totalCostLabel.Location = new Point(470, 0);
            totalCostLabel.Font = new Font(totalCostLabel.Font.FontFamily, 10, FontStyle.Bold);
            panel1.Controls.Add(totalCostLabel);
        }

        private void CreateControlsForWork(Work work, int y)
        {
            // Create controls for each work item
            Label nameLabel = new Label();
            nameLabel.Text = work.NameOfWork;
            nameLabel.Location = new Point(10, y);
            nameLabel.AutoSize = false; 
            nameLabel.Width = 130;
            panel1.Controls.Add(nameLabel);

            Label materialLabel = new Label();
            materialLabel.Text = $"{work.MaterialCosts} Ft";
            materialLabel.Location = new Point(150, y);
            panel1.Controls.Add(materialLabel);

            Label timeLabel = new Label();
            // how to display the time for each work
            if (work.Hours > 0)
            {
                timeLabel.Text = $"{work.Hours} h {work.Minutes} min";
            }
            else
            {
                timeLabel.Text = $"{work.Minutes} min";
            }
            timeLabel.Location = new Point(300, y);
            panel1.Controls.Add(timeLabel);

            // Create checkbox for total cost
            CheckBox totalCostCheckBox = new CheckBox();
            totalCostCheckBox.Location = new Point(450, y);
            totalCostCheckBox.Name = work.NameOfWork;
            totalCostCheckBox.CheckedChanged += TotalCostCheckBox_CheckedChanged;
            panel1.Controls.Add(totalCostCheckBox);

            // Set the initial text of the checkbox to empty string
            totalCostCheckBox.Text = "";

        }


        private void UpdateTotalCost()
        {
            try
            {
                int totalMaterialCost = 0;
                int totalTimeCost = 0;
                int totalInvoicedTime = 0;
                int numberOfRegisteredWorks = 0;

                foreach (Control control in panel1.Controls)
                {
                    if (control is CheckBox totalCostCheckBox)
                    {
                        if (totalCostCheckBox.Checked)
                        {
                            // Get the corresponding work item for the checkbox
                            Work work = worksheets.FirstOrDefault(w => w.NameOfWork == totalCostCheckBox.Name);

                            if (work != null)
                            {
                                int individualCost = worksheetCalculator.CalculateIndividualCost(work);

                                // Update the text of the checkbox to show the individual total cost
                                totalCostCheckBox.Text = $" {individualCost} Ft";

                                // Update total material cost, total time cost and related fields
                                totalMaterialCost += work.MaterialCosts;
                                totalTimeCost += worksheetCalculator.CalculateTimeCost(work.RequiredTimeInMinutes);
                                totalInvoicedTime += worksheetCalculator.CalculateInvoicedTime(work.RequiredTimeInMinutes);

                                numberOfRegisteredWorks++;
                            }
                        }
                        else
                        {
                            // If checkbox is unchecked, set the text to empty string
                            totalCostCheckBox.Text = "";
                        }
                    }
                }

                // Update total material cost and total time cost labels 
                materialCost.Text = $"{totalMaterialCost} Ft";
                timeCost.Text = $"{totalTimeCost} Ft";

                this.totalMaterialCost = totalMaterialCost;
                this.totalTimeCost = totalTimeCost;
                this.totalInvoicedTime = totalInvoicedTime;
                this.numberOfRegisteredWorks = numberOfRegisteredWorks;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while updating total cost: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for when we select a checkbox
        private void TotalCostCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Update the values each time a checkbox is selected
            UpdateTotalCost();
        }

   
        // Event handler for the Register button
        private void registerButton_Click(object sender, EventArgs e)
        {
            // Check if any work type is selected
            bool anyWorkSelected = panel1.Controls.OfType<CheckBox>().Any(checkBox => checkBox.Checked);

            if (!anyWorkSelected)
            {
                // Display an error message if no work types are selected
                MessageBox.Show("Please select at least one work type to register!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Proceed with registering the worksheet
                if (worksheets != null && worksheets.Count > 0)
                {

                    // Select the first worksheet
                    Work firstWorksheet = worksheets[0]; 

                    // Register the worksheet 
                    worksheetRegistrar.RegisterWorksheet(firstWorksheet, totalInvoicedTime, totalMaterialCost, totalTimeCost, numberOfRegisteredWorks);

                    // Set the flag to indicate that the worksheet is registered
                    worksheetRegistered = true;

                    // Raise the WorksheetRegistered event
                    WorksheetRegistered?.Invoke(this, EventArgs.Empty);

                    // Close the form
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No worksheets to register!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void WorksheetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if any work type is selected
            bool anyWorkSelected = panel1.Controls.OfType<CheckBox>().Any(checkBox => checkBox.Checked);

            if (!worksheetRegistered && anyWorkSelected)
            {
                DialogResult result = MessageBox.Show("Do you want to register the worksheet?", "Register Worksheet", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (worksheets != null && worksheets.Count > 0)
                    {
                        // Select the first worksheet
                        Work firstWorksheet = worksheets[0];

                        // Register the worksheet 
                        worksheetRegistrar.RegisterWorksheet(firstWorksheet, totalInvoicedTime, totalMaterialCost, totalTimeCost, numberOfRegisteredWorks);

                        // Raise the WorksheetRegistered event
                        WorksheetRegistered?.Invoke(this, EventArgs.Empty);

                    }
                    else
                    {
                        MessageBox.Show("No worksheets to register!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true; 
                    }
                }
                else
                {
                    e.Cancel = true; // Prevent the form from closing if the user chooses not to register the worksheet
                }
            }
            else if (!worksheetRegistered && !anyWorkSelected)
            {
                // If no work type is selected and the worksheet is not registered, ask if the user wants to close the window
                DialogResult result = MessageBox.Show("No work type is selected. Do you want to close the window?", "Close Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Prevent the form from closing if the user chooses not to close the window
                }
            }
        }
    }
}


