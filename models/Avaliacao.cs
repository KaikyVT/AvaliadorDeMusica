using System.Text.Json.Serialization;

namespace AvaliarMusica.Models;

public class Avaliacao
{
    [JsonInclude]
    public string NomeBanda { get; protected set; }
    [JsonInclude]
    public double NotaBanda { get; protected set; }
    [JsonInclude]
    public Dictionary<string, double> Top5 { get; protected set; }
    [JsonInclude]
    public List<string> Pros { get; protected set; }
    [JsonInclude]
    public List<string> Contras { get; protected set; }
    [JsonInclude]
    public List<string> Extras { get; protected set; }

    public void SetNomeBanda(string nomeBanda)
    {
        if (string.IsNullOrEmpty(nomeBanda) || string.IsNullOrWhiteSpace(nomeBanda))
            throw new Exception("Nome da Banda");
        NomeBanda = nomeBanda;
    }
    public void SetNotaBanda(double notaBanda)
    {
        if (notaBanda < 0 || notaBanda > 10)
            throw new ArgumentOutOfRangeException("Range inválido para notaBanda");
        NotaBanda = notaBanda;
    }
    public void AdicionarPro(string pro)
    {
        if (string.IsNullOrEmpty(pro) || string.IsNullOrWhiteSpace(pro))
            throw new Exception("Pro novo");
        Pros.Add(pro);
    }
    public void AdicionarPro(List<string> pros)
    {
        foreach (var pro in pros)
        {
            Pros.Add(pro);
        }
    }
    public void AdicionarContra(string contra)
    {
        if (string.IsNullOrEmpty(contra) || string.IsNullOrWhiteSpace(contra))
            throw new Exception("Contra novo");
        Contras.Add(contra);
    }
    public void AdicionarContra(List<string> contras)
    {
        foreach (var contra in contras)
        {
            Contras.Add(contra);
        }
    }
    public void AdicionarExtra(string extra)
    {
        if (string.IsNullOrEmpty(extra) || string.IsNullOrWhiteSpace(extra))
            throw new Exception("Extra novo");
        Extras.Add(extra);
    }
    public void AdicionarExtras(List<string> extras)
    {
        foreach (var extra in extras)
        {
            Extras.Add(extra);
        }
    }
    public void MontarTop5(Dictionary<string, double> top5)
    {
        foreach (var musica in top5)
        {
            Top5.Add(musica.Key, musica.Value);
        }
    }
    public void VisualizarInfo()
    {
        Console.WriteLine("==================================================================");
        Console.Write($"Nome: {NomeBanda} ≈ ");
        if (NotaBanda == 10)
            Console.ForegroundColor = ConsoleColor.Blue;
        else if (NotaBanda >= 8)
            Console.ForegroundColor = ConsoleColor.Green;
        else if (NotaBanda >= 6)
            Console.ForegroundColor = ConsoleColor.Yellow;
        else if (NotaBanda >= 4)
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        else if (NotaBanda >= 2)
            Console.ForegroundColor = ConsoleColor.DarkGray;
        else
            Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(NotaBanda.ToString("F2"));
        Console.ForegroundColor = ConsoleColor.White;
        {

        }
        ;
        int indice = 1;
        foreach (var top in Top5)
        {
            Console.WriteLine($"{indice} - {top.Key} {top.Value}/10");
            indice++;
        }
        Console.WriteLine();
        Console.WriteLine("Pros:");
        foreach (var pro in Pros)
        {
            Console.WriteLine($"- {pro}");
        }
        Console.WriteLine();
        Console.WriteLine("Contras:");
        foreach (var contra in Contras)
        {
            Console.WriteLine($"- {contra}");
        }
        Console.WriteLine();
        Console.WriteLine("Extra:");
        foreach (var extra in Extras)
        {
            Console.WriteLine($"- {extra}");
        }
        Console.WriteLine("==================================================================");

    }

    public Avaliacao(string nomeBanda, double notaBanda)
    {
        SetNomeBanda(nomeBanda);
        SetNotaBanda(notaBanda);
        Pros = new();
        Contras = new();
        Extras = new();
        Top5 = new();
    }
}