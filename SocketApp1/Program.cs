using SocketApp1.Comm;
using System;
using System.Configuration;
using System.Net.Sockets;
using System.Net;

namespace SocketApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciar un servidor socket (ServerSocket)
            ServerSocket serverProduction = new ServerSocket();

            // Levantar el servidor de sockets
            if(serverProduction.Start())
            {
                // Indicar que el servidor fue iniciado exitosamente
                string puerto = ConfigurationManager.AppSettings["port"];

                Console.WriteLine($"Servidor iniciado en el puerto {puerto}");

                // LOOP INFINITO (hasta cierta condición)
                while (true)
                {
                    // Crear una nueva conexión desde un cliente
                    // Creamos la conexión en un socket (que nos otorga ServerSocket)
                    Socket conexionCliente = serverProduction.getClient();

                    Console.WriteLine("Nuevo cliente conectado");

                    // Instanciamos nuestra clase de CLientSocket
                    ClientSocket clienteSocket = new ClientSocket(conexionCliente);

                    clienteSocket.Write("Hola mundo"); // Escribimos en el socket (comm)

                    string lectura = clienteSocket.Read(); // Leemos desde el socket (comm)

                    if (lectura != null) // Si es que el cliente no escribió nada, no procese nada
                    {
                        Console.WriteLine($"Cliente: {lectura}"); // Mostrar mensaje desde cliente

                        if (lectura.ToLower() == "q")
                        {
                            clienteSocket.Disconnect();
                            serverProduction.Stop();
                            Environment.Exit(0);
                        }
                    }

                    clienteSocket.Disconnect();
                }
            } else
            {
                Console.WriteLine("No pasó! :(");
                // No pudo levantar el servidor
            }

            Console.ReadKey();
            serverProduction.Stop();
        }
    }
}
