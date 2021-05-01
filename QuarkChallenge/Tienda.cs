using System;
using System.Collections.Generic;
using System.Linq;

namespace QuarkChallenge
{
    class Tienda
    {
        private string Nombre { get; set; }
        private string Direccion { get; set; }
        private List<Prenda> Prendas { get; }
        public List<Cotizacion> Cotizaciones { get; }
        public List<Vendedor> Vendedores { get; }

        public Tienda(string nombre, string direccion)
        {
            Prendas = new List<Prenda>();
            Vendedores = new List<Vendedor>();
            Cotizaciones = new List<Cotizacion>();
            Nombre = nombre;
            Direccion = direccion;
        }

        public void AgregarVendedor(string nombre, string apellido)
        {
            Vendedores.Add(new Vendedor(nombre, apellido, CrearCodigo(Vendedores.ToList<object>()), this));
        }
        public int StockDisponibleCamisa(Camisa.MANGA manga, Camisa.CUELLO cuello, Prenda.TIPO_PRENDA tipoPrenda)
        {
            return Prendas.Find(p => p is Camisa c && c.TipoManga == manga && c.TipoCuello == cuello && c.TipoDePrenda == tipoPrenda).Stock;
        }
        public int StockDisponiblePantalon(Pantalon.TIPO tipo, Prenda.TIPO_PRENDA tipoPrenda)
        {
            return Prendas.Find(p => p is Pantalon pan && pan.TipoDePrenda == tipoPrenda && pan.TipoPantalon == tipo).Stock;
        }
        public void AgregarCotizacion(int codigoVendedor, Prenda prendaCotizada, int cantidadUnidades)
        {
            if (TraerVendedor(codigoVendedor) == null)
            {
                throw new Exception("El código de vendedor específicado no existe.");
            }
            if (cantidadUnidades > prendaCotizada.Stock)
            {
                throw new Exception("No se puede cotizar una cantidad que supera el stock actual.");
            }

            Cotizaciones.Add(new Cotizacion(codigoVendedor, CrearCodigo(Cotizaciones.ToList<object>()), DateTime.Now, 
                prendaCotizada, cantidadUnidades));
        }
        public bool EliminarCotizacion(int numeroDeIdentification)
        {
            return Cotizaciones.Remove(TraerCotizacion(numeroDeIdentification));
        }
        public Vendedor TraerVendedor(int codigo)
        {
            return Vendedores.First(v => v.Equals(codigo));
        }
        public Cotizacion TraerCotizacion(int codigo)
        {
            return Cotizaciones.First(c => c.Equals(codigo));
        }
        public void AgregarPrenda(Prenda prenda)
        {
            Prendas.Add(prenda);
        }
        private int CrearCodigo(List<object> listaDondeBuscar)
        {
            int codigo;
            do {
                codigo = new Random().Next(1, 5000);
            } while (listaDondeBuscar.Any(o => o.Equals(codigo)));
            return codigo;
        }

        public Prenda TraerPrenda(Prenda.TIPO_PRENDA tipoPrenda, Camisa.MANGA manga, Camisa.CUELLO cuello)
        {
            return Prendas.First(p => p is Camisa c && c.TipoManga == manga && c.TipoCuello == cuello && c.TipoDePrenda == tipoPrenda);
        }
        public Prenda TraerPrenda(Pantalon.TIPO tipo, Prenda.TIPO_PRENDA tipoPrenda)
        {
            return Prendas.First(p => p is Pantalon pan && pan.TipoPantalon == tipo && pan.TipoDePrenda == tipoPrenda);
        }

        public bool HayPrenda(Camisa.MANGA manga, Camisa.CUELLO cuello, Prenda.TIPO_PRENDA tipoPrenda)
        {
            return Prendas.Any(p => p is Camisa c && c.TipoManga == manga && c.TipoCuello == cuello && c.TipoDePrenda == tipoPrenda );
        }
        public bool HayPrenda(Pantalon.TIPO tipo, Prenda.TIPO_PRENDA tipoPrenda)
        {
            return Prendas.Any(p => p is Pantalon pan && pan.TipoPantalon == tipo && pan.TipoDePrenda == tipoPrenda);
        }
    }
}