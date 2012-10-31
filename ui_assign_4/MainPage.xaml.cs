﻿using System;
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
using Windows.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ui_assign_4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            GridValues = new NumberBox[81];

            for (int i = 0; i < 81; i++)
            {
                var a = new NumberBox();

                mainGrid.Children.Add(a);
                Grid.SetRow(a, (int)i / 9);
                Grid.SetColumn(a, i % 9);
                a.TextColor = Normal;
                a.Selected += (n, e) =>
                {
                    if (!n.Locked)
                    {
                        if (Selected != null && Selected.Number == 0)
                        {
                            Selected.Number = 0;
                        }

                        Selected = n;
                        foreach(var b in GridValues)
                        {
                            b.TextColor = b == n ? Highlight : b.Locked ? Locked : Normal;
                        }
                    }
                };

                GridValues[i] = a;
            }

            numPad.ButtonPressed += (b, e) =>
            {
                if (Selected != null)
                {
                    Selected.Number = e.Number;
                    Selected = null;
                    ResetColors();
                }
            };

            LoadGame("005314000400580100170090048030970060600000009040036010360040085004058003000263400");
        }

        private static Color Locked = Colors.Black;
        private static Color Conflict = Colors.Red;
        private static Color Highlight = Colors.Blue;
        private static Color Normal = Colors.DarkGray;

        private void ResetColors()
        {
            // TODO: detect conflicts...

            foreach (var b in GridValues)
            {
                b.TextColor = b.Locked ? Locked: Normal;
            }
        }

        private NumberBox[] GridValues { get; set; }

        private NumberBox Selected { get; set; }

        private void LoadGame(string game)
        {
            for (int i = 0; i < 81; i++)
            {
                var n = int.Parse(game.Substring(i, 1));
                GridValues[i].Number = n;
                GridValues[i].Locked = n > 0;
                GridValues[i].TextColor = n > 0 ? Locked : Normal;
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void mainGrid_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            var grid = sender as Grid;
            if (grid.ActualHeight> grid.ActualWidth)
            {
                grid.Height = grid.Width;
            }
            else if (grid.ActualHeight < grid.ActualWidth)
            {
                grid.Width = grid.Height;
            }
        }
    }
}
