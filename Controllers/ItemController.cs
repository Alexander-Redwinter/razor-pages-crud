using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorCRUD.Model;

namespace RazorCRUD.Controllers
{
    [Route("api/Item")]
    [ApiController]
    public class ItemController : Controller
    {

        private readonly ApplicationDbContext _Db;

        public ItemController(ApplicationDbContext Db)
        {
            _Db = Db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _Db.Item.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var itemFromDb = await _Db.Item.FirstOrDefaultAsync(u => u.Id == id);
            if (itemFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting"});
            }
            _Db.Item.Remove(itemFromDb);
            await _Db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}