namespace Hackathon.Models;

    public  class PessoaJuridica : Pessoa
    {

            public virtual long Cnpj { get; set; }
            
    }