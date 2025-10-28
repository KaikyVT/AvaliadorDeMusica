using AvaliarMusica.Data;

namespace AvaliarMusica.Controller;

public class AdicionarExtra
{
    public static void Adicionar(BD bd)
    {
        Console.Clear();
        Console.WriteLine("Digite o nome da banda/artista da qual você deseja adicionar um extra:");
        string nome = LoopsVerificacao.VerificaNome();
        Console.WriteLine($"Deseja adicionar um extra à {nome}?");
        Console.WriteLine("P.S: Tenha em mente que isso adicionará na primeira avaliação com esse nome de banda/artista!");
        Console.WriteLine("[1] Sim");
        Console.WriteLine("[2] Não");
        int escolha = VerificarEscolha.Verificar(1, 2);
        if (bd.Avaliacoes.Any(n => n.NomeBanda.Equals(nome)) && escolha == 1)
        {
            var bandaAddExtra = bd.Avaliacoes.FirstOrDefault(n => n.NomeBanda.Equals(nome));
            var extrasNovos = LoopsVerificacao.VerificaAdicionarPro();
            foreach (var extra in extrasNovos)
            {
                bandaAddExtra.AdicionarPro(extra);
            }
            bd.Salvar();
        }
    }
}