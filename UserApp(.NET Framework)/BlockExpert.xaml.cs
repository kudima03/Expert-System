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
    /// Логика взаимодействия для BlockExpert.xaml
    /// </summary>
    public partial class BlockExpert : Window
    {
        bool isEmpty = true;
        private IAdminAccess module;
        public BlockExpert(IAdminAccess module)
        {
            this.module = module;
            InitializeComponent();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FindExpert_Click(object sender, RoutedEventArgs e)
        {
            var answer = module.BanExpertWith(LoginInput.Text);
            switch (answer)
            {
                case ClassLibraryForTCPConnectionAPI_C_sharp_.AnswerFromServer.Successfully:
                    {
                        MessageBox.Show("Успешно!");
                        break;
                    }
                case ClassLibraryForTCPConnectionAPI_C_sharp_.AnswerFromServer.Error:
                    {
                        MessageBox.Show("Ошибка!");
                        break;
                    }
                case ClassLibraryForTCPConnectionAPI_C_sharp_.AnswerFromServer.UnknownCommand:
                    {
                        MessageBox.Show("Ошибка!");
                        break;
                    }
                default:
                    break;
            }
        }

        private void LoginInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                LoginInput.Text = "";
                isEmpty = false;
            }
        }
    }
}
