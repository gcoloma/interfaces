using System;
using System.Collections.Generic;
using System.Text;

namespace IVTA010.Models._001
{
    class RespuestaWS
    {
        public string CodigoTransaccion { get; set; }//Código respuesta transacción
        public string EstadoTransaccion { get; set; }//Resultado transacción
        public string DescripcionTransaccion { get; set; }//Descripción transacción
    }
}
