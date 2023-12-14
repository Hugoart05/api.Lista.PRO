
using System.ComponentModel.DataAnnotations;

namespace api.Lista.PRO.Models
{
    public class Equipamento
    {
        public int EquipamentoId { get; set; }
        public string Nome { get; set; }
        [Required]
        public string NumeroDeSerie { get; set; }
        public string? Descricao { get; set; }
        public string? Ip { get; set; }
        public string? Mac{ get; set; }
        public string? Usuario { get; set; }
        public string? Senha { get; set; }
        public List<Preventiva>? PreventivasRealizadas {  get; set; }

        public int CondominioId { get; set; }
        public Condominio Condominio { get; set; }

        
    }
}