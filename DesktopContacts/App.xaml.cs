using System;
using System.IO;
using System.Windows;

namespace DesktopContacts
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string databaseName = "Contacts.db";
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string databasePath = Path.Combine(folderPath, databaseName);
    }
}
