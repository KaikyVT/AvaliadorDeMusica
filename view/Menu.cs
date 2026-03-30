using AvaliarMusica.Controller;
using AvaliarMusica.Data;

namespace AvaliarMusica.View;

public class Menu
{
    public static void iniciarMenu(BD bd)
    {
        Console.Clear();
        int escolha = -1;
        while (escolha != 0)
        {
            Imprimir();
            escolha = VerificarEscolha.Verificar(0, 9);
            switch (escolha)
            {
                case 1: Avaliar.AvaliarBanda(bd); break;
                case 2: Deletar.DeletarBanda(bd); break;
                case 3: Console.Clear(); MostrarInfoBanda.SelecionaBanda(bd); break;
                case 4: AdicionarPro.Adicionar(bd); break;
                case 5: AdicionarContra.Adicionar(bd); break;
                case 6: AdicionarExtra.Adicionar(bd); break;
                case 7: AdicionarTop5.Adicionar(bd); break;
                case 8: ModificarNotaBanda.Modificar(bd); break;
                case 9: EstatisticasGerais.VisualizarEstatisticas(bd); break;
                case 0: return;
                default: Console.WriteLine("Digite um número válido"); Thread.Sleep(1000); break;
            }
        }

    }

    private static void Imprimir()
    {
        Console.Clear();
        Console.WriteLine("😺 -> Olá! Vamos avaliar a bandinha/artista de hoje??");
        Console.WriteLine("[1] Avaliar banda/artista nova");
        Console.WriteLine("[2] Deletar uma avaliação");
        Console.WriteLine("[3] Visualizar informações de banda/artista");
        Console.WriteLine("[4] Adicionar um Pro em uma avaliação");
        Console.WriteLine("[5] Adicionar um Contra em uma avaliação");
        Console.WriteLine("[6] Adicionar um Extra em uma avaliação");
        Console.WriteLine("[7] Adicionar/Modificar um top 5 músicas de banda/artista");
        Console.WriteLine("[8] Modificar a nota de banda/artista");
        Console.WriteLine("[9] Estatísticas gerais de avaliações");
        Console.WriteLine("[0] Sair do programa");
    }
}