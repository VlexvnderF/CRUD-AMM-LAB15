using Database2022.Models;
using Database2022.Services;
using Database2022.Views;



using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace Database2022.ViewModels
{
    public class ProductsViewModel: BaseViewModel
    {
              
        private readonly ProductService dataServiceProducts;

        private ObservableCollection<Product> products;
       

        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { SetValue(ref this.products, value); }
        }


        public ICommand NewProductCommand
        {
            get
            {
                return new Command(NewProduct);
            }
        }

        public ICommand LoadProductsCommand
        {
            get
            {
                return new Command(LoadProducts);
            }
        }
        public ICommand DeleteProductCommand
        {
            get
            {
                return new Command((x) =>
                {
                    var item = (x as Product);
                    DeleteProduct(item);
                });
            }
            //get;
            //set;
        }
        public ICommand UpdateProductCommand
        {
            get
            {
                return new Command(async (x) =>
                {
                    var item = (x as Product);
                    await UpdateProduct(item);
                });
            }
        }
       
        public ProductsViewModel()
        {
            this.dataServiceProducts = new ProductService();

            this.LoadProducts();

        }
       

        private void NewProduct()
        {
            Product product = new Product();
            product.ProductId = 0;
            product.Name = "";
            product.Brand = "";
            product.Stock = 0;
            product.Price = 0.0;

            Application.Current.MainPage.Navigation.PushAsync(new ProductPage(product));

            LoadProducts();

        }

        private async Task UpdateProduct(Product product)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ProductPage(product));

        }

        private void DeleteProduct(Product product)
        {

            this.dataServiceProducts.Delete(product);
            LoadProducts();
        }

        public void LoadProducts()
        {
            var productsDB = this.dataServiceProducts.Get();
            this.Products = new ObservableCollection<Product>(productsDB);
        }
       
    }
}
