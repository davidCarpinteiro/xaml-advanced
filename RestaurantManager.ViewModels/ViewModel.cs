using RestaurantManager.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantManager.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        private bool _isLoading;

        protected RestaurantContext Repository { get; private set; }

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }

            set
            {
                if (value != null)
                {
                    _isLoading = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public ViewModel()
        {
            LoadData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void LoadData()
        {
            this.IsLoading = true;
            this.Repository = await RestaurantContextFactory.GetRestaurantContextAsync();
            OnDataLoaded();
            this.IsLoading = false;
        }

        protected abstract void OnDataLoaded();

        public void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}