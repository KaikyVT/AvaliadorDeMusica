using AvaliarMusica.Data;

namespace AvaliarMusica.View;

public class PaginacaoAvaliacoes
{
    public static void Paginacao(BD bd)
    {
        const int tamanhoPagina = 2;
        int totalRegistros = bd.Avaliacoes.Count();

        if (totalRegistros == 0)
        {
            Console.WriteLine("Nenhuma avaliação encontrada.");
            Console.ReadKey();
            return;
        }

        int maxPagina = (int)Math.Ceiling((double)totalRegistros / tamanhoPagina);
        int paginaAtual = 1;
        ConsoleKey tecla = ConsoleKey.NoName;

        while (tecla != ConsoleKey.Enter)
        {
            Console.Clear();

            var paginacao = bd.Avaliacoes
                .OrderByDescending(n => n.NotaBanda)
                .Skip((paginaAtual - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToList();

            Console.WriteLine($"--- Página {paginaAtual} de {maxPagina} ---");
            foreach (var avaliacao in paginacao)
            {
                avaliacao.VisualizarInfo();
            }

            string navegação = "";
            if (paginaAtual > 1) navegação += "<- (Seta Esquerda) ";
            navegação += "| ENTER para voltar |";
            if (paginaAtual < maxPagina) navegação += " (Seta Direita) ->";

            Console.WriteLine("\n" + navegação);

            tecla = Console.ReadKey(true).Key;

            if (tecla == ConsoleKey.RightArrow && paginaAtual < maxPagina)
                paginaAtual++;
            else if (tecla == ConsoleKey.LeftArrow && paginaAtual > 1)
                paginaAtual--;
        }
    }
}