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

namespace ApplicationDB
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        private readonly Database.user8Entities database;

        public Authorization(Database.user8Entities entities)
        {
            InitializeComponent();
            database = entities;
        }

        private void UserEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password = Password.Password;
            var account = database.Accounts.FirstOrDefault(a => a.Login == login && a.Password == password);
            if (account != null)
            {
                var role = database.Roles.FirstOrDefault(r => r.ID == account.Role);
                if (role != null)
                {
                    switch (role.Name)
                    {
                        case "Student":
                            NavigationService.Navigate(PageController.PageStudent);
                            break;
                        case "Teacher":
                            NavigationService.Navigate(PageController.PageTeacher);
                            break;

                    }
                }
            }
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PageController.Registration);
        }
    }
}
