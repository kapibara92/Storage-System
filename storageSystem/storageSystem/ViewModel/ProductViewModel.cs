using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using storageSystem.Views;
using System.Collections.ObjectModel;
using storageSystem.Models;
using System.Windows;

namespace storageSystem.ViewModel
{
    public class ProductViewModel : ViewModelBase
    {
        private ProductList product;
        /// <summary>
        /// lista produktów
        /// </summary>
        public ProductList Product
        {
            get { return product; }
           set
            {
                product = value;
                RaisePropertyChanged("Product");
            }

        }
        private string _code;
        /// <summary>
        /// kod produktu
        /// </summary>
        public string Code
        {
            get {
                if(_code==null)
                {
                    _code = "";
                }
                return _code; }
            set { _code = value;  filterData(); RaisePropertyChanged("Code"); }

        }
        private string _name;
        /// <summary>
        /// nazwa produktu
        /// </summary>
        public string Name
        {
            get {
                if (_name == null)
                {
                    _name = "";
                }
                return _name;
            }
            set { _name = value; filterData(); RaisePropertyChanged("Name"); }
        }

        /// <summary>
        /// filtrowanie danych
        /// </summary>
        private void filterData()
        {

            ProductList = DatabaseOperation.filterProducts(Code, Name);
        }
        private ObservableCollection<ProductList> _productList;
        /// <summary>
        /// lista produktów
        /// </summary>
        public ObservableCollection<ProductList> ProductList
        {
            get
            {
                if (_productList == null)
                {
                    _productList = DatabaseOperation.getProducts();
                }
                return _productList;
            }
            private set
            {
                _productList = value;
                RaisePropertyChanged("ProductList");
            }
        }
        private RelayCommand _editProductCommand;
        public ICommand EditProductCommand
        {
            get
            {
                if (_editProductCommand == null)
                {
                    _editProductCommand = new RelayCommand(() => editProduct());
                }
                return _editProductCommand;
            }
        }

        /// <summary>
        /// wywoływanie widoku edycji produktu
        /// </summary>
        private void editProduct()
        {
            if (Product != null)
            {
                addProduct addProductView = new addProduct();
                _addProduct = new addProductViewModel(addProductView,Product, this);

                addProductView.DataContext = _addProduct;
                addProductView.Show();
                refreshProduct();
            }
        }

        private RelayCommand _addProductCommand;
        private addProductViewModel _addProduct;
        public ICommand AddProductCommand
        {
            get
            {
                if (_addProductCommand == null)
                {
                    _addProductCommand = new RelayCommand(() => addProduct());
                }
                return _addProductCommand;
            }
        }

        /// <summary>
        /// wywoływanie widoku dodawania produktu
        /// </summary>
        private void addProduct()
        { 
            addProduct addProductView = new addProduct();
            _addProduct = new addProductViewModel(addProductView, this);

            addProductView.DataContext = _addProduct;
            addProductView.Show();
            refreshProduct();
        }
        private RelayCommand _deleteProduct;
        public ICommand DeleteProductCommand
        {
           get{
                if (_deleteProduct == null)
                {
                    _deleteProduct = new RelayCommand(() => deleteProduct());
                }
                return _deleteProduct;
            }
        }

        /// <summary>
        /// usuwanie produktu
        /// </summary>
        private void deleteProduct()
        {
            if (Product != null)
            {
                string komunikat = "czy na pewno chcesz usunąć produkt: " + Product.code.ToString() + " " + Product.name;
                MessageBoxResult message = MessageBox.Show(komunikat,"ostrzeżenie", MessageBoxButton.YesNo);
                if (message == MessageBoxResult.Yes)
                {
                    DatabaseOperation.deleteProduct(Product.id);
                    refreshProduct();
                }
            }
        }
       
        /// <summary>
        /// odświeżanie listy produktów
        /// </summary>
        public void refreshProduct()
        {
            ProductList = DatabaseOperation.getProducts();
        }
    }
}
