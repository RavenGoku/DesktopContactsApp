﻿using DesktopContactsApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewConctactWindow : Window
    {
        public NewConctactWindow()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO:save contact
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                PhoneNumber = phoneTextBox.Text
            };

            // SQLIteConnection  is a Class(type) that create connection between database and application
            // using directive for opening and closing connections  of databases or IO files, best way to always using that
            // directive because is the safest way to do so

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                //Create a table from connection that is generic and can take only our Contact class and nothing else
                //that will prevent from errors from other inputs
                //If database of Contact exists already this will be ignored, so don't worry it will not create a new Table
                connection.CreateTable<Contact>();

                //insert our contact object that we just made and store into our database
                connection.Insert(contact);
            }
            //closing window after save new contact
            this.Close();
        }
    }
}