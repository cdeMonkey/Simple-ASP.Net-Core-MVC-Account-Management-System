using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _netCoreWebApp.Context;
using _netCoreWebApp.Models;
using _netCoreWebApp.DAL;

namespace _netCoreWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;
        private IUserRepository _userRepository;
        public UsersController(AppDbContext context)
        {
            _context = context;
            _userRepository = new UserRepository(_context);

        }


        // GET: Users
        public async Task<IActionResult> Index()
        {
            
            return View(await _userRepository.GetUsers());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersModel = await _userRepository.GetDetails((int)id);
            if (usersModel == null)
            {
                return NotFound();
            }

            return View(usersModel);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,Email,PhoneNO")] UsersModel usersModel)
        {
            if (ModelState.IsValid)
            {
                _userRepository.CreateUser(usersModel);
                _userRepository.SaveChanges();  
                return RedirectToAction(nameof(Index));
            }
            return View(usersModel);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersModel = await _userRepository.FindAsync((int)id);
            if (usersModel == null)
            {
                return NotFound();
            }
            return View(usersModel);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,Email,PhoneNO")] UsersModel usersModel)
        {
            if (id != usersModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _userRepository.EditUser((int)id, usersModel);
                    _userRepository.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersModelExists(usersModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usersModel);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersModel = await _userRepository.DeleteUser((int)id);
            if (usersModel == null)
            {
                return NotFound();
            }

            return View(usersModel);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userRepository.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _userRepository.DeleteUserConfirmed(user);
            _userRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersModelExists(int id)
        {
            return _context.users.Any(e => e.Id == id);
        }
    }
}
