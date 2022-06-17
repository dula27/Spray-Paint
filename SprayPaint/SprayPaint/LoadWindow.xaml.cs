using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace SprayPaint
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        // Initialize public variables
        int sprayDensity = 2;
        SolidColorBrush spray = new SolidColorBrush();
        
        public Window1()
        {
            InitializeComponent();

            // Initialize spray color
            spray.Color = Colors.Black;

            // Center the image
            imgPhoto.HorizontalAlignment = HorizontalAlignment.Center;
            imgPhoto.VerticalAlignment = VerticalAlignment.Center;

            // Set up the DrawingAttributes for the Spray 
            DrawingAttributes SprayP = new DrawingAttributes();
            SprayP.Color = Colors.Transparent;
            SprayP.StylusTip = StylusTip.Ellipse;
            SprayP.IgnorePressure = true;
            SprayP.Height = 0.1;
            SprayP.Width = 0.1;
            inkCanvas.DefaultDrawingAttributes = SprayP;            

        }
        private void Canvas_TouchMove(object sender, MouseEventArgs e)
        {
            bool mouseIsDown = System.Windows.Input.Mouse.LeftButton == MouseButtonState.Pressed;
            if (mouseIsDown)
            {
                // Initialize variables before loop to save runtime memory
                double r, theta, x, y;
                var rand = new Random();

                // Runs a power of 2 times to be memory cache efficient
                for (int i = 0; i < sprayDensity; i++)
                {
                    // Randomize elipse position to look like Spray Paint
                    r = rand.NextDouble() * 5;
                    theta = rand.NextDouble() * (Math.PI * 2);
                    x = e.GetPosition(inkCanvas).X + Math.Cos(theta) * r;
                    y = e.GetPosition(inkCanvas).Y + Math.Sin(theta) * r;

                    // Create point collection
                    StylusPointCollection points = new StylusPointCollection();

                    // Add random points to the collection
                    points.Add(new StylusPoint(x, y));

                    // Create a stroke object
                    Stroke stroke = new Stroke(points);
                    stroke.DrawingAttributes.Color = spray.Color;

                    // Add the stroke object as element to the inkCanvas
                    inkCanvas.Strokes.Add(stroke);

                }
            }
        }
        private void buttonSaveAsClick(object sender, RoutedEventArgs e)
        {
            // Configure save file dialog box
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.Title = "Save as";
            dialog.Filter = "isf files (*.isf)|*.isf";

            if (dialog.ShowDialog() == true)
            {
                FileStream fs = new FileStream(dialog.FileName, FileMode.Create);
                inkCanvas.Strokes.Save(fs);
                fs.Close();
            }
        }

        private void buttonLoadClick(object sender, RoutedEventArgs e)
        {
            // Configure save file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Title = "Open inkCollection";
            dialog.Filter = "isf files (*.isf)|*.isf";

            if (dialog.ShowDialog() == true)
            {
                FileStream fs = new FileStream(dialog.FileName, FileMode.Open);
                inkCanvas.Strokes = new StrokeCollection(fs);
                fs.Close();
            }
        }

        // Erase the ink Stroke Collections
        void eraser_Click(Object sender, RoutedEventArgs e)
        {
            inkCanvas.Strokes.Clear();
        }

        // Button functions for colors
        private void BlackBtn(object sender, RoutedEventArgs e)
        {
            spray.Color = Colors.Black;
        }
        private void WhiteBtn(object sender, RoutedEventArgs e)
        {
            spray.Color = Colors.White;
        }
        private void Purple1Btn(object sender, RoutedEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#E0B1CB");
            spray.Color = color;
        }
        private void Purple2Btn(object sender, RoutedEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#BE95C4");
            spray.Color = color;
        }
        private void Purple3Btn(object sender, RoutedEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#9F86C0");
            spray.Color = color;
        }
        private void Purple4Btn(object sender, RoutedEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#5E548E");
            spray.Color = color;
        }
        private void Purple5Btn(object sender, RoutedEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#231942");
            spray.Color = color;
        }
        private void Blue1Btn(object sender, RoutedEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#001D3D");
            spray.Color = color;
        }
        private void Blue2Btn(object sender, RoutedEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#003566");
            spray.Color = color;
        }
        private void Yellow1Btn(object sender, RoutedEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FFC300");
            spray.Color = color;
        }
        private void Yellow2Btn(object sender, RoutedEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FFD60A");
            spray.Color = color;
        }

    }
}
