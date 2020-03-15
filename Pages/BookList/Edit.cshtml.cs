using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCRUD.Model;

namespace RazorCRUD
{
    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _Db;

        public EditModel(ApplicationDbContext Db)
        {
            _Db = Db;
        }

        [BindProperty]
        public Item Item { get; set; }
        public async Task OnGet(int Id)
        {
            Item = await _Db.Item.FindAsync(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ItemFromDb = await _Db.Item.FindAsync(Item.Id);
                ItemFromDb.Name = Item.Name;
                ItemFromDb.Author = Item.Author;
                ItemFromDb.ISBN = Item.ISBN;

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