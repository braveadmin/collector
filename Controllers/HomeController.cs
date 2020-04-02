using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using collector.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace collector.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(WordModel model)
        {
            if (!string.IsNullOrEmpty(model.word))
            {
                string contentRootPath = _hostingEnvironment.ContentRootPath;
                try
                {
                    using (StreamWriter writer = new StreamWriter(contentRootPath + "/wordsfile/words.txt", true))
                    {
                        writer.Write(model.word + ",");
                    }
                    ViewBag.ok = true;
                    model.word = "";
                }
                catch (Exception ex)
                {
                    ViewBag.ok = false;
                }
            }
            
            return View(model);
        }

    }
}
