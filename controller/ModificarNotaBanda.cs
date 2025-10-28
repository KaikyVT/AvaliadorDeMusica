using AvaliarMusica.Data;

namespace AvaliarMusica.Controller;

public class ModificarNotaBanda
{
    public static void Modificar(BD bd)
    {
        Console.Clear();
        Console.WriteLine("Digite o nome da banda/artista da qual você deseja modificar a nota:");
        string nome = LoopsVerificacao.VerificaNome();
        if (bd.Avaliacoes.Any(n => n.NomeBanda.Equals(nome)))
        {
            var bandaNovaNota = bd.Avaliacoes.FirstOrDefault(n => n.NomeBanda.Equals(nome));
            var notaNova = LoopsVerificacao.VerificaNota();
            bandaNovaNota.SetNotaBanda(notaNova);
            bd.Salvar();
        }
    }
}