using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MegaDesk1
{
    public partial class ViewAllQuotes : Form
    {
        public ViewAllQuotes()
        {
            InitializeComponent();
            LoadQuotes();
        }

        private void LoadQuotes()
        {
            try
            {
                // Path to the saved quotes JSON file
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "quotes.json");

                if (File.Exists(filePath))
                {
                    // Read all the quotes from the JSON file
                    string json = File.ReadAllText(filePath);
                    List<DeskQuote> quotes = JsonConvert.DeserializeObject<List<DeskQuote>>(json);

                    // Bind the list of quotes to the DataGridView
                    dataGridView1.DataSource = quotes;
                }
                else
                {
                    MessageBox.Show("No saved quotes found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading quotes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
