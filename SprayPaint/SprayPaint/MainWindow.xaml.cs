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
    }
}
