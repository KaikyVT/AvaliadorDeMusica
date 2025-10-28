using AvaliarMusica.Data;

namespace AvaliarMusica.Controller;

public class AdicionarTop5
{
    public static void Adicionar(BD bd)
    {
        Console.Clear();
        Console.WriteLine("Digite o nome da banda/artista da qual você deseja adicionar/modificar um top 5:");
        string nome = LoopsVerificacao.VerificaNome();
        Console.WriteLine($"Deseja adicionar/modificar um top5 à {nome}?");
        Console.WriteLine("P.S: Tenha em mente que isso adicionará na primeira avaliação com esse nome de banda/artista!");
        Console.WriteLine("[1] Sim");
        Console.WriteLine("[2] Não");
        int escolha = VerificarEscolha.Verificar(1, 2);
        if (bd.Avaliacoes.Any(n => n.NomeBanda.Equals(nome)) && escolha == 1)
        {
            var bandaAddPro = bd.Avaliacoes.FirstOrDefault(n => n.NomeBanda.Equals(nome));
            var top5Novos = LoopsVerificacao.VerificaMontarTop5();
            bandaAddPro.MontarTop5(top5Novos);
            bd.Salvar();
        }
    }
}