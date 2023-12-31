﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Kebab.Models;
using Kebab.Tools;
using Kebab.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Kebab.XAML
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage, INotifyPropertyChanged
    {
        public ProductsPage(): base()
        {
            InitializeComponent();
        }

        
        protected override void OnAppearing()
        {
            ((ProductView)BindingContext).OnAppearing();
        }

      
       

    }
}