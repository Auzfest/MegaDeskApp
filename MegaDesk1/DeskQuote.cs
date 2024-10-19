using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MegaDesk1
{
    public class DeskQuote
    {
        public Desk Desk { get; set; }

        [DisplayName("Customer Name")] // this is for showing in the ViewallQuotes window's dataGridView
        public string Customer { get; set; }

        [DisplayName("Shipping date")]
        public string ShippingDate { get; set; }

        [DisplayName("Desk width")]
        public string Width { get; set; }

        [DisplayName("Desk depth")]
        public string Depth { get; set; }

        [DisplayName("Number of drawers")]
        public string Ndrawers { get; set; }

        [DisplayName("Desk material")]
        public string SurfaceMaterial { get; set; }

        [DisplayName("Date to ship")]
        public int DaysToShip { get; set; }

        [DisplayName("Total Price")]
        public string TotalPrice { get; set; }
       

        private int[,] rushPricesFromFile;

        public DeskQuote(string customer, int daysToShip)
        {
            Customer = customer;
            DaysToShip = daysToShip;

            rushPricesFromFile = this.ReadRushPricesFromFile();
        }

        public DeskQuote CreateQuote(Desk desk)
        {
            Desk = desk;
            TotalPrice = GetTotalPrice(desk).ToString();
            ShippingDate = DateTime.Now.AddDays(DaysToShip).ToString("MMMM dd, yyyy");
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


        public int[,] ReadRushPricesFromFile()
        {
            int[,] priceMatrix = new int[3, 3];

            try
            {
                const string filename = @"..\..\rushOrderPrices.txt";
                string[] lines = File.ReadAllLines(filename);
                priceMatrix[0, 0] = int.Parse(lines[0]);
                priceMatrix[0, 1] = int.Parse(lines[1]);
                priceMatrix[0, 2] = int.Parse(lines[2]);
                priceMatrix[1, 0] = int.Parse(lines[3]);
                priceMatrix[1, 1] = int.Parse(lines[4]);
                priceMatrix[1, 2] = int.Parse(lines[5]);
                priceMatrix[2, 0] = int.Parse(lines[6]);
                priceMatrix[2, 1] = int.Parse(lines[7]);
                priceMatrix[2, 2] = int.Parse(lines[8]);
            }
            catch
            {
                MessageBox.Show("I cannot find the rushOrderPrices.txt file. Sorry.");

                // I will need to fill out with negative values if no file is found!
                // you will need to check if the price orders are negative. If they
                // are negative, the quote will be wrong until the user provides a file
                for (int i = 0; i < 3; i++) {
                    for (int j = 0; j < 3; j++) {
                        priceMatrix[i, j] = -1;
                    }
                }
            }
            return priceMatrix;
        }

        public double GetRushCost(double deskArea)
        {

            if (DaysToShip == 3)
            {
                if (deskArea < 1000) return this.rushPricesFromFile[0, 0];
                if (deskArea >= 1000 && deskArea <= 2000) return this.rushPricesFromFile[0, 1];
                if (deskArea > 2000) return this.rushPricesFromFile[0, 2];
            }
            else if (DaysToShip == 5)
            {
                if (deskArea < 1000) return this.rushPricesFromFile[1, 0];
                if (deskArea >= 1000 && deskArea <= 2000) return this.rushPricesFromFile[1, 1];
                if (deskArea > 2000) return this.rushPricesFromFile[1, 2];
            }
            else if (DaysToShip == 7)
            {
                if (deskArea < 1000) return this.rushPricesFromFile[2, 0];
                if (deskArea >= 1000 && deskArea <= 2000) return this.rushPricesFromFile[2, 1];
                if (deskArea > 2000) return this.rushPricesFromFile[2, 2];
            }
            return 0.00;
        }

        // "static" so that I can use it without instantianting
        static public List<DeskQuote> GetListDeskQuoteFromJson(string filePath) 
        {
            List<DeskQuote> listDeskQuote = new List<DeskQuote>();

            if (File.Exists(filePath))
            {
                string existingJson = File.ReadAllText(filePath);
                listDeskQuote = JsonConvert.DeserializeObject<List<DeskQuote>>(existingJson) ?? new List<DeskQuote>();
            }
            else
            {
                listDeskQuote = new List<DeskQuote>();
            }

            return listDeskQuote;
        }

        public void SaveQuoteToFile(string jsonPath, DeskQuote quoteDetails)
        {
            try
            {

                List<DeskQuote> quotes = DeskQuote.GetListDeskQuoteFromJson(jsonPath);

                quotes.Add(quoteDetails);

                string updatedJson = JsonConvert.SerializeObject(quotes, Newtonsoft.Json.Formatting.Indented,
                new JsonSerializerSettings
                {
                    Converters = new List<JsonConverter> { new StringEnumConverter() } // Convert enums to strings
                });

                File.WriteAllText(jsonPath, updatedJson);

                MessageBox.Show("Quote saved to JSON file successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving quote to JSON file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
