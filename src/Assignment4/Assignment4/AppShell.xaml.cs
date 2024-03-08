using Assignment4.ViewModels;
using Assignment4.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Assignment4
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

       
    }
}
