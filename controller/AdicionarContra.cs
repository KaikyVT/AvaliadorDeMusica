using AvaliarMusica.Data;

namespace AvaliarMusica.Controller;

public class AdicionarContra
{
    public static void Adicionar(BD bd)
    {
        Console.Clear();
        Console.WriteLine("Digite o nome da banda da qual você deseja adicionar um contra:");
        string nome = LoopsVerificacao.VerificaNome();
        Console.WriteLine($"Deseja adicionar um contra à {nome}?");
        Console.WriteLine("P.S: Tenha em mente que isso adicionará na primeira avaliação com esse nome de banda!");
        Console.WriteLine("[1] Sim");
        Console.WriteLine("[2] Não");
        int escolha = VerificarEscolha.Verificar(1, 2);
        if (bd.Avaliacoes.Any(n => n.NomeBanda.Equals(nome)) && escolha == 1)
        {
            var bandaAddContra = bd.Avaliacoes.FirstOrDefault(n => n.NomeBanda.Equals(nome));
            var contrasNovos = LoopsVerificacao.VerificaAdicionarContra();
            foreach (var contra in contrasNovos)
            {
                bandaAddContra.AdicionarPro(contra);
            }
            bd.Salvar();
        }
    }
}