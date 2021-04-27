using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketAppDAL.DTO;

namespace SocketAppDAL.DAL
{
    /*
     * Quiero que cuando se envíen mensajes a través de mi DTO, los mensajes sean capturados
     * y guardados en un archivo llamado "messages_log.txt"
     * 
     */

    /*
     * PATRÓN SIGLETON: Para crear una sola instancia de objetos
     * MessagesDAL mensajesDAL = MessagesDAL.GetInstance(); -> Crea objeto referencia 1
     * MessagesDAL mensajesDAL2 = MessagesDAL.GetInstance(); -> Se adhiere al objeto anterior referencia 1, sin crear nuevos
     * 
     */

    public class MessageDAL
    {
        // Obtener ruta completa de carpeta donde está ejecutandose el .exe de la app
        // (p.ej.: C:\Users\enriq\source\repos\SocketApp1\SocketAppDal\bin\Debug\ )
        private string archivo = Directory.GetCurrentDirectory() + "/messages_log.txt";
        // Ej archivo quedará en
        // C:\Users\enriq\source\repos\SocketApp1\SocketAppDal\bin\Debug\messages_log.txt
        private static MessageDAL instancia;
        private MessageDAL() { } // No se puede crear a través de un MessageDAL algo = new MessageDAL();

        // Método estático que reemplazará al constructor: Su función es verificar que
        // exista una sola instancia y devolverla. O en caso de que no exista, crear una 
        // única instancia y devolverla
        public static MessageDAL GetInstance()
        {
            if(instancia == null) // No existe el objeto creado anteriormente
            {
                instancia = new MessageDAL(); // Constructor es privado
            }

            return instancia;
        }

        // Agregar mensajes al archivo de texto
        public void Add(Message message)
        {
            // Streams (Writer & Reader)
            //StreamWriter writer = new StreamWriter(archivo); // Vacía el archivo y escribe el mensaje

            /* Con destructor */
            /*
            StreamWriter writer = new StreamWriter(archivo, true); // Abre el archivo y anexa el mensaje

            writer.WriteLine(message);
            writer.Flush();

            writer.Dispose(); // Llamar a Destructor (en cualquier lenguaje) */
            // DESTRUCTOR SE LLAMA PARA LIBERAR EL OBJETO DE MEMORIA Y TAMBIÉN LIBERAR
            // EL ARCHIVO "message_log.txt"

            /* Con técnica USING de C# */
            // Using: Instanciar un objeto y cuando se termine de ejecutar
            // todo su bloque de código, llama automaticamente al destructor (bórralo apenas termina)
            using(StreamWriter writer = new StreamWriter(archivo, true))
            {
                writer.WriteLine(message);
                writer.Flush();
            }

        }

        // * Obtener los mensajes del archivo de texto (todos)
        public List<Message> GetAll()
        {
            // Creamos una lista vacía para guardar los valores
            List<Message> mensajes = new List<Message>();
            
            // 1. Crear un lector que tenga duración definida
            using (StreamReader reader = new StreamReader(archivo))
            {
                string lineaLeida = null; // variable que guardará cada línea

                do
                {
                    lineaLeida = reader.ReadLine(); // Leer línea, guardar el valor y pasar a la siguiente línea
                    if(lineaLeida != null)
                    {
                        // Construir el objeto message a partir de una línea de texto
                        // Trim = Eliminar espacios vacíos al comienzo y al final de un string
                        string[] textos = lineaLeida.Trim().Split(';'); // Guardar elementos separados por ;
                        Message mensaje = new Message()
                        {
                            Tipo = textos[0],
                            Remitente = textos[1],
                            Texto = textos[2]
                        };
                        mensajes.Add(mensaje);
                        /* RETRO 
                        mensaje.Tipo = textos[0];
                        mensaje.Remitente = textos[1];
                        mensaje.Texto = textos[2]; */
                    }

                } while (lineaLeida != null);
            }

            return mensajes;            
        }
    }
}
