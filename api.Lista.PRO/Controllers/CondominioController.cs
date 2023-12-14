using api.Lista.PRO.Interfaces;
using api.Lista.PRO.Models;
using api.Lista.PRO.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Lista.PRO.Controllers
{
    
   
    public class CondominioController : ControllerBase
    {
        private readonly ICondominio _condominio;

        public CondominioController(ICondominio condominio)
        {
            _condominio = condominio;
        }

        [HttpGet]
        public async Task<IActionResult> Condominios()
        {
            var condominios = _condominio.PegarTodos();
            
            return Ok(condominios);
        }

        [HttpGet]
        public async Task<IActionResult> Condominio(int id)
        {
            var condominio = _condominio.DadosDoCondominio(id);
            if (condominio == null)
            {
                return NotFound(new { message = "Condominio inexistente" });
            }
            return Ok(condominio);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CondominioViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var newCondominio = await _condominio.CriarCondominio(viewModel);
                if (newCondominio)
                {
                    return Ok(new { message = "Condomínio criado com sucesso!" });
                }
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Deletar(int id)
        {
            var condominio = _condominio.PegarUm(id);
            if (condominio != null)
            {
                if (_condominio.Deletar(condominio))
                {
                    return Ok(new { message = "Condominio deletado com sucesso!" });
                }

                return NoContent();
            }

            return NotFound(new { message = "Condominio não existe!" });
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] Condominio condominio)
        {
            if (ModelState.IsValid)
            {
                var condominioEditar = _condominio.Editar(condominio);

                if (condominioEditar)
                    return Ok(new { message = "Condominio editado!" });

            }
            return BadRequest();
        }
    }
}
