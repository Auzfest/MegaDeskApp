using System;
using System.Windows.Forms;

namespace MegaDesk1
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
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

        private void ViewQuotes_Click(object sender, EventArgs e)
        {
            ViewAllQuotes viewAllQuotesForm = new ViewAllQuotes();
            viewAllQuotesForm.Tag = this;
            viewAllQuotesForm.Show(this);
            Hide();
        }

        private void ViewQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void AddQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
