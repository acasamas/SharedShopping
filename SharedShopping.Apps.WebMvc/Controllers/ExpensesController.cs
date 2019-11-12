using System.Collections.Generic;
using System.Web.Mvc;
using SharedShopping.Domain.Models;
using SharedShopping.Domain.Services;

namespace SharedShopping.Apps.WebMvc.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpenseService expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            this.expenseService = expenseService;
            //this.expenseService = new FakeExpenseService();
        }

        // GET: Expenses
        public ViewResult Index()
        {
            IEnumerable<Expense> expenses;

            expenses = this.expenseService.getExpenses();

            return View(expenses);
        }
    }
}