using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xaml.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlanRza.Extensions;
using PlanRza.Models;
using PlanRza.Models.Data;
using PlanRza.Models.Enums;

namespace PlanRza.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Branch> _repo;

        public HomeController(ILogger<HomeController> logger, IRepository<Branch> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var branches = await _repo.GetListAsync();

            IndexViewModel[] model = branches.Select(x => new IndexViewModel { Params = "branch/"+x.Id.ToString(), 
                IsFolder = true, 
                Name = x.Name, 
                Method =nameof(AjaxController.VoltLevels)}).ToArray();

            return View(model);
        }
    }
}
