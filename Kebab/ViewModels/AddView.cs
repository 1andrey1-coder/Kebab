using Kebab.Models;
using Kebab.Tools;
using Kebab.XAML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamarinSQLiteMVVM.Tools;

namespace Kebab.ViewModels
{
    public class AddView: BaseViewModel
    {
        public CustomCommand<Product> RemoveProductCommand { get; set; }
        public CustomCommand AddProductCommand { get; set; }

        private Product selectedProduct;

        public List<Product> Products { get; set; }

        public Product SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
            }
        }
        public AddView()
        {
            Products = App.Db.Products.ToList();
            RemoveProductCommand = new CustomCommand<Product>(
                action: async (product) =>
                {
                    App.Db.Products.Remove(product);
                    App.Db.SaveChanges();
                    Products = App.Db.Products.ToList();
                    SignalChanged(nameof(Products));
                    await App.Current.MainPage.DisplayAlert("", "Выполнилась", "Ладно");

                },

                      canExecute: (item) =>
                      {
                          return item != null;
                      }

                );
            AddProductCommand = new CustomCommand(AddProduct);
            SelectedProduct = new Product();
        }

   
        private void AddProduct()
        {
            App.Db.Add(SelectedProduct);
            App.Db.SaveChanges();
            Products = App.Db.Products.ToList();
            SignalChanged(nameof(Products));
        }
        public void OnAppearing()
        {
           
        }
    }
}
