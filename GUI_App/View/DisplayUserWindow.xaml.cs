using System.Collections.ObjectModel;
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
using GUI_App.Model;
using SQLite;

namespace GUI_App.View
{
    /// <summary>
    /// Interaction logic for DisplayUserWindow.xaml
    /// </summary>
    public partial class DisplayUserWindow : Window
    {
        List<User> users;
        public DisplayUserWindow()
        {
            InitializeComponent();

            users = new List<User>();

            ReadDatabase();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // This Function is for Draging the Window
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove(); 
            }
        }

        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                if(IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height= 720;

                    IsMaximized= false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    
                    IsMaximized = true;
                }
            }

        }

        private void menbersdatagide_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        

        void ReadDatabase()
        {

            using (SQLiteConnection connection = new SQLiteConnection(App.dataBasePath))
            {
                connection.CreateTable<User>(); // Creating Genaric type Table
                users = (connection.Table<User>().ToList());  // Adding Objects to the class
            }

            if (users != null)
            {
                ContactListView.ItemsSource = users;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.ShowDialog();

            ReadDatabase();

        }

        private void textsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchtextbox = sender as TextBox;
            var filteredList = users.Where(c => c.FirstName.ToLower().Contains(searchtextbox.Text.ToLower())).ToList(); // Seaching Function Implementing
            ContactListView.ItemsSource = filteredList;
        }


        private void ContactListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User selecteduser = (User)ContactListView.SelectedItem;

            if (selecteduser != null)
            {
                EditUserWindow deleteandUpdateWindow = new EditUserWindow(selecteduser);
               deleteandUpdateWindow.ShowDialog();

                ReadDatabase();
            }
        }
    }
}

