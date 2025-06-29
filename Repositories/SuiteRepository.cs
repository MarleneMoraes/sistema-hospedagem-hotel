using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace DesafioProjetoHospedagem.Repositories;

public class SuiteRepository
{
    private readonly string _filePath;

    public SuiteRepository(string filePath = "./Data/Suites.json")
    {
        _filePath = Path.Combine(AppContext.BaseDirectory, filePath);
    }

    public List<Suite> CarregarSuitesComQuantidade()
    {
        if (!File.Exists(_filePath))
        {
            Console.WriteLine($"Erro: Arquivo '{_filePath}' não encontrado. Criando um arquivo JSON vazio.");
            File.WriteAllText(_filePath, "[]");
            return new List<Suite>();
        }

        string jsonString = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Suite>>(jsonString);
    }
}