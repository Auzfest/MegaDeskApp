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
    public partial class AddQuote : Form
    {
        private Desk newDesk;
        private DeskQuote newQuote;

        public AddQuote()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();
        }

        // width validation
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            string input = textBox1.Text;
            if (double.TryParse(input, out double width))
            {
                if (width < 24 || width > 96)
                {
                    MessageBox.Show("Please enter a width between 24 and 96 inches.", "Invalid Width", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Clear();
            }
        }

        // depth validation
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Prevent the input if it's not a valid key
                MessageBox.Show("Only numeric input is allowed.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            string input = textBox2.Text;
            if (double.TryParse(input, out double depth))
            {
                if (depth < 12 || depth > 48)
                {
                    MessageBox.Show("Please enter a depth between 12 and 48 inches.", "Invalid Depth", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Clear();
            }
        }

        // drawers validation
        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            string input = textBox3.Text;
            if (int.TryParse(input, out int drawers))
            {
                if (drawers < 0 || drawers > 7)
                {
                    MessageBox.Show("Please enter a whole number between 0 and 7.", "Invalid Drawers", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Clear();
            }
        }

        // material selection from listbox
        private string GetSelectedMaterial()
        {
            if (comboBox1.SelectedItem != null)
            {
                string material = comboBox1.SelectedItem.ToString();
                return comboBox1.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Please select a material.", "Invalid Material", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }
        }

        // Rush order selection from listbox
        private int GetSelectedRushOrder()
        {
            if (listBox2.SelectedItem != null && int.TryParse(listBox2.SelectedItem.ToString(), out int result))
            {
                return result;
            }
            else
            {
                MessageBox.Show("Please select a rush order.", "Invalid order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        //add quote
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text) &&
            double.TryParse(textBox1.Text, out double width) && width >= 24 && width <= 96 &&
            double.TryParse(textBox2.Text, out double depth) && depth >= 12 && depth <= 48 &&
            int.TryParse(textBox3.Text, out int drawers) && drawers >= 0 && drawers <= 7)
            {
                string material = GetSelectedMaterial();
                int daysToShip = GetSelectedRushOrder();
                if (!string.IsNullOrEmpty(material) && daysToShip > 0)
                {
                    string customer = textBox4.Text;
                    newDesk = new Desk(width, depth, drawers, material);
                    newQuote = new DeskQuote(customer, daysToShip);
                    var completeQuote = newQuote.CreateQuote(newDesk);
                    DisplayQuote displayQuoteForm = new DisplayQuote(completeQuote);
                    displayQuoteForm.Tag = this;
                    displayQuoteForm.Show(this);
                    Hide();
                }
            }
            else
            {
                MessageBox.Show("Please ensure all inputs are valid before submitting.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //customer name validation
        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                string name = textBox4.Text.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }

                if (name.Any(char.IsDigit) || name.Any(ch => !char.IsLetter(ch) && !char.IsWhiteSpace(ch)))
                {
                    throw new FormatException("Name cannot contain numbers or special characters.");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; 
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void AddQuote_Load(object sender, EventArgs e)
        {
            List<DesktopMaterial> materials = Enum.GetValues(typeof(DesktopMaterial))
                                      .Cast<DesktopMaterial>()
                                      .ToList();
            comboBox1.DataSource = materials;
        }
    }
}
