
namespace api.Lista.PRO.Models
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }

        public int CondominioId { get; set; }
        public Condominio Condominio { get; set; }


    }
}