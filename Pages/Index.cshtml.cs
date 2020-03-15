using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCRUD.Model;

namespace RazorCRUD
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _Db;
        public IndexModel(ApplicationDbContext Db)
        {
            _Db = Db;
        }

        public IEnumerable<Item> Books { get; set; }
        public async Task OnGet()
        {
            Books = await _Db.Item.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var item = await _Db.Item.FindAsync(Id);
            if(item == null)
            {
                return NotFound();
            }
            _Db.Item.Remove(item);
            await _Db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}