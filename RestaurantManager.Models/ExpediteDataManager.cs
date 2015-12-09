using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class ExpediteDataManager : DataManager
    {
        private List<Order> _orderItems;

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

        protected override void OnDataLoaded()
        {
            this.OrderItems = base.Repository.Orders;
        }
    }
}