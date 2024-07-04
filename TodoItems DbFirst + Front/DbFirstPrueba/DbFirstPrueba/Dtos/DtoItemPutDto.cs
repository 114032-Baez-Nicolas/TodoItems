namespace DbFirstPrueba.Dtos;

public class DtoItemPutDto
{
    public Guid Id { get; set; }

    public string NombreTarea { get; set; } = null!;

    public bool EstaCompleta { get; set; }

    public int CategoriaId { get; set; }
}
