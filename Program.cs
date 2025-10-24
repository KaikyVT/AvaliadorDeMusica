using AvaliarMusica.Data;
using AvaliarMusica.View;

namespace AvaliarMusica;

public class Program
{
    static BD bd = new();
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Menu.iniciarMenu(bd);
    }
}