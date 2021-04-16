using System;
using System.Net;
using System.Net.Sockets;
using System.Configuration;

namespace SocketApp1.Comm
{
    public class ServerSocket
    {
        private int puerto;
        private Socket servidor; // no está inicializado

        public ServerSocket()
        {
            puerto = Convert.ToInt32(ConfigurationManager.AppSettings["port"]); // leer llave "port" desde App.config
        }

        public bool Start() // serverSocket.Start() <- True o False
        {
            // crashear = app. va a cerrarse inesperadamente
            try
            {
                // 1. Construir el servidor
                // Socket(<IPv4>, <Tipo comunicación Stream>, <Protocolo TCP>)
                servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // 2. Definir dónde se escucha y a quién escucha
                servidor.Bind(new IPEndPoint(IPAddress.Any, puerto));

                // 3. Determinar capacidad de clientes (En #)
                servidor.Listen(4);

                // 4. Logró levantar servidor
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Socket getClient()
        {
            try
            {
                return servidor.Accept(); // Conexión OK = Recibí socket
            }
            catch (Exception)
            {
                return null; // Conexión Fallida = Recibí objeto nulo
            }
        }

        public void Stop()
        {
            try
            {
                servidor.Close();
            }
            catch (Exception)
            {
                // throw;
            }
        }
    }
}
