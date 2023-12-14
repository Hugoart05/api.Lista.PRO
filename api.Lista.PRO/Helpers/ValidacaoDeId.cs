using api.Lista.PRO.Context;
using api.Lista.PRO.Interfaces;
using Cassandra.DataStax.Graph;

namespace api.Lista.PRO.Helpers
{
    public class ValidacaoDeId : IValidateEntityId
    {
        private readonly ContextData _conn;
        private bool isValid;

        public ValidacaoDeId(ContextData conn)
        {
            _conn = conn;
        }

        

        public bool ValidarCondominio(int id)
        {
            var idValidado = _conn.Condominios.FirstOrDefault(c => c.Id == id);
            if (idValidado == null)
            {
                return false;
            }
            
            return true;
        }

    }
}
