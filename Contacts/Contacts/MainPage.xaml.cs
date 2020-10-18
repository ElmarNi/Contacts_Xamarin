using Contacts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using static Contacts.Extensions.EmailExtension;

namespace Contacts
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }



        private void Savebutton_Clicked(object sender, EventArgs e)
        {
            Contact contact = new Contact()
            {
                Firstname = firstname.Text,
                Lastname = lastname.Text,
                Email = email.Text,
                Phonenumber = number.Text,
                Adress = adress.Text
            };
            using (SQLiteConnection connection = new SQLiteConnection(App._filePath))
            {
                connection.CreateTable<Contact>();
                int rows = connection.Insert(contact);
            }
            Navigation.PopAsync();
        }
    }
}
