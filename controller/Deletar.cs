using AvaliarMusica.Data;

namespace AvaliarMusica.Controller;

public class Deletar
{
    public static void DeletarBanda(BD bd)
    {
        Console.Clear();
        Console.WriteLine("Digite o nome da banda da qual você deseja deletar:");
        string nome = LoopsVerificacao.VerificaNome();
        Console.WriteLine($"Deseja deletar a avaliação de {nome}?");
        Console.WriteLine("P.S: Tenha em mente que isso apagará qualquer avaliação com esse nome de banda!");
        Console.WriteLine("[1] Sim");
        Console.WriteLine("[2] Não");
        int escolha = VerificarEscolha.Verificar(1, 2);
        if (bd.Avaliacoes.Any(n => n.NomeBanda.Equals(nome)) && escolha == 1)
        {
            var bandaDeletada = bd.Avaliacoes.First(n => n.NomeBanda.Equals(nome));
            bd.Avaliacoes.Remove(bandaDeletada);
            bd.Salvar();
        }

    }
}