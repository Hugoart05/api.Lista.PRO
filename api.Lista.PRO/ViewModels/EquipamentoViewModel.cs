using api.Lista.PRO.Models;

namespace api.Lista.PRO.ViewModels
{
    public class EquipamentoViewModel
    {
        public int CondominioId { get; set; }
        public string Nome { get; set; }
        public string NumeroDeSerie { get; set; }
        public string? Descricao { get; set; }
        public string? Ip { get; set; }
        public string? Mac { get; set; }
        public string? Usuario { get; set; }
        public string? Senha { get; set; }



        public Equipamento ToEquipamento()
        {
            return new Equipamento
            {
                Nome = Nome,
                NumeroDeSerie = NumeroDeSerie,
                CondominioId = CondominioId,
                Descricao = Descricao,
                Mac = Mac,
                Usuario = Usuario,
                Senha = Senha
            };
        }

    }
}
