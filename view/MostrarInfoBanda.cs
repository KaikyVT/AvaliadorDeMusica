using AvaliarMusica.Controller;
using AvaliarMusica.Data;

namespace AvaliarMusica.View;

public class MostrarInfoBanda
{
    public static void SelecionaBanda(BD bd)
    {
        Console.WriteLine("Digite o nome da banda/artista da qual você deseja adicionar/modificar um top 5:");
        string nome = LoopsVerificacao.VerificaNome();
        if (nome.Equals("/all"))
        {
            foreach (var banda in bd.Avaliacoes)
            {
                banda.VisualizarInfo();
            }
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
            Console.ReadKey();
            return;
        }
        if (nome.Equals("/pagination"))
        {
            PaginacaoAvaliacoes.Paginacao(bd);
            return;
        }
        var bandaMostra = bd.Avaliacoes.FirstOrDefault(n => n.NomeBanda.Equals(nome));
        if (bd.Avaliacoes.Contains(bandaMostra))
            bandaMostra.VisualizarInfo();
        else
            Console.WriteLine("Não tem tal banda/artista...");
        Console.WriteLine("Clique em qualquer lugar para voltar para o menu!");
        Console.ReadKey();
        Console.Clear();
    }
}