using System;
using System.Collections.Generic;

namespace prueba_tecnica_api.models;

public partial class Contract
{
    public int Id { get; set; }

    public string CourseCode { get; set; } = null!;

    public DateTime FechaAlta { get; set; }

    public int Estado { get; set; }

    public ushort CantidadEgresados { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public string? MedioEntrega { get; set; }

    public string? Vendedor { get; set; }

    public string? ColegioNivel { get; set; }

    public string? ColegioNombre { get; set; }

    public string? ColegioCurso { get; set; }

    public string? ColegioLocalidad { get; set; }

    public string? Comision { get; set; }

    public decimal Total { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool Enabled { get; set; }

    public bool Deleted { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<Contractitem> Contractitems { get; set; } = new List<Contractitem>();
}
