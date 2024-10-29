using Angulo;
using System;

namespace Angulo
{
    class Program
    {
        static void Main(string[] args)
        {
            Poligonal poligonal = new Poligonal("Fazenda Rio Verde", 225, 32, 48);
            Console.SetWindowSize(100, 12);

            // Exibe a lista inicial e o rodapé
            poligonal.Listar();

            while (true)
            {
                var keyInfo = Console.ReadKey(intercept: true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        return;

                    case ConsoleKey.F1:
                        poligonal.Inserir();
                        break;

                    case ConsoleKey.F2:
                        poligonal.Editar(); 
                        break;

                    case ConsoleKey.F3:
                        poligonal.Excluir();
                        break;

                    case ConsoleKey.PageDown:
                        poligonal.ProximaPagina();
                        break;

                    case ConsoleKey.PageUp:
                        poligonal.PaginaAnterior();
                        break;

                    case ConsoleKey.S when (keyInfo.Modifiers & ConsoleModifiers.Control) != 0:
                        Console.Write("Digite o nome do arquivo para salvar: ");
                        string arquivo = Console.ReadLine();
                        poligonal.Salvar(arquivo);
                        Console.WriteLine($"Arquivo salvo como {arquivo}");
                        break;
                }
            }
        }
    }
}
