using api.Lista.PRO.Models;

namespace api.Lista.PRO.Interfaces
{
    public interface IEquipamento : IBaseReposiory<Equipamento>
    {
        public Task<List<Equipamento>> PorStringValue(string condominio);
    }
}
