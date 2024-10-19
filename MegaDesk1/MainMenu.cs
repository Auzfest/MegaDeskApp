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
    public partial class MainMenu : Form
    {

        public List<DeskQuote> listDeskQuote;
        public string jsonPath = @"..\..\quotes.json";
        

        public MainMenu()
        {
            InitializeComponent();

            // read the json file of quotes
            this.UpdateListDeskQuote();
        }

        private void UpdateListDeskQuote()
        {
            listDeskQuote = DeskQuote.GetListDeskQuoteFromJson(this.jsonPath);
        }

        private void AddQuote_Click(object sender, EventArgs e)
        {
            AddQuote addQuoteForm = new AddQuote();
            addQuoteForm.Tag = this;
            addQuoteForm.Show(this);
            Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void viewAllQuotesButton_Click(object sender, EventArgs e)
        {
            this.UpdateListDeskQuote();

            ViewAllQuotes viewAllQuotes = new ViewAllQuotes();
            viewAllQuotes.Tag = this;
            viewAllQuotes.Show();
            this.Hide();
        }
    }
}
