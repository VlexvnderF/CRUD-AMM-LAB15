using Database2022.DataContext;
using Database2022.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database2022.Services
{
    public class ProductService
    {

        private readonly AppDbContext _context;

        public ProductService() => _context = App.GetContext();

        public List<Product> Get()
        {
            return _context.Products.ToList();
        }

        public void Create(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
        }

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public void Delete(Product product)
        {
            var Product = _context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
            _context.Products.Remove(Product);
            _context.SaveChanges();
        }

    }
}
