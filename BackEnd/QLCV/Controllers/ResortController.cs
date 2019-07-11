using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessDomain;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace QLCV.Controllers
{
    public class ResortController : Controller
    {
        private static readonly IResort _iResort = new ResortManager();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadResort()
        {
            var result = _iResort.LoadResort();
            return Json(result);
        }

        [HttpPost]
        public JsonResult UpdateResort(ResortModel resort)
        {
            var result = _iResort.UpdateResort(resort);
            return Json(result);
        }

        [HttpPost]
        public JsonResult RemoveResort(int Id)
        {
            var result = _iResort.RemoveResort(Id);
            return Json(result);
        }
    }
}