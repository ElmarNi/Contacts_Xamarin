using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts
{
    public partial class App : Application
    {
        public static string _filePath;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ContactsList());
        }
        public App(string filePath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ContactsList());

            _filePath = filePath;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
