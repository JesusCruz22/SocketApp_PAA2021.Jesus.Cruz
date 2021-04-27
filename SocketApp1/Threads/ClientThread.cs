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

            // A) SOLICITAR DATOS AL CLIENTE
            // Enviar solicitud de ingreso de remitente y guardar resultado desde el socket
            clientSocket.Write("Ingrese remitente:");
            string remitente = clientSocket.Read();

            // Enviar solicitud de ingreso de texto y guardar resultado desde el socket
            clientSocket.Write("Ingrese texto:");
            string texto = clientSocket.Read();

            // B) CREAR EL MENSAJE
            // Elaboramos el mensaje (DTO)
            Message mensaje = new Message()
            {
                Remitente = remitente,
                Texto = texto,
                Tipo = "NORMAL"
            };

            // Para enviar un DTO => DAL
            MessageDAL messageDAL = MessageDAL.GetInstance();

            // GUARDAR EL MENSAJE (DE FORMA SEGURA)
            lock (messageDAL)
            {
                messageDAL.Add(mensaje);
            }
            clientSocket.Disconnect();
        }
    }
}
