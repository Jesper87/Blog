using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Website.Controllers
{
  [Authorize]
  public class BlogController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
