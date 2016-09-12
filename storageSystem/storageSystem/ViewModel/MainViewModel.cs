using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using storageSystem.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Input;

namespace storageSystem.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        private int selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
                RaisePropertyChanged("SelectedIndex");
                refreshView();
            }
        }
        private ViewModelBase _currentViewModel;
        static ProductViewModel _productVM;
        public ProductViewModel ProductVM
        {
            get
            {
                if (_productVM == null)
                {
                    _productVM = new ProductViewModel();
                }
                return _productVM;
            }
            private set
            {
                _productVM = value;
                RaisePropertyChanged("ProductVM");
            }
        }
        /// <summary>
        /// odœwie¿anie widoku
        /// </summary>
        private void refreshView()
        {
            ProductVM = new ProductViewModel();
            OrderVM = new OrdersViewModel();
        }
        static OrdersViewModel _orderVM; 

        public OrdersViewModel OrderVM
        {
            get
            {
                if (_orderVM == null)
                {
                    _orderVM = new OrdersViewModel(ProductVM);
                }
                return _orderVM;
            }
            private set
            {
                _orderVM = value;
                RaisePropertyChanged("OrderVM");
            }
        }
        public MainViewModel()
        {
        }

    }
}