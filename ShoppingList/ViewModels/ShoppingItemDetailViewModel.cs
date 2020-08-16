using Prism.Navigation;
using PropertyChanged;

namespace ShoppingList.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ShoppingItemDetailViewModel : ViewModelBase
    {
        public ShoppingItemDetailViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Detail View";
        }

        public string Name { get; private set; }
        public string StateText { get; private set; }
        public string LastBought { get; private set; }
    }
}
