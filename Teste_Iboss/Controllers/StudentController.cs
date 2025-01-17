using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste_Iboss.Context;
using Teste_Iboss.Models;

namespace Teste_Iboss.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    public readonly AppDbContext _context;
    
    public StudentController(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
    {
        return await _context.Students.Take(5).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
        var student = await _context.Students.FindAsync(id);

        return Ok(student);
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> PutStudent(int id, Student student)
    {
        if (id == student.StudentId)
        {
            return BadRequest();
        }
        
        _context.Entry(student).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok(student);
    }

    [HttpPost]
    public async Task<ActionResult<Student>> PostStudent(Student student)
    {
        if (student is null || !ModelState.IsValid)
        {
            return BadRequest();
        }
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
        
        return new CreatedAtRouteResult("ObterStudent", new { id = student.StudentId }, student);
    }

    [HttpDelete("{id}")]

    public async Task<ActionResult<Student>> DeleteStudent(int id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student is null)
        {
           return BadRequest();
        }
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return Ok(student);
    }
}