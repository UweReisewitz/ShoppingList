using PropertyChanged;

namespace ShoppingList.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModelBase 
    {
        public bool IsBusy { get; set; }

        public string Title { get; set; }

        public virtual void OnAppearing() { }
        public virtual void OnDisappearing() { }
    }
}
