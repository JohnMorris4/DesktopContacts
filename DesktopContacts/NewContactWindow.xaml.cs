using DesktopContacts.Models;
using SQLite;
using System.Windows;

namespace DesktopContacts
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {

            //TODO - Setup the Save Contact
            Contacts contacts = new Contacts()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                PhoneNumber = phoneNumberTextBox.Text
            };



            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contacts>();
                connection.Insert(contacts);
            }
            Close();
        }
    }
}
