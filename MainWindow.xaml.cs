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
        private DataContext _context;
        private List<Contact> _contacts = [];
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
            _context = new DataContext();
            _contacts = await _context.Contacts.OrderBy(c => c.Id).ToListAsync();
            contactsListView.ItemsSource = _contacts;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = searchTextBox.Text.ToLower();
            List<Contact> filteredContacts = _contacts.Where(c => c.FirstName.ToLower().Contains(text)).ToList();
            contactsListView.ItemsSource = filteredContacts;
        }

        private void ContactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact? contact = (Contact)contactsListView.SelectedItem;
            if (contact is not null)
            {
                new ContactDetailsWindow(contact).ShowDialog();

                ReadContacts();
            }


        }
    }
}