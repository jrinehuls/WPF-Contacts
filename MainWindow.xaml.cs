using Contacts.Data;
using Contacts.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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

namespace Contacts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataContext _context;
        public MainWindow()
        {
            _context = new DataContext();
            InitializeComponent();
            ReadContacts();
        }

        private void NewContactButton_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new ();
            newContactWindow.ShowDialog();

            ReadContacts();
        }

        private async void ReadContacts()
        {
            List<Contact> contacts = await _context.Contacts.ToListAsync();
            contactsListView.ItemsSource = contacts;
        }
    }
}