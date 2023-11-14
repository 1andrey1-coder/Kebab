using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Kebab.Models;
using Kebab.Tools;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kebab.XAML
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void SignalChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

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

            if(SelectedItem != null)
            {
                var Del = App.Db.Products.FirstOrDefault(s => s.id == SelectedItem.id);
                App.Db.Remove(Del);
                App.Db.SaveChanges();
            }
            else
            {
                DisplayAlert("Ошибка", "Объекта не существует", "OK");
            }

         
        }

       
    }
}