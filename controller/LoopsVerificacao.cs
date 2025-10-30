using System.Runtime.Intrinsics.Arm;

namespace AvaliarMusica.Controller;

public class LoopsVerificacao
{
    public static string VerificaNome()
    {
        while (true)
        {
            Console.Write("Digite um nome:\n> ");
            string nome = Console.ReadLine();
            Console.WriteLine($"😺 -> Você selecionou {nome}?");
            Console.WriteLine("[1] Sim");
            Console.WriteLine("[2] Não");
            int escolha = VerificarEscolha.Verificar(1, 2);
            if (escolha == 1 && !string.IsNullOrEmpty(nome))
                return nome;
            Console.WriteLine("Faltou digitar algo decente né...");
        }
    }
    public static double VerificaNota()
    {
        while (true)
        {
            Console.Write("Digite a sua nota:\n> ");
            try
            {
                double nota = double.Parse(Console.ReadLine()!);
                if (nota % 1 != 0 || nota > 10)
                    nota = nota / 10;
                Console.WriteLine($"😺 -> Deseja avaliar com {nota}?");
                Console.WriteLine("[1] Sim");
                Console.WriteLine("[2] Não");
                int escolha = VerificarEscolha.Verificar(1, 2);
                if (escolha == 1)
                    return nota;
            }
            catch
            {
                Console.WriteLine("Você não digitou um número...");
            }
        }
    }
    public static List<string> VerificaAdicionarPro()
    {
        List<string> pros = new();
        while (true)
        {
            Console.Clear();
            Console.Write("Digite um ponto positivo dessa banda:\n> ");
            string pro = Console.ReadLine();
            Console.WriteLine($"😺 -> Deseja registrar essa característica:\n\"{pro}\"?");
            Console.WriteLine("[1] Sim");
            Console.WriteLine("[2] Não");
            int escolha = VerificarEscolha.Verificar(1, 2);
            if (escolha == 1 && !string.IsNullOrEmpty(pro))
                pros.Add(pro);
            Console.WriteLine($"😺 -> Deseja registrar mais algum pro?");
            Console.WriteLine("[1] Sim");
            Console.WriteLine("[2] Não");
            escolha = VerificarEscolha.Verificar(1, 2);
            if (escolha == 2)
                return pros;
        }
    }
    public static List<string> VerificaAdicionarContra()
    {
        List<string> contras = new();
        while (true)
        {
            Console.Clear();
            Console.Write("Digite um ponto negativo dessa banda:\n> ");
            string contra = Console.ReadLine();
            Console.WriteLine($"😺 -> Deseja registrar essa característica:\n\"{contra}\"?");
            Console.WriteLine("[1] Sim");
            Console.WriteLine("[2] Não");
            int escolha = VerificarEscolha.Verificar(1, 2);
            if (escolha == 1 && !string.IsNullOrEmpty(contra))
                contras.Add(contra);
            Console.WriteLine($"😺 -> Deseja registrar mais algum contra?");
            Console.WriteLine("[1] Sim");
            Console.WriteLine("[2] Não");
            escolha = VerificarEscolha.Verificar(1, 2);
            if (escolha == 2)
                return contras;
        }
    }
    public static List<string> VerificaAdicionarExtra()
    {
        List<string> extras = new();
        while (true)
        {
            Console.Clear();
            Console.Write("Digite um ponto adicional (neutro) dessa banda:\n> ");
            string extra = Console.ReadLine();
            Console.WriteLine($"😺 -> Deseja registrar essa característica:\n\"{extra}\"?");
            Console.WriteLine("[1] Sim");
            Console.WriteLine("[2] Não");
            int escolha = VerificarEscolha.Verificar(1, 2);
            if (escolha == 1 && !string.IsNullOrEmpty(extra))
                extras.Add(extra);
            Console.WriteLine($"😺 -> Deseja registrar mais algum extra?");
            Console.WriteLine("[1] Sim");
            Console.WriteLine("[2] Não");
            escolha = VerificarEscolha.Verificar(1, 2);
            if (escolha == 2)
                return extras;
        }
    }
    public static Dictionary<string, double> VerificaMontarTop5()
    {
        Dictionary<string, double> top5 = new();
        Console.WriteLine("😺 -> Vamos montar um top 5 melhores músicas dessa banda!\nAperte qualquer tecla para continuar");
        int indice = 1;
        Console.ReadKey();
        while (indice <= 5)
        {
            Console.Clear();
            Console.WriteLine("Digite o nome da música:");
            string nome = VerificaNome();
            double nota = VerificaNota();
            top5.Add(nome, nota);
            indice++;
        }
        top5 = top5.OrderByDescending(v => v.Value).ToDictionary();
        return top5;
    }

}

