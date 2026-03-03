using ApiProject.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebUI.ViewComponents.DashboardViewComponents
{
    public class _DashboardMainChartComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var vm = new RevenueChartViewModel
            {
                Labels = new List<string> { "Jan", "Feb", "Mar", "Apr", "May", "Jun" },
                Income = new List<int> { 5, 15, 14, 36, 32, 32 },
                Expense = new List<int> { 7, 11, 30, 18, 25, 13 }
            };

            return View(vm);
        }
    }
}
