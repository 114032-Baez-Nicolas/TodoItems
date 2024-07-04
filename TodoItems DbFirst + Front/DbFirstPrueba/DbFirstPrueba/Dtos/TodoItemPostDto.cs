namespace DbFirstPrueba.Dtos;

public class TodoItemPostDto
{
    public Guid Id { get; set; }

    public string NombreTarea { get; set; }

    public bool EstaCompleta { get; set; }

    public int CategoriaId { get; set; }
}
