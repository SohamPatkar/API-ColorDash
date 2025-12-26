using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupabaseConnection.Data;
using SupabaseConnection.Models;

namespace SupabaseConnection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private AppDBContext _context;

        public PlayerController(AppDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return Ok(player);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Players.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null) return NotFound();
            return Ok(player);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Player updated)
        {
            var player = await _context.Players.FindAsync(id);

            if (player == null) return NotFound();

            player.Name = updated.Name;
            player.Score = updated.Score;

            await _context.SaveChangesAsync();
            return Ok(player);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null) return NotFound();

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
