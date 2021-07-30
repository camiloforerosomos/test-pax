using System.ComponentModel;
using TestAppPaxPayment.ViewModels;
using Xamarin.Forms;

namespace TestAppPaxPayment.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}