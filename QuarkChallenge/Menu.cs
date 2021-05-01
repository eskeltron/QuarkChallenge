using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkChallenge
{
    enum MENU
    {
        SALIR = 1,
        COTIZAR = 2,
        HISTORIAL = 3
    }
    class Menu
    {
        private Tienda Tienda { get; set; }
        private Vendedor VendedorElegido { get; set; }
        private enum PRENDA
        {
            CAMISA = 1,
            PANTALON = 2
        }

        public Menu(Tienda tienda)
        {
            Tienda = tienda;
            VendedorElegido = null;
        }

        public void MenuPrincipal()
        {
            int opc = 0;
            do
            {
                if(VendedorElegido == null)
                {
                    MenuElegirVendedor();
                    Console.Clear();
                }

                MostrarOpcionesDisponibles(new string[] { "SALIR", "COTIZAR", "HISTORIAL" }, $"Quark Store. Hola {VendedorElegido.Nombre} {VendedorElegido.Apellido}, elija una opción:", out opc, false);

                Console.Clear();
                switch ((MENU) opc)
                {
                    case MENU.COTIZAR:
                        MenuCotizar();
                        break;
                    case MENU.HISTORIAL:
                        MenuHistorialCotizaciones();
                        break;
                }
                Console.Clear();
            } while (((MENU) opc) != MENU.SALIR);

            Console.WriteLine("Adios! :). Presione una tecla para salir.");
        }
        
        private void MenuHistorialCotizaciones()
        {
            string[] cotizacionesConCodigoYVendedor = Tienda.Cotizaciones.Select(c => c.CodigoYVendedor()).ToArray<string>();
            MostrarOpcionesDisponibles(cotizacionesConCodigoYVendedor, "Elija la cotización para obtener más detalles.", out int opc);
            if (opc == 0) return;
            int idCotizacion = int.Parse(cotizacionesConCodigoYVendedor[opc - 1].Split(':')[2].Trim());
            Cotizacion cotizacion = Tienda.TraerCotizacion(idCotizacion);
            MostrarOpcionesDisponibles(new string[] { "Eliminar" }, $"Cotización seleccionada:{cotizacion.ToString()}", out opc);
            if (opc == 0)
            {
                return;
            }
            else
            {
                Tienda.EliminarCotizacion(idCotizacion);
            }
            
        }
        private void MenuCotizar()
        {
            MostrarOpcionesDisponibles(Enum.GetNames(typeof(PRENDA)), "Quark Store. Cotización. Elija la prenda a cotizar:", out int opc);
            if (opc == 0) return;
            PRENDA prendaACotizar = (PRENDA)opc;

            MostrarOpcionesDisponibles(Enum.GetNames(typeof(Prenda.TIPO_PRENDA)), $"Quark Store. Cotización.\nPrenda: {prendaACotizar}\nElija el tipo de prenda:", out opc);
            if (opc == 0) return;

            Prenda.TIPO_PRENDA tipoPrenda = (Prenda.TIPO_PRENDA) opc;

            switch (prendaACotizar)
            {
                case PRENDA.CAMISA:
                    MenuCotizarCamisa(prendaACotizar, tipoPrenda);
                    break;
                case PRENDA.PANTALON:
                    MenuCotizarPantalon(prendaACotizar, tipoPrenda);
                    break;
            }
        }

        private void MenuCotizarCamisa(PRENDA prendaACotizar, Prenda.TIPO_PRENDA tipoPrenda)
        {

            MostrarOpcionesDisponibles(Enum.GetNames(typeof(Camisa.MANGA)), $"Quark Store. Cotización.\nPrenda: {prendaACotizar}\nTipo de prenda: {tipoPrenda}.\nElija la manga de la camisa a cotizar", out int opc);
            if (opc == 0) return;
            Camisa.MANGA manga = (Camisa.MANGA)opc;

            MostrarOpcionesDisponibles(Enum.GetNames(typeof(Camisa.CUELLO)), $"Quark Store. Cotización.\nPrenda: {prendaACotizar}\nTipo de prenda: {tipoPrenda}.\nManga seleccionada: {manga}.\n" +
                $"Elija el cuello la camisa a cotizar", out opc);
            if (opc == 0) return;
            Camisa.CUELLO cuello = (Camisa.CUELLO)opc;

            MostrarOpcionesDisponibles(new string[] { "Confirmar" }, $"Quark Store. Cotización.\nPrenda: {prendaACotizar}\nTipo de prenda: {tipoPrenda}.\nManga seleccionada: {manga}.\n" +
                $"Cuello seleccionado: {cuello}. ", out opc);
            if (opc == 0) return;

            if (!Tienda.HayPrenda(manga, cuello, tipoPrenda))
            {
                Console.WriteLine("No hay prendas para la combinación seleccionada. Presione una tecla para volver al menu principal.");
                return;
            }

            Console.WriteLine("Ingrese la cantidad que desea cotizar:");
            int stockDisponible = Tienda.StockDisponibleCamisa(manga, cuello, tipoPrenda);
            Console.WriteLine($"Mínimo: 1 Máximo:{stockDisponible}");
            Utils.ValidarEntero(1, stockDisponible, out int cantACotizar);
            Console.Clear();

            MostrarOpcionesDisponibles(new string[] { "Confirmar" }, $"Quark Store. Cotización.\nPrenda: {prendaACotizar}\nTipo de prenda: {tipoPrenda}.\nManga seleccionada: {manga}.\n" +
                $"Cuello seleccionado: {cuello}.\nCantidad a cotizar: {cantACotizar}.", out opc);
            if(opc == 0)
            {
                return;
            }
            else
            {
                Tienda.AgregarCotizacion(VendedorElegido.Codigo, Tienda.TraerPrenda(tipoPrenda, manga, cuello), cantACotizar);
                Console.WriteLine("Cotización agregada satisfactoriamente. Presiona una tecla para volver al menu principal.");
            }
        }

        private void MenuCotizarPantalon(PRENDA prendaACotizar, Prenda.TIPO_PRENDA tipoPrenda)
        {

            MostrarOpcionesDisponibles(Enum.GetNames(typeof(Pantalon.TIPO)), $"Quark Store. Cotización.\nPrenda: {prendaACotizar}\nTipo de prenda: {tipoPrenda}.\nElija el tipo de pantalón:", out int opc);
            if (opc == 0) return;
            Pantalon.TIPO pantalonTipo = (Pantalon.TIPO) opc;

            MostrarOpcionesDisponibles(new string[] { "Confirmar" }, $"Quark Store. Cotización.\nPrenda: {prendaACotizar}\nTipo de prenda: {tipoPrenda}.\nTipo de pantalon: {pantalonTipo}.\n", out opc);
            if (opc == 0) return;

            if (!Tienda.HayPrenda(pantalonTipo, tipoPrenda))
            {
                Console.WriteLine("No hay prendas para la combinación seleccionada. Presione una tecla para volver al menu principal.");
                return;
            }

            Console.WriteLine("Ingrese la cantidad que desea cotizar:");
            int stockDisponible = Tienda.StockDisponiblePantalon(pantalonTipo, tipoPrenda);
            Console.WriteLine($"Mínimo: 1 Máximo:{stockDisponible}");
            Utils.ValidarEntero(1, stockDisponible, out int cantACotizar);
            Console.Clear();

            MostrarOpcionesDisponibles(new string[] { "Confirmar" }, $"Quark Store. Cotización.\nPrenda: {prendaACotizar}\nTipo de prenda: {tipoPrenda}.\nTipo de pantalon: {pantalonTipo}." +
                $"\nCantidad a cotizar: {cantACotizar}.", out opc);
            if (opc == 0)
            {
                return;
            }
            else
            {
                Tienda.AgregarCotizacion(VendedorElegido.Codigo, Tienda.TraerPrenda(pantalonTipo, tipoPrenda), cantACotizar);
                Console.WriteLine("Cotización agregada satisfactoriamente. Presiona una tecla para volver al menu principal.");
            }
        }


        private void MostrarOpcionesDisponibles(string[] opciones, string mensajePrincipal, out int opc, bool volverAlMenuPrincipal = true)
        {
            Console.WriteLine(mensajePrincipal);
            for (int i = 1; i <= opciones.Length; i++)
            {
                Console.WriteLine($"{i} - {opciones[i - 1]}");
            }
            if (volverAlMenuPrincipal)
            {
                Console.WriteLine($"\n0 - Volver menu principal");
            }
            Utils.ValidarEntero(volverAlMenuPrincipal ? 0 : 1, opciones.Length, out opc);
            Console.Clear();
        }
        private void MenuElegirVendedor()
        {
            Console.WriteLine("Quark Store. escriba su número de vendedor:");
            Tienda.Vendedores.ForEach(v =>
            {
                Console.WriteLine($"Código: {v.Codigo}\tVendedor: {v.Nombre} {v.Apellido}");
            });
            int codigoVendedor = Utils.ValidarEnteroEsteEnLista(Tienda.Vendedores.Select(v => v.Codigo).ToList<int>());
            VendedorElegido = Tienda.TraerVendedor(codigoVendedor);
        }
    }
}
