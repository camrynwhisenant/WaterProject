using System;
namespace WaterProject.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumProjects{ get; set; }
        public int CurrentPage { get; set; }
        public int ProjectsPerPage { get; set; }

        //calculates pages needed
        public int TotalPages => (int) Math.Ceiling((double) TotalNumProjects / ProjectsPerPage);
    }
}
