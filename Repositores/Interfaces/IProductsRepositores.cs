using ShoppingList.Models;

namespace ShoppingList.Repositores.Interfaces
{
    public interface IProductsRepositores
    {
         Task<List<ProductsModel>> SearchAllProducts();

         Task<ProductsModel> SearchProductsId(int id);

         Task<ProductsModel> CreateNewProduct(ProductsModel product);

         Task<ProductsModel> UpdateProduct(ProductsModel product, int id);

         Task<bool> DeleteProduct(int id);
    }
}