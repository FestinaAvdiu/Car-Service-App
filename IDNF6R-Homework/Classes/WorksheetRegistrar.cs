using IDNF6R_Homework;
using System.Collections.Generic;
using System.Windows.Forms;

public class WorksheetRegistrar
{
    // Automatic properties 
    public List<Work> RegisteredWorksheets { get; private set; }
    public int TotalMaterialCost { get; private set; }
    public int TotalTimeCost { get; private set; }
    public int TotalInvoicedTime { get; private set; }
    public int NumberOfWorksheetsRegistered { get; private set; }
    public int TotalNumberOfRegisteredWorks { get; private set; }

    // Constructor
    public WorksheetRegistrar()
    {
        // Initialized list and other properties
        RegisteredWorksheets = new List<Work>();
        TotalMaterialCost = 0;
        TotalTimeCost = 0;
        TotalInvoicedTime = 0;
        NumberOfWorksheetsRegistered = 0;
        TotalNumberOfRegisteredWorks = 0;
    }

    // Method to register a worksheet
    public void RegisterWorksheet(Work worksheet, int individualInvoicedTime, int individualTotalMaterialCost, int individualTotalTimeCost, int numberOfRegisteredWorks)
    {
        // Update total material cost, time cost, invoiced time (for all the worksheets registered)
        TotalInvoicedTime += individualInvoicedTime;
        TotalMaterialCost += individualTotalMaterialCost;
        TotalTimeCost += individualTotalTimeCost;

        // Add the worksheet to the list of registered worksheets
        RegisteredWorksheets.Add(worksheet);

        // Increment the number of registered worksheets and the total number of registered works
        NumberOfWorksheetsRegistered++;
        TotalNumberOfRegisteredWorks += numberOfRegisteredWorks; 

        // Display registration successful message 
        MessageBox.Show($"Worksheet registered successfully!\n",
                        "Registration Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
    }

    // Method to delete all registered worksheets
    public void DeleteAllWorksheets()
    {
        // Clear all registered worksheets
        RegisteredWorksheets.Clear();

        // Reset other accumulated totals and counts
        TotalMaterialCost = 0;
        TotalTimeCost = 0;
        TotalInvoicedTime = 0;
        NumberOfWorksheetsRegistered = 0;
        TotalNumberOfRegisteredWorks = 0;
    }
}
