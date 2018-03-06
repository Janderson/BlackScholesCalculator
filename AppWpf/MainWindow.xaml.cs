using Calculations;
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

namespace AppWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        public void Calculate()
        {
            var Calculator = new BlackScholes();

            var Values = new CalculatorValues
            {
                UnderlinePrice = Convert.ToDouble(TextBoxStockPrice.Text),
                RiskFreeRate = Convert.ToDouble(TextBoxRiskRate.Text) / 100,
                Volatility = Convert.ToDouble(TextBoxVolatility.Text) / 100,
                Strike = Convert.ToDouble(TextBoxStrikeOption.Text),
                QtdDaysExpire = Convert.ToDouble(TextBoxTimeToExpire.Text),
                Dividend = 0
            };


            TextBoxBSCallPrice.Content = Calculator.CallPremium(Values).ToString("0.000");
            TextBoxBSPutPrice.Content = Calculator.PutPremium(Values).ToString("0.000");

        }
        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_KeyDown(object sender, KeyEventArgs KeyEvent)
        {
            if (KeyEvent.Key == Key.Enter)
            {
                Calculate();
            }
        }
    }
}
