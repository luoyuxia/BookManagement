using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.IService;
using Entity;
using Repository.Concrete;
using Repository.Abstract;

namespace Service.Service
{
    public class CategoryService : ICategoryService
    {
        IBookCategoryRespository categoryRespository = new BookCategoryRespository();
        public bool AddCategory(category_info Category)
        {
            return categoryRespository.SaveBookCategory(Category);
        }

        public bool DeleteCategory(int CategoryId)
        {
            return categoryRespository.DeleteBookCategory(CategoryId);
        }

        public IEnumerable<category_info> GetAllCategory()
        {
            return categoryRespository.GetBookCategory;
        }

        public IEnumerable<category_info> GetCategoryByPagable(int pageIndex, int pageSize, string name = "")
        {
            if(name=="")
            {
                return categoryRespository.GetBookCategory.OrderBy(p=>p.category_id).Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize);
            }
            else
            {
                return categoryRespository.GetBookCategory.Where(p => p.category.Contains(name))
                    .OrderBy(p=>p.category_id)
                    .Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }

        public bool UpdateCategory(category_info Category)
        {
            return categoryRespository.SaveBookCategory(Category);
        }
    }
}
