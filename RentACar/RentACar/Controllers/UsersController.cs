using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Authorize(Roles = "Admin")] // Only allow Admins to access this controller
public class UsersController : Controller {
    private readonly UserManager<IdentityUser> _userManager;

    public UsersController(UserManager<IdentityUser> userManager) {
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
    public async Task<IActionResult> Create(IdentityUser model) {
        if (ModelState.IsValid) {
            var result = await _userManager.CreateAsync(model, "DefaultPassword123!"); // Set a default password

            if (result.Succeeded) {
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors) {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(model);
    }

    // GET: Users/Edit/5
    public async Task<IActionResult> Edit(string id) {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) {
            return NotFound();
        }

        return View(user);
    }

    // POST: Users/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(IdentityUser model) {
        if (ModelState.IsValid) {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null) {
                return NotFound();
            }

            user.Email = model.Email;
            user.UserName = model.UserName;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) {
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors) {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(model);
    }

    // GET: Users/Delete/5
    public async Task<IActionResult> Delete(string id) {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) {
            return NotFound();
        }

        return View(user);
    }

    // POST: Users/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id) {
        var user = await _userManager.FindByIdAsync(id);
        if (user != null) {
            await _userManager.DeleteAsync(user);
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: Users/Details/5
    public async Task<IActionResult> Details(string id) {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) {
            return NotFound();
        }

        return View(user);
    }
}