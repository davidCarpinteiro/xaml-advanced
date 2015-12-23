using RestaurantManager.Models;
using System.Collections.Generic;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        private List<Order> _orderItems;

        protected override void OnDataLoaded()
        {
            this.OrderItems = base.Repository.Orders;
        }

        public List<Order> OrderItems
        {
            get
            {
                return _orderItems;
            }

            set
            {
                if (value != null)
                {
                    _orderItems = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}