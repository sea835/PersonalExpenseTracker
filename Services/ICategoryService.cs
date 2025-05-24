using Microsoft.AspNetCore.Mvc;
using PersonalExpenseTracker.Models;
using PersonalExpenseTracker.ViewModels;

namespace PersonalExpenseTracker.Services;

public interface ICategoryService
{
    ResultViewModel GetCategories();
    ResultViewModel GetCategory(int id);
    ResultViewModel AddCategory(Category category);
    ResultViewModel DeleteCategory(int id);
    ResultViewModel UpdateCategory(Category category);
}