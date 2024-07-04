using DbFirstPrueba.ModelsDatabase;

namespace DbFirstPrueba.Dtos;

public class TodoItemGetDto
{
    public Guid Id { get; set; }

    public string NombreTarea { get; set; } = null!;

    public bool EstaCompleta { get; set; }

    public string Categoria { get; set; }
}
