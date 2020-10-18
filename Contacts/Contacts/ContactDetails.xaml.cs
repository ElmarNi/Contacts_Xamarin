using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Contacts.Extensions.EmailExtension;

namespace Contacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetails : ContentPage
    {
        public Contact _contact { get; set; }
        public ContactDetails()
        {
            InitializeComponent();
        }
        public ContactDetails(Contact contact)
        {
            InitializeComponent();
            _contact = contact;
            firstname.Text = _contact.Firstname;
            lastname.Text = _contact.Lastname;
            email.Text = _contact.Email;
            number.Text = _contact.Phonenumber;
            adress.Text = _contact.Adress;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (number.Text.Length < 3)
            {
                DisplayAlert("Failed", "Phone number is not valid", "OK");
                return;
            }
            _contact.Firstname = firstname.Text;
            _contact.Lastname = lastname.Text;
            _contact.Adress = adress.Text;
            _contact.Phonenumber = number.Text;
            _contact.Email = email.Text;
            using (SQLiteConnection connection = new SQLiteConnection(App._filePath))
            {
                connection.CreateTable<Contact>();
                int row = connection.Update(_contact);
                if (row > 0)
                {
                    DisplayAlert("Success", "Contact successfully uptaded", "OK");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Failed", "Contact not uptaded", "OK");
                }
            }
        }

        private void RemoveButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App._filePath))
            {
                connection.CreateTable<Contact>();
                int row = connection.Delete(_contact);
                if (row > 0)
                {
                    DisplayAlert("Success", "Contact successfully deleted", "OK");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Failed", "Contact not deleted", "OK");
                }
            }
        }
    }
}