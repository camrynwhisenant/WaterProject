using System;
using System.Linq;

namespace WaterProject.Models.ViewModels
{
    public class ProjectsViewModel
    {
        public IQueryable<Projects> Projects { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
