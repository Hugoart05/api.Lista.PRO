using api.Lista.PRO.Models;
using api.Lista.PRO.ViewModels;

namespace api.Lista.PRO.Interfaces
{
    public interface ICondominio : IBaseReposiory<Condominio>
    {
        Task<bool> CriarCondominio(CondominioViewModel condominio);
        public Condominio DadosDoCondominio(int id);
    }
}
