using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkChallenge
{
    class Utils
    {
        public static void ValidarEntero(int min, int max, out int opc)
        {
            while (!int.TryParse(Console.ReadLine(), out opc) || opc < min || opc > max) {
                Console.WriteLine($"Número fuera de rango. Mínimo: {min}. Máximo:{max}");
            }
        }
        public static int ValidarEnteroEsteEnLista(List<int> CodigoVendedores)
        {
            int opc;
            while (!int.TryParse(Console.ReadLine(), out opc) || !CodigoVendedores.Any(c => c == opc)) { }
            return opc;
        }
    }
}
