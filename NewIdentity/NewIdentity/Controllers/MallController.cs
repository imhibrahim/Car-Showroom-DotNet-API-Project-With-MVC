using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewIdentity.Areas.Identity.Data;
using NewIdentity.Models;
using System.Threading.Tasks;

namespace NewIdentity.Controllers
{
    public class MallController : Controller
    {
        private readonly userDbContext malldb;

        public MallController(userDbContext malldb)
        {
            this.malldb = malldb;
        }


        public IActionResult insert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> insert(mall mall)
        {
            if (ModelState.IsValid)
            {
               await malldb.mall.AddAsync(mall);
              await malldb.SaveChangesAsync();
            }
            return RedirectToAction("fatch","mall");
             
        }

        public async Task<IActionResult> fatch()
        {
            var data= await malldb.mall.ToListAsync();
            return View(data);
        }

        public async Task<IActionResult> edit(int id)
        {
            var data = await malldb.mall.FirstOrDefaultAsync(x=>x.MallId==id);
            return View(data);
        }

    }
}
