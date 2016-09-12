using ClientApplication.Models;
using ClientApplication.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ClientApplication.ViewModel
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
        private ObservableCollection<ProductList> _productsList;
        public ObservableCollection<ProductList> ProductsCollection
        {
            get
            {
                if (_productsList == null)
                {
                    _productsList = WebServiceOperation.showProducts();
                }
                return _productsList;
            }
            private set
            {
                _productsList = value;
                RaisePropertyChanged("ProductsCollection");
            }
        }
        private ProductList _selectedProduct;
        public ProductList SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                RaisePropertyChanged("SelectedProduct");
            }
        }
        private RelayCommand _newOrderCommand;
        public ICommand NewOrderCommand
        {
            get
            {
                if (_newOrderCommand == null)
                {
                    _newOrderCommand = new RelayCommand(() => addOrder());
                }
                return _newOrderCommand;
            }
        }
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
        private void addOrder()
        {
            if (SelectedProduct != null)
            {
                NewOrderView orderView = new NewOrderView();
                orderView.DataContext = new NewOrderVM(this, orderView);
                orderView.Show();
            }
        }
        public void Refresh()
        {
            ProductsCollection= WebServiceOperation.showProducts();
        }
    }
}