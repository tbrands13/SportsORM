using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            // all womens' leagues
            ViewBag.NumberOne = _context.Leagues
            .Where(l => l.Name.Contains("Women"))
            .ToList();


            // all leagues where sports type is hockey
            ViewBag.NumberTwo = _context.Leagues
            .Where(s => s.Name.Contains("Hockey"))
            .ToList();


            // every league but football (ask about this one)
            ViewBag.NumberThree = _context.Leagues
            .Where(foot => foot.Sport != "Football")
            .ToList();


            // call themselves conferences(ask about this too)
            ViewBag.NumberFour = _context.Leagues
            .Where(con => con.Name.Contains("Conference"))
            .ToList();

            // Leagues in Atlantic region
            ViewBag.NumberFive = _context.Leagues
            .Where(a => a.Name.Contains("Atlantic"))
            .ToList();


            // Teams based in Dallas
            ViewBag.NumberSix = _context.Teams
            .Where(loc => loc.Location.Contains("Dallas"))
            .ToList();


            // Teams named the Raptors
            ViewBag.NumberSeven = _context.Teams
            .Where(rap => rap.TeamName.Contains("Raptors"))
            .ToList();


            // all teams who's location includes "city"
            ViewBag.NumberEight = _context.Teams
            .Where(x => x.Location.Contains("City"))
            .ToList();


            // All teams who's name begins with "T"
            ViewBag.NumberNine = _context.Teams
            .Where(t => t.TeamName.StartsWith("T"))
            .ToList();


            // teams ordered alphabetically by location
            ViewBag.NumberTen = _context.Teams
            .OrderBy(alpha => alpha.Location)
            .ToList();


            // teams ordered by team name in reverse alpha order
            ViewBag.NumberEleven =_context.Teams
            .OrderByDescending(rev => rev.TeamName)
            .ToList();


            // player with last name "Cooper"
            ViewBag.NumberTwelve = _context.Players
            .Where(coop => coop.LastName.Contains("Cooper"))
            .ToList();


            // player with first name "Joshua"
            ViewBag.NumberThirteen = _context.Players
            .Where(j => j.FirstName.Contains("Joshua"))
            .ToList();


            // player with last name Cooper but not Josh as the first
            ViewBag.NumberFourteen = _context.Players
            .Where(c => c.LastName.Contains("Cooper") && c.FirstName != "Joshua")
            .ToList();


            // Players with the first name "Alexander" or "Wyatt"
            ViewBag.NumberFifteen = _context.Players
            .Where(n => n.FirstName.Contains("Alexander") || n.FirstName == "Wyatt")
            .ToList();
            return View();

        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}