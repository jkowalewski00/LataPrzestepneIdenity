using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LataPrzestepneIdenity.Data;
using LataPrzestepneIdenity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace LataPrzestepneIdenity.Pages
{
    [Authorize]
    public class HistoryModel : PageModel
    {
        private readonly LataPrzestepneIdenity.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HistoryModel(LataPrzestepneIdenity.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        
        public IList<LeapYears> AddedData { get; set; }

        public string CurrentUser;

        public void OnGet()
        {
            AddedData = _context.LeapYears.ToList();
            CurrentUser = _userManager.GetUserId(User);
        }

        public IActionResult OnPost()
        {
            int id = Convert.ToInt32(Request.Form["id"]);

            var data = _context.LeapYears.SingleOrDefault(d => d.Id == id);

           if(data != null)
            {
                _context.LeapYears.Remove(data);
                _context.SaveChanges();
                RedirectToAction("/History");
                OnGet();
            }

           return Page();
        }
    }
}
