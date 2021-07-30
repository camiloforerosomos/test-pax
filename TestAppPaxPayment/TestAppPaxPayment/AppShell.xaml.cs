using System;
using System.Collections.Generic;
using TestAppPaxPayment.ViewModels;
using TestAppPaxPayment.Views;
using Xamarin.Forms;

namespace TestAppPaxPayment
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
