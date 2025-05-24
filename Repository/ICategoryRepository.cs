using Microsoft.AspNetCore.Mvc;
using PersonalExpenseTracker.Models;
using PersonalExpenseTracker.ViewModels;

namespace PersonalExpenseTracker.Interface;

public interface ICategoryRepository
{
    ResultViewModel GetCategories();
    ResultViewModel GetCategory(int id);
    ResultViewModel AddCategory(Category category);
    ResultViewModel DeleteCategory(int id);
    ResultViewModel UpdateCategory(Category category);
}