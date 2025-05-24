using PersonalExpenseTracker.Context;
using PersonalExpenseTracker.Interface;
using PersonalExpenseTracker.Models;
using PersonalExpenseTracker.ViewModels;

namespace PersonalExpenseTracker.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public ResultViewModel GetCategories()
        {
            var categories = _context.Categories.ToList();
            return ResultViewModel.Success(data: categories);
        }

        public ResultViewModel GetCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
                return ResultViewModel.Fail("Category not found.");
            return ResultViewModel.Success(data: category);
        }

        public ResultViewModel AddCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return ResultViewModel.Success("Category added successfully.", category);
            }
            catch (Exception ex)
            {
                return ResultViewModel.FailException(ex);
            }
        }

        public ResultViewModel DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
                return ResultViewModel.Fail("Category not found.");

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return ResultViewModel.Success("Category deleted successfully.", id);
        }

        public ResultViewModel UpdateCategory(Category category)
        {
            try
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return ResultViewModel.Success("Category updated successfully.", category);
            }
            catch (Exception ex)
            {
                return ResultViewModel.FailException(ex);
            }
        }
    }
}
