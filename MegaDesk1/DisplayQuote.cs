using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk1
{
    public partial class DisplayQuote : Form
    {
        private DeskQuote deskQuote;


        public DisplayQuote(DeskQuote deskQuote)
        {
            InitializeComponent();
            //textBox1.Text = deskQuote.GetQuoteDetails();
            this.deskQuote = deskQuote;

            string customer = deskQuote.Customer;
            string now = DateTime.Now.ToString("MMMM dd, yyyy");
            string shippingDate = deskQuote.ShippingDate;
            string width = deskQuote.Desk.Width.ToString();
            string depth = deskQuote.Desk.Depth.ToString();
            string ndrawers = deskQuote.Desk.Drawers.ToString();
            string surfaceMaterial = deskQuote.Desk.Material.ToString();
            string totalPrice = deskQuote.TotalPrice.ToString();

            this.CustomerDisplay.Text = customer;
            this.DateDisplay.Text = now;
            this.WidthDisplay.Text = width;
            this.DepthDisplay.Text = depth;
            this.DrawersDisplay.Text = ndrawers;
            this.MaterialDisplay.Text = surfaceMaterial;
            this.RushDisplay.Text = shippingDate;
            this.TotalPriceDisplay.Text = totalPrice;

            this.deskQuote.Width = width;
            this.deskQuote.Depth = depth;
            this.deskQuote.Ndrawers = ndrawers;
            this.deskQuote.SurfaceMaterial = surfaceMaterial;
            this.deskQuote.TotalPrice = totalPrice;

            //this.CustomerDisplay.Text = deskQuote.Customer;
            //this.DateDisplay.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            //this.DepthDisplay.Text = deskQuote.Desk.GetDepth().ToString();
            //this.WidthDisplay.Text = deskQuote.Desk.GetWidth().ToString();
            //this.MaterialDisplay.Text = deskQuote.Desk.GetDrawers().ToString();
            //this.MaterialDisplay.Text = deskQuote.Desk.GetMaterial().ToString();
            //this.RushDisplay.Text = deskQuote.DaysToShip.ToString();
            //this.TotalPriceDisplay.Text = deskQuote.TotalPrice.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            MainMenu mainMenu = (MainMenu)this.Tag;
            string jsonPath = mainMenu.jsonPath;

            if (jsonPath != null){
                this.deskQuote.SaveQuoteToFile(jsonPath, this.deskQuote);
            }
        }

        private void backToMainMenuButton_Click(object sender, EventArgs e)
        {
            MainMenu viewMainMenu = (MainMenu)this.Tag;
            viewMainMenu.Show();
            this.Close();
        }
    }
}
