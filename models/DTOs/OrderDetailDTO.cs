using System;
using System.Collections.Generic;

namespace prueba_tecnica_api.models;

public class OrderDetailDTO
{
    public ushort CantidadEgresados { get; set; }

    public string? Nombre { get; set; }

    public decimal Precio { get; set; }

    public decimal PrecioTotal { get; set; }
}