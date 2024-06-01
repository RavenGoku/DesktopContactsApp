using System.Configuration;
using System.Data;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //create database Name for database SQLite postfix .db
        private static string databaseName = "Contacts.db";

        //create folder path where to store our data
        private static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //database is System.IO.Path.Combine() for connecting our path and database name without any errors and mistakes
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName);
    }
}