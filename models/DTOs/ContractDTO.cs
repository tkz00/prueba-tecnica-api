using System;
using System.Collections.Generic;

namespace prueba_tecnica_api.models;

public class ContractDTO
{
    public string CourseCode { get; set; } = null!;

    public DateTime FechaAlta { get; set; }

    public string? ColegioNivel { get; set; }

    public string? ColegioNombre { get; set; }

    public string? ColegioCurso { get; set; }

    public string? ColegioLocalidad { get; set; }

    public List<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();

    public decimal Total { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public static explicit operator ContractDTO(Contract contract)
    {
        return new ContractDTO{
            CourseCode = contract.CourseCode,
            FechaAlta = contract.FechaAlta,
            ColegioNivel = contract.ColegioNivel,
            ColegioNombre = contract.ColegioNombre,
            ColegioCurso = contract.ColegioCurso,
            ColegioLocalidad = contract.ColegioLocalidad,
            Total = contract.Total,
            FechaEntrega = contract.FechaEntrega,
            OrderDetails = contract.Contractitems
                                .Where(ci => ci.Enabled == true && ci.Deleted == false)
                                .Select(ci => new OrderDetailDTO{
                                    CantidadEgresados = contract.CantidadEgresados,
                                    Nombre = ci.Item.Nombre,
                                    Precio = ci.Item.Precio,
                                    PrecioTotal = contract.Total
                                })
                                .ToList()
        };
    }
}