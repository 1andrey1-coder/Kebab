﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kebab.ViewModels;
using Kebab.XAML;
using Xamarin.Forms;

namespace Kebab.XAML
{
    public partial class MainShell : Shell
    {
        public MainShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("AddView", typeof(AddProduct));

   
        }

        protected override void OnAppearing()
        {
            ((MainView)BindingContext).OnAppearing();
        }
    }
}
