using System.Security.AccessControl;
using System.Security.Cryptography;
using AvaliarMusica.Data;

namespace AvaliarMusica.View;

public class PaginacaoAvaliacoes
{
    public static void Paginacao(BD bd)
    {
        const int primeiraPagina = 1;
        const int tamanhoPagina = 2;
        int maxPagina = (int)Math.Ceiling((double)bd.Avaliacoes.Count() / tamanhoPagina);
        int paginaAtual = primeiraPagina;
        var tecla = new ConsoleKey();
        while (tecla != ConsoleKey.Enter)
        {
            Console.Clear();
            var paginacao = bd.Avaliacoes.OrderByDescending(n => n.NotaBanda)
                .Skip((paginaAtual - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToList();
            foreach (var pagina in paginacao)
            {
                pagina.VisualizarInfo();
            }
            if (paginaAtual == 1)
                Console.WriteLine("     Pressione ENTER para voltar ao menu!   ->");
            else if (paginaAtual == maxPagina)
                Console.WriteLine("<-   Pressione ENTER para voltar ao menu!     ");
            else
                Console.WriteLine("<-   Pressione ENTER para voltar ao menu!   ->");
            tecla = Console.ReadKey(true).Key;

            if (tecla.Equals(ConsoleKey.RightArrow) && paginaAtual < maxPagina)
                paginaAtual += 1;
            else if (tecla.Equals(ConsoleKey.LeftArrow) && paginaAtual > primeiraPagina)
                paginaAtual -= 1;
        }
        Console.Clear();

    }
}