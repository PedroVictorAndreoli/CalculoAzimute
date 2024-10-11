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
        public void Inserir(Estacao novaEstacao)
        {
            Estacoes.Add(novaEstacao);
            Console.WriteLine("Estação inserida com sucesso.");
        }


        public void Editar(int numeroEstacao,Estacao estacao1)
        {
            if (numeroEstacao < 1 || numeroEstacao > Estacoes.Count)
            {
                Console.WriteLine("Número de estação inválido.");
                return;
            }

            Estacao estacao = Estacoes[numeroEstacao - 1];
            Console.WriteLine("Editando estação número " + numeroEstacao);
            estacao.AngEstacao = estacao1.AngEstacao;
            estacao.Distancia = estacao1.Distancia;
            estacao.Deflexao = estacao1.Deflexao;
            Console.WriteLine("Estação editada com sucesso.");
        }
        public void Excluir(int numeroEstacao)
        {
            if (numeroEstacao < 1 || numeroEstacao > Estacoes.Count)
            {
                Console.WriteLine("Número de estação inválido.");
                return;
            }
            string confirmacao = "o";
            while (confirmacao.ToUpper() != "S" || confirmacao.ToUpper() != "N")
            { 
            Console.WriteLine("Tem certeza que deseja excluir a estação? (S/N)");
            confirmacao = Console.ReadLine();
                if (confirmacao.ToUpper() == "S")
                {
                    Estacoes.RemoveAt(numeroEstacao - 1);
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
        }
        public void Listar()
        {
            int totalEstacoes = Estacoes.Count;
            int totalPaginas = (totalEstacoes + estacoesPorPagina - 1) / estacoesPorPagina;
            CalcularAzimutes();
            Console.Clear();
            Console.WriteLine($"Engenharia Cartográfica         Sistema de Poligonais         Data: {DateTime.Now:dd/MM/yyyy}");
            Console.WriteLine(new string('=', 100));
            Console.WriteLine($"Poligonal: {Descricao}");
            Console.WriteLine(new string('-', 100));
            Console.WriteLine("Estação    Ângulo lido    Deflexão    Distância(m)    Azimute");
            Console.WriteLine(new string('=', 100));

            for (int i = (paginaAtual - 1) * estacoesPorPagina; i < Math.Min(totalEstacoes, paginaAtual * estacoesPorPagina); i++)
            {
                var estacao = Estacoes[i];
                Console.WriteLine($"{i + 1:0000}       {estacao.AngEstacao.ToString()}     {estacao.Deflexao.ToString().ToUpper()}         {estacao.Distancia:F2}          {estacao.Azimute.ToString()}");
            }

            Console.WriteLine(new string('=', 100));
            Console.Write("Perímetro: ");
            Console.ForegroundColor = ConsoleColor.Red; // Cor vermelha
            Console.Write($"{Perimetro():F2} ");
            Console.ResetColor(); // Resetar para a cor padrão do console

            Console.WriteLine($"metros                                                             Pag.: {paginaAtual} de {totalPaginas}");
           
            Console.Write("<Esc> Sair ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("<F1> Inserir ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("<F2> Alterar ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("<F3> Excluir ");
            Console.ResetColor();
            Console.WriteLine("<PgDn> Próxima Página <PgUp> Página Anterior");

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
                    if(atual.Deflexao.ToString().ToUpper().Equals('D'))
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
    }
}
