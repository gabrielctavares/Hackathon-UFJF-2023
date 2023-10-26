namespace Hackathon.Models;

    public  class Endereco 
    {

            public int Id { get; set; }
        
            public virtual string Logradouro { get; set; }
        
            public virtual string Complemento { get; set; }
        
            public virtual string Bairro { get; set; }
        
            public virtual string Cidade { get; set; }
        
            public virtual string Estado { get; set; }
        
            public virtual string Cep { get; set; }
            
    }