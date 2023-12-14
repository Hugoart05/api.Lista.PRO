using System.ComponentModel.DataAnnotations;

namespace api.Lista.PRO.Models
{
    public class Usuario
    {
        public Usuario()
        {
            Preventivas = new List<Preventiva>();
        }
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        public string Email{ get; set; }
        public string Senha { get; set; }
        public List<Preventiva>? Preventivas  { get; set; }
        public string Role {  get; set; }
    }
}