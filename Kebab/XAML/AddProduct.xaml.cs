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
    public partial class AddProduct : ContentPage, INotifyPropertyChanged
    {
        

        public AddProduct()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ((AddView)BindingContext).OnAppearing();
        }
    }
}