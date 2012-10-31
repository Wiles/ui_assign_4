using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace ui_assign_4
{
    public delegate void NumberSelected(object sender, NumberSelectedEventArgs e);

    public class NumberSelectedEventArgs : EventArgs
    {
        public int Number { get; set; }
    }

    public sealed partial class NumPad : UserControl
    {
        public NumPad()
        {
            this.InitializeComponent();
        }

        public event NumberSelected ButtonPressed;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var text = (((sender as Button).Content as Viewbox).Child as TextBlock).Text;

            int i;

            if (int.TryParse(text, out i))
            {
                TriggerButton(i);
            }
            else
            {
                TriggerButton(0);
            }
        }

        private void TriggerButton(int i)
        {
            if (ButtonPressed != null)
            {
                ButtonPressed(this, new NumberSelectedEventArgs() { Number = i });
            }
        }
    }
}
