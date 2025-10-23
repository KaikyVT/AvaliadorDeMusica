namespace AvaliarMusica.Controller;

public class VerificarEscolha
{
    public static int Verificar(int min, int max)
    {
        int escolha = -1;
        while (true)
        {
            Console.Write("> ");
            try
            {
                escolha = int.Parse(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("Digite um número, não outra coisa =(");
            }
            if (escolha < min || escolha > max)
            {
                Console.WriteLine("Número inválido...");
                Thread.Sleep(1000);
                Console.Clear();
            }
            else
                return escolha;
        }
    }
}