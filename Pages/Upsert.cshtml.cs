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
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _Db;

        public UpsertModel(ApplicationDbContext Db)
        {
            _Db = Db;
        }

        [BindProperty]
        public Item Item { get; set; }
        public async Task<IActionResult> OnGet(int? Id)
        {
            Item = new Item();
            if (Id == null)
            {
                //create
                return Page();
            }

            //update
            Item = await _Db.Item.FirstOrDefaultAsync(u => u.Id == Id);
            if (Item == null)
            {
                return NotFound();
            }
            return Page();
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                if (Item.Id == 0)
                {
                    _Db.Item.Add(Item);
                }
                else
                {
                    //update all properties
                    _Db.Update(Item);

                }


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