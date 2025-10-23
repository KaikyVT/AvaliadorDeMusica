using System.Text.Json;
using AvaliarMusica.Models;

namespace AvaliarMusica.Data;

public class BD
{
    public static string caminhoArquivo = Path.Combine(Environment.CurrentDirectory, "data/avaliacoes.json");
    public List<Avaliacao> Avaliacoes { get; protected set; }

    public void Salvar(Avaliacao avaliacao)
    {
        Avaliacoes.Add(avaliacao);
        string json = JsonSerializer.Serialize(Avaliacoes, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(caminhoArquivo, json);
    }

    public void Salvar()
    {
        string json = JsonSerializer.Serialize(Avaliacoes, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(caminhoArquivo, json);
    }
    public static List<Avaliacao> CarregarAvaliacoes()
    {
        if (!File.Exists(caminhoArquivo))
            return new List<Avaliacao>();

        string json = File.ReadAllText(caminhoArquivo);

        if (string.IsNullOrWhiteSpace(json))
            return new List<Avaliacao>();

        return JsonSerializer.Deserialize<List<Avaliacao>>(json) ?? new List<Avaliacao>();
    }


    public BD()
    {
        Avaliacoes = CarregarAvaliacoes();
    }
}