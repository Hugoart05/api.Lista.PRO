using api.Lista.PRO.Context;
using api.Lista.PRO.Interfaces;
using api.Lista.PRO.Models;
using api.Lista.PRO.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Lista.PRO.Controllers
{

    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly ContextData _conn;

        public AccountController(ITokenService tokenService, ContextData conn)
        {
            _tokenService = tokenService;
            _conn = conn;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var user = _conn.Usuarios.AsNoTracking().FirstOrDefault(x => x.Email == login.Email);
                if (user != null)
                {
                    if (user.Senha.ToLower() == login.Password.ToLower())
                    {
                        var tokenResponse = _tokenService.GenerateToken(user);
                        return Ok(new {
                                token = tokenResponse,
                                user = user.Nome,
                                id = user.Id,
                                permission = user.Role
                        });
                    }
                }
                return NotFound(new { message = "Usuario não encontrado!" });
            }
            return BadRequest(new { message = "Dados inválidos!" });
        }

    }
}
