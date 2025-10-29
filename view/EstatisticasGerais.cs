using AvaliarMusica.Data;

namespace AvaliarMusica.View;

public class EstatisticasGerais
{
    public static void VisualizarEstatisticas(BD bd)
    {
        Console.Clear();
        var melhorBanda = bd.Avaliacoes.MaxBy(n => n.NotaBanda);
        var piorBanda = bd.Avaliacoes.MinBy(n => n.NotaBanda);
        var mediaBandas = bd.Avaliacoes.Average(n => n.NotaBanda);
        Console.WriteLine($"😺 -> A melhor banda/artista de acordo com este que vos fala é {melhorBanda.NomeBanda} com {melhorBanda.NotaBanda} de nota!");
        Console.WriteLine($"😺 -> Já a pior banda/artista de acordo com este que vos fala é {piorBanda.NomeBanda} com {piorBanda.NotaBanda} de nota...");
        Console.WriteLine($"😺 -> A avaliação média registrada é de {mediaBandas:f}");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu");
        Console.ReadKey();
    }
}