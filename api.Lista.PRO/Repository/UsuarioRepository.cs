using api.Lista.PRO.Context;
using api.Lista.PRO.Interfaces;
using api.Lista.PRO.Models;
using NPOI.SS.Formula.Functions;

namespace api.Lista.PRO.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuario
    {
        public UsuarioRepository(ContextData context) : base(context)
        {
        }
    }
}
