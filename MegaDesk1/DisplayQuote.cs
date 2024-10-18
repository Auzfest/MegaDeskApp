using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk1
{
    public partial class DisplayQuote : Form
    {
        //private DeskQuote Quote;


        public DisplayQuote(DeskQuote deskQuote)
        {
            InitializeComponent();
            //textBox1.Text = deskQuote.GetQuoteDetails();
            //Quote = deskQuote;

            this.CustomerDisplay.Text = deskQuote.Customer;
            this.DateDisplay.Text = deskQuote.ShippingDate.ToString("MMMM dd, yyyy");
            this.DepthDisplay.Text = deskQuote.Desk.GetDepth().ToString();
            this.WidthDisplay.Text = deskQuote.Desk.GetWidth().ToString();
            this.MaterialDisplay.Text = deskQuote.Desk.GetDrawers().ToString();
            this.MaterialDisplay.Text = deskQuote.Desk.GetMaterial().ToString();
            this.RushDisplay.Text = deskQuote.DaysToShip.ToString();
            this.TotalPriceDisplay.Text = deskQuote.TotalPrice.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Quote.SaveQuoteToFile("C:\\Users\\barne\\source\\repos\\MegaDesk1\\MegaDesk1\\quotes.json", Quote);

        }
    }
}
