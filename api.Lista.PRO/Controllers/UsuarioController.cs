using api.Lista.PRO.Interfaces;
using api.Lista.PRO.Models;
using api.Lista.PRO.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Lista.PRO.Controllers
{
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuario;
        private readonly IPreventiva _manutencao;

        public UsuarioController(IUsuario usuario, IPreventiva manutencao)
        {
            _usuario = usuario;
            _manutencao = manutencao;
        }

        [HttpGet]

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Usuarios()
        {
            var usuarios = _usuario.PegarTodos();
            return Ok(usuarios);
        }

        [HttpGet]
        public async Task<IActionResult> Usuario(int id)
        {
            var tecnico = _usuario.PegarUm(id);
            if (tecnico == null)
            {
                return NotFound(new { message = "Tecnico inexistente" });
            }
            return Ok(tecnico);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarServicoManutencao(PreventivaViewModel manutencao)
        {
            if(ModelState.IsValid)
            {
                var registro = _manutencao.Criar(manutencao.ToPreventiva());
                if (registro)
                {
                    return Ok(new { message = "Registro concluido!" });
                }
                return BadRequest();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(UserRegisterViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var newusuario = _usuario.Criar(usuario.ToUsuario());
                if (newusuario)
                {
                    return Ok(new { message = "Tecnico criado com sucesso" });
                }
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Deletar(int id)
        {
            var usuario = _usuario.PegarUm(id);
            if (usuario != null)
            {
                _usuario.Deletar(usuario);
                return Ok(new { message = "Tecnico deletado com sucesso!" });
            }

            return NotFound(new { message = "Tecnico não existe!" });
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioEditar = _usuario.Editar(usuario);
                if (usuarioEditar)
                {
                    return Ok(new { message = "Tecnico editado!" });
                }
            }
            return BadRequest();
        }
    }
}
