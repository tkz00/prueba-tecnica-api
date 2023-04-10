using System;
using System.Collections.Generic;

namespace prueba_tecnica_api.models;

public partial class Item
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public decimal Precio { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool Enabled { get; set; }

    public bool Deleted { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<Contractitem> Contractitems { get; } = new List<Contractitem>();
}
