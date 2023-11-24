using Kebab.Models;
using Kebab.Tools;
using Kebab.XAML;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamarinSQLiteMVVM.Tools;

namespace Kebab.ViewModels
{
    public class ProductView: BaseViewModel
    {
        public CustomCommand<Product> OnDelete { get; set; }
        public CustomCommand<Product> EditProduct { get; set; }
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

        public void OnAppearing()
        {
            Products = App.Db.Products.ToList();
            SignalChanged(nameof(Products));
        }
        private void RedactorClick(object sender, EventArgs e)
        {


        }
       
        public ProductView()
        {
            EditProduct = new CustomCommand<Product>(
                action: async (product) =>
                {
                    await Shell.Current.GoToAsync($"AddView?DI={product.id}");
                },
                    canExecute: (item) =>
                    {
                        return item != null;
                    }

                );

            OnDelete = new CustomCommand<Product>(
                action: async (product) =>
                {
                    App.Db.Products.Remove(product);
                    App.Db.SaveChanges();
                    Products = new List<Product>();
                    Products = App.Db.Products.ToList();
                    SignalChanged(nameof(Products));
                    await App.Current.MainPage.DisplayAlert("", "ИНГРИДИБИС", "Ок");

                },

                      canExecute: (item) =>
                      {
                          return item != null;
                      }

                );

            Routing.RegisterRoute("matka", typeof(Product));


        }

      


        //private void OnDeleteSwipeItemInvoked()
        //{
        //    SwipeItem swipeItem = (SwipeItem)sender;
        //    Product product = (Product)swipeItem.BindingContext;
        //    App.Db.Products.Remove(product);
        //    SignalChanged(nameof(Products));
        //    App.Db.SaveChanges();
        //}

    }
}
