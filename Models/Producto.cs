using System;
using System.Collections.Generic;

namespace Store.Models;

public partial class Producto
{
    public int IdProduct { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }
}
