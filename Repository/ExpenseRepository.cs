using Microsoft.EntityFrameworkCore;
using PersonalExpenseTracker.Context;
using PersonalExpenseTracker.Interface;
using PersonalExpenseTracker.Models;
using PersonalExpenseTracker.ViewModels;

namespace PersonalExpenseTracker.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _context;

        public ExpenseRepository(AppDbContext context)
        {
            _context = context;
        }

        public ResultViewModel GetExpenses()
        {
            var data = _context.Expenses.Include(e => e.Category).ToList();
            return ResultViewModel.Success(data: data);
        }

        public ResultViewModel GetExpense(int id)
        {
            var expense = _context.Expenses.Find(id);
            if (expense == null)
                return ResultViewModel.Fail("Expense not found.");
            return ResultViewModel.Success(data: expense);
        }

        public ResultViewModel AddExpense(Expense expense)
        {
            try
            {
                _context.Expenses.Add(expense);
                _context.SaveChanges();
                return ResultViewModel.Success("Expense added successfully.", expense);
            }
            catch (Exception ex)
            {
                return ResultViewModel.FailException(ex);
            }
        }

        public ResultViewModel DeleteExpense(int id)
        {
            var expense = _context.Expenses.Find(id);
            if (expense == null)
                return ResultViewModel.Fail("Expense not found.");

            _context.Expenses.Remove(expense);
            _context.SaveChanges();
            return ResultViewModel.Success("Expense deleted successfully.", id);
        }

        public ResultViewModel UpdateExpense(Expense expense)
        {
            try
            {
                _context.Expenses.Update(expense);
                _context.SaveChanges();
                return ResultViewModel.Success("Expense updated successfully.", expense);
            }
            catch (Exception ex)
            {
                return ResultViewModel.FailException(ex);
            }
        }
    }
}
