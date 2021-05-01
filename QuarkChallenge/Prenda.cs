namespace QuarkChallenge
{
    abstract class Prenda
    {
        public enum TIPO_PRENDA
        {
            STANDARD = 1, PREMIUM = 2
        }

        protected decimal PrecioSinCalculo { get; set; }
        private decimal precioConCalculo { get; set; }
        public decimal PrecioConCalculo { get => precioConCalculo; set => precioConCalculo = value; }
        private int stock { get; set; }
        public int Stock { get => stock; }
        private TIPO_PRENDA tipoDePrenda { get; set; }
        public TIPO_PRENDA TipoDePrenda { get => tipoDePrenda; }

        public Prenda(decimal precio, int stock,TIPO_PRENDA tipoPrenda)
        {
            PrecioSinCalculo = precio;
            this.stock = stock;
            this.tipoDePrenda = tipoPrenda;
        }
        abstract protected void CalcularPrecio();
        protected int PorcentajeSegunTipoDePrenda()
        {
            return (TipoDePrenda == TIPO_PRENDA.PREMIUM) ? 30 : 0;
        }
    }
}