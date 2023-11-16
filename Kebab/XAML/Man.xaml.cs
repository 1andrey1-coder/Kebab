using Kebab.ViewModels;
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
    public partial class Man : ContentPage
    {
        public Man()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            ((ManView)BindingContext).OnAppearing();
        }

       
    }
}