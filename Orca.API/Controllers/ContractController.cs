using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Orca.API.DTOs;
using Orca.Domain.Entities;
using Orca.Domain.Interfaces;

namespace Orca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;
        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContract(Guid id)
        {
            var contract = await _contractService.GetContract(id);
            if (contract == null)
            {
                return NotFound();
            }
            return Ok(contract);
        }

        [HttpPost]
        public async Task<AddContractResponse> SaveContract([FromBody] Contract contract)
        {
            //if (contract == null)
            //{
            //    return BadRequest();
            //}
            await _contractService.SaveContract(contract);
            return JsonSerializer.Deserialize<AddContractResponse>(contract.ToString());
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {

        }
    }
}
