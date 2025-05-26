using Microsoft.AspNetCore.Mvc;
using PersonalExpenseTracker.Interface;
using PersonalExpenseTracker.Models;
using PersonalExpenseTracker.Services;


namespace PersonalExpenseTracker.Controllers
{
 
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly ICategoryService _categoryService;

        public ExpenseController(IExpenseService expenseService, ICategoryService categoryService)
        {
            _expenseService = expenseService;
            _categoryService = categoryService;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllExpenses()
        {
            var expenses = _expenseService.GetExpenses().Data;
            var categories = _categoryService.GetCategories().Data;
            
            ViewData["Categories"] = categories;
            
            return Json(new {data = expenses});
        }

        public IActionResult GetExpense(int id)
        {
            var expense = _expenseService.GetExpense(id).Data;
            return Json(expense);
        }

        [HttpPost]
        public IActionResult AddExpense(Expense expense)
        {
            _expenseService.AddExpense(expense);
            return Json(expense);
        }

        [HttpPost]
        public IActionResult DeleteExpense(int id)
        {
            _expenseService.DeleteExpense(id);
            return Json(id);
        }

        [HttpPost]
        public IActionResult UpdateExpense(Expense expense)
        {
            _expenseService.UpdateExpense(expense);
            return Json(expense);
        }
    }
}