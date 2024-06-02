using DesktopContactsApp.Classes;
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

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        private Contact _contact;

        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();
            _contact = contact;
            nameTextBox.Text = _contact.Name;
            emailTextBox.Text = _contact.Email;
            phoneTextBox.Text = _contact.PhoneNumber;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            _contact.Name = nameTextBox.Text;
            _contact.Email = emailTextBox.Text;
            _contact.PhoneNumber = phoneTextBox.Text;

            using (SQLiteConnection openConnection = new SQLiteConnection(App.databasePath))
            {
                openConnection.CreateTable<Contact>();
                openConnection.Update(_contact);
            };
            Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want delete contact?", "Warning", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            //get result from message box button if you would like to delete contact
            if (result == MessageBoxResult.Yes)
            {
                using (SQLiteConnection openConnection = new SQLiteConnection(App.databasePath))
                {
                    openConnection.CreateTable<Contact>();
                    openConnection.Delete(_contact);
                };
                Close();
            }
        }
    }
}