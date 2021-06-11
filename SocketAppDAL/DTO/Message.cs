using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketAppDAL.DTO
{
    public class Message
    {
        private string idCelda;

        private string voltaje;
        private string temperatura;
        private string nivel;
        private string flujo;

        private string observaciones;

        public string IdCelda { get => idCelda; set => idCelda = value; }
        public string Voltaje { get => voltaje; set => voltaje = value; }
        public string Temperatura { get => temperatura; set => temperatura = value; }
        public string Nivel { get => nivel; set => nivel = value; }
        public string Flujo { get => flujo; set => flujo = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }

        public override string ToString()
        {
            // Construir mensaje a enviar con los valores ingresados
            string mensaje =
                $"{idCelda}-{voltaje}-{temperatura}-{nivel}-{flujo}-{observaciones}";
            // Retornar mensaje
            return mensaje;
        }

    }
}

