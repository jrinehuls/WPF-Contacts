using Contacts.Data;
using Contacts.Models;
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
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        private readonly DataContext _dataContext;
        public NewContactWindow()
        {
            _dataContext = new DataContext();
            InitializeComponent();
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new()
            {
                FirstName = firstNameTextBox.Text,
                LastName = lastNameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text
            };

            _dataContext.Contacts.Add(contact);
            await _dataContext.SaveChangesAsync();

            this.Close();
        }
    }
}
