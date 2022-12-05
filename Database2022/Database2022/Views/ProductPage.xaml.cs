using Database2022.Models;
using Database2022.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Database2022.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        public ProductPage(Product product)
        {
            InitializeComponent();
            this.BindingContext = new ProductViewModel(product);
        }
    }
}