using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterProject.Models;
using Microsoft.EntityFrameworkCore;
using WaterProject.Models.ViewModels;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterProject.Controllers
{
    public class HomeController : Controller
    {
        private WaterProjectContext context { get; set; }
        private IWaterProjectRespository repo;
        // GET: /<controller>/

        //public HomeController (WaterProjectContext temp)
        //{
        //    context = temp;
        //}

        public HomeController(IWaterProjectRespository temp)
        {
            repo = temp;
        }
        public IActionResult Index(string projectType, int pageNum = 1) //accepts pageNum, default 1
        {
            int pageSize = 5;

            var x = new ProjectsViewModel
            {
                Projects = repo.Projects
                .Where(p => p.ProjectType == projectType || projectType == null)
                .OrderBy(p => p.ProjectName) //puts it in alphabetical order
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = (projectType == null
                        ? repo.Projects.Count()
                        : repo.Projects.Where(x => x.ProjectType == projectType).Count()),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
