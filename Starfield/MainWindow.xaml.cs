using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Starfield
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            _Tools.Canvas = MyCanvas;
        }

        private static int speed = 20;

        private Star[] starfield;
        private int starCount = 100;
        private bool stop;

        private async void MyCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            _Tools.Canvas.ClearVisuals();
            stop = false;
            starfield = Enumerable.Range(0, starCount).Select(x => new Star()).ToArray();
            while (!stop)
            {
                for (int i = 0; i < starfield.Length; i++)
                {
                    starfield[i].Update();
                    starfield[i].Show();
                }
                await Task.Delay(speed);
            }
        }

        private async void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            stop = true;
            await Task.Delay(1000);
            MyCanvas_Loaded(this, new RoutedEventArgs());
        }

        private void IncreseButton_Click(object sender, RoutedEventArgs e)
        {
            speed = speed / 2;
            SpeedTextBlock.Text = speed.ToString();
        }

        private void DecreseButton_Click(object sender, RoutedEventArgs e)
        {
            speed = speed * 2;
            SpeedTextBlock.Text = speed.ToString();
        }
    }
}
