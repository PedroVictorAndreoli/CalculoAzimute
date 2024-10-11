using Angulo;
using System;

namespace Angulo
{
    class Program
    {
        static void Main(string[] args)
        {
            Poligonal poligonal = new Poligonal("Fazenda Rio Verde", 225, 32, 48);
            int Grau = 0;
            int Segundo = 0;
            int Minuto = 0;
            int estacao = 0 ;
            float Distancia = 0.0f;
            char Deflexao = Char.Parse("O");
            poligonal.Listar();
            while (true)
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.Escape:
                        return;

                    case ConsoleKey.F1:
                        Console.Clear();
                        Console.WriteLine("Insira o Grau do Angulo de Estacao");
                        Grau = int.Parse(Console.ReadLine());
                        Console.WriteLine("Insira o Minuto do Angulo de Estacao");
                        Minuto = int.Parse(Console.ReadLine());
                        Console.WriteLine("Insira o Segundo do Angulo de Estacao");
                        Segundo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Insira a Distancia");
                        Distancia = float.Parse(Console.ReadLine());
                        Deflexao = Char.Parse("O");
                        while (Deflexao.ToString().ToUpper() != "D" && Deflexao.ToString().ToUpper() != "E") { 
                            Console.WriteLine("Insira a Deflexao (D/E)");
                            Deflexao = char.Parse(Console.ReadLine());
                            if (Deflexao.ToString().ToUpper() != "D" && Deflexao.ToString().ToUpper() != "E")
                                Console.WriteLine("Deflexao invalida");
                        }
                        poligonal.Inserir(new Estacao(new Angulo(Grau,Minuto,Segundo),Distancia, Deflexao));
                        poligonal.Listar();
                        break;
                    case ConsoleKey.F2:
                        Console.Clear();
                        Console.WriteLine("Qual a estacao deseja alterar?");
                        estacao = int.Parse(Console.ReadLine());
                        Console.WriteLine("Insira o Grau do Angulo de Estacao");
                        Grau = int.Parse(Console.ReadLine());
                        Console.WriteLine("Insira o Minuto do Angulo de Estacao");
                        Minuto = int.Parse(Console.ReadLine());
                        Console.WriteLine("Insira o Segundo do Angulo de Estacao");
                        Segundo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Insira a Distancia");
                        Distancia = float.Parse(Console.ReadLine());
                        Deflexao = Char.Parse("O");
                        while (Deflexao.ToString().ToUpper() != "D" && Deflexao.ToString().ToUpper() != "E")
                        {
                            Console.WriteLine("Insira a Deflexao (D/E)");
                            Deflexao = char.Parse(Console.ReadLine());
                            if (Deflexao.ToString().ToUpper() != "D" && Deflexao.ToString().ToUpper() != "E")
                                Console.WriteLine("Deflexao invalida");
                        }
                        Console.WriteLine("Qual a estacao deseja alterar?");
                        poligonal.Editar(estacao, new Estacao(new Angulo(Grau, Minuto, Segundo), Distancia, Deflexao));
                        poligonal.Listar();
                        break;

                    case ConsoleKey.F3:
                        Console.Clear();
                        Console.WriteLine("Qual a estacao deseja excluir?");
                        estacao = int.Parse(Console.ReadLine());
                        poligonal.Excluir(estacao);
                        poligonal.Listar();
                        break;

                    case ConsoleKey.PageDown:
                        // Próxima página
                        poligonal.ProximaPagina();
                        break;

                    case ConsoleKey.PageUp:
                        // Página anterior
                        poligonal.PaginaAnterior();
                        break;
                }
            }
        }
    }
}
