using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkChallenge
{
    class Camisa : Prenda
    {
        public enum MANGA
        {
            CORTA = 1, LARGA = 2
        }
        public enum CUELLO
        {
            MAO = 1, COMUN = 2
        }
        private MANGA tipoManga { get; set; }
        public MANGA TipoManga { get => tipoManga; }
        private CUELLO tipoCuello { get; set; }
        public CUELLO TipoCuello { get => tipoCuello; }
        private Camisa(decimal precio, int stock, TIPO_PRENDA tipoPrenda) : base(precio, stock, tipoPrenda) { }

        public Camisa(decimal precio, int stock, TIPO_PRENDA tipoPrenda, MANGA tipoManga, CUELLO tipoCuello) :
            this(precio, stock, tipoPrenda)
        {
            this.tipoManga = tipoManga;
            this.tipoCuello = tipoCuello;
            CalcularPrecio();
        }

        protected override void CalcularPrecio()
        {
            int porcentajeASumar = PorcentajeSegunTipoDePrenda();
            porcentajeASumar += (TipoManga == MANGA.CORTA) ? -10 : 0;
            porcentajeASumar += (TipoCuello == CUELLO.MAO) ? 3 : 0;
            PrecioConCalculo = PrecioSinCalculo + (PrecioSinCalculo * porcentajeASumar / 100);
        }

    }
}
