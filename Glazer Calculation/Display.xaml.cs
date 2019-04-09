using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Glazer_Calculation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Display : Page
    {
        public Display()
        {
            this.InitializeComponent();

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Glazer glazer = (Glazer)e.Parameter;
            populateTextBoxes(glazer);
        }

        private void populateTextBoxes(Glazer glazer)
        {
            this.lblDate.Text = glazer.Date.ToShortDateString();
            this.lblHeight.Text = glazer.Height.ToString();
            this.lblWidth.Text = glazer.Width.ToString();
            this.lblQuantity.Text = glazer.Quantity.ToString();
            this.lblColor.Text = glazer.Color.ToString();
            this.lblGlassArea.Text = glazer.GlassArea.ToString();
            this.lblWoodLength.Text = glazer.WoodLength.ToString();
        }
    }
}
