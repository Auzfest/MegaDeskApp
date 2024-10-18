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
        private DeskQuote Quote;

        public DisplayQuote(DeskQuote deskQuote)
        {
            InitializeComponent();
            textBox1.Text = deskQuote.GetQuoteDetails();
            Quote = deskQuote;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "quotes.json");
            if (filePath != null){
                Quote.SaveQuoteToFile(filePath, Quote);
            }

        }
    }
}
