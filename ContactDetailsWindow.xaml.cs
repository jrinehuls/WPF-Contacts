using Contacts.Data;
using Contacts.Models;
using Microsoft.EntityFrameworkCore;
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

namespace Contacts
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {

        DataContext _context;
        Contact _contact;

        public ContactDetailsWindow(Contact contact)
        {
            _context = new DataContext();
            _contact = contact;
            InitializeComponent();
            InitializeTextBoxes();
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Contact? oldContact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == _contact.Id);

            if (oldContact is not null)
            {
                oldContact.FirstName = firstNameTextBox.Text;
                oldContact.LastName = lastNameTextBox.Text;
                oldContact.Email = emailTextBox.Text;
                oldContact.Phone = phoneTextBox.Text;

                await _context.SaveChangesAsync();
            }
            new MainWindow().Show();
            Close();
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            _context.Contacts.Remove(_contact);
            await _context.SaveChangesAsync();
            new MainWindow().Show();
            Close();
        }

        private void InitializeTextBoxes()
        {
            firstNameTextBox.Text = _contact.FirstName;
            lastNameTextBox.Text = _contact.LastName;
            emailTextBox.Text = _contact.Email;
            phoneTextBox.Text = _contact.Phone;
        }
    }
}
