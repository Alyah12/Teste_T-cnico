namespace Teste_Iboss.Models;

public class Curse
{
    public int CurseId { get; set; }
    public string Name { get; set; }
    public string Descricao { get; set; }
    public string Professor { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }
}