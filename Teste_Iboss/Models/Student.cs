using Microsoft.EntityFrameworkCore;

namespace Teste_Iboss.Models;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string DataNascimento { get; set; }
    
    ICollection<Curse> Curses { get; set; }
}