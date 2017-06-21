using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Service.IService
{
    public interface ICategoryService
    {
        bool AddCategory(category_info Category);

        bool DeleteCategory(int CategoryId);

        bool UpdateCategory(category_info Category);

        IEnumerable<category_info> GetCategoryByPagable(int pageIndex, int pageSize,string name="");

        IEnumerable<category_info> GetAllCategory();
    }
}
