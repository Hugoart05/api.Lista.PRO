using System.ComponentModel.DataAnnotations;

namespace api.Lista.PRO.Models
{
    public class Preventiva
    {
        public Preventiva()
        {
            DataExecucao = DateTime.Now;
        }
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataExecucao { get; set; }

        public int EquipamentoId { get; set; }
        public Equipamento Equipamento { get; set; }

        [Required]
        public int UsuarioId{ get; set; }
        
        public Usuario Usuario { get; set; }
    }
}