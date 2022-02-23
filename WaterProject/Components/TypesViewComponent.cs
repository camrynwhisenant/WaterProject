using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WaterProject.Models;

namespace WaterProject.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IWaterProjectRespository repo { get; set; }

        public TypesViewComponent(IWaterProjectRespository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["projectType"];
            var types = repo.Projects
                .Select(x => x.ProjectType)
                .Distinct()
                .OrderBy(x => x);
            return View(types);
        }
    }
}
