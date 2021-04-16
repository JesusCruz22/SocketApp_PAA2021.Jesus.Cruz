using System;
using System.IO;
using System.Net.Sockets;

namespace SocketApp1.Comm
{
    public class ClientSocket
    {
        // Socket recibido con conexión abierta
        private Socket cliente;
        // Trabajo de Stream (corriente o flujo)
        // flujo para enviar datos al socket (servidor)
        private StreamWriter writer;

        // flujo para recibir datos desde el socket (servidor)
        private StreamReader reader;

        public ClientSocket(Socket cliente)
        {
            // guardamos el socket con la conexión abierta en los atributos
            this.cliente = cliente;

            // voy a crear un objeto que me permita escribir una corriente o flujo en RED
            // (Existen corrientes o flujos que también sirven para escribir archivos o directamente en memoria)
            Stream stream = new NetworkStream(cliente);
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);
        }

        // Leer, Escribir - Desconectarse
        public string Read()
        {
            try
            {
                return reader.ReadLine(); // si devuelve una string, leyó correctamente
            }
            catch (Exception)
            {
                return null; // si devuelve null, no leyó correctamente                
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

        public void Disconnect()
        {
            try
            {
                cliente.Close();
            }
            catch (Exception)
            {
            }
        }
    }
}
