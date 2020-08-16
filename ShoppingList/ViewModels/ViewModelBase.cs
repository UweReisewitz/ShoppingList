﻿using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using PropertyChanged;

namespace ShoppingList.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModelBase : BindableBase, IInitializeAsync, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        public bool IsBusy { get; set; }

        public string Title { get; set; }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual Task InitializeAsync(INavigationParameters parameters)
        {
            return Task.CompletedTask;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

    }
}