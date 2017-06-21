using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Service.IService;
using Service.Service;

namespace Boya.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        ICategoryService categoryService = new CategoryService();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCategory(int pageIndex = 1,int pageSize = 10,string name = "")
        {
            IEnumerable<category_info> categoryList = categoryService.GetCategoryByPagable(pageIndex,
                pageSize, name);
            int total = categoryList.Count();
            var list = from category in categoryList
                       select new
                       {
                           category_id = category.category_id,
                           category = category.category
                       };
            return Json(new {rows= list, total = total }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllCategory()
        {
            IEnumerable<category_info> categoryList = categoryService.GetAllCategory();
            var list = from category in categoryList
                       select new
                       {
                           ID = category.category_id,
                           Name = category.category
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateCategory(category_info Category)
        {
            return Json(new { result = categoryService.UpdateCategory(Category) },
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddCategory(List<category_info> Categorys)
        {
            bool addSuccess = true;
            foreach(category_info category in Categorys)
            {
                addSuccess = categoryService.AddCategory(category) && addSuccess;
            }
            return Json(new { result = addSuccess },JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCategory(List<int> categoryIdList)
        {
            bool deleteSuccess = true;
            foreach (int id in categoryIdList)
            {
                if (id == 1)
                    continue;
                deleteSuccess = deleteSuccess && categoryService.DeleteCategory(id);
            }
            return Json(new { result = deleteSuccess }, JsonRequestBehavior.AllowGet);
        }

    }
}