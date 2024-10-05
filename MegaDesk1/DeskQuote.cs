using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk1
{
    public class DeskQuote
    {
        public Desk Desk { get; set; }
        public string Customer { get; set; }
        public double TotalPrice { get; set; }
        public DateTime ShippingDate { get; set; }
        public int DaysToShip { get; set; }

        public DeskQuote(string customer, int daysToShip)
        {
            Customer = customer;
            DaysToShip = daysToShip;
        }

        public DeskQuote CreateQuote(Desk desk)
        {
            Desk = desk;
            TotalPrice = GetTotalPrice(desk);
            ShippingDate = DateTime.Now.AddDays(DaysToShip);
            return this;
        }

        public double GetTotalPrice(Desk desk)
        {
            double basePrice = 200.00;
            double deskArea = desk.GetWidth() * desk.GetDepth();

            double areaCost = (deskArea > 1000) ? (deskArea - 1000) : 0;

            double drawerCost = desk.GetDrawers() * 50;

            double materialCost = 0.0;

            if (desk.GetMaterial() == "Oak")
            {
                materialCost = 200.00;
            }
            else if (desk.GetMaterial() == "Laminate")
            {
                materialCost = 100.00;
            }
            else if (desk.GetMaterial() == "Pine")
            {
                materialCost = 50.00;
            }
            else if (desk.GetMaterial() == "Rosewood")
            {
                materialCost = 300.00;
            }
            else if (desk.GetMaterial() == "Veneer")
            {
                materialCost = 125.00;
            }

            double rushCost = GetRushCost(deskArea);

            return basePrice + areaCost + drawerCost + materialCost + rushCost;
        }

        public double GetRushCost(double deskArea)
        {
            if (DaysToShip == 3)
            {
                if (deskArea < 1000) return 60.00;
                if (deskArea >= 1000 && deskArea <= 2000) return 70.00;
                if (deskArea > 2000) return 80.00;
            }
            else if (DaysToShip == 5)
            {
                if (deskArea < 1000) return 40.00;
                if (deskArea >= 1000 && deskArea <= 2000) return 50.00;
                if (deskArea > 2000) return 60.00;
            }
            else if (DaysToShip == 7)
            {
                if (deskArea < 1000) return 30.00;
                if (deskArea >= 1000 && deskArea <= 2000) return 35.00;
                if (deskArea > 2000) return 40.00;
            }
            return 0.00;
        }

        public string GetCustomer()
        {
            return Customer;
        }

        public DateTime GetShippingDate()
        {
            return ShippingDate;
        }

        public string GetQuoteDetails()
        {
            return $"Customer: {Customer}\n" +
                   $"Desk Material: {Desk.Material}\n" +
                   $"Desk Width: {Desk.Width} inches\n" +
                   $"Desk Depth: {Desk.Depth} inches\n" +
                   $"Number of Drawers: {Desk.Drawers}\n" +
                   $"Total Price: ${TotalPrice}\n" +
                   $"Shipping Date: {ShippingDate.ToShortDateString()}\n";
        }

        public void SaveQuoteToFile(string filePath, DeskQuote quoteDetails)
        {
            try
            {
                string details = GetQuoteDetails();
                File.WriteAllText(filePath, details);
                MessageBox.Show("Quote saved to file successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving quote to file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
