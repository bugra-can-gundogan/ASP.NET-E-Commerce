using System.Collections.Generic;
using bugraGundoganASP.business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace bugraGundoganASP.webui.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoriesViewComponent(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            if (RouteData.Values["category"] != null)
                ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_categoryService.GetAll());
        }
    }
}