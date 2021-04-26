using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketAppDAL.DTO
{
    // En otra parte del proyecto:
    // Message mensaje = new Message() {
    //      Tipo = "Mensaje",
    //      Remitente = "Servidor",
    //      Texto = "Oli"
    //  }

    // mensaje.toString() -> (SIN CAMBIAR EL MÉTODO TO STRING) -> CONSOLE OUTPUT: [object]
    // mensaje.toString() -> (PERSONALIZANDO MÉTODO TO STRING) -> CONSOLE OUTPUT: Mensaje;Servidor;Oli
    public class Message
    {
        private string tipo;
        private string remitente;
        private string texto;

        public string Tipo { get => tipo; set => tipo = value; }
        public string Remitente { get => remitente; set => remitente = value; }
        public string Texto { get => texto; set => texto = value; }

        public override string ToString()
        {
            //return Tipo + ";" + Remitente + ";" + Texto;
            return $"{Tipo};{Remitente};{Texto}";
        }

    }
}

