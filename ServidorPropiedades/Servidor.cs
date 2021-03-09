using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Threading;

namespace ServidorPropiedades
{
    class Servidor
    {
        IPHostEntry host;
        IPAddress ipAddress;
        Socket socketServidor;
        Socket socketCliente;
        IPEndPoint conectar;
        //string enviar_mensaje;
        public Servidor(string ip,int puerto)
        {
            host = Dns.GetHostEntry(ip);
            ipAddress = host.AddressList[0];
            conectar = new IPEndPoint(ipAddress,puerto);
            socketServidor = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socketServidor.Bind(conectar);
            socketServidor.Listen(10);
        }

       
            
        public void aceptarConexion(){
           // Thread t;
           // while (true)
           // {
                
           //     t = new Thread(conexionSocket);
            //    t.Start(socketCliente);
           // }
        }


        public string conexionSocket(string mensaje) {

            socketCliente = socketServidor.Accept();
            int index;

            byte[] recibir_mensaje = new byte[1024];
            string data = "";
            int array_size = 0;
            //Creamos exacatamente la longitud con el cuial no esta llegando el mensaje
            array_size = socketCliente.Receive(recibir_mensaje, 0, recibir_mensaje.Length, 0);
            //se ajusa justamente con la bits q necesitamos
            Array.Resize(ref recibir_mensaje, array_size);

            data = Encoding.ASCII.GetString(recibir_mensaje);
            index = data.IndexOf('\0');
            if (index>0)
            {
                data = data.Substring(0, index);
            }

            if (data == "true")
            {
                enviarMensaje(mensaje);

            }


            return "La info que recibimos : " + data;
              
        }
        public void enviarMensaje(string mensaje)
        {
            //conectar = new IPEndPoint(IPAddress.Parse("10.187.46.226"), 6400);
            //listen.Connect(conectar);
            byte[] enviar_mensaje;
            enviar_mensaje = Encoding.Default.GetBytes(mensaje);
            socketCliente.Send(enviar_mensaje);
        }
    }
}
