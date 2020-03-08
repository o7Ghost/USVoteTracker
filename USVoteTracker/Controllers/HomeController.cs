using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USVoteTracker.Models;

namespace USVoteTracker.Controllers
{
    public class HomeController : Controller
    {
        private List<Candidate> Candidates;
        public Candidate C = new Candidate();
        public ActionResult Index()
        {
            return View(C);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddCandidate(string Name, string Party)
        {
            
            C.Name = Name;
            C.Party = Party;
            C.Votes = 0;

            return RedirectToAction("Index");
        }

        public ActionResult AddCandidateView()
        {
            return View();
        }
    }
}