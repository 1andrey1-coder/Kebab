using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kebab.Models;
using Kebab.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Kebab.XAML
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        public ProductsPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            ((ProductView)BindingContext).OnAppearing();
        }

        private void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
        {

        }

        private async void PerehodAddProduct(object sender, EventArgs e)
        {
            XAML.AddProduct addProduct = (XAML.AddProduct)BindingContext;
            await Navigation.PushModalAsync(addProduct);
        }
    }
}