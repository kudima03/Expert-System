using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для FindUser.xaml
    /// </summary>
    public partial class FindUser : Window
    {
        bool isEmpty = true;
        private IAdminAccess module;
        public FindUser(IAdminAccess module)
        {
            this.module = module;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           /* Client client = new Client();
            Bitmap photo  = new Bitmap("");*/            
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FindUser_Click(object sender, RoutedEventArgs e)
        {
            /*var client = module.FindClientByLogin(LoginInput.Text);
            if (client.Login == "empty")
            {
                MessageBox.Show("Не найден!");
            }
            else
            {
               
            }       */    
        }

        private void FindVehicle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserLoginInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                UserLoginInput.Text = "";
                isEmpty = false;
            }
        }
    }
}
