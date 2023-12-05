using Kebab.Models;
using Kebab.Tools;
using Kebab.XAML;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                    var product = App.Db.Products.FirstOrDefault(s => s.id == productId);
                    //idproduct.id = productId;
                    SelectedProduct =  new Product
                    {
                        id = product.id,
                        Name = product.Name,
                        Title = product.Title,  
                        Category = product.Category,
                        Image = product.Image

                    };
                  

                }
                else
                {
                    return;

                }
            }
        }
        public CustomCommand AddProductCommand { get; set; }

        public Product SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                SignalChanged();

            }
        }
        public AddView()
        {
            Products = App.Db.Products.ToList();
            Products.Clear();
            
            AddProductCommand = new CustomCommand(AddProduct);
            SelectedProduct = new Product();
        }

        //DbContextOptionsBuilder.EnableSensitiveDataLogging
        private async void AddProduct()
        {
            
            
            var product = App.Db.Products.FirstOrDefault(s => s.id == productId);
            if (SelectedProduct.id != 0)
            {
                product.Name = SelectedProduct.Name;
                product.Title = SelectedProduct.Title;
                product.Category = SelectedProduct.Category;
                product.Image = SelectedProduct.Image;
                App.Db.SaveChanges(); // сохранение изменений в базе данных
            }
            else
            {
                App.Db.Add(SelectedProduct);

                Products = App.Db.Products.ToList();
                SignalChanged(nameof(Products));
                App.Db.SaveChanges();
            }
            await App.Current.MainPage.DisplayAlert("", "Объект добавился во влажного мужика", "Лады");

            //var assembly = typeof(App).GetTypeInfo().Assembly;
            //var stream = assembly.GetManifestResourceStream("Music/yametekudasaicat.mp3");
            //var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            //player.Load(stream);
            //player.Play();

            //var player = new SoundPlayer("Music/yametekudasaicat.mp3");
        }
        public void OnAppearing()
        {
           
        }

     
    }
}
