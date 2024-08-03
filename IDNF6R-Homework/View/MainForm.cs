using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IDNF6R_Homework
{
    public partial class MainForm : Form
    {
        private List<Work> worksheets = new List<Work>();
        private WorksheetRegistrar worksheetRegistrar;

        // Defined fields to track the application state
        private bool fileLoaded = false;
        private bool worksheetRegistered = false;

        //Constructor 
        public MainForm()
        {
            InitializeComponent();

            // Disabled the Worksheet and Payment menu items initially (can't use menu items when their function isn't available yet)
            worksheetToolStripMenuItem.Enabled = false;
            paymentToolStripMenuItem.Enabled = false;

            worksheetRegistrar = new WorksheetRegistrar();
        }

        // Event handler for the Load File menu item
        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Title = "Browse Text Files";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // Create an instance of FileLoader
                    FileLoader fileLoader = new FileLoader();

                    // Load works from the file using FileLoader
                    List<Work> loadedWorks = fileLoader.LoadFile(filePath);

                    // Clear existing worksheets
                    worksheets.Clear();

                    // Add the loaded works to the worksheets list
                    worksheets.AddRange(loadedWorks);

                    // Set the fileLoaded flag to true
                    fileLoaded = true;

                }
                catch (Exception ex)
                {
                    // Handle exceptions related to file loading
                    MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Enable the Worksheet menu item after file was loaded successfully
            if(fileLoaded == true)
            {
                worksheetToolStripMenuItem.Enabled = true;
            }
        }

        private void worksheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if worksheets list is empty
            if (worksheets.Count == 0)
            {
                MessageBox.Show("Please load a file first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the event handler

            }

            // Open the worksheet form
            WorksheetForm worksheetForm = new WorksheetForm(worksheets, worksheetRegistrar);
            worksheetForm.Show();

            // Subscribe to the WorksheetRegistered event
            worksheetForm.WorksheetRegistered += WorksheetForm_WorksheetRegistered;

        }

        // Event when the worksheet is registered, so we can enable the Payment menu item
        private void WorksheetForm_WorksheetRegistered(object sender, EventArgs e)
        {
            // Set the flag to true when a worksheet is registered
            worksheetRegistered = true;

            // Enable the Payment menu item
            paymentToolStripMenuItem.Enabled = true;
        }

        // Event handler for the Payment menu item 
        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm(worksheetRegistrar);
            paymentForm.Show();

            // Subscribe to the PaymentCompleted event
            paymentForm.PaymentCompleted += PaymentForm_PaymentCompleted;
            
        }

        // Event when the payment is completed, so we disable the Payment menu item
        private void PaymentForm_PaymentCompleted(object sender, EventArgs e)
        {
            // Reset the flag when the payment process is completed
            worksheetRegistered = false;

            // Disable the Payment menu item
            paymentToolStripMenuItem.Enabled = false;
        }

        // Event handler for the About menu item
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        // Event handler for the Exit menu item
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show a message box with a question and Yes/No buttons
            DialogResult result = MessageBox.Show("Are you sure you want to quit?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                // If the user clicks "Yes", close the application
                Application.Exit();
            }
            // If the user clicks "No", application will not exit
        }

        // Event handler if the user closes the Main Form 
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the form is being closed by the user
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Show a message box with a question and Yes/No buttons
                DialogResult result = MessageBox.Show("Are you sure you want to quit?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check the user's response
                if (result == DialogResult.No)
                {
                    // If the user clicks "No", cancel the form closing event
                    e.Cancel = true;
                }
            }
        }
    }
}