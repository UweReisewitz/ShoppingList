using System.ComponentModel;
using Xamarin.Forms;
using ShoppingList.ViewModels;

namespace ShoppingList.Views
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