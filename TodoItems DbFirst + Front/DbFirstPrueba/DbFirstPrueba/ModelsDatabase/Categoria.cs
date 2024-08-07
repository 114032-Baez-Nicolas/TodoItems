﻿using System;
using System.Collections.Generic;

namespace DbFirstPrueba.ModelsDatabase;

public partial class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
}
