namespace DesafioProjetoHospedagem.Models;

public class Hospede
{
    private List<Hospede> _hospedesRegistrados = new List<Hospede>();
    public Hospede() { }

    public Hospede(string nome)
    {
        Nome = nome;
    }

    public Hospede(string nome, string sobrenome)
    {
        Nome = nome;
        Sobrenome = sobrenome;
    }

    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();

    private void CadastrarHospedes(string nome, string sobrenome) {
        _hospedesRegistrados.Add(new Hospede(nome, sobrenome));

        Console.WriteLine($"Hóspede '{novoHospede.NomeCompleto}' adicionado com sucesso.");
    }

    public List<Hospede> ObterHospedesRegistrados()
    {
        return _hospedesRegistrados;
    }

    public void ExibirHospedes()
    {
        if (_hospedesRegistrados.Any())
        {
            Console.WriteLine("\nHóspedes Registrados:");
            foreach (var hospede in _hospedesRegistrados)
            {
                Console.WriteLine($"- {hospede.NomeCompleto}");
            }
        }
        else
        {
            Console.WriteLine("\nNenhum hóspede registrado ainda.");
        }
    }
}