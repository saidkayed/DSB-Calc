using Calculator_DSB.Interfaces;
using Calculator_DSB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculator_DSB.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IBasicCalculator basicCalculator;


        public CalculatorController(IBasicCalculator basicCalculator)
        {
            this.basicCalculator = basicCalculator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate(double a, string symbol, double b)
        {
            try
            {
                double result = basicCalculator.Calculate(a, symbol, b);

                return Content(result.ToString(), "text/plain");
            }
            catch (Exception)
            {
                return Content("Error", "text/plain");
            }

        }
    }
}
