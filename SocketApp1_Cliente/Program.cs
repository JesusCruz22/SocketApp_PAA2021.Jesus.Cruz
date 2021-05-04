using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketApp1_Cliente.Comm;

namespace SocketApp1_Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            // Obtener IP y Puerto
            string server = ConfigurationManager.AppSettings["ip"];
            int port = int.Parse(ConfigurationManager.AppSettings["port"]); // Anterior: Convert.ToInt32

            Console.WriteLine($"Conectando a {server}:{port} ...");

            // Inicializar objeto de comunicación cliente
            ClientComm communicationServer = new ClientComm(server, port);

            // Intentar conectar
            if (communicationServer.Connect())
            {
                // Lo que se hará a continuación tiene un orden que puede variar,
                // dependiento de la implementación y requerimientos del problema
                /* Proceso de leer e imprimir mensaje del servidor */
                string mensajeRecibido = communicationServer.Read();
                Console.WriteLine($"Servidor: {mensajeRecibido}");

                /* Proceso de solicitar input del usuario y enviar al servidor */
                Console.WriteLine("Escriba el remitente del mensaje:");
                string mensajeEnviar = Console.ReadLine().Trim(); // Sanitizar
                communicationServer.Write(mensajeEnviar);

                /* Proceso de leer e imprimir mensaje del servidor */
                mensajeRecibido = communicationServer.Read();
                Console.WriteLine($"Servidor: {mensajeRecibido}");

                /* Proceso de solicitar input del usuario y enviar al servidor */
                Console.WriteLine("Escriba el mensaje:");
                mensajeEnviar = Console.ReadLine().Trim(); // Sanitizar
                communicationServer.Write(mensajeEnviar);

                communicationServer.Disconnect();
            } else // Si es que no logró conectar
            {
                Console.WriteLine("No se pudo conectar con el servidor");
            }
        }
    }
}
