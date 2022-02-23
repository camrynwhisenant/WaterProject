using System;
using System.Linq;

namespace WaterProject.Models
{
    public interface IWaterProjectRespository
    {

        IQueryable<Projects> Projects { get; }



        //public IWaterProjectRespository()
        //{
        //}
    }
}
