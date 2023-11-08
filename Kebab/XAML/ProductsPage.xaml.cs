using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kebab.XAML
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        public List<Product> List { get; set; } 
        public Product SelectedItem { get; set; }
        public ProductsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            List = App.Db.Products.ToList();
            BindingContext = this;
        }

        private void RedactorClick(object sender, EventArgs e)
        {

        }

        private void DeleteClick(object sender, EventArgs e)
        {

        }

       
    }
}