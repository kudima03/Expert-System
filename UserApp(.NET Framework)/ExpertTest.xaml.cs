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
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TotalRate = 20;
            this.Close();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {

        }
        

    }
}
