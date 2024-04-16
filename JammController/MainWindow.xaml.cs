using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace JammController
{
    /// <summary>
    /// Interaction logic for 
    /// MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        static bool power = false;
        static bool jamm = false;
        static List<System.Windows.Controls.Image> batteryLevels = new List<System.Windows.Controls.Image>();
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void CloseBtnClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void BtnPressed(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Equals(PowerBtn))
            {
                if (power) btn.RenderTransform = new ScaleTransform(1.27, 1.27);
                else btn.RenderTransform = new ScaleTransform(0.9, 0.9);
                power = !power;
            }
            else
            {
                if (jamm) btn.RenderTransform = new ScaleTransform(1.27, 1.27);
                else btn.RenderTransform = new ScaleTransform(0.9, 0.9);
                if (power) jamm = !jamm;
            }
        }
        private void PowerBtnReleased(object sender, RoutedEventArgs e)
        {
            BitmapImage img;
            if (power)
            {
                PowerBtn.RenderTransform = new ScaleTransform(1.37, 1.37);
                PowerBtn.Background = new ImageBrush(new BitmapImage(new Uri("Assets\\PowerBtnOn.png", UriKind.Relative)));
                img = new BitmapImage(new Uri("Assets\\PowerOn.png", UriKind.Relative));
                Ready1.RenderTransform = new ScaleTransform(4.2, 4.2);
                Ready2.RenderTransform = new ScaleTransform(4.2, 4.2);
                Ready3.RenderTransform = new ScaleTransform(4.2, 4.2);
            }
            else
            {
                if (jamm)
                {
                    JammBtn.RenderTransform = new ScaleTransform(1, 1);
                    JammBtn.Background = new ImageBrush(new BitmapImage(new Uri("Assets\\JammBtnOff.png", UriKind.Relative)));
                    img = new BitmapImage(new Uri("Assets\\JammOff.png", UriKind.Relative));
                    Jamm1.RenderTransform = new ScaleTransform(1, 1);
                    Jamm2.RenderTransform = new ScaleTransform(1, 1);
                    Jamm3.RenderTransform = new ScaleTransform(1, 1);
                    Jamm1.Source = img;
                    Jamm2.Source = img;
                    Jamm3.Source = img;
                    jamm = false;
                }
                PowerBtn.RenderTransform = new ScaleTransform(1, 1);
                PowerBtn.Background = new ImageBrush(new BitmapImage(new Uri("Assets\\PowerBtnOff.png", UriKind.Relative)));
                img = new BitmapImage(new Uri("Assets\\PowerOff.png", UriKind.Relative));
                Ready1.RenderTransform = new ScaleTransform(1, 1);
                Ready2.RenderTransform = new ScaleTransform(1, 1);
                Ready3.RenderTransform = new ScaleTransform(1, 1);
                Ready1.Source = img;
                Ready2.Source = img;
                Ready3.Source = img;
            }
            Ready1.Source = img;
            Ready2.Source = img;
            Ready3.Source = img;
        }
        private void JammBtnReleased(object sender, RoutedEventArgs e)
        {
            BitmapImage img;          
            if (jamm)
            {
                if (power)
                {
                    JammBtn.RenderTransform = new ScaleTransform(1.37, 1.37);
                    JammBtn.Background = new ImageBrush(new BitmapImage(new Uri("Assets\\StartBtnOn.png", UriKind.Relative)));
                    img = new BitmapImage(new Uri("Assets\\JammOn.png", UriKind.Relative));
                    Jamm1.RenderTransform = new ScaleTransform(4.2, 4.2);
                    Jamm2.RenderTransform = new ScaleTransform(4.2, 4.2);
                    Jamm3.RenderTransform = new ScaleTransform(4.2, 4.2);
                    Jamm1.Source = img;
                    Jamm2.Source = img;
                    Jamm3.Source = img;
                }
            }
            else
            {
                JammBtn.RenderTransform = new ScaleTransform(1, 1);
                JammBtn.Background = new ImageBrush(new BitmapImage(new Uri("Assets\\JammBtnOff.png", UriKind.Relative)));
                if (power)
                {
                    img = new BitmapImage(new Uri("Assets\\JammOff.png", UriKind.Relative));
                    Jamm1.RenderTransform = new ScaleTransform(1, 1);
                    Jamm2.RenderTransform = new ScaleTransform(1, 1);
                    Jamm3.RenderTransform = new ScaleTransform(1, 1);
                    Jamm1.Source = img;
                    Jamm2.Source = img;
                    Jamm3.Source = img;
                }
            }
            
        }

        private void PortSelected(object sender, RoutedEventArgs e)
        {
            mainPanel.Opacity = 1;
            mainPanel.IsEnabled = true;
            Content.Children.Remove(selectDeviceLabel);
            for (int i = 0; i < 4; i++)
            {
                batteryLevels[i].Source = new BitmapImage(new Uri("Assets\\BatteryA.png", UriKind.Relative));
                batteryLevels[i].RenderTransform = new ScaleTransform(7, 7);
            }
        }
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                batteryLevels.Add((System.Windows.Controls.Image)VisualTreeHelper.GetChild(batteryLevel, i));
            }
            batteryLevels.Reverse();
        }
        private void AboutBtnPressed(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWIndow = new AboutWindow();
            aboutWIndow.Show();
        }
    }
}