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
                string mensajeRecibido = communicationServer.Read();
                Console.WriteLine($"Servidor: {mensajeRecibido}");

                Console.WriteLine("Escriba el mensaje que desea enviar al servidor:");
                string mensajeEnviar = Console.ReadLine().Trim(); // Sanitizar
                communicationServer.Write(mensajeEnviar);
                communicationServer.Disconnect();
            } else // Si es que no logró conectar
            {
                Console.WriteLine("No se pudo conectar con el servidor");
            }
        }
    }
}
