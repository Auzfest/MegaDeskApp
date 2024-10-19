using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MegaDesk1
{
    public partial class SearchQuotes : Form
    {
        public List<DeskQuote> filteredListDeskQuotes;

        public SearchQuotes()
        {
            InitializeComponent();
        }

        private void SearchQuotes_Load(object sender, EventArgs e)
        {


            List<DesktopMaterial> materials = Enum.GetValues(typeof(DesktopMaterial))
                                      .Cast<DesktopMaterial>()
                                      .ToList();
            comboBox1.DataSource = materials;


        }

        private void backToMainMenuButton_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = (MainMenu)this.Tag;
            mainMenu.Show();
            this.Close();
        }

        private void searchQuotesButton_Click(object sender, EventArgs e)
        {
            string selectedMaterial = comboBox1.SelectedItem.ToString();

            // reset filtered list
            this.filteredListDeskQuotes = new List<DeskQuote>();

            // retrive entire list from MainMenu (from Json file)
            MainMenu mainMenu = (MainMenu)this.Tag;
            List<DeskQuote> entireListDeskQuotes = mainMenu.listDeskQuote;


            // filter
            foreach(DeskQuote deskQuote in entireListDeskQuotes)
            {
                if (selectedMaterial == deskQuote.SurfaceMaterial) {
                   this.filteredListDeskQuotes.Add(deskQuote); 
                }
            }

            // Show into the screen
            this.dataGridView1.DataSource = this.filteredListDeskQuotes;

            // Don't show a nested dictionary! it won't work
            this.dataGridView1.Columns["Desk"].Visible = false;

        }
    }
}
