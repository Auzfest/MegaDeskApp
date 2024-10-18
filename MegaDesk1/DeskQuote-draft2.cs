using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MegaDesk1
{
    public class DeskQuote
    {
        public Desk Desk { get; set; }
        public string Customer { get; set; }
        public double TotalPrice { get; set; }
        public DateTime ShippingDate { get; set; }
        public int DaysToShip { get; set; }

        // Array to store rush order prices
        private int[,] rushOrderPrices = new int[3, 3];

        public DeskQuote(string customer, int daysToShip)
        {
            Customer = customer;
            DaysToShip = daysToShip;
            GetRushOrderPrices();  // Call method to load rush prices from file
        }

        // Method to read rush order prices from file and populate the 2D array
        public void GetRushOrderPrices()
        {
            try
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines("rushOrderPrices.txt");
                
                // Populate the 2D array (3x3 matrix)
                int index = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        rushOrderPrices[i, j] = int.Parse(lines[index]);
                        index++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading rush order prices: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            double materialCost = GetMaterialCost(desk.GetMaterial());
            double rushCost = GetRushCost(deskArea);

            return basePrice + areaCost + drawerCost + materialCost + rushCost;
        }

        // Method to calculate rush order cost based on area and days to ship
        public double GetRushCost(double deskArea)
        {
            if (DaysToShip == 14) return 0.0;  // No rush

            int sizeIndex = 0;
            if (deskArea >= 1000 && deskArea <= 2000) sizeIndex = 1;
            else if (deskArea > 2000) sizeIndex = 2;

            int daysIndex = (DaysToShip == 3) ? 0 : (DaysToShip == 5) ? 1 : 2;

            return rushOrderPrices[daysIndex, sizeIndex];
        }

        // Utility method to get material cost
        private double GetMaterialCost(string material)
        {
            switch (material)
            {
                case "Oak":
                    return 200.00;
                case "Laminate":
                    return 100.00;
                case "Pine":
                    return 50.00;
                case "Rosewood":
                    return 300.00;
                case "Veneer":
                    return 125.00;
                default:
                    return 0.00;
            }
        }

        // Get the details of the quote in a formatted string
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

        // Method to save the quote to a JSON file
        public void SaveQuoteToFile(string filePath)
        {
            try
            {
                List<DeskQuote> quotes;

                // Check if file exists
                if (File.Exists(filePath))
                {
                    // Read existing quotes from file
                    string existingJson = File.ReadAllText(filePath);
                    quotes = JsonConvert.DeserializeObject<List<DeskQuote>>(existingJson) ?? new List<DeskQuote>();
                }
                else
                {
                    quotes = new List<DeskQuote>();
                }

                // Add the current quote to the list
                quotes.Add(this);

                // Save the updated list back to the file
                string updatedJson = JsonConvert.SerializeObject(quotes, Formatting.Indented);
                File.WriteAllText(filePath, updatedJson);

                MessageBox.Show("Quote saved to JSON file successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving quote to JSON file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
