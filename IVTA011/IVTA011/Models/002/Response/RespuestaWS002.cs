using System;
using System.Collections.Generic;
using System.Text;

namespace IVTA011.Models._002.Response
{
    class RespuestaWS002
    {
        public string CodigoTransaccion { get; set; }//Código respuesta transacción
        public string EstadoTransaccion { get; set; }//Resultado transacción
        public string DescripcionTransaccion { get; set; }//Descripción transacción
    }
}
