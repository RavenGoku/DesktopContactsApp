using DesktopContactsApp.Classes;
using Microsoft.Win32;
using SQLite;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Contact> contacts;

        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            ReadDatabase();
        }

        private void OpenNewContact_Click(object sender, RoutedEventArgs e)
        {
            NewConctactWindow newContactWindow = new NewConctactWindow();
            newContactWindow.ShowDialog();

            //update window with saved new contact
            ReadDatabase();
        }

        private void ReadDatabase()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                //use of lambda expression to OrderBy i.e. Name
                contacts = (conn.Table<Contact>().ToList()).OrderBy(c => c.Name).ToList();

                //Linq Query syntax rather than lambda expression
                //var variable = from c2 in contacts
                //               orderby c2.Name
                //               select c2;
            }
            if (contacts != null)
            {
                contactsListView.ItemsSource = contacts;
            }
        }

        // ********************************************************************************
        /// <summary>
        /// search bar for filtration when text is input, filter all text and check if value is in the list
        /// then display all items that have all input characters in searchTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // <created>Kamil Mikolajewski,01/06/2024</created>
        // <changed>Kamil Mikolajewski,01/06/2024</changed>
        // ********************************************************************************
        private void IfTextIsChanging_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchBarTextBox = (TextBox)sender;

            var filteredList = contacts.Where(letters => letters.Name.ToLower().Contains(searchBarTextBox.Text.ToLower()));

            //Linq Query syntax rather than lambda expression
            //var filteredList2 = (from c3 in contacts
            //                     where c3.Name.ToLower().Contains(searchBarTextBox.Name.ToLower())
            //                     orderby c3.Name
            //                     select c3).ToList();

            contactsListView.ItemsSource = filteredList;
        }

        private void SelectedContact_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Contact selectedContact = (Contact)contactsListView.SelectedItem;

            if (selectedContact != null)
            {
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(selectedContact);
                contactDetailsWindow.ShowDialog();
            }

            ReadDatabase();
        }
    }
}