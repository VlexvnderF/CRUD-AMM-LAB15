using Database2022.ViewModels;
using Database2022.Services;
using Database2022.Views;
using Database2022.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Database2022.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {

       
        private readonly ProductService dataServiceProducts;
      

      
        private string name;
        private string brand;
        private int stock;
        private double price;
        private Product product;
   



        public Product Product
        {
            get { return this.product; }
            set { SetValue(ref this.product, value); }
        }
        public string Name
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }
        public string Brand
        {
            get { return this.brand; }
            set { SetValue(ref this.brand, value); }
        }
        public int Stock
        {
            get { return this.stock; }
            set { SetValue(ref this.stock, value); }
        }
        public double Price
        {
            get { return this.price; }
            set { SetValue(ref this.price, value); }
        }



        public ICommand CreateCommand
        {
            get
            {
                return new Command<Product>(execute: async (product) =>
                {
                    if (this.Product.ProductId > 0)
                    {

                        var newProduct = new Product()
                        {
                            ProductId = this.Product.ProductId,
                            Name = this.Name,
                            Brand = this.Brand,
                            Stock = this.Stock,
                            Price = this.Price
                        };

                        await this.dataServiceProducts.Update(newProduct);

                    }
                    else
                    {
                        var newProduct = new Product()
                        {
                            Name = this.Name,
                            Brand = this.Brand,
                            Stock = this.Stock,
                            Price = this.Price
                        };

                        this.dataServiceProducts.Create(newProduct);
                        await Application.Current.MainPage.Navigation.PopAsync();
                    }


                    await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());
                    ProductsViewModel productsViewModel = new ProductsViewModel();
                    productsViewModel.LoadProducts();
                });
            }
        }
       

        public ProductViewModel(Product product)
        {
            this.dataServiceProducts = new ProductService();
            if (product != null)
            {
                this.Product = product;
                this.Name = product.Name;
                this.Brand = product.Brand;
                this.Stock = product.Stock;
                this.Price = product.Price;

            }
            else
            {
                this.Name = "";
                this.Brand = "";
                this.Stock = 0;
                this.Price = 0.0;
            }
        }
    

    }
}
