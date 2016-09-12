using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using storageSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace storageSystem.ViewModel
{
    public class OrdersViewModel : ViewModelBase
    {
        ProductViewModel productVM;
        public OrdersViewModel(ProductViewModel productVM)
        {
            this.productVM = productVM;
        }

        public OrdersViewModel()
        {
        }

        private OrderList _selectedOrder;
        /// <summary>
        /// wybrane zamówienie
        /// </summary>
        public OrderList SelectedOrder
        {
            get
            {
                return _selectedOrder;
            }
            set
            {
                _selectedOrder = value;
                RaisePropertyChanged("Order");
            }
        }
        private ObservableCollection<OrderList> _orders;
        /// <summary>
        /// lista zamówień
        /// </summary>
        public ObservableCollection<OrderList> Orders
        {
            get
            {
                if (_orders == null)
                {
                    using (WarehouseTEntities database=new WarehouseTEntities())
                    {
                        
                        _orders = DatabaseOperation.getOrders();
                    }
                }
                return _orders;
            }
            private set
            {
                _orders = value;
                RaisePropertyChanged("Orders");
            }
        }
      
        private RelayCommand _realiseOrderCommand;
        public ICommand RealiseOrderCommand
        {
            get
            {
                if (_realiseOrderCommand == null)
                {
                    _realiseOrderCommand = new RelayCommand(() => realiseOrder());
                }
                return _realiseOrderCommand;
            }
        }
        /// <summary>
        /// funkcja realizująca zamówienie
        /// </summary>
        private void realiseOrder()
        {
            try
            {
                if (SelectedOrder != null)
                {

                    DatabaseOperation.realiseOrder(SelectedOrder.id);
                    Orders = DatabaseOperation.getOrders();
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("Nie można zrealizować zamówienia");
            }
        }

    }
}
