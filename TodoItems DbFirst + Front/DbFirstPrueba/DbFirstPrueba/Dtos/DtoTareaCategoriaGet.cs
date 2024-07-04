using DbFirstPrueba.ModelsDatabase;

namespace DbFirstPrueba.Dtos;

public class DtoTareaCategoriaGet
{
    public Guid Id { get; set; }
    public string NombreTarea { get; set; }
    public string CategoriaName { get; set; }
}
