using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste_Iboss.Context;
using Teste_Iboss.Models;

namespace Teste_Iboss.Controllers;


[ApiController]
[Route("[controller]")]
public class CurseController : ControllerBase
{
   public readonly AppDbContext _context;
    
    public CurseController(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    [HttpGet("Student")]
    public async Task <ActionResult<IEnumerable<Curse>>> GetCurses()
    {
        var allCurses = await _context.Curses.Include(x => x.Student).ToListAsync();
        
        return Ok(allCurses);
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<Curse>> GetCurse(int id)
    {
        var onlyCurse = await _context.Curses.FindAsync(id);

        if (onlyCurse is null)
        {
            return NotFound();
        }

        return Ok(onlyCurse);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Curse>> PutCurse(int id, Curse curse)
    {
        if (id == curse.CurseId)
        {
            return BadRequest();
        }
        
        _context.Entry(curse).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return Ok(curse);
    }

    [HttpPost]
    public async Task<ActionResult<Curse>> PostCurse(Curse curse)
    {
        if (curse is null)
        {
            return BadRequest();
        }
        _context.Curses.AddAsync(curse);
        await _context.SaveChangesAsync();

        return Ok(curse);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Curse>> DeleteCurse(int id)
    {
        var curse = await _context.Curses.FindAsync(id);
        
        if (curse is null)
        {
            return BadRequest();
        }
        _context.Curses.Remove(curse);
        await _context.SaveChangesAsync();
        
        return Ok(curse);
    }
}