using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkChallenge
{
    class Vendedor
    {
        private string nombre { get; set; }
        public string Nombre { get => nombre; }
        private string apellido { get; set; }
        public string Apellido { get => apellido; }
        private int codigo { get; set; }
        public int Codigo { get => codigo; }
        Tienda Tienda { get; set; }

        public Vendedor(string nombre, string apellido, int codigo, Tienda tienda)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.codigo = codigo;
            Tienda = tienda;
        }
        public override bool Equals(object obj)
        {
            return (obj is Vendedor vendedor && Codigo == vendedor.Codigo) 
                || (obj is int codigo && Codigo == codigo);
        }
    }
}
