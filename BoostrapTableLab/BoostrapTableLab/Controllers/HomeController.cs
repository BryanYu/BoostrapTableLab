using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoostrapTableLab.Controllers
{
    public class HomeController : Controller
    {
        public static List<Sample> _data = new List<Sample>
        {
            new Sample
            {
                Id = 1,
                Name = "測試1",
                Type = 1
            },
            new Sample
            {
                Id = 2,
                Name = "測試2",
                Type = 2
            },
            new Sample
            {
                Id = 3,
                Name = "測試3",
                Type = 1
            },
            new Sample
            {
                Id = 4,
                Name = "測試4",
                Type = 2
            }
        };
        public HomeController()
        {
            
        }
        /// <summary>
        /// 首頁的View
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Json(_data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _data.RemoveAll(item => item.Id == id);
            return Json(new
            {
                status = 1,
                message = "OK"
            });
        }
    }


    public class Sample
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Type { get; set; }
    }
}