using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Services;

namespace Mvc.Controllers
{
 public class GreetingController : Controller
 {
     private GreetingService _service;
     //注入service
     public GreetingController(GreetingService service)
     {
         _service = service;
     }
     //通过service获取model
     public JsonResult Index(int id=0,string name = "")
     {
         var model = _service.GetGreetings(id,name);
         return Json(model);
     }
 }
}
