using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{
    public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
    // Why hello there
    // GET: User
    public ActionResult Index(string searchString, string searchBy)
    {
        var users = userlist;

        if (!String.IsNullOrEmpty(searchString))
        {
            switch (searchBy)
            {
                case "Name":
                    users = userlist.Where(u => u.Name.Contains(searchString, 
                        StringComparison.OrdinalIgnoreCase)).ToList();
                    break;
                case "Email":
                    users = userlist.Where(u => u.Email.Contains(searchString, 
                        StringComparison.OrdinalIgnoreCase)).ToList();
                    break;
                default:
                    users = userlist.Where(u => 
                        u.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) || 
                        u.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    break;
            }
        }

        return View(users);
    }

    // GET: User/Details/5
    public ActionResult Details(int id)
    {
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    // GET: User/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: User/Create
    [HttpPost]
    public ActionResult Create(User user)
    {
        try
        {
            if (ModelState.IsValid)
            {
                user.Id = userlist.Count > 0 ? userlist.Max(u => u.Id) + 1 : 1;
                userlist.Add(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        catch
        {
            return View(user);
        }
    }

    // GET: User/Edit/5
    public ActionResult Edit(int id)
    {
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    // POST: User/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, User user)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var existingUser = userlist.FirstOrDefault(u => u.Id == id);
                if (existingUser == null)
                {
                    return NotFound();
                }

                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        catch
        {
            return View(user);
        }
    }

    // GET: User/Delete/5
    public ActionResult Delete(int id)
    {
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    // POST: User/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            userlist.Remove(user);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
