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
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        List<User> users;
        public AddUserWindow()
        {
            InitializeComponent();
            users = new List<User>();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            User newuser = new User()
            {
                FirstName = Userfirstnamedisplay.Text,
                LastName = Userlastnamedispaly.Text,
                DateOfBirth = UserDateofbirthdispaly.Text,
                GPA = Convert.ToDouble(UserGPAdispaly.Text)
        };

            using (SQLiteConnection connection = new SQLiteConnection(App.dataBasePath))
            {
                connection.CreateTable<User>(); // Creating Genaric type Table
                connection.Insert(newuser);  // Adding Objects to the class
            }

            this.Close();
        }
    }
}
