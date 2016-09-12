using ClientApplication.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientApplication.ViewModel
{
    public class NewOrderVM : ViewModelBase
    {
        private string _nameProduct;
        /// <summary>
        /// nazwa produktu
        /// </summary>
        public string NameProduct
        {
            get
            {
                return _nameProduct;
            }
            set
            {
                _nameProduct = value;
                RaisePropertyChanged("NameProduct");
            }
        }
        private long? _codeProduct;
        private NewOrderView orderView { get; set; }
        public long? CodeProduct
        {
            get
            {
                return _codeProduct;
            }
            set
            {
                if (value >= 0)
                {
                    _codeProduct = value;
                RaisePropertyChanged("CodeProduct");
                }
            }
        }
        private IEnumerable<string> _deliveryList;
        /// <summary>
        /// lista metod dostawy
        /// </summary>
        public IEnumerable<string> DeliveryList
        {
            get
            {
                if (_deliveryList == null)
                {
                    _deliveryList = WebServiceOperation.showDeliveryMethod();
                }
                return _deliveryList;
            }
           private set
            {
                _deliveryList = value;
                RaisePropertyChanged("DeliveryList");
            }
        }
        private string _deliveryMethod;
        /// <summary>
        /// rodzaj dostawy
        /// </summary>
        public string DeliveryMethod
        {
            get
            {
                return _deliveryMethod;
            }
            set
            {
                _deliveryMethod = value;
                RaisePropertyChanged("DeliveryMethod");
            }
        }
        private string _address;
        /// <summary>
        /// adres zamówienia
        /// </summary>
        public string Address {
            get { return _address; }
            set
            {
                _address = value;
                RaisePropertyChanged("Address");
            }
        }
        private int _quantity;

        /// <summary>
        /// ilość zamówionych towarów
        /// </summary>
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (value >= 0)
                {
                    _quantity = value;
                RaisePropertyChanged("Quantity");
                }
            }
        }
        private MainViewModel mainVM { get; set; }
        public NewOrderVM() { }
        public NewOrderVM(MainViewModel mainVM, NewOrderView orderView)
        {
            this.mainVM = mainVM;
            this.orderView = orderView;
            NameProduct = mainVM.SelectedProduct.name;
            CodeProduct = mainVM.SelectedProduct.code;
        }
        private RelayCommand _submitOrder;
        public ICommand SubmitCommand
        {
            get
            {
                if (_submitOrder == null)
                {
                    _submitOrder = new RelayCommand(() => addOrder());
                }
                return _submitOrder;
            }
        }
        /// <summary>
        /// metoda dodająca nowe zamówienie
        /// </summary>
        public void addOrder()
        {
            try
            {
                WebServiceOperation.addOrder(NameProduct, DeliveryMethod, Address, Quantity, CodeProduct.Value);
                this.mainVM.Refresh();
                orderView.Close();
            }
            catch
            {
                System.Windows.MessageBox.Show("Blad podczas dodawania danych w bazie. Sprawdz, czy wpisałeś poprawne dane");
            }
        }
    }
}
