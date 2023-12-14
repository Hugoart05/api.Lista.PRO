using api.Lista.PRO.Models;

namespace api.Lista.PRO.ViewModels
{
    public class CondominioViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }


        public Condominio ToCondominio()
        {
            
            return new Condominio
            {
                Nome = Nome,
                Descricao = Descricao,
            };
        }

        public Endereco ToEndereco(int condominioId)
        {
            return new Endereco
            {
                Rua = Rua,
                Cidade = Cidade,
                Numero = Numero,
                CEP = CEP,
                CondominioId = condominioId
            };
        }
    }
}
