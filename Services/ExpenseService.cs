using PersonalExpenseTracker.Interface;
using PersonalExpenseTracker.Models;
using PersonalExpenseTracker.ViewModels;

namespace PersonalExpenseTracker.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;

        public ExpenseService(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public ResultViewModel GetExpenses()
        {
            return _repository.GetExpenses();
        }

        public ResultViewModel GetExpense(int id)
        {
            return _repository.GetExpense(id);
        }

        public ResultViewModel AddExpense(Expense expense)
        {
            return _repository.AddExpense(expense);
        }

        public ResultViewModel DeleteExpense(int id)
        {
            return _repository.DeleteExpense(id);
        }

        public ResultViewModel UpdateExpense(Expense expense)
        {
            return _repository.UpdateExpense(expense);
        }
    }
}