using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using simple_CRUD.Models;

namespace simple_CRUD.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserDbContext _context;

    public HomeController(ILogger<HomeController> logger, UserDbContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AddEditUsers(int id)
    {
        if (id != null)
        {
            var query = _context.Users.SingleOrDefault(x => x.U_Id == id);
        return View(query);
        }
        return View();
    }

    [HttpPost]
    public IActionResult AddEditUsers(User u)
    {
        if (u.U_Id == 0)
        {
            //Add New User
        _context.Users.Add(u);

        }
        else
        {
            //Edit Existing User Details
            _context.Users.Update(u);
        }
            _context.SaveChanges();
        return RedirectToAction("viewUsers", "Home");
    }

    public IActionResult viewUsers()
    {
        var query = _context.Users.ToList();
        return View(query);
    }


    public IActionResult DeleteUser(int? id)
    {
        if (id != null)
        {
            var query = _context.Users.SingleOrDefault(x => x.U_Id == id);
            _context.Users.Remove(query);
            _context.SaveChanges();
        return RedirectToAction("viewUsers");
        }
        return View();
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
