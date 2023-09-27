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

namespace RedactImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double x1,x2,y1,y2;
        Brush customColor;
        Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            shapeCanvas.Children.Clear();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }
            //shapeCanvas.Children.Clear();
            //shapeCanvas.Children.Remove(newRectangle);
        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs args)
        {
            Window win = sender as Window;
            Point startPoint = args.GetPosition(win);
            x1 = args.GetPosition(win).X;
            y1 = args.GetPosition(win).Y;

            

        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs args)
        {
            Window win = sender as Window;
            Point startPoint = args.GetPosition(win);
            x2 = args.GetPosition(win).X;
            y2 = args.GetPosition(win).Y;

            double x_diff = Math.Abs(x2 - x1);
            double y_diff = Math.Abs(y2 - y1);

            customColor = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 255)));

            Rectangle newRectangle = new Rectangle
            {
                Width = x_diff,
                Height = y_diff,
                Fill = customColor,
                StrokeThickness = 3,
                Stroke = Brushes.Black

            };

            Canvas.SetLeft(newRectangle, (x1 < x2) ? x1 : x2);
            Canvas.SetTop(newRectangle, (y1 < y2) ? y1 : y2);

            shapeCanvas.Children.Add(newRectangle);

            
        }
    }
}
