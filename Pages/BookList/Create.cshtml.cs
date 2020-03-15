using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCRUD.Model;

namespace RazorCRUD
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _Db;
        public CreateModel(ApplicationDbContext Db)
        {
            _Db = Db;
        }

        [BindProperty]
        public Item Item { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _Db.Item.AddAsync(Item);
                await _Db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}