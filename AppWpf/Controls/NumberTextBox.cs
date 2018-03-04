using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Input;


namespace AppWpf.Controls
{
    class NumberTextBox : TextBox
    {

        public double Number
        {
            get { return ToDouble(); }
            set { }
        }
        public NumberTextBox() : base()
        {
            //this.DefaultStyleKey = typeof(NumberTextBox);
            this.PreviewTextInput += NumberValidationTextBox;

        }


        public double ToDouble()
        {
            if (this.Text == "")
            {
                return 0;
            }

            return Convert.ToDouble(this.Text);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.,\\-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
