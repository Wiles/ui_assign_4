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
    public sealed partial class WinPanel : Page
    {
        public WinPanel()
        {
            this.InitializeComponent();

            var bounds = Window.Current.Bounds;
            this.Root.Width = bounds.Width;
            this.Root.Height = bounds.Height;
        }

        public string DisplayName
        {
            get
            {
                return name.Text;
            }
            set
            {
                name.Text = value;
            }
        }

        public string Time
        {
            get
            {
                return time.Text;
            }
            set
            {
                time.Text = value;
            }
        }

        public event EventHandler CloseRequested;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.CloseRequested != null)
            {
                this.CloseRequested(this, EventArgs.Empty);
            }
        }
    }
}
