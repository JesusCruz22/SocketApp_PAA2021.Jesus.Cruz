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

        // Construir el socket a partir del thread
        // Ejecutar la lectura de clientes
        // Hacer una ejecución de cada cliente que se conecta en otro thread
        public void Execute()
        {
            serverSocket = new ServerSocket(); // Crear servidor socket (hecho previamente)
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

                // ToDo: Hacer una ejecución de cada cliente que se conecta en otro thread (req: ClientThread)

            } else
            {
                Console.WriteLine("Error al levantar servidor");
            }
        }

    }
}
