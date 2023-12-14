using api.Lista.PRO.Context;
using api.Lista.PRO.Interfaces;
using api.Lista.PRO.Models;

namespace api.Lista.PRO.Repository
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEndereco
    {
        public EnderecoRepository(ContextData context) : base(context)
        {
        }
    }
}
