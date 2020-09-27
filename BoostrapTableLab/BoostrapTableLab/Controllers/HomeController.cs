using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

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
                Type = 1,
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

        private static int GetTypeName(int v)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 首頁的View
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Insert()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Get()
        {
            var types = GetSampleTypes().ToDictionary(key => key.Value, value => value.Text);
            foreach (var sample in _data)
            {
                sample.TypeName = types[sample.Type];
            }

            return Json(_data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetEditData(int id)
        {
            var data = _data.FirstOrDefault(item => item.Id == id);
            return Json(new
            {
                status = 1,
                message = "OK",
                data = data
            }, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult Update(int id, string name, int type)
        {
            var edit = _data.FirstOrDefault(item => item.Id == id);
            if (edit == null)
            {
                return Json(new
                {
                    status = 2,
                    message = "Data Not Found"
                });
            }

            edit.Name = name;
            edit.Type = type;
            return Json(new
            {
                status = 1,
                message = "OK"
            });
        }

        [HttpPost]
        public ActionResult Insert(string name, int type)
        {
            var id = _data.OrderByDescending(item => item.Id).FirstOrDefault()?.Id;
            var newData = new Sample
            {
                Id = id.GetValueOrDefault() + 1,
                Name = name,
                Type = type
            };
            _data.Add(newData);

            return Json(new
            {
                status = 1,
                message = "OK"
            });
        }

        [HttpGet]
        public ActionResult GetSampleTypeList()
        {
            var types = this.GetSampleTypes();
            return Json(new
            {
                status = 1,
                message = "OK",
                data = types
            }, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<SampleType> GetSampleTypes()
        {
            var result = new List<SampleType>
            {
                new SampleType {Text = "類型1", Value = 1},
                new SampleType {Text = "類型2", Value = 2},
            };
            return result;
        }
    }


    public class Sample
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Type { get; set; }

        public string TypeName { get; set; }
    }

    public class SampleType
    {
        public string Text { get; set; }

        public int Value { get; set; }
    }
}