using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofaciocweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Autofaciocweb.Controllers
{
    public class GameController : Controller
    {
        //private readonly IGame _game;
        public IServiceProvider serviceProvider { get; set; }
        //public GameController(IGame game)
        //{
        //    _game = game;
        //}
        public IActionResult Index()
        {
            //serviceProvider = new ServiceProvider();
            var s = HttpContext.RequestServices.GetService(typeof(IGame)) as IGame;

            //var service = (IGame)serviceProvider.GetService(typeof(IGame));
            ViewBag.yy = s.Showme();
            return View();
        }
    }
}