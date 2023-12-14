using api.Lista.PRO.Context;
using api.Lista.PRO.Interfaces;
using api.Lista.PRO.Models;

namespace api.Lista.PRO.Repository
{
    public class PreventivaRepository : RepositoryBase<Preventiva>, IPreventiva
    {
        public PreventivaRepository(ContextData context) : base(context)
        {
        }
    }
}
