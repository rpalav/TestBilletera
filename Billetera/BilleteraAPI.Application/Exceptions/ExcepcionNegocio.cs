namespace BilleteraAPI.Application.Exceptions
{
    public class ExcepcionNegocio : Exception
    {
        public string CodigoError { get; }

        public ExcepcionNegocio()
        {
        }

        public ExcepcionNegocio(string mensaje) : base(mensaje)
        {
        }

        public ExcepcionNegocio(string mensaje, string codigoError) : base(mensaje)
        {
            CodigoError = codigoError;
        }

        public ExcepcionNegocio(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
    }
}
