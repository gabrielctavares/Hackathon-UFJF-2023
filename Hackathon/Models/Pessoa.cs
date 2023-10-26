namespace Hackathon.Models;

    public abstract class Pessoa 
    {

            public int Id { get; set; }
        
            public virtual string Nome { get; set; }
        
            public int EnderecoId { get; set; }
            
            public virtual Endereco Endereco { get; set; }
            
    }