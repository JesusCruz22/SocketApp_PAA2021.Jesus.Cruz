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
                // Solicitar e ingresar ID de la celda desde el servidor
                string idCelda = communicationServer.Read();
                Console.WriteLine(idCelda);
                idCelda = Console.ReadLine().Trim();
                communicationServer.Write(idCelda);

                Console.WriteLine($"Ingrese los valores de la celda con ID {idCelda}\n");

                // Solicitar e ingresar Voltaje
                string voltaje = communicationServer.Read();
                Console.WriteLine(voltaje);
                voltaje = Console.ReadLine().Trim();
                communicationServer.Write(voltaje);

                // Solicitar e ingresar Temperatura
                string temperatura = communicationServer.Read();
                Console.WriteLine(temperatura);
                temperatura = Console.ReadLine().Trim();
                communicationServer.Write(temperatura);

                // Solicitar e ingresar Nivel
                string nivel = communicationServer.Read();
                Console.WriteLine(nivel);
                nivel = Console.ReadLine().Trim();
                communicationServer.Write(nivel);

                // Solicitar e ingresar Flujo
                string flujo = communicationServer.Read();
                Console.WriteLine(flujo);
                flujo = Console.ReadLine().Trim();
                communicationServer.Write(flujo);

                // Solicitar e ingresar Observaciones
                string observaciones = communicationServer.Read();
                Console.WriteLine(observaciones);
                observaciones = Console.ReadLine().Trim();
                communicationServer.Write(observaciones);

                Console.WriteLine($"\nLos valores de la celda con ID {idCelda}, fueron ingresados correctamente." +
                    $"\nPresione cualquier tecla para desconectarse del servidor." +
                    $"\nAdios.");
                Console.ReadKey();

                communicationServer.Disconnect();
            } else // Si es que no logró conectar
            {
                Console.WriteLine("No se pudo conectar con el servidor");
                Console.ReadKey();
            }
        }
    }
}
