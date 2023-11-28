﻿using Kebab.Models;
using Kebab.Tools;
using Kebab.XAML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinSQLiteMVVM.Tools;

namespace Kebab.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(ProductId), "DI")]
    public class AddView: BaseViewModel
    {

        private Product selectedProduct;

        public List<Product> Products { get; set; }

        private int productId;

        public int ProductId
        {
            get => productId;
            set
            {
                productId = value;
                if(productId > 0)
                {
                   App.Db.Products.FirstOrDefault(s => s.id == productId);


                }
                else
                {
                    return;

                }
            }
        }
        public CustomCommand<Product> RemoveProductCommand { get; set; }
        public CustomCommand AddProductCommand { get; set; }

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
            Products.Clear();
            RemoveProductCommand = new CustomCommand<Product>(
                action: async (product) =>
                {
                    App.Db.Products.Remove(product);
                    App.Db.SaveChanges();
                    Products = App.Db.Products.ToList();
                    SignalChanged(nameof(Products));
                    await App.Current.MainPage.DisplayAlert("Удаление", "Удалилась", "Ок");

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
          
            Products = App.Db.Products.ToList();
            SignalChanged(nameof(Products));
            App.Db.SaveChanges();
        }
        public void OnAppearing()
        {
           
        }
    }
}
