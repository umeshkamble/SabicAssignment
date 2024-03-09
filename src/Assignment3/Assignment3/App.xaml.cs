using Assignment3.DataStorage;
using Assignment3.Services;
using Assignment3.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment3
{
    public partial class App : Application
    {
        static FeildDatabase database;

        // Create the database connection as a singleton.
       
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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

        public static FeildDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new FeildDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FieldDB.db3"));
                }
                return database;
            }
        }
    }
}
