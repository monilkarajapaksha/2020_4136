using GUI_App.Model;
using SQLite;
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

namespace GUI_App.View
{
    /// <summary>
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        User users;
        public EditUserWindow(User users)
        {
            InitializeComponent();

            this.users = users;

            this.users = users;
            Userfirstnamedisplay.Text = users.FirstName;
            Userlastnamedispaly.Text = users.LastName;
            UserDateofbirthdispaly.Text = users.DateOfBirth;
            UserGPA.Text = Convert.ToString(users.GPA);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            users.FirstName = Userfirstnamedisplay.Text;
            users.LastName = Userlastnamedispaly.Text;
            users.DateOfBirth = UserDateofbirthdispaly.Text;
            users.GPA = Convert.ToDouble(UserGPA.Text);

            using (SQLiteConnection connection = new SQLiteConnection(App.dataBasePath))
            {
                connection.CreateTable<User>();
                connection.Update(users);
            }

            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.dataBasePath))
            {
                connection.CreateTable<User>();
                connection.Delete(users);
            }

            this.Close();
        }
    }
}
