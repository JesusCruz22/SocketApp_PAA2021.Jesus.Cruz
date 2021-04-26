using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        

        // ToDo: Diseñar e implementar los métodos:
        // * Agregar mensaje al archivo de texto
        // * Obtener los mensajes del archivo de texto (todos)
    }
}
