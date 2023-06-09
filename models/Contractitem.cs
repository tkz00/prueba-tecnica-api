﻿using System;
using System.Collections.Generic;

namespace prueba_tecnica_api.models;

public partial class Contractitem
{
    public int Id { get; set; }

    public int ContractId { get; set; }

    public int ItemId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool Enabled { get; set; }

    public bool Deleted { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Contract Contract { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;
}
