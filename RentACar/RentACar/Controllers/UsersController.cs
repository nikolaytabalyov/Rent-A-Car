using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentACar.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Authorize(Roles = "Admin")] // Only allow Admins to access this controller
public class UsersController : Controller {
    private readonly UserManager<User> _userManager;

    public UsersController(UserManager<User> userManager) {
        _userManager = userManager;
    }

    // GET: Users
    public IActionResult Index() {
        var users = _userManager.Users.ToList();
        return View(users);
    }

    // GET: Users/Create
    public IActionResult Create() {
        return View();
    }

    // POST: Users/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(User model) {
        if(ModelState.IsValid) {
            var user = new User {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EGN = model.EGN,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password); // Use the provided password

            if(result.Succeeded) {
                return RedirectToAction(nameof(Index));
            }

            foreach(var error in result.Errors) {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(model);
    }

    // GET: Users/Edit/5
    public async Task<IActionResult> Edit(string id) {
        var user = await _userManager.FindByIdAsync(id);
        if(user == null) {
            return NotFound();
        }

        return View(user);
    }

    // POST: Users/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(User model) {
        if(ModelState.IsValid) {
            var user = await _userManager.FindByIdAsync(model.Id.ToString());
            if(user == null) {
                return NotFound();
            }

            user.Email = model.Email;
            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.EGN = model.EGN;
            user.PhoneNumber = model.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded) {
                return RedirectToAction(nameof(Index));
            }

            foreach(var error in result.Errors) {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(model);
    }

    // GET: Users/Delete/5
    public async Task<IActionResult> Delete(string id) {
        var user = await _userManager.FindByIdAsync(id);
        if(user == null) {
            return NotFound();
        }

        return View(user);
    }

    // POST: Users/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id) {
        var user = await _userManager.FindByIdAsync(id);
        if(user != null) {
            await _userManager.DeleteAsync(user);
        }
        return RedirectToAction(nameof(Index));
    }
}