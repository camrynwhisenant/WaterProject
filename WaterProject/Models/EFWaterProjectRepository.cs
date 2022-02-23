using System;
using System.Linq;

namespace WaterProject.Models
{
    public class EFWaterProjectRepository : IWaterProjectRespository
    {
        private WaterProjectContext context {get; set;}

        public EFWaterProjectRepository(WaterProjectContext temp)
        {
            context = temp;
        }
        public IQueryable<Projects> Projects => context.Projects;
    }
}
