using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraAPI.Application.Constantes
{
    public class ErroresNegocio
    {
        public static class Billetera
        {
            public const string CodigoNoEncontrada = "BLL-001";
            public const string MensajeNoEncontrada = "La billetera no existe.";

            public const string CodigoSaldoInsuficiente = "BLL-002";
            public const string MensajeSaldoInsuficiente = "El monto de la transferencia excede el saldo disponible.";

            public const string CodigoTransferenciaMismaBilletera = "BLL-003";
            public const string MensajeTransferenciaMismaBilletera = "No se puede transferir a la misma billetera.";
        }

        public static class Movimiento
        {
            public const string CodigoMontoInvalido = "MOV-001";
            public const string MensajeMontoInvalido = "El monto de la transferencia no puede ser negativo.";
        }
    }
}
