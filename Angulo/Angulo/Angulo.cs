using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Angulo
{
    public class Angulo
    {
        public int Graus { get; set; }
        public int Minutos { get; set; }
        public int Segundos { get; set; }

        public Angulo(int graus, int minutos, int segundos)
        {
            Graus = graus;
            Minutos = minutos;
            Segundos = segundos;
        }

        
        public override string ToString()
        {
            return $"{Graus}º {Minutos}' {Segundos}''";
        }

    }
}
