namespace DesafioProjetoHospedagem.Models;

public class Hospede
{

    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();

    public Hospede()
    {
        Id = Guid.NewGuid();
    }

    public Hospede(string nome) : this()
    {
        Nome = nome;
    }

    public Hospede(string nome, string sobrenome) : this()
    {
        Nome = nome;
        Sobrenome = sobrenome;
    }
    
}