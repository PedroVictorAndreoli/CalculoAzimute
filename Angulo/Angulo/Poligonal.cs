using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angulo
{
    public class Poligonal
    {
        public string Descricao { get; set; }
        public int AzGraus { get; set; }
        public int AzMinutos { get; set; }
        public int AzSegundos { get; set; }
        public List<Estacao> Estacoes { get; set; }

        private int paginaAtual = 1;
        private const int estacoesPorPagina = 3;

        public Poligonal(string descricao, int azGraus, int azMinutos, int azSegundos)
        {
            Descricao = descricao;
            AzGraus = azGraus;
            AzMinutos = azMinutos;
            AzSegundos = azSegundos;
            Estacoes = new List<Estacao>();
        }
        public float Perimetro()
        {
            float soma = 0;
            foreach (var estacao in Estacoes)
            {
                soma += estacao.Distancia;
            }
            return soma;
        }
        public void Inserir()
        {

            Console.Clear();
            ImprimirCabecalho(); // Exibe o cabeçalho

            int Grau = 0;
            int Segundo = 0;
            int Minuto = 0;
            int estacao = 0;
            float Distancia = 0.0f;
            char Deflexao = Char.Parse("O");

            // Exibindo todas as instruções de entrada na tela
            Console.Write("Grau:           ");  // Espaço adicional para alinhamento
            Console.Write("Minuto:         ");
            Console.WriteLine(); // Quebra de linha para organizar

            Console.Write("Segundo:        ");
            Console.Write("Distância:      ");
            Console.WriteLine(); // Quebra de linha para organizar

            Console.Write("Deflexão (D/E):      ");
            Console.WriteLine(); // Quebra de linha final

            ImprimirRodape();

            Console.SetCursorPosition(5, 4);
            Deflexao = 'O';
            while (!int.TryParse(Console.ReadLine(), out Grau) || Grau > 360 || Grau<0)
            {
                Inserir();
                return;
            }

            Console.SetCursorPosition(25, 4);
            while (!int.TryParse(Console.ReadLine(), out Minuto) || Minuto>60 || Minuto < 0)
            {
                Inserir();
                return;
            }

            Console.SetCursorPosition(8, 5);
            while (!int.TryParse(Console.ReadLine(), out Segundo) || Segundo > 60 || Segundo < 0)
            {
                Inserir();
                return;
            }

            Console.SetCursorPosition(27, 5);
            while (!float.TryParse(Console.ReadLine(), out Distancia) || Distancia < 0)
            {
                Inserir();
                return;
            }
            Console.SetCursorPosition(15, 6);
            while (Deflexao.ToString().ToUpper() != "D" && Deflexao.ToString().ToUpper() != "E")
            {
                Deflexao = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine(); // Pula linha após leitura
                if (Deflexao != 'D' && Deflexao != 'E')
                {
                    Inserir();
                    return;
                }
            }

            // Limpa a tela e lista as estações inseridas
            Console.Clear();
            Estacoes.Add(new Estacao(new Angulo(Grau, Minuto, Segundo), Distancia, Deflexao));
            Listar(); // Lista as estações  
            
        }


        public void Editar()
        {
            Console.Clear();
            ImprimirCabecalho(); // Exibe o cabeçalho

            int Grau = 0;
            int Segundo = 0;
            int Minuto = 0;
            int estacao = 0;
            float Distancia = 0.0f;
            char Deflexao = Char.Parse("O");

            // Exibindo todas as instruções de entrada na tela
            Console.Write("Estacao:        ");
            Console.Write("Grau:           ");
            Console.WriteLine();
            Console.Write("Minuto:         ");
            Console.Write("Segundo:        ");
            Console.WriteLine();
            Console.Write("Distância:      ");
            Console.Write("Deflexão (D/E): ");
            Console.WriteLine();
            ImprimirRodape();
            Console.SetCursorPosition(8, 4);
            while (!int.TryParse(Console.ReadLine(), out estacao) || estacao > Estacoes.Count || estacao<0)
            {
                Editar();
                return;
            }
            Console.SetCursorPosition(21, 4);
            Deflexao = 'O';
            while (!int.TryParse(Console.ReadLine(), out Grau) || Grau > 360 || Grau < 0)
            {
                Editar();
                return;
            }

            Console.SetCursorPosition(8, 5);
            while (!int.TryParse(Console.ReadLine(), out Minuto) || Minuto > 60 || Minuto < 0)
            {
                Editar();
                return;
            }

            Console.SetCursorPosition(24, 5);
            while (!int.TryParse(Console.ReadLine(), out Segundo) || Segundo > 60 || Segundo < 0)
            {
                Editar();
                return;
            }

            Console.SetCursorPosition(10, 6);
            while (!float.TryParse(Console.ReadLine(), out Distancia) || Segundo < 0)
            {
                Editar();
                return;
            }
            Console.SetCursorPosition(31, 6);
            while (Deflexao.ToString().ToUpper() != "D" && Deflexao.ToString().ToUpper() != "E")
            {
                Deflexao = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine(); // Pula linha após leitura
                if (Deflexao != 'D' && Deflexao != 'E')
                {
                    Editar();
                    return;
                }
            }
            Estacao estacao1 = new Estacao(new Angulo(Grau, Minuto, Segundo), Distancia, Deflexao);
            Estacao estacao2 = Estacoes[estacao - 1];
            estacao2.AngEstacao = estacao1.AngEstacao;
            estacao2.Distancia = estacao1.Distancia;
            estacao2.Deflexao = estacao1.Deflexao;
            Console.Clear();
            Listar();
        }
        public void Excluir()
        {
            Console.Clear();
            ImprimirCabecalho();
            Console.WriteLine("Qual a estacao deseja excluir?");
            int estacao = 0;
            ImprimirRodape();
            Console.SetCursorPosition(31, 4);
            while (!int.TryParse(Console.ReadLine(), out estacao) || estacao > Estacoes.Count)
            {
                Excluir();
                return;
            }
            if (estacao < 1 || estacao > Estacoes.Count)
            {
                Console.WriteLine("Número de estação inválido.");
                return;
            }
            string confirmacao = "o";
            while (confirmacao.ToUpper() != "S" && confirmacao.ToUpper() != "N")
            { 
            Console.WriteLine("Tem certeza que deseja excluir a estação? (S/N)");
            confirmacao = Console.ReadLine();
                if (confirmacao.ToUpper() == "S")
                {
                    Estacoes.RemoveAt(estacao - 1);
                    Console.WriteLine("Estação excluída com sucesso.");
                }
                else if(confirmacao.ToUpper() == "N")
                {
                    Console.WriteLine("Exclusão cancelada.");
                }
                else
                {
                    Console.WriteLine("Operacao Invalida");
                }
            }
            Listar();
        }
        public void Listar()
        {

            CalcularAzimutes();
            ImprimirCabecalho(); // Exibe o cabeçalho
            Console.WriteLine("Estação    Ângulo lido    Deflexão    Distância(m)    Azimute");
            Console.WriteLine(new string('=', 100));
            int totalEstacoes = Estacoes.Count;
            for (int i = (paginaAtual - 1) * estacoesPorPagina; i < Math.Min(totalEstacoes, paginaAtual * estacoesPorPagina); i++)
            {
                var estacao = Estacoes[i];

                // Definindo os tamanhos de coluna
                string estacaoStr = $"{i + 1:0000}".PadRight(11);                       // Estação (4 dígitos, alinhado à esquerda)
                string anguloStr = estacao.AngEstacao.ToString().PadRight(15);          // Ângulo (alinhado à esquerda)
                string deflexaoStr = estacao.Deflexao.ToString().ToUpper().PadRight(12); // Deflexão (alinhado à esquerda)
                string distanciaStr = estacao.Distancia.ToString("F2").PadRight(16);    // Distância (alinhado à esquerda)
                string azimuteStr = estacao.Azimute.ToString().PadRight(20);            // Azimute (alinhado à esquerda)

                // Imprime a linha formatada com os valores alinhados
                Console.WriteLine($"{estacaoStr}{anguloStr}{deflexaoStr}{distanciaStr}{azimuteStr}");
            }
            ImprimirRodape();
        }

        public void CalcularAzimutes()
        {
            for (int i = 0; i < Estacoes.Count; i++)
            {
                if (i == 0)
                {
                    Estacoes[i].Azimute = new Angulo(AzGraus, AzMinutos, AzSegundos);
                }
                else
                {
                    var anterior = Estacoes[i - 1];
                    var atual = Estacoes[i];
                    atual.Azimute = new Angulo(0, 0, 0);
                    if(atual.Deflexao.Equals('D'))
                    {
                        atual.Azimute.Segundos = anterior.Azimute.Segundos + atual.AngEstacao.Segundos;
                        if(atual.Azimute.Segundos > 60)
                        {
                            atual.Azimute.Minutos = 1 + anterior.Azimute.Minutos + atual.AngEstacao.Minutos;
                            atual.Azimute.Segundos -= 60;
                        }
                        else
                        {
                            atual.Azimute.Minutos = anterior.Azimute.Minutos + atual.AngEstacao.Minutos;
                        }
                        if (atual.Azimute.Minutos > 60)
                        {
                            atual.Azimute.Graus = 1 + anterior.Azimute.Graus + atual.AngEstacao.Graus;
                            atual.Azimute.Minutos -= 60;
                        }
                        else
                        {
                            atual.Azimute.Graus = anterior.Azimute.Graus + atual.AngEstacao.Graus;
                        }
                        if(atual.Azimute.Graus > 359)
                        {
                            atual.Azimute.Graus -= 360;
                        }
                    }
                    else
                    {
                        Console.WriteLine(atual.Azimute.Segundos);
                        atual.Azimute.Segundos = anterior.Azimute.Segundos - atual.AngEstacao.Segundos;
                        if (atual.Azimute.Segundos < 0)
                        {
                            atual.Azimute.Minutos = anterior.Azimute.Minutos + atual.AngEstacao.Minutos - 1;
                            atual.Azimute.Segundos += 60;
                        }
                        else
                        {
                            atual.Azimute.Minutos = anterior.Azimute.Minutos - atual.AngEstacao.Minutos;
                        }
                        if(atual.Azimute.Minutos < 0)
                        {
                            atual.Azimute.Graus = anterior.Azimute.Graus + atual.AngEstacao.Graus - 1;
                            atual.Azimute.Minutos += 60;
                        }
                        else
                        {
                            atual.Azimute.Graus = anterior.Azimute.Graus - atual.AngEstacao.Graus;
                        }
                        if(atual.Azimute.Graus < 0)
                        {
                            atual.Azimute.Graus += 360;
                        }
                    }
                }
            }
        }
        public void ProximaPagina()
        {
            if (paginaAtual * estacoesPorPagina < Estacoes.Count)
            {
                paginaAtual++;
                Listar();
            }
        }
        public void PaginaAnterior()
        {
            if (paginaAtual > 1)
            {
                paginaAtual--;
                Listar();
            }
        }

        public void Salvar(string arquivo)
        {
            using (StreamWriter writer = new StreamWriter(arquivo))
            {
                writer.WriteLine($"{Descricao};{AzGraus};{AzMinutos};{AzSegundos}");

                foreach (var estacao in Estacoes)
                {
                    writer.WriteLine($"{estacao.AngEstacao.Graus};{estacao.AngEstacao.Minutos};{estacao.AngEstacao.Segundos};{estacao.Distancia};{estacao.Deflexao}");
                }
            }
            Console.WriteLine("Dados salvos com sucesso.");
        }

        public void ImprimirCabecalho()
        {
            Console.Clear();
            Console.WriteLine($"Engenharia Cartográfica         Sistema de Poligonais         Data: {DateTime.Now:dd/MM/yyyy}");
            Console.WriteLine(new string('=', 100));
            Console.WriteLine($"Poligonal: {Descricao}");
            Console.WriteLine(new string('-', 100));
        }

        public void ImprimirRodape()
        {
            // Calcula quantas linhas estão faltando para preencher o console até o final
            int currentLineCursor = Console.CursorTop;
            int blankLines = Console.WindowHeight - currentLineCursor - 4; // Ajusta para garantir espaço para o rodapé
            int totalPaginas = (Estacoes.Count + estacoesPorPagina - 1) / estacoesPorPagina; // Calcula o total de páginas

            // Preenche com linhas em branco até chegar ao rodapé
            for (int i = 0; i < blankLines; i++)
            {
                Console.WriteLine();
            }

            // Exibe o rodapé fixo no final da janela
            Console.WriteLine(new string('=', 100));
            Console.Write("Perímetro: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{Perimetro():F2} ");
            Console.ResetColor();
            Console.WriteLine($"metros                                                             Pag.: {paginaAtual} de {totalPaginas}");

            // Opções de navegação e interação
            Console.Write("<Esc> Sair ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("<F1> Inserir ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("<F2> Alterar ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("<F3> Excluir ");
            Console.ResetColor();
            Console.Write("<PgDn> Próxima Página <PgUp> Página Anterior");
        }
    }
}
