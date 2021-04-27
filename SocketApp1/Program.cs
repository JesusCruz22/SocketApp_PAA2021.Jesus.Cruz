using SocketApp1.Comm;
using System;
using System.Configuration;
using System.Net.Sockets;
using System.Net;
using SocketApp1.Threads;
using System.Threading;

namespace SocketApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Obtener el puerto desde las configuraciones para escribirlo en consola mas tarde
            string puerto = ConfigurationManager.AppSettings["port"];

            // Iniciar el procedimiento del lanzamiento del hilo servidor
            ServerThread server = new ServerThread();
            Thread hiloNuevoServidor = new Thread(new ThreadStart(server.Execute)); // indicar método que se ejecutará al iniciar el hilo
            hiloNuevoServidor.IsBackground = true;
            hiloNuevoServidor.Start();

            Console.ReadKey();
        }        
    }
}
