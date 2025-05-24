using Microsoft.AspNetCore.Mvc;
using PersonalExpenseTracker.Models;
using PersonalExpenseTracker.Services;
using PersonalExpenseTracker.ViewModels;

namespace PersonalExpenseTracker.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetAllCategories()
    {
        var categories = _categoryService.GetCategories().Data;
        return Json(new { data = categories });
    }

    public IActionResult GetCategory(int id)
    {
        var category = _categoryService.GetCategory(id).Data;
        return Json(category);
    }

    public IActionResult AddCategory()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddCategory(CategoryViewModel category)
    {
        _categoryService.AddCategory(category);
        return RedirectToAction("Index");
    }

    public IActionResult EditCategory(int id)
    {
        var category = (Category)_categoryService.GetCategory(id).Data;
        var categoryViewModel = new CategoryViewModel() { id = 0, name = category.name };
        return View("EditCategory", categoryViewModel);
    }

    [HttpPost]
    public IActionResult EditCategory(CategoryViewModel category)
    {
        _categoryService.UpdateCategory(category);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteCategory(int id)
    {
        _categoryService.DeleteCategory(id);

        return RedirectToAction("Index");
    }
}