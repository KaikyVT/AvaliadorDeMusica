using AvaliarMusica.Data;
using AvaliarMusica.Models;

namespace AvaliarMusica.Controller;

public class Avaliar
{
    public static void AvaliarBanda(BD bd)
    {
        Console.Clear();
        string nome = LoopsVerificacao.VerificaNome();
        double nota = LoopsVerificacao.VerificaNota();
        var pros = LoopsVerificacao.VerificaAdicionarPro();
        var contras = LoopsVerificacao.VerificaAdicionarContra();
        var extras = LoopsVerificacao.VerificaAdicionarExtra();
        Console.WriteLine("Deseja montar o top 5 da banda/artista agora?");
        Console.WriteLine("[1] Sim");
        Console.WriteLine("[2] Não");
        Avaliacao avaliacao = new(nome, nota);
        avaliacao.AdicionarPro(pros);
        avaliacao.AdicionarContra(contras);
        avaliacao.AdicionarExtras(extras);
        int escolha = VerificarEscolha.Verificar(1, 2);
        if (escolha == 1)
        {
            var top5 = LoopsVerificacao.VerificaMontarTop5();
            avaliacao.MontarTop5(top5);
        }
        bd.Salvar(avaliacao);
        Console.WriteLine("Sua banda/artista foi salva!");
        avaliacao.VisualizarInfo();
    }
}