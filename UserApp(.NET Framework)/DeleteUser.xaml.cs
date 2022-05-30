﻿using System;
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
    /// Логика взаимодействия для DeleteUser.xaml
    /// </summary>
    public partial class DeleteUser : Window
    {
        int counter = 0;
        ParamToFindUser choosenParam;
        bool isEmpty = true;
        private IAdminAccess module;
        List<DatabaseEntities.Client> clients;
        DatabaseEntities.Client clientBuffer;
        public DeleteUser(IAdminAccess module)
        {
            choosenParam = ParamToFindUser.Login;
            this.module = module;
            clients = module.GetAllClients();
            InitializeComponent();
            if (clients.Count == 0)
            {
                MessageBox.Show("Нет данных!");
            }
            else
                Show(clients[0]);
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Show(DatabaseEntities.Client client)
        {
            if (client == null)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                UserImage.Source = App.ConvertToBitmapImage(client.Photo);
                UserLogin.Text = client.Login;
                UserStatus.Text = client.UserStatus.ToString();
                if (client.IsOnline)
                {
                    UserLastOnline.Text = "В сети";
                }
                else
                {
                    UserLastOnline.Text = client.LastOnline.ToString();
                }

            }
        }
        private void FindUser_Click(object sender, RoutedEventArgs e)
        {
            clients.Clear();
            switch (choosenParam)
            {
                case ParamToFindUser.Login:
                    {
                        clientBuffer = module.FindClientByLogin(DataInput.Text);
                        clients.Add(clientBuffer);
                        break;
                    }
                case ParamToFindUser.None:
                    {
                        clients = module.GetAllClients();
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Повторите попытку!");
                        break;
                    }
            }

            if (clients.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                Show(clients[0]);
            }
        }

        private void FindByLogin_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFindUser.Login;
            TopMenuItem.Header = "Поиск по логину";
        }

        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFindUser.None;
            TopMenuItem.Header = "Показать всё";
        }

        private void LeftArrow_Click(object sender, RoutedEventArgs e)
        {
            clients.Clear();
            clients = module.GetAllClients();
            if (clients.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                if (counter == 0)
                {
                    Show(clients[0]);
                }
                else
                {
                    counter--;
                    Show(clients[counter]);
                }
            }
        }

        private void RightArrow_Click(object sender, RoutedEventArgs e)
        {
            clients.Clear();
            clients = module.GetAllClients();
            if (clients.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else if (clients.Count == 1)
            {
                Show(clients[0]);
            }
            else
            {
                if (counter + 1 == clients.Count)
                {
                    Show(clients[counter]);
                }
                else
                {
                    counter++;
                    Show(clients[counter]);
                }
            }
        }
        private void DataInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                DataInput.Text = "";
                isEmpty = false;
            }
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (clients.Count == 0)
                MessageBox.Show("Ошибка!");
            else if (clients.Count == 1)
            {
                module.DeleteClientWith(clients[0].Login);
                MessageBox.Show("Удаление успешно!");
            }
            else
            {
                module.DeleteClientWith(clients[counter].Login);
                MessageBox.Show("Удаление успешно!");
            }
        }
    }
}
