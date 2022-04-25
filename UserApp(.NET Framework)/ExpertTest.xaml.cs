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
using System.Windows.Shapes;

namespace UserApp_.NET_Framework_
{
    /// <summary>
    /// Логика взаимодействия для ExpertTest.xaml
    /// </summary>
    public partial class ExpertTest : Window
    {
        public float TotalRate { get; set; }
        public ExpertTest()
        {
            TotalRate = 0;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FirstButton.IsChecked == true)
                TotalRate += (float)0.3;
            if (SecondButton.IsChecked == true)
                TotalRate += (float)0.2;
            if (ThirdButton.IsChecked == true)
                TotalRate += (float)0.1;
            if (FourButton.IsChecked == true)
                TotalRate += (float)0.5;
            if (FiveButton.IsChecked == true)
                TotalRate += (float)0.4;
            if (SixButton.IsChecked == true)
                TotalRate += (float)0.2;
            if (SevenButton.IsChecked == true)
                TotalRate += (float)0.05;
            if (EightButton.IsChecked == true)
                TotalRate += (float)0.05;
            if (TenButton.IsChecked == true)
                TotalRate += (float)0.05;
            if (ElevenButton.IsChecked == true)
                TotalRate += (float)0.05;
            if (TwelveButton.IsChecked == true)
                TotalRate += (float)0.05;
            if (ThirteenButton.IsChecked == true)
                TotalRate += (float)0.05;
            if (FourteenButton.IsChecked == true)
                TotalRate += (float)0.05;
            if (FiftheenButton.IsChecked == true)
                TotalRate += (float)0.05;
            if (SixteenButton.IsChecked == true)
                TotalRate += (float)0.05;
            this.Close();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FirstButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstButton.IsChecked == true)
            {
                SecondButton.IsChecked = false;
                ThirdButton.IsChecked = false;
            }
        }

        private void SecondButton_Click(object sender, RoutedEventArgs e)
        {
            if (SecondButton.IsChecked == true)
            {
                FirstButton.IsChecked = false;
                ThirdButton.IsChecked = false;
            }
        }

        private void ThirdButton_Click(object sender, RoutedEventArgs e)
        {
            if (ThirdButton.IsChecked == true)
            {
                FirstButton.IsChecked = false;
                SecondButton.IsChecked = false;
            }
        }

        private void FourButton_Click(object sender, RoutedEventArgs e)
        {
            if (FourButton.IsChecked == true)
            {
                FiveButton.IsChecked = false;
                SixButton.IsChecked = false;
            }
        }

        private void FiveButton_Click(object sender, RoutedEventArgs e)
        {
            if (FiveButton.IsChecked == true)
            {
                SixButton.IsChecked = false;
                FourButton.IsChecked = false;
            }
        }

        private void SixButton_Click(object sender, RoutedEventArgs e)
        {
            if (SixButton.IsChecked == true)
            {
                FiveButton.IsChecked = false;
                FourButton.IsChecked = false;
            }
        }

        private void SevenButton_Click(object sender, RoutedEventArgs e)
        {
            if (SevenButton.IsChecked == true)
            {
                EightButton.IsChecked = false;
                TenButton.IsChecked = false;
            }
        }

        private void EightButton_Click(object sender, RoutedEventArgs e)
        {
            if (EightButton.IsChecked == true)
            {
                SevenButton.IsChecked = false;
                TenButton.IsChecked = false;
            }
        }

        private void TenButton_Click(object sender, RoutedEventArgs e)
        {
            if (TenButton.IsChecked == true)
            {
                SevenButton.IsChecked = false;
                EightButton.IsChecked = false;
            }
        }

        private void ElevenButton_Click(object sender, RoutedEventArgs e)
        {
            if (ElevenButton.IsChecked == true)
            {
                TwelveButton.IsChecked = false;
                ThirteenButton.IsChecked = false;
            }
        }

        private void TwelveButton_Click(object sender, RoutedEventArgs e)
        {
            if (TwelveButton.IsChecked == true)
            {
                ElevenButton.IsChecked = false;
                ThirteenButton.IsChecked = false;
            }
        }

        private void ThirteenButton_Click(object sender, RoutedEventArgs e)
        {
            if (ThirteenButton.IsChecked == true)
            {
                TwelveButton.IsChecked = false;
                ElevenButton.IsChecked = false;
            }
        }

        private void FourteenButton_Click(object sender, RoutedEventArgs e)
        {
            if (FourteenButton.IsChecked == true)
            {
                FiftheenButton.IsChecked = false;
                SixteenButton.IsChecked = false;
            }
        }

        private void FiftheenButton_Click(object sender, RoutedEventArgs e)
        {
            if (FiftheenButton.IsChecked == true)
            {
                FourteenButton.IsChecked = false;
                SixteenButton.IsChecked = false;
            }
        }

        private void SixteenButton_Click(object sender, RoutedEventArgs e)
        {
            if (SixteenButton.IsChecked == true)
            {
                FourteenButton.IsChecked = false;
                FiftheenButton.IsChecked = false;
            }
        }
    }
}
