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

        private void DeleteClick(object sender, EventArgs e)
        {

            if (SelectedProduct != null)
            {
                var Del = App.Db.Products.FirstOrDefault(s => s.id == SelectedProduct.id);
                App.Db.Remove(Del);
                App.Db.SaveChanges();
            }
            //else
            //{
            //    DisplayAlert("Ошибка", "Объекта не существует", "OK");
            //}


        }
        private async void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
        {
            SwipeItem swipeItem = (SwipeItem)sender;
            Product product = (Product)swipeItem.BindingContext;
            App.Db.Products.Remove(product);
            SignalChanged(nameof(Products));
            App.Db.SaveChanges();
        }
      
    }
}
