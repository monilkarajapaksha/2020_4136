using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string dataBaseName = "Users.db";
        public static string foulderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Creatting CONNECTION TO THE DATABASE **Database file stores in MyDocuments** 
        public static string dataBasePath = System.IO.Path.Combine(foulderPath, dataBaseName);
    }
}
