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
        private DeskQuote Quote;

        public DisplayQuote(DeskQuote deskQuote)
        {
            InitializeComponent();
            textBox1.Text = deskQuote.GetQuoteDetails();
            Quote = deskQuote;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Quote.SaveQuoteToFile("C:\\Users\\barne\\source\\repos\\MegaDesk1\\MegaDesk1\\quotes.json", Quote);

        }
    }
}
