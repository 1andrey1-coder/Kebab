using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kebab.Models;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Kebab.XAML
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProduct : ContentPage
    {

        public AddProduct()
        {
            InitializeComponent();

        }

        //private void product(object sender, EventArgs e)
        //{
        //    List<Product> products = new List<Product>();
        //    products.AddRange(products);

        //}

        
        private async void SaveProduct(object sender, EventArgs e)
        {

            string name = NameField.Text.Trim();
            string image = ImageField.Text.Trim();
            string title = TitleField.Text.Trim();

            //провекра

            if (name.Length < 2)
            {
                await DisplayAlert("Ошибка", "Name min 2", "OK");
            }
            else if (image == null)
            {

            }
            else if (title.Length < 2)
            {
                await DisplayAlert("Ошибка", "Title min 2", "OK");
            }

            Product prod = new Product//все данные и значения аксеса
            {
                Name = name,//то что получаем от пользователя
                Image = image,
            
                Title = title,


            };

            App.Db.Products.Add(prod); 
            App.Db.SaveChanges();
            /* App.Db.SaveProductToDB(prod);*///сохранение в бд
                                              //Очистка после добавления
            NameField.Text = "";
            ImageField.Text = "";
            TitleField.Text = "";


        }


        private void DeleteProduct(object sender, EventArgs e)
        {

            App.Db.Remove(NameField.Text);
            App.Db.Remove(ImageField.Text);
            App.Db.Remove(TitleField.Text);
            App.Db.SaveChanges();
            //var product = (Product)BindingContext;
            //App.Db.Products.Remove(product);
            //App.Db.SaveChanges();
            //this.Navigation.PopModalAsync();
        }




    }
}