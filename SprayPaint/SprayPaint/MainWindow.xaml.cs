using Microsoft.Win32;
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

namespace SprayPaint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /* Welcome styling */
            // Set the font size
            WelcomeHolder.FontSize = 30;

            // Center allign the Welcome text
            WelcomeHolder.HorizontalAlignment = HorizontalAlignment.Center;
            WelcomeHolder.VerticalAlignment = VerticalAlignment.Center;

            // Set the content
            WelcomeHolder.Text = "Welcome to Spray Painter";

            /* Creating/Loading styling */
            // Set the font size
            NewHolder.FontSize = 20;
            LoadHolder.FontSize = 20;

            // Center allign the text and button
            NewHolder.HorizontalAlignment = HorizontalAlignment.Center;
            LoadHolder.HorizontalAlignment = HorizontalAlignment.Center;

            // Set the content
            NewHolder.Text = "New file";
            LoadHolder.Text = "Load file";
        }

        //Button function for load button
        private void btnLoadClick(object sender, RoutedEventArgs e)
        {
            // Create new window object
            Window1 LoadWindow = new Window1();

            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Title = "Select a picture";
            dialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
                BitmapImage loadedImg = new BitmapImage(new Uri(filename));

                // Load source into xaml
                LoadWindow.imgPhoto.Source = loadedImg;
                LoadWindow.Title = "Spray Painter - Edit - " + filename;

                /* Idea is to see if loaded Image size is greater than our current screen size, 
                 * if yes then it should auto rescale the window size. I do not want to do that
                 * for smaller images because then the brush ribbon would not fit. However, bitmap
                 * images cannot figure out size at runtime, so need async thread to decode size at
                 * runtime so this does not work. */
                
                if (loadedImg.PixelHeight > 700 || loadedImg.PixelWidth > 1000)
                {
                    // Scale the content to change window size automatically to fill
                    this.SizeToContent = SizeToContent.WidthAndHeight;
                }

                // Hide current window visibility
                this.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Unable to load file, try again.", "Load error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LoadWindow.Show();
        }
        private void btnNewClick(object sender, RoutedEventArgs e)
        {
            // Create new window object
            Window1 LoadWindow = new Window1();

            
            BitmapImage loadedImg = new BitmapImage(new Uri("/SprayPaint;component/Images/down.png", UriKind.Relative));

            // Load source into xaml
            LoadWindow.imgPhoto.Source = loadedImg;
            LoadWindow.Title = "Spray Painter - Edit - Plain Canvas";

            // Hide current window visibility
            this.Visibility = Visibility.Hidden;

            LoadWindow.Show();
        }
    }
}
