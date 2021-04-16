using System;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace SocketApp1_Cliente.Comm
{
    public class ClientComm
    {
        private string server;
        private int port;
        private Socket communication;
        private StreamReader reader;
        private StreamWriter writer;

        public ClientComm(string server, int port)
        {
            this.server = server;
            this.port = port;
        }

        public bool Connect()
        {
            try
            {
                // 1.- Instanciar el socket (construirlo)
                communication = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp
                    );

                // 2.- Conectar
                communication.Connect(new IPEndPoint(IPAddress.Parse(server), port));

                // 3.- Construir el reader y el writer para posteriorment enviar/recibir mensajes (full-duplex)
                Stream stream = new NetworkStream(communication);
                writer = new StreamWriter(stream);
                reader = new StreamReader(stream);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public void Write(string message)
        {
            try
            {
                writer.WriteLine(message);
                writer.Flush(); // sanitizado 
            }
            catch (Exception)
            {
            }
        }

        public string Read()
        {
            try
            {
                return reader.ReadLine().Trim();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Disconnect()
        {
            try
            {
                communication.Close();
            } catch (Exception)
            {

            }
        }

    }
}
