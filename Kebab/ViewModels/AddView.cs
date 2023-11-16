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

        public List<Product> List { get; set; }
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
            List = App.Db.Products.ToList();
            RemoveProductCommand = new CustomCommand<Product>(
                action: async (product) =>
                {
                    App.Db.Products.Remove(product);
                    App.Db.SaveChanges();
                    List = App.Db.Products.ToList();
                    SignalChanged(nameof(List));
                    await App.Current.MainPage.DisplayAlert("", "Выполнилась", "Ладно");

                },

                      canExecute: (item) =>
                      {
                          return item != null;
                      }

                );
            AddProductCommand = new CustomCommand(AddProduct);

        }
        private async void AddProduct()
        {
            Product product = new Product();
            App.Db.Add(product);
            App.Db.SaveChanges();
            List = App.Db.Products.ToList();
            SignalChanged(nameof(List));
        }
        public void OnAppearing()
        {
           
        }










        private async void SaveProduct(object sender, EventArgs e)
        {
            //string name = Name.Text.Trim();
            //string image = ImageField.Text.Trim();
            //string title = TitleField.Text.Trim();

            ////провекра

            //if (name.Length < 2)
            //{
            //    await DisplayAlert("Ошибка", "Name min 2", "OK");
            //}
            //else if (image == null)
            //{

            //}
            //else if (title.Length < 2)
            //{
            //    await DisplayAlert("Ошибка", "Title min 2", "OK");
            //}

            //Product prod = new Product//все данные и значения аксеса
            //{
            //    Name = name,//то что получаем от пользователя
            //    Image = image,

            //    Title = title,


            //};

            //App.Db.Products.Add(prod);
            //App.Db.SaveChanges();
            ///* App.Db.SaveProductToDB(prod);*///сохранение в бд
            //                                  //Очистка после добавления
            //NameField.Text = "";
            //ImageField.Text = "";
            //TitleField.Text = "";


        }

       
        private void DeleteProduct(object sender, EventArgs e)
        {

            //App.Db.Remove(NameField.Text);
            //App.Db.Remove(ImageField.Text);
            //App.Db.Remove(TitleField.Text);
            //App.Db.SaveChanges();
            //var product = (Product)BindingContext;
            //App.Db.Products.Remove(product);
            //App.Db.SaveChanges();
            //this.Navigation.PopModalAsync();
        }
    }
}
