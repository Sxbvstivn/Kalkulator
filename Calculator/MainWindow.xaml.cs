using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Content.ToString();

            if (buttonText == "=")
            {
                try
                {
                    string wyrazenie = WyrazenieTextBox.Text;
                    double wynik = Evaluate(wyrazenie);
                    WynikTextBox.Text = wynik.ToString();
                }
                catch (Exception ex)
                {
                    WynikTextBox.Text = "Błąd";
                }
            }
            else if (buttonText == "C")
            {
                WyrazenieTextBox.Text = "";
                WynikTextBox.Text = "";
            }
            else
            {
                WyrazenieTextBox.Text += buttonText;
            }
        }

        public double Evaluate(string expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("expression", string.Empty.GetType(), expression);
            System.Data.DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }

        private void Button_ClickC(object sender, RoutedEventArgs e)
        {
            WyrazenieTextBox.Text = ""; // Wyczyszczenie zawartości TextBox
        }
    }
}