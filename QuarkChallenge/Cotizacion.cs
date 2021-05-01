using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkChallenge
{
    class Cotizacion
    {
        private int CodigoVendedor { get; set; }
        private int NumeroDeIdentification { get; set; }
        private DateTime FechaYHora { get; set; }
        private Prenda PrendaCotizada { get; set; }
        private int CantidadUnidades { get; set; }
        private decimal Total { get; set; }

        public Cotizacion(int codigoVendedor, int numeroDeIdentification, DateTime fechaYHora, Prenda prendaCotizada, 
            int cantidadUnidades) 
        {
            this.CodigoVendedor = codigoVendedor;
            this.NumeroDeIdentification = numeroDeIdentification;
            this.FechaYHora = fechaYHora;
            this.PrendaCotizada = prendaCotizada;
            this.CantidadUnidades = cantidadUnidades;
            this.Total = prendaCotizada.PrecioConCalculo * cantidadUnidades;
        }
        public override string ToString()
        {
            return $"Código vendedor: {CodigoVendedor}\nNumero de Identificación: {NumeroDeIdentification}\n" +
                $"Fecha y hora: {FechaYHora}\nPrenda: {PrendaCotizada.GetType().Name}\nCantidad unidades: {CantidadUnidades}\nTotal: {Total}";
        }
        public string CodigoYVendedor()
        {
            return $"Código vendedor: {CodigoVendedor}\tNumero de Identificación: {NumeroDeIdentification}";
        }

        public override bool Equals(object obj)
        {
            return (obj is Cotizacion cotizacion && NumeroDeIdentification == cotizacion.NumeroDeIdentification)
                || (obj is int numIdentification && NumeroDeIdentification == numIdentification);
        }
    }
}
