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
using Wpf_PR_12_2_Pisarev.ApplicationData;
using Wpf_PR_12_2_Pisarev.PageAdmin;
using Wpf_PR_12_2_Pisarev.PageStudent;

namespace Wpf_PR_12_2_Pisarev.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.modelOdb.User.FirstOrDefault(x => x.login == txbLogin.Text && x.password == psbPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте, Администратор " + userObj.name + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new PageMenuAdmin());
                            
                            break;
                        case 2:
                            MessageBox.Show("Здравствуйте, Ученик " + userObj.name + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new PageAccountStudent());
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString() + "Критическая ошибка приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void btnRegIn_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageCreateAcc());
        }
    }
}
