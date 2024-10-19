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
    public partial class ViewAllQuotes : Form
    {
        public ViewAllQuotes()
        {
            InitializeComponent();
        }

        private List<DeskQuote> quotes;
        public ViewAllQuotes(List<DeskQuote> quotes)
        {
            InitializeComponent();
            this.quotes = quotes;

        }
        private List<DeskQuote> GetDeskQuotes()
        {
            return this.quotes;
        }
        private void ViewAllQuotes_Load(object sender, EventArgs e)
        {
            var bindingList = new BindingList<DeskQuote>(quotes);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;

        }
    }
}
