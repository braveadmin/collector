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
    public class JijiController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public JijiController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var model = new JijiModel();
            try
            {
                using (StreamReader writer = new StreamReader(contentRootPath + "/wordsfile/words.txt", true))
                {
                    model.contenttext += writer.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ok = false;
            }

            return View(model);
        }       

    }
}
