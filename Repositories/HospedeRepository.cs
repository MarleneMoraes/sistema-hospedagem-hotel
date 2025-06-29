using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace DesafioProjetoHospedagem.Repositories;

public class HospedeRepository
{
    private readonly string _filePath;
    private List<Hospede> _hospedesCache;

    public HospedeRepository(string filePath = "./Data/Hospedes.json")
    {
        _filePath = Path.Combine(AppContext.BaseDirectory, filePath);
        _hospedesCache = CarregarHospedes();
    }

    private List<Hospede> CarregarHospedes()
    {
        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]");
            return new List<Hospede>();
        }

        string jsonString = File.ReadAllText(_filePath);

        return JsonSerializer.Deserialize<List<Hospede>>(jsonString) ?? new List<Hospede>();
    }

    private void SalvarHospedes()
    {
        string jsonString = JsonSerializer.Serialize(_hospedesCache, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, jsonString);
    }

    public void AdicionarHospede(Hospede hospede)
    {
        _hospedesCache.Add(hospede);
        SalvarHospedes();
        Console.WriteLine($"Hóspede '{hospede.NomeCompleto}' adicionado com sucesso.");
    }

    public List<Hospede> ObterTodosHospedes()
    {
        return _hospedesCache;
    }

    public Hospede ObterHospedePorId(Guid id)
    {
        return _hospedesCache.FirstOrDefault(h => h.Id == id);
    }

    public Hospede ObterHospedePorNomeCompleto(string nomeCompleto)
    {
        return _hospedesCache.FirstOrDefault(h => h.NomeCompleto.Equals(nomeCompleto, StringComparison.OrdinalIgnoreCase));
    }


    // Update (Atualizar)
    public void AtualizarHospede(Hospede hospedeAtualizado)
    {
        Hospede hospedeExistente = _hospedesCache.FirstOrDefault(h => h.Id == hospedeAtualizado.Id);
        if (hospedeExistente != null)
        {
            hospedeExistente.Nome = hospedeAtualizado.Nome;
            hospedeExistente.Sobrenome = hospedeAtualizado.Sobrenome;
            SalvarHospedes();
            Console.WriteLine($"Hóspede '{hospedeAtualizado.NomeCompleto}' atualizado com sucesso.");
        }
        else
        {
            Console.WriteLine($"Hóspede com ID '{hospedeAtualizado.Id}' não encontrado para atualização.");
        }
    }

    public void RemoverHospede(Guid idHospede)
    {
        Hospede hospedeParaRemover = _hospedesCache.FirstOrDefault(h => h.Id == idHospede);
        if (hospedeParaRemover != null)
        {
            _hospedesCache.Remove(hospedeParaRemover);
            SalvarHospedes();
            Console.WriteLine($"Hóspede '{hospedeParaRemover.NomeCompleto}' removido com sucesso.");
        }
        else
        {
            Console.WriteLine($"Hóspede com ID '{idHospede}' não encontrado para remoção.");
        }
    }
}