using api.Lista.PRO.Models;

namespace api.Lista.PRO.ViewModels
{
    public class UserRegisterViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }


        public Usuario ToUsuario()
        {
            return new Usuario
            {
                Nome = Nome,
                Email = Email,
                Senha = Senha,
                Role = Role
            };
        }
    }
}
