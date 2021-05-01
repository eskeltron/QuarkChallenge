using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkChallenge
{
    class Pantalon : Prenda
    {
        public enum TIPO
        {
            COMUN = 1, CHUPIN = 2
        }

        private TIPO tipoPantalon { get; set; }
        public TIPO TipoPantalon { get => tipoPantalon; }
        private Pantalon(decimal precio, int stock, TIPO_PRENDA tipoPrenda) : base(precio, stock, tipoPrenda) { }

        public Pantalon(decimal precio, int stock, TIPO_PRENDA tipoPrenda, TIPO tipoPantalon) :
            this(precio, stock, tipoPrenda)
        {
            this.tipoPantalon = tipoPantalon;
            CalcularPrecio();
        }

        protected override void CalcularPrecio()
        {
            int porcentajeASumar = PorcentajeSegunTipoDePrenda();
            porcentajeASumar += (TipoPantalon == TIPO.CHUPIN) ? -12: 0 ;
            PrecioConCalculo = PrecioSinCalculo  + (PrecioSinCalculo * porcentajeASumar / 100);
        }
    }
}
