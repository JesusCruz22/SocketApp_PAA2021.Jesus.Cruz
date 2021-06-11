using SocketApp1.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketApp1.Threads
{
    public class ServerThread
    {
        private ServerSocket serverSocket;

        public void Execute()
        {
            // Crear servidor socket
            serverSocket = new ServerSocket(); 
            if(serverSocket.Start())
            {
                Console.WriteLine("Servidor iniciado!");
                while (true)
                {
                    Socket socket = serverSocket.getClient(); // Cuando un cliente se conecte, levantará el socket
                    Console.WriteLine("Cliente conectado!");

                    // Cuando se conecta un cliente, se levanta el hilo del cliente con la conexión de socket del mismo
                    ClientThread clientThread = new ClientThread(socket);

                    // Levantar el hilo del nuevo cliente
                    Thread hiloNuevoCliente = new Thread(new ThreadStart(clientThread.LaunchClient));
                    hiloNuevoCliente.IsBackground = true;
                    hiloNuevoCliente.Start(); 
                }
            } 
            else
            {
                Console.WriteLine("Error al levantar servidor");
            }
        }

    }
}
