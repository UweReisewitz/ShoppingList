using System;
using System.Diagnostics;
using System.Threading.Tasks;
using PropertyChanged;
using ShoppingList.Models;
using Xamarin.Forms;

namespace ShoppingList.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ShoppingItemDetailViewModel : ViewModelBase
    {
        public string Name { get; private set;
        }
        public string StateText { get; private set; }

        public string LastBought { get; private set; }
    }
}
