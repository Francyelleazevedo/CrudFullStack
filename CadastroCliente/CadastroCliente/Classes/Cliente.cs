using Dominio.Entity;

namespace CadastroCliente.Classes
{
    public class Cliente : BaseEntity
    { 
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Cidade { get; set; }
    }
}
