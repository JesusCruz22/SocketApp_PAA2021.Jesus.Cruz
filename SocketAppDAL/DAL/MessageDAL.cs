using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketAppDAL.DTO;

namespace SocketAppDAL.DAL
{
    public class MessageDAL
    {
        // Obtener ruta completa de carpeta donde está ejecutandose el .exe de la app
        private string archivo = Directory.GetCurrentDirectory() + "/messages_log.txt";

        // Patron singleton
        private static MessageDAL instancia;

        private MessageDAL() { }

        public static MessageDAL GetInstance()
        {
            if(instancia == null)
            {
                instancia = new MessageDAL();
            }

            return instancia;
        }

        // Agregar mensajes al archivo de texto
        public void Add(Message message)
        {
            using(StreamWriter writer = new StreamWriter(archivo, true))
            {
                writer.WriteLine(message);
                writer.Flush();
            }

        }

        // Obtener los mensajes del archivo de texto (todos)
        public List<Message> GetAll()
        {
            // Lista para guardar DTO Message
            List<Message> mensajes = new List<Message>();
            
            /* Crear un lector que tenga duración definida */
            using (StreamReader reader = new StreamReader(archivo))
            {
                // variable que guardará cada línea
                string lineaLeida = null; 

                do
                {
                    lineaLeida = reader.ReadLine(); // Leer línea, guardar el valor y pasar a la siguiente línea
                    if(lineaLeida != null)
                    {
                        // Construir el objeto message a partir de una línea de texto
                        string[] valoresCelda = lineaLeida.Trim().Split('-');
                        Message mensaje = new Message()
                        {
                            IdCelda = valoresCelda[0],
                            Temperatura = valoresCelda[1],
                            Voltaje = valoresCelda[2],
                            Flujo = valoresCelda[3],
                            Nivel = valoresCelda[4],
                            Observaciones = valoresCelda[5]
                        };
                        mensajes.Add(mensaje);
                    }

                } while (lineaLeida != null);
            }

            return mensajes;            
        }
    }
}
