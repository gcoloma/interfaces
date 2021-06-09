using System;
using System.Collections.Generic;
using System.Text;

namespace ICOB007.Models._001.Response
{
    class RespuestaWS001
    {
        public string CodigoTransaccion { get; set; }//Código respuesta transacción
        public string EstadoTransaccion { get; set; }//Resultado transacción
        public string DescripcionTransaccion { get; set; }//Descripción transacción
    }
}
