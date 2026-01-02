using Microsoft.AspNetCore.Mvc;
using MVCSaller.Models;
using MVCSaller.Services;

namespace MVCSaller.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _records;

        public SalesRecordsController(SalesRecordService records)
        {
            _records = records;
        }



        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if(!minDate.HasValue)
                minDate = new DateTime(2020,1,1);
            if (!maxDate.HasValue)
                maxDate = DateTime.Now;
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var list = await _records.FindByDateAsync(minDate, maxDate);
            return View(list);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
                minDate = new DateTime(2020, 1, 1);
            if (!maxDate.HasValue)
                maxDate = DateTime.Now;
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var list = await _records.FindByDateGroupingAsync(minDate,maxDate);
            return View(list);
        }
    }
}
