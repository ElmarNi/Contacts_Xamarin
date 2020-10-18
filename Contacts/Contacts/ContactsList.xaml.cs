using Contacts.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsList : ContentPage
    {
        public string SelectedContact { get; set; }
        public ContactsList()
        {
            InitializeComponent();
        }

        private void AddNewContact_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection connection = new SQLiteConnection(App._filePath))
            {
                connection.CreateTable<Contact>();
                List<Contact> contacts = connection.Table<Contact>().ToList();
                AllContactsList.ItemsSource = contacts;
            }
        }

        private void AllContactsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Contact SelectedItem = AllContactsList.SelectedItem as Contact;
            if (SelectedItem !=null)
            {
                Navigation.PushAsync(new ContactDetails(SelectedItem));
            }
        }
    }
}