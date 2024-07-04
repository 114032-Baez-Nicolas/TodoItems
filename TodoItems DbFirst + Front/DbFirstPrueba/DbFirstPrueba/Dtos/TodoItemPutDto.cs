namespace DbFirstPrueba.Dtos;

public class TodoItemPutDto
{
    public Guid Id { get; set; }

    public string NombreTarea { get; set; }

    public bool EstaCompleta { get; set; }

    public int CategoriaId { get; set; }
}
