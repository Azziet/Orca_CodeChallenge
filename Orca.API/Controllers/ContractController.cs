using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]
        public IActionResult GetContract(Guid id)
        {
            Dictionary<string, object> contracts = new();
            var contract = _contractService.GetContract(id);
            contracts.Add("Contracts", contract);
            if (contract == null)
            {
                return NotFound();
            }
            return Ok(contracts);
        }

        [HttpPost]
        public IActionResult SaveContract([FromBody] Domain.Entities.Contract contract)
        {
            if (_contractService.SaveContract(contract))
            {
                return Ok();
            }
            return BadRequest();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (_contractService.RemoveContract(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
