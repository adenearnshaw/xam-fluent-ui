using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AsyncAwaitBestPractices;

namespace XF.FluentUI.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged, INavigationAware
    {
        private readonly WeakEventManager _notifyPropertyChangedEventManager = new WeakEventManager();

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add => _notifyPropertyChangedEventManager.AddEventHandler(value);
            remove => _notifyPropertyChangedEventManager.RemoveEventHandler(value);
        }

        protected void SetProperty<T>(ref T backingStore, T value, Action? onChanged = null, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return;

            backingStore = value;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);
        }

        public virtual void OnNavigatedTo(params object[] navigationParam)
        { }

        public virtual void OnNavigatingFrom()
        { }

        private void OnPropertyChanged([CallerMemberName] string name = "") =>
            _notifyPropertyChangedEventManager.HandleEvent(this, new PropertyChangedEventArgs(name), nameof(INotifyPropertyChanged.PropertyChanged));


    }
}