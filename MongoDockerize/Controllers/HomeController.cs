using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDockerize.Models;

namespace MongoDockerize.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {


            var mongoClient = new MongoClientDBFactory().GetUrl();
           

            dbObjects dbObj = new dbObjects();
            dbObj.dbInfo=  new MongoActions(mongoClient).getDatabaseList();



            return View(dbObj);
        }


        public IActionResult Create()
        {
            string dbname = "test";
            try
            {
                var mongoClient = new MongoClientDBFactory().GetUrl();
                new MongoActions(mongoClient).GetDatabase(dbname);
                return Json( dbname +" is being created."); 

            }
            catch (Exception)
            {
                return Json("Error has been occured.");
                
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
