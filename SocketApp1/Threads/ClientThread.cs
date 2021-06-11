using SocketApp1.Comm;
using SocketAppDAL.DAL;
using SocketAppDAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketApp1.Threads
{
    public class ClientThread
    {
        private Socket clienteConectado;
        private ClientSocket clientSocket;

        public ClientThread(Socket clienteConectado)
        {
            this.clienteConectado = clienteConectado;
        }

        // Método que se llamará SIN PARÁMETROS al crear el hilo del Cliente! => ThreadStart(LaunchLient)
        public void LaunchClient()
        {
            // Interactuar con el cliente
            clientSocket = new ClientSocket(clienteConectado);

            /* SOLICITAR VALORES DE CELDA AL CLIENTE */
            // Solicitar ID de celda
            clientSocket.Write("Ingrese el ID de la celda:");
            string idCelda = clientSocket.Read();

            // Solicitar los valores de la celda
            // Voltaje
            clientSocket.Write("- Voltaje:");
            string voltaje = clientSocket.Read();
            // Temperatura
            clientSocket.Write("- Temperatura:");
            string temperatura = clientSocket.Read();
            // Nivel
            clientSocket.Write("- Nivel:");
            string nivel = clientSocket.Read();
            // Flujo
            clientSocket.Write("- Flujo:");
            string flujo = clientSocket.Read();
            // Observaciones
            clientSocket.Write("- Observaciones:");
            string observaciones = clientSocket.Read();

            /* CREAR EL MENSAJE PARA EL DTO */
            Message message = new Message()
            {
                IdCelda = idCelda,
                Voltaje = voltaje,
                Temperatura = temperatura,
                Flujo = flujo,
                Nivel = nivel,
                Observaciones = observaciones
            };

            // Para enviar un DTO => DAL
            MessageDAL messageDAL = MessageDAL.GetInstance();

            /* GUARDAR EL MENSAJE DE FORMA SEGURA Y DESCONECTAR CLIENT SOCKET */
            lock (messageDAL)
            {
                messageDAL.Add(message);
            }

            clientSocket.Disconnect();
        }
    }
}
