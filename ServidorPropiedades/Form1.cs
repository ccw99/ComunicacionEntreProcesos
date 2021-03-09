using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Newtonsoft.Json;

namespace ServidorPropiedades
{
    public partial class Form1 : Form
    {
        EstructuraPropiedades.Temperatura temp;
        EstructuraPropiedades.SistemaOperativo so;
        EstructuraPropiedades.TarjetaMadre tarmadre;
        EstructuraPropiedades.Procesador process;
        EstructuraPropiedades.Bios bi;
        List<EstructuraPropiedades.DiscoDuro> discosD;
        DateTime date;
        PropiedadesServidor sp;
        Servidor servidor;
        string hora;
        string fecha;
        public Form1()
        {
            InitializeComponent();

            detallesMetodos();
            servidor = new Servidor("10.187.249.56", 6400);
            conexion(enviarMensaje());
           // Console.ReadKey();
        }
        public void detallesMetodos()
        {
            getDate();
            tarjetaMadre();
            discoDuro();
            procesador();

            bios();
            sistemaOperativo();
            temperatura();
        }

        public void getDate() {
            date = DateTime.Now;
            hora = date.ToShortTimeString();
            fecha = date.ToLongDateString();
            lblFecha.Text = hora  + "   " + fecha;
        
        }

        private void btnPropiedades_Click(object sender, EventArgs e)
        {
            
        }
        public void tarjetaMadre()
        {
           
            sp = new PropiedadesServidor();
            tarmadre = sp.tarjetaMadre();
            lblTarjetaMadre.Text = "";
               
            lblTarjetaMadre.Text = tarmadre.deviceID + " - " + tarmadre.primaryBus + " - " + tarmadre.status;
            string json = JsonConvert.SerializeObject(tarmadre, Formatting.Indented);
        }
        public void discoDuro()
        {
            
            sp = new PropiedadesServidor();
            discosD = sp.discoDuro();
            lblDiscoDuro.Text = "";
            foreach (EstructuraPropiedades.DiscoDuro item in discosD)
            {

                //lbldiscoduro.text += item + " ";
                lblDiscoDuro.Text += item.name +" - "+ item.model + " - " + item.partitions + " - " + item.status;
            }
        }
        public void procesador()
        {
           
            sp = new PropiedadesServidor();
            process = sp.procesador();
            lblProcesador.Text = "";
            

           lblProcesador.Text = process.name + " " + process.velocity + " " + process.addressWidth + " " +process.status;
            string json = JsonConvert.SerializeObject(process, Formatting.Indented);
            // txtDescripcion.Text += item + " - ";

        }
        public void bios()
        {
           
            sp = new PropiedadesServidor();
            bi = sp.bios();
            lblBios.Text = "";
            lblBios.Text = bi.name + " " + bi.version + " ";
            
            // txtDescripcion.Text += item + " - ";

        }
        public void sistemaOperativo()
        {
           
            sp = new PropiedadesServidor();
            so = sp.sistemaOperativo();
            lblSO.Text = "";
           lblSO.Text = so.name + " " +  so.organization +" " + so.primary;
                // txtDescripcion.Text += item + " - ";
       
        }
        public void temperatura()
        {
           
            sp = new PropiedadesServidor();
            temp = sp.temperatura();
            lblTemperatura.Text = "";
            lblTemperatura.Text = temp.status + " " + temp.temperature;
                // txtDescripcion.Text += item + " - ";
       
        }
        public void conexion(string mensaje) {
            
            txtMensaje.Text = servidor.conexionSocket(mensaje);
        }

        public string enviarMensaje()
        {

            EstructuraPropiedades.DetallesPC detallePc = new EstructuraPropiedades.DetallesPC(date.ToShortTimeString(), date.ToLongDateString(), tarmadre,discosD,process,bi,so,temp);
            string json = JsonConvert.SerializeObject(detallePc, Formatting.Indented);
            txtMensaje.Text = json;
            return json;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // enviarMensaje();
        }
    }
}
