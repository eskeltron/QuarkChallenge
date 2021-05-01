using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Tienda tienda = new Tienda("Quark store", "Calle falsa 123");
            tienda.AgregarVendedor("Nicolás", "Gomez");
            tienda.AgregarVendedor("Marlene", "Taca");

            tienda.AgregarPrenda(new Camisa(100, 200, Prenda.TIPO_PRENDA.PREMIUM, Camisa.MANGA.CORTA, Camisa.CUELLO.MAO));
            tienda.AgregarPrenda(new Camisa(100, 300, Prenda.TIPO_PRENDA.STANDARD, Camisa.MANGA.CORTA, Camisa.CUELLO.COMUN));
            tienda.AgregarPrenda(new Camisa(100, 150, Prenda.TIPO_PRENDA.PREMIUM, Camisa.MANGA.LARGA, Camisa.CUELLO.MAO));
            tienda.AgregarPrenda(new Camisa(100, 350, Prenda.TIPO_PRENDA.STANDARD, Camisa.MANGA.CORTA, Camisa.CUELLO.COMUN));
            tienda.AgregarPrenda(new Pantalon(100, 1500, Prenda.TIPO_PRENDA.PREMIUM, Pantalon.TIPO.CHUPIN));
            tienda.AgregarPrenda(new Pantalon(100, 500, Prenda.TIPO_PRENDA.STANDARD, Pantalon.TIPO.COMUN));

            Menu menu = new Menu(tienda);
            menu.MenuPrincipal();
        }
    }
}
