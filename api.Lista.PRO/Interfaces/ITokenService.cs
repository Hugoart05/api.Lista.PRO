using api.Lista.PRO.Models;

namespace api.Lista.PRO.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(Usuario usuario);

    }
}
