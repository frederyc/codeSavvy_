using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CodeSavvy.Domain.DataAccess;
using CodeSavvy.Domain.Models;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _db;

        public HomeController(ILogger<HomeController> logger, DatabaseContext db)
        {
            _logger = logger;
            _db = db;
            _logger.LogInformation("created");
        }

        public IActionResult Index()
        {
            LoadSampleData();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void LoadSampleData()
        {
            _logger.LogInformation("LoadSampleData: started");
            if (_db.Credentials.Any())
            {
                _logger.LogInformation("LoadSampleData: Database is not empty");
                return;
            }
            try
            {
                _logger.LogInformation("LoadSampleData: Database is empty - Adding data");
                var fileContent = System.IO.File.ReadAllText("sampleData.json");
                var credentials = 
                    JsonSerializer.Deserialize<List<Credentials>>(fileContent);
                _db.AddRange(credentials!);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                var stackTrace = e.StackTrace;
                _logger.LogInformation($"LoadSampleData: ErrorStackTrace: {stackTrace}");
            }
            _logger.LogInformation("LoadSampleData: ended");
        }
    }
}
