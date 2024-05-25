using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ICategoryService
    {
        public Task<ResponseData<List<DishGroup>>> GetCategoryListAsync(string? categoryNormalizedName, int pageNo = 1);
        Task<ResponseData<ListModel<Dish>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1);
    }
}
