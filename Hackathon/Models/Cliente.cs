namespace Hackathon.Models;

    public  class Cliente 
    {

            public int Id { get; set; }
        
            public virtual string Nome { get; set; }
        
            public virtual long Cpf { get; set; }
        
            public virtual double Saldo { get; set; }
        
            public virtual int QuantidadeCompras { get; set; }
            
    }