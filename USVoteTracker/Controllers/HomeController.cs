using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using USVoteTracker.Models;
using System.Diagnostics;

namespace USVoteTracker.Controllers
{
    public class HomeController : Controller
    {
        ObjectCache cache = MemoryCache.Default;
        List<Candidate> Candidates;
        
        public HomeController()
        {
            Candidates = cache["Candidates"] as List<Candidate>;

            if (Candidates == null)
            {
                Candidates = new List<Candidate>();
            }
        }

        public void saveCache()
        {
            cache["Candidates"] = Candidates;
        }

        public ActionResult Index()
        {
            //System.Diagnostics.Debug.WriteLine(Candidates.Count());
            return View(Candidates);
        }

        public ActionResult About()
        {
            return View(Candidates);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Vote(string vote)
        {
           foreach (var candidate in Candidates)
            {
                if (candidate.Name == vote)
                {
                    candidate.Votes++;
                    break;
                }
            }
            saveCache();
            return RedirectToAction("Index");
        }
        public ActionResult AddCandidate(string Name, string Party)
        {
            Candidate C = new Candidate();
            C.Name = Name;
            C.Party = Party;
            C.Votes = 0;

            Candidates.Add(C);

            saveCache();
     
            return RedirectToAction("Index");
        }

        public ActionResult AddCandidateView()
        {
            return View();
        }

        public ActionResult showChart()
        {
            return View(Candidates);
        }
    }
}