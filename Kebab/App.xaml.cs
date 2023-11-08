using Kebab.XAML;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kebab
{
    public partial class App : Application
    {
        //private static DB db;//создание некоторого поля
        private const string FILE_NAME = "db2.db";

        private static DB db;
        public static DB Db//аксесер
        {
            get
            {
                if (db == null)
                {
                    string path = DependencyService.Get<IDBPath>()
                        .GetDBPath(FILE_NAME);
                    db = new DB(path);
                    //db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
                }
                return db;//выделить память для подключения, а если память
                          //не надо выделять мы и так выдадим готовое подключение
                          //Combine - это обьединить несколько значений в один общий путь
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }


    //public static DB Db//аксесер
    //{
    //    get
    //    {
    //        if (db == null)
    //            db = new DB(Path.Combine(Environment.GetFolderPath(Environment
    //                .SpecialFolder.LocalApplicationData), "db.sqlite4"));
    //        return db;//выделить память для подключения, а если память
    //                  //не надо выделять мы и так выдадим готовое подключение
    //                  //Combine - это обьединить несколько значений в один общий путь
    //    }
    //}
}
