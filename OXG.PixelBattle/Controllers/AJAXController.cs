using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OXG.PixelBattle.Models;

namespace OXG.PixelBattle.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AJAXController : ControllerBase
    {
        private readonly PixelDbContext db;

        public AJAXController( PixelDbContext context)
        {
            db = context;
        }

        public async Task<IActionResult> AddCell(int x, int y, string color)
        {//TODO: проверка на существование ячейки
            var cell = new Cell(x, y, color);
            await db.Cells.AddAsync(cell);
            await db.SaveChangesAsync();
            return Ok();
        }

        public IActionResult GetCells()
        {
            var cells = db.Cells;
            return new JsonResult(cells);
        }
    }
}