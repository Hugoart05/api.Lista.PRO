using api.Lista.PRO.Context;
using api.Lista.PRO.Interfaces;
using api.Lista.PRO.Models;
using api.Lista.PRO.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Lista.PRO.Repository
{
    public class CondominioRepository : RepositoryBase<Condominio>, ICondominio
    {
        private readonly ContextData _contextData;
        private readonly IEndereco _endereco;
        public CondominioRepository(ContextData context, ContextData contextData, IEndereco endereco) : base(context)
        {
            _contextData = contextData;
            _endereco = endereco;
        }


        public async Task<bool> CriarCondominio(CondominioViewModel viewModel)
        {
            try
            {
                var condominio = viewModel.ToCondominio();
                _contextData.Condominios.Add(condominio);
                await _contextData.SaveChangesAsync();

                var endereco = viewModel.ToEndereco(condominio.Id);
                _endereco.Criar(endereco);

                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Erro ao criar condomínio:{ex.Message}");
                throw;
            }
            return false;
        }
        public Condominio DadosDoCondominio(int id)
        {
            var condominioCompleto = _contextData.Condominios
                .Where(x => x.Id == id)
                .Include(x => x.Endereco)
                .Include(x => x.Equipamentos)
                .Include(x => x.ManutencoesPreventivas)
                .FirstOrDefault();
            return condominioCompleto;
        }
    }
}
