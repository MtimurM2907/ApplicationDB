using Database;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private readonly Database.user8Entities database;

        public List<Role> roles;
        public RegistrationPage(Database.user8Entities entities)
        {
            InitializeComponent();
            database = entities;
            LoadRoles();
        }

        private void LoadRoles()
        {
            roles = database.Roles.ToList();
            CBRole.ItemsSource = roles;
            CBRole.DisplayMemberPath = "Name";
            CBRole.SelectedValuePath = "ID";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PageController.Authorization);
        }

        private void FullName_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var newUser = new Account
            {
                FullName = FullName.Text,
                Login = Login.Text,
                Password = PasswordBox.Text,
                Role = 1//Convert.ToInt32(roles.Where(role => role.Name == CBRole.Text))
            };

            database.Accounts.Add(newUser);
            database.SaveChanges();
            NavigationService.Navigate(PageController.Authorization);
        }
    }
}
