using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Glazer_Calculation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
   
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(1200, 800);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            this.buttonCalculate.IsEnabled = false;
        }

        private void TextBox_OnBeforeTextChanging(TextBox sender,
                                          TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void TextBoxHeight_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (this.textHeight.Text.ToString() == "")
                return;

            double height = ToDouble(this.textHeight);
        

            if (height < 0.75 || height > 3.0)
            {
                this.textHeightError.Text = "The height should be between 0.75 and 3.0";
                this.buttonCalculate.IsEnabled = false;
            }
            else
            {
                this.textHeightError.Text = "";
                this.buttonCalculate.IsEnabled = this.textWidth.Text.ToString() != "";
            }
            
        }

        private void TextBoxWidth_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (this.textWidth.Text.ToString() == "")
                return;

            double width = ToDouble(this.textWidth);

            if (width < 0.5 || width > 5.0)
            {
                this.textWidthError.Text = "The width should be between 0.5 and 5.0";
                this.buttonCalculate.IsEnabled = false;
            }
            else
            {
                this.textWidthError.Text = "";
                this.buttonCalculate.IsEnabled = this.textHeight.Text.ToString() != ""; ;
            }

        }

        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {

            double width = ToDouble(this.textWidth);
            double height = ToDouble(this.textHeight);

            Glazer glazer = new Glazer()
            {
                Height = ToDouble(this.textWidth),
                Width = ToDouble(this.textHeight),
                WoodLength = 2 * (width + height) * 3.25,
                GlassArea = 2 * (width + height),
                Color = this.ComboBoxColors.SelectedValue.ToString(),
                Date = DateTime.Today,
                Quantity = Int32.Parse(this.sliderQuantity.Value.ToString())
            };
            
            Frame.Navigate(typeof(Display), glazer);
        }

        private double ToDouble(TextBox value)
        {
            return double.Parse(value.Text.ToString());
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}

