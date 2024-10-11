using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angulo
{
    public class Estacao
    {
        public Angulo AngEstacao { get; set; }
        public Angulo Azimute { get; set; }
        public float Distancia { get; set; }
        public char Deflexao { get; set; }  

        public Estacao(Angulo angEstacao, float distancia, char deflexao)
        {
            AngEstacao = angEstacao;
            Distancia = distancia;
            Deflexao = deflexao;
        }

       
        public override string ToString()
        {
            return $"{AngEstacao.ToString()} - {Distancia}m - {Deflexao}";
        }
    }
}
