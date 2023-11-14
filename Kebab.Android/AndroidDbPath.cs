using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Kebab.Tools;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamarinSQLiteMVVM.Droid;

[assembly: Dependency(typeof(AndroidDbPath))]
namespace XamarinSQLiteMVVM.Droid
{
    public class AndroidDbPath : IDBPath
    {
        public string GetDBPath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.Personal),
                filename);
        }
    }
}