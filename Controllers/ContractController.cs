using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using prueba_tecnica_api.models;

namespace prueba_tecnica_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractController : ControllerBase
{

    private readonly PruebaTecnicaDbContext _dbContext;

    public ContractController(PruebaTecnicaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("/GetContract", Name="GetContract")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContractDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContractDTO>> GetContract(int Id)
    {
        try
        {
            Contract contract = _dbContext.Contracts
                                    .Where(c => c.Enabled == true && c.Deleted == false)
                                    .Include(c => c.Contractitems)
                                    .ThenInclude(ci => ci.Item)
                                    .First(c => c.Id == Id);

            ContractDTO contractDTO = (ContractDTO)contract;

            return Ok(contractDTO);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound();
        }
    }
}