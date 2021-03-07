using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServidorPropiedades
{
    class Servidor
    {
        Socket listen;
        Socket conexion;
        IPEndPoint conectar;
        public Servidor()
        {
            listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            conectar= new IPEndPoint(IPAddress.Parse("10.185.169.253"), 6400);
            
        }



        public void escuchando(){
        
        }


        public string conexionSocket() {
            listen.Bind(conectar);
            //Numero maximo de conexciones
            listen.Listen(10);
            conexion = listen.Accept();

            byte[] recibir_mensaje = new byte[100];
            string data = "";
            int array_size = 0;
            //Creamos exacatamente la longitud con el cuial no esta llegando el mensaje
            array_size = conexion.Receive(recibir_mensaje, 0, recibir_mensaje.Length, 0);
            //se ajusa justamente con la bits q necesitamos
            Array.Resize(ref recibir_mensaje, array_size);

            data = Encoding.Default.GetString(recibir_mensaje);

            return "La info que recibimos : " + data;
              
        }
    }
}
