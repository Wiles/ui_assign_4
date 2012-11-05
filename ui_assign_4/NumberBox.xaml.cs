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
    public delegate void NumberBoxClicked(NumberBox sender, EventArgs e);

    public sealed partial class NumberBox : UserControl
    {
        public NumberBox()
        {
            this.InitializeComponent();
            TextColor = Windows.UI.Color.FromArgb(255, 0, 0, 0);
        }

        public NumberBox(int row, int column): this()
        {
            this.Row = row;
            this.Column = column;
        }

        private Windows.UI.Color textColor { get; set;}
        public Windows.UI.Color TextColor
        {
            get
            {
                return textColor;
            }
            set
            {
                textColor = value;
                num.Foreground = new SolidColorBrush(value);
            }
        }

        private int number =  0;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value > 9 || value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                number = value;
                num.Text = number.ToString();
                if (number == 0)
                {
                    num.Opacity = 0;
                }
                else
                {
                    num.Opacity = 1;
                }
            }
        }

        private int conflicts;
        public bool HasConflict
        {
            get
            {
                return conflicts > 0;
            }
        }

        public void AddConflict()
        {
            conflicts++;
        }

        public void ClearConflicts()
        {
            conflicts = 0;
        }

        public bool Locked { get; set; }

        public bool Duplicate { get; set; }

        public event NumberBoxClicked Selected;
        public int Row;
        public int Column;

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            HighlightSelection();
        }

        public void HighlightSelection()
        {
            if (Selected != null)
            {
                if (num.Text == "0")
                {
                    num.Text = "_";
                    num.Opacity = 1;
                }

                Selected(this, new EventArgs());
            }
        }

    }
}
