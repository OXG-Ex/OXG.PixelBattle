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

        /// <summary>
        /// Заносит закрашенную ячейку в базу данных
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="color">Цвет закрашенной клетки</param>
        /// <returns></returns>
        public async Task<IActionResult> AddCell(int x, int y, string color)
        {
            var cell = await db.Cells.Where(c => c.X == x && c.Y == y).FirstOrDefaultAsync();
            if (cell == null)
            {
                cell = new Cell(x, y, color);
                await db.Cells.AddAsync(cell);
            }
            else
            {
                cell.Color = color;
            }
            await db.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Возвращает все закрашенные клетки в формате JSON
        /// </summary>
        /// <returns></returns>
        public IActionResult GetCells()
        {
            var cells = db.Cells;
            return new JsonResult(cells);
        }
    }
}