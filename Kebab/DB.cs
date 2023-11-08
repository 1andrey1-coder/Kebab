
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Kebab
{
    public class DB:DbContext
    {

        private string _filePath;
        //Путь куда будет все сохраняться(в filePath)
        public DB(string filePath)
        {
            _filePath = filePath;
        }
        //Path-(параметрр)где будет храниться и создаваться файл

        //Получаем все записи
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_filePath}");
            base.OnConfiguring(optionsBuilder);
        }
    }











    //SQLiteConnection conn;

    ////конструктор
    ////Путь куда будет все сохраняться(в path)
    //public DB(string path)
    //{
    //    conn = new SQLiteConnection(path);//выделение памяти
    //    conn.CreateTable<Product>();//таблица где все записывается
    //}
    ////Path-(параметрр)где будет храниться и создаваться файл

    ////Получаем все записи
    //public IEnumerable<Product> GetProducts()
    //{
    //    return conn.Table<Product>().ToList();//получаем все записи из Product и преобразуем к списку
    //}

    //public Product GetProduct(int prod)
    //{
    //    return conn.Get<Product>(prod);
    //}

    //public int DeleteProduct2(int id)
    //{
    //    return conn.Delete<Product>(id);

    //}

    //public int SaveProductToDB(Product prod)
    //{
    //    //добавляем в бд и сохраняем
    //    if (prod.id != 0)
    //    {
    //        conn.Update(prod);
    //        return prod.id;
    //    }
    //    else
    //    {
    //        return conn.Insert(prod);
    //    }
    //}
}
