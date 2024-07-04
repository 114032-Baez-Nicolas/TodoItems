using System;
using System.Collections.Generic;

namespace DbFirstPrueba.ModelsDatabase;

public partial class TodoItem
{
    public Guid Id { get; set; }

    public string NombreTarea { get; set; } = null!;

    public bool EstaCompleta { get; set; }

    public int CategoriaId { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;
}
