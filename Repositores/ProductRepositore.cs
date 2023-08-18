using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Data;
using ShoppingList.Models;
using ShoppingList.Repositores.Interfaces;

namespace ShoppingList.Repositores
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductRepositore : IProductsRepositores
    {

        private readonly ShoppingDbContext _dbContext;

        public ProductRepositore(ShoppingDbContext shoppingDbContext)
        {
            _dbContext = shoppingDbContext;
        }

        [HttpGet]
        public Task<List<ProductsModel>> SearchAllProducts()
        {
            return _dbContext.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ProductsModel> SearchProductsId(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ProductsModel> CreateNewProduct(ProductsModel product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        [HttpPut("{id}")]
        public async Task<ProductsModel> UpdateProduct(ProductsModel product, int id)
        {
            ProductsModel productId = await SearchProductsId(id);

            if (productId == null)
            {
                throw new Exception("Produto não encontrado");
            }

            productId.Name = product.Name;
            productId.Price = product.Price;
            productId.Weight = product.Weight;
            productId.Quantity = product.Quantity;
            productId.Brand = product.Brand;

            _dbContext.Products.Update(productId);
            await _dbContext.SaveChangesAsync();

            return productId;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteProduct(int id)
        {
            ProductsModel productId = await SearchProductsId(id);

            if (productId == null)
            {
                throw new Exception("Produto não encontrado");
            }

            _dbContext.Products.Remove(productId);
            await _dbContext.SaveChangesAsync();

            return true;
        }


    }
}