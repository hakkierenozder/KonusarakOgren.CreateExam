using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using KonusarakOgren.CreateExam.MVC.ViewModels;
using KonusarakOgren.CreateExam.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.CreateExam.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IExamService _examService;

        public HomeController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var exams = await _examService.GetAllAsync();
            return View(exams);
         
        }
        [HttpGet]
        public async Task<JsonResult> GetExams()
        {
            var exams = await _examService.GetAllAsync();
            return Json(new { data = exams });
        }

        [HttpGet]
        public async Task<IActionResult> AddExam()
        
        {
            var url = "https://www.wired.com/search/";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            //QuerySelectorAll("body").QuerySelectorAll("#app-root div").QuerySelectorAll("#main-content").QuerySelectorAll("div.SearchPageSummaryRiverGrid-euCWFe div div section").QuerySelectorAll("div.GridWrapper-vNBSO").QuerySelectorAll("div.grid-layout__content div")
            IList<HtmlNode> nodes = doc.QuerySelectorAll("div.summary-list__items").QuerySelectorAll("div.summary-list__item").QuerySelectorAll("div.summary-item__content").QuerySelectorAll("a.summary-item__hed-link h3");
            IList<HtmlNode> nodes2 = doc.QuerySelectorAll("div.summary-list__items").QuerySelectorAll("div.summary-list__item").QuerySelectorAll("div.summary-item__content a");

            List<string> nodesLinks = new List<string>();
            List<string> nodesContents = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                nodesLinks.Add(nodes2[i].Attributes["href"].Value);
            }
            foreach (var item in nodesLinks)
            {
                string nodeLink = "https://www.wired.com" + item;
                HtmlDocument doc2 = web.Load(nodeLink);
                HtmlNode node = doc2.QuerySelector("div.body__inner-container");
                if (node != null)
                {
                    nodesContents.Add(node.InnerText);
                }
               
            }


            List<WiredDataViewModel> wiredDataViewModels = new List<WiredDataViewModel>();
            for (int i = 0; i < wiredDataViewModels.Count; i++)
            {
                wiredDataViewModels.Add(
                new WiredDataViewModel
                {
                    Title = nodes[i].InnerText,
                    Content = nodesContents[i] != null ? nodesContents[i] : "Değer çekilemedi"
                });
            }

            ViewBag.WiredDataViewModels = wiredDataViewModels;

            return View();
        }


    }
}
