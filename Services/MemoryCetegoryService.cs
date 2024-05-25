using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Models;


namespace WebApplication1.Services
{
    public class MemoryCategoryService : ICategoryService
    {
        List<Dish> _dishes;
        List<DishGroup> _categories;
        public void MemoryProductService([FromServices] IConfiguration config, ICategoryService categoryService, int pageNo)
        {
            //_categories = categoryService.GetCategoryListAsync(, pageNo).Result.Data;
            SetupData();
            
        }

		public Task<ResponseData<List<DishGroup>>> GetCategoryListAsync(string? categoryNormalizedName, int pageNo = 1)
        {
            var categories = new List<DishGroup>
                {
                 new DishGroup {DishGroupId=1, GroupName="Стартеры",
                NormalizedName="starters"},
                 new DishGroup {DishGroupId=2, GroupName="Салаты",
                NormalizedName="salads"}
                 };
            var result = new ResponseData<List<DishGroup>>();
            result.Data = categories;
            return Task.FromResult(result);
        }

        private void SetupData()
        {
            _dishes = new List<Dish>
             {
             new Dish {DishId = 1, DishName="Суп-харчо",
             Description="Очень острый, невкусный",
             Calories =200, Image="Images/Суп.jpg",
             DishGroupId=
            _categories.Find(c=>c.NormalizedName.Equals("soups")).DishGroupId},
             new Dish { DishId = 2, DishName="Борщ",
             Description="Много сала, без сметаны",
            Calories =330, Image="Images/Борщ.jpg",
             DishGroupId=
            _categories.Find(c=>c.NormalizedName.Equals("soups")).DishGroupId}

             };
        }

        public Task<ResponseData<ListModel<Dish>>>GetProductListAsync(string? categoryNormalizedName,int pageNo = 1)
                    {
                        var model = new ListModel<Dish>() { Items = _dishes };
                        var result = new ResponseData<ListModel<Dish>>()
                        {
                            Data = model
                        };
                        return Task.FromResult(result);
                    }

    }

    }
