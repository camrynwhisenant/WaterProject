using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterProject.Infastructure;
using WaterProject.Models;

namespace WaterProject.Pages
{
    public class DonateModel : PageModel
    {
        private IWaterProjectRespository repo { get; set; }
        public DonateModel(IWaterProjectRespository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();

        }
        public IActionResult OnPost(int projectId, string returnUrl)
        {
           
            Projects p = repo.Projects.FirstOrDefault(x => x.ProjectId == projectId);
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();       
            basket.AddItem(p, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });

        }
    }
}
