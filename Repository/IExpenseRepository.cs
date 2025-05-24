using PersonalExpenseTracker.Models;
using PersonalExpenseTracker.ViewModels;

namespace PersonalExpenseTracker.Interface
{
    public interface IExpenseRepository
    {
        ResultViewModel GetExpenses();
        ResultViewModel GetExpense(int id);
        ResultViewModel AddExpense(Expense expense);
        ResultViewModel DeleteExpense(int id);
        ResultViewModel UpdateExpense(Expense expense);
    }
}