using PersonalExpenseTracker.Interface;
using PersonalExpenseTracker.Models;
using PersonalExpenseTracker.ViewModels;

namespace PersonalExpenseTracker.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public ResultViewModel GetCategories()
        {
            return _repository.GetCategories();
        }

        public ResultViewModel GetCategory(int id)
        {
            return _repository.GetCategory(id);
        }

        public ResultViewModel AddCategory(Category category)
        {
            return _repository.AddCategory(category);
        }

        public ResultViewModel DeleteCategory(int id)
        {
            return _repository.DeleteCategory(id);
        }

        public ResultViewModel UpdateCategory(Category category)
        {
            return _repository.UpdateCategory(category);
        }
    }
}