using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using storageSystem.Views;
using storageSystem.Models;
using System.Windows;
using System.ComponentModel.DataAnnotations;

namespace storageSystem.ViewModel
{
    /// <summary>
    /// ViewModel: edycja i dodawaie produktu
    /// </summary>
    public class addProductViewModel : ViewModelBase, IViewModel
    {
        private string title;
        private ProductViewModel productVM;

        /// <summary>
        /// tytuł widoku
        /// </summary>
        public string Title
        {
            get { return title; }
            private set {
                if (value != null && value != "")
                {
                    title = value; RaisePropertyChanged("title");
                }
            }
        }    
        public addProductViewModel() {
            this.Title = "dodaj produkt";
        }
        public addProductViewModel(addProduct addProductView, ProductViewModel productVM)
        {
            this.addProductView = addProductView;
            this.productVM = productVM;
          //  addProdyctView = addView;
            this.Title = "dodaj produkt";
        }
        public addProductViewModel(addProduct addProductView, ProductList product, ProductViewModel productVM)
        {
            this.addProductView = addProductView;
            this.productVM = productVM;
            this.Title = "edytuj produkt";
            Id = product.id;
            Name = product.name;
            Code = product.code;
            Type = product.Type;
            Quantity = product.quantity.Value;
            Date = product.guaranteeDate.Value;
        }
        private string _name;
        /// <summary>
        /// nazwa produktu
        /// </summary>
        public string Name
        {
            get { return _name; }
            set {
                _name = value;
                RaisePropertyChanged("Name");

            }
        }
        private string _type;
        /// <summary>
        /// rodzaj produktu
        /// </summary>
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                RaisePropertyChanged("Type");
            }
        }
        private int _quantity;
        /// <summary>
        /// ilość produktu
        /// </summary>
        public int Quantity
        {
            get { return _quantity; }
            set {
                _quantity = value;
                    RaisePropertyChanged("Quantity"); }
        }
        private DateTime _date;
        /// <summary>
        /// czas gwarancji
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
            set
            {
            //    DateTime date;
            //    if (DateTime.TryParse(value, out date))
            //    {
                    _date = value;
                //}
                //else
                //{
                //    _date = null;
                //}
                RaisePropertyChanged("Date");
            }
        }
        private int id;
        /// <summary>
        /// id produktu
        /// </summary>
        public int Id
        {
            get { return id; }
            private set {
                if (value >= 0)
                {
                    id = value; RaisePropertyChanged("Id");
                }
            }
        }
        private long code;
        /// <summary>
        /// kod produktu
        /// </summary>
        public long Code
        {
            get { return code; }
            set {
                if (value >= 0)
                {
                    code = value;
                    RaisePropertyChanged("Code");
                }
            }
        }
        private addProduct addProductView { get; set; }
        private RelayCommand _addProductCommand;
        public ICommand AddProductCommand
        {
            get
            {
                if (title == "dodaj produkt")
                {
                    if (_addProductCommand == null)
                    {

                        _addProductCommand = new RelayCommand(() => addProduct());
                    }
                }
                if (title == "edytuj produkt")
                {
                    if (_addProductCommand == null)
                    {

                        _addProductCommand = new RelayCommand(() => editProduct());
                    }
                }
                return _addProductCommand;
            }
        }


        /// <summary>
        /// lista rodzajów produktu
        /// </summary>
        public IEnumerable<string> Names
        {
            get
            {
                using (WarehouseTEntities database = new WarehouseTEntities())
                {
                    return database.showProductTypes().ToArray<string>();
                }
            }
            set
            {
                Names = value;
                RaisePropertyChanged("Names");
            }
        }
        
        /// <summary>
        /// metoda dodająca produkt do bazy danych
        /// </summary>
        private void addProduct()
        {
            try
            {
                DatabaseOperation.addProduct(Code, Name, Date, Type, Quantity);
                this.addProductView.Close();
                this.productVM.refreshProduct();
            }
            catch(Exception e)
            {
                MessageBox.Show("blad podczas edytowania danych. Sprawdz, czy wpisales poprawne wartosci");
            }

        }
        /// <summary>
        /// metoda edytująca produkt w bazie danych
        /// </summary>
        private void editProduct()
        {
            try
            {
                DatabaseOperation.editProduct(Id, Code, Name, Date, _type, Quantity);

                this.addProductView.Close();
                this.productVM.refreshProduct();
            }
            catch(Exception e)
            {
                MessageBox.Show("blad podczas edytowania danych. Sprawdz, czy wpisales  poprawne wartosci");
            }

        }
    }
}
