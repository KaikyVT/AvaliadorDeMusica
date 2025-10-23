using AvaliarMusica.Data;

namespace AvaliarMusica.Controller;

public class AdicionarPro
{
    public static void Adicionar(BD bd)
    {
        Console.Clear();
        Console.WriteLine("Digite o nome da banda da qual você deseja adicionar um pro:");
        string nome = LoopsVerificacao.VerificaNome();
        Console.WriteLine($"Deseja adicionar um pro à {nome}?");
        Console.WriteLine("P.S: Tenha em mente que isso adicionará na primeira avaliação com esse nome de banda!");
        Console.WriteLine("[1] Sim");
        Console.WriteLine("[2] Não");
        int escolha = VerificarEscolha.Verificar(1, 2);
        if (bd.Avaliacoes.Any(n => n.NomeBanda.Equals(nome)) && escolha == 1)
        {
            var bandaAddPro = bd.Avaliacoes.FirstOrDefault(n => n.NomeBanda.Equals(nome));
            var prosNovos = LoopsVerificacao.VerificaAdicionarPro();
            foreach (var pro in prosNovos)
            {
                bandaAddPro.AdicionarPro(pro);
            }
            bd.Salvar();
        }
    }
}