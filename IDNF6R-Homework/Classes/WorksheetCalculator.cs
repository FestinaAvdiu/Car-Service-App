using IDNF6R_Homework;
using System.Collections.Generic;

public class WorksheetCalculator
{
    // Method to calculate the individual "total cost" of a work
    public int CalculateIndividualCost(Work work)
    {
        int timeCost = CalculateTimeCost(work.RequiredTimeInMinutes);
        return work.MaterialCosts + timeCost;
    }

    // Method to calculate the "individual" time cost of 1 work type based on the required time in minutes
    public int CalculateTimeCost(int requiredTime)
    {
        int costPerHour = 15000; // Cost for 1 hour invoiced
        int costPer30Minutes = 7500; // Cost for 30 minutes invoiced

        int hours = requiredTime / 60; // Convert minutes to hours
        int minutes = requiredTime % 60; // Remaining minutes

        if (hours == 0 && minutes <= 30)
        {
            // Time <= 30 min is invoiced as 30 min's price, price = 7500 Ft
            return costPer30Minutes;
        }
        else if (hours == 0 && minutes > 30)
        {
            // More than 30 min but less than 1 hour, is invoiced as 1 hour's price, charge the cost for 1 hour = 15000 Ft
            return costPerHour;
        }
        else
        {
            // More than 1 hour, calculate based on the hourly rate
            return costPerHour * hours;
        }
    }

    public int CalculateInvoicedTime(int requiredTimeInMinutes)
    {
        // Calculate invoiced time for the given required time in minutes
        int invoicedTime = 0;

        // If required time is less than or equal to 30 minutes, invoice as 30 minutes
        if (requiredTimeInMinutes <= 30)
        {
            invoicedTime = 30;
        }
        // If required time is more than 30 minutes, round up to the nearest hour
        else
        {
            int hours = requiredTimeInMinutes / 60;
            int remainingMinutes = requiredTimeInMinutes % 60;

            if (remainingMinutes > 0)
            {
                hours += 1;
                invoicedTime = hours * 60; // Invoiced time in minutes
            }
            else
            {
                invoicedTime = requiredTimeInMinutes; // Invoiced time in minutes
            }
        }

        return invoicedTime;
    }

    // The total amount to pay for the worksheet
    public int CalculateTotalAmountToPay(int totalMaterialCost, int totalTimeCost)
    {
        return totalMaterialCost + totalTimeCost;
    }

    // Formatting the invoiced time to display based on hours and minutes
    public string FormatInvoicedTime(int totalInvoicedTime)
    {
        int totalHours = totalInvoicedTime / 60;
        int totalMinutes = totalInvoicedTime % 60;

        // Logic how to display the time 
        if (totalHours > 0)
        {
            return $"{totalHours} h {totalMinutes} min";
        }
        else
        {
            return $"{totalMinutes} min";
        }
    }

}
