namespace api.Lista.PRO.Models
{
    public class Condominio
    {
        public Condominio()
        {
            Equipamentos = new List<Equipamento>();
            ManutencoesPreventivas = new List<Preventiva>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Endereco Endereco { get; set; }
        public List<Equipamento> Equipamentos { get; set; }

        public List<Preventiva> ManutencoesPreventivas { get; set; }
        
    }
}
