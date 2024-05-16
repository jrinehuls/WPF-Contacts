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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Contacts.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {

        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        private static Contact defaultContact = new()
        {
            FirstName = string.Empty,
            LastName = string.Empty,
            Email = string.Empty,
            Phone = string.Empty
        };


        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(defaultContact, SetText));

        public ContactControl()
        {
            InitializeComponent();
        }

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl contactControl = (ContactControl)d;
            Contact contact = (Contact)e.NewValue;

            contactControl.firstNameTextBlock.Text = contact.FirstName;
            contactControl.lastNameTextBlock.Text = contact.LastName;
            contactControl.emailTextBlock.Text = contact.Email;
            contactControl.phoneTextBlock.Text = contact.Phone;
        }
    }
}
