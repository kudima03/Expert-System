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
using TCPConnectionAPIClientModule_C_sharp_;
namespace UserApp_.NET_Framework_
{
    /// <summary>
    /// Логика взаимодействия для FindExpert.xaml
    /// </summary>
    public partial class FindExpert : Window
    {
        bool isEmpty = true;
        private IAdminAccess module;
        public FindExpert(IAdminAccess module)
        {
            this.module = module;
            InitializeComponent();
        }

        private void FindExpert_Click(object sender, RoutedEventArgs e)
        {
            var expert = module.FindExpertByLogin(ExpertLogin.Text);
            ExpertLogin.Text = expert.Login;
            ExpertStatus.Text = expert.UserStatus.ToString();
            ExpertImage.Source = App.ConvertToBitmapImage(expert.Photo);
            if (expert.IsOnline == true)
            {
                ExpertLastOnline.Text = "Сейчас онлайн";
            }
            else
            {
                ExpertStatus.Text = expert.LastOnline.ToString();
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ExpertLoginInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                ExpertLoginInput.Text = "";
                isEmpty = false;
            }
        }
    }
}
