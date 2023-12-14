using api.Lista.PRO.Models;
using System.ComponentModel.DataAnnotations;

namespace api.Lista.PRO.ViewModels
{
    public class PreventivaViewModel
    {
        public string? Descricao { get; set; }
        public DateTime DataExecucao { get; set; }

        [Required]
        public int UsuarioId { get; set; }



        public Preventiva ToPreventiva()
        {
            return new Preventiva
            {
                Descricao = Descricao,
                DataExecucao = DataExecucao,
                UsuarioId = UsuarioId
            };
        }
    }
}
