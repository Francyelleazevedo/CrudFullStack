using Microsoft.AspNetCore.Mvc;
using CadastroCliente.Classes;
using Dominio.Interfaces;
using Api.Dto;
using CadastroCliente.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IService<Cliente> _baseClienteService;

        public ClienteController(IService<Cliente> baseClienteService)
        {
            _baseClienteService = baseClienteService;
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] CreateClienteDto cliente) //passar um json de cliente
        {
            if (cliente == null)
                return NotFound();

            return Execute(() => _baseClienteService.Add<CreateClienteDto, ClienteDto, ClienteValidator>(cliente));
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] ClienteDto cliente)
        {
            if (cliente == null)
                return NotFound();
            //cliente dto é a entrada e cliente a saida
            return Execute(() => _baseClienteService.Update<ClienteDto, Cliente, ClienteValidator>(cliente));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseClienteService.Get<ClienteDto>());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseClienteService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        //mensagem de erro ou sucesso
        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

