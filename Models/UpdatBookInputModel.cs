namespace GerencimentoBiblioteca.Models;

public class UpdatBookInputModel
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Isbn { get; set; }
    public int AnoDePublicacao { get; set; }
}