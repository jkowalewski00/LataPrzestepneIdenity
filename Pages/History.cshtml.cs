using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LataPrzestepneIdenity.Data;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration Configuration;

        public HistoryModel(LataPrzestepneIdenity.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            Configuration = configuration;
        }

        [BindProperty]
        
        public PaginatedList<LeapYears> AddedData { get; set; }

        public string CurrentUser;

        public async Task OnGetAsync(int? pageIndex)
        {
            pageIndex = pageIndex ?? 1;
            IQueryable<LeapYears> leapYears = _context.LeapYears.AsQueryable();
            var pageSize = Configuration.GetValue("PageSize", 4);
            AddedData = await PaginatedList<LeapYears>.CreateAsync(leapYears.AsNoTracking(), pageIndex.Value, pageSize);
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
            }

           return Page();
        }
    }
}
