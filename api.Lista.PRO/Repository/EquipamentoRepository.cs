using api.Lista.PRO.Context;
using api.Lista.PRO.Interfaces;
using api.Lista.PRO.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Lista.PRO.Repository
{
    public class EquipamentoRepository : RepositoryBase<Equipamento>, IEquipamento
    {
        private readonly ContextData _contextData;
        private readonly ILogger<EquipamentoRepository> _logger;
        public EquipamentoRepository(ContextData context, ContextData contextData) : base(context)
        {
            _contextData = contextData;

        }

        public async Task<List<Equipamento>> PorStringValue(string nome)
        {
            var equipamentosStringValue = await _contextData
                .Equipamentos
                .Where(x => x.Condominio.Nome.Contains(nome) || x.Nome.Contains(nome) || x.NumeroDeSerie.Contains(nome))
                .Distinct()
                .ToListAsync();

            return equipamentosStringValue;

        }

        public List<Equipamento> PorNome(string nomeDoEquipamento)
        {
            throw new NotImplementedException();
        }
    }
}
