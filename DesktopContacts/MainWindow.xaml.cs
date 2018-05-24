using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DesktopContacts.Models;
using SQLite;

namespace DesktopContacts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contacts> contacts;
        public MainWindow()
        {
            InitializeComponent();

            contacts = new List<Contacts>();

            ReadDatabase();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            ReadDatabase();
        }

        void ReadDatabase()
        {
            
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                contacts = (connection.Table<Contacts>().ToList()).OrderBy(c => c.Name).ToList();
            }
            if (contacts != null)
            {
                contactsListView.ItemsSource = contacts;
                
            }
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox =  sender as TextBox;

            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            contactsListView.ItemsSource = filteredList;
        }
    }
}
