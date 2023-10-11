using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kebab
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pupsik : ContentPage
    {
        public Pupsik()
        {
            InitializeComponent();
            Shell.Current.GoToAsync("//pupsik");

            //[QueryProperty("pupsik", nameof(Id))];
        }
    }
}