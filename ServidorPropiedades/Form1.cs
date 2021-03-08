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
        List<string> listapropiedades;
        DateTime date;
        PropiedadesServidor sp;
        Servidor servidor;
        public Form1()
        {
            InitializeComponent();
            getDate();
            tarjetaMadre();
            discoDuro();
            procesador();

            bios();
            sistemaOperativo();
            temperatura();
            servidor = new Servidor();
           // conexion();
           // Console.ReadKey();
        }


        public void getDate() {
            date = DateTime.Now;
            lblFecha.Text = date.ToShortTimeString() + "   " + date.ToLongDateString();
        
        }

        private void btnPropiedades_Click(object sender, EventArgs e)
        {
            
        }
        public void tarjetaMadre()
        {
            EstructuraPropiedades.TarjetaMadre tarmadre;
            sp = new PropiedadesServidor();
            tarmadre = sp.tarjetaMadre();
            lblTarjetaMadre.Text = "";
               
            lblTarjetaMadre.Text = tarmadre.deviceID + " - " + tarmadre.primaryBus + " - " + tarmadre.status;
            string json = JsonConvert.SerializeObject(tarmadre, Formatting.Indented);
        }
        public void discoDuro()
        {
            //listapropiedades = new List<string>();
            //sp = new PropiedadesServidor();
            //listapropiedades = sp.discoDuro();
            //lblDiscoDuro.Text = "";
            //foreach (string item in listapropiedades)
            //{
                
            //    lblDiscoDuro.Text += item + " ";
                
            //}
        }
        public void procesador()
        {
            EstructuraPropiedades.Procesador process = new EstructuraPropiedades.Procesador();
            sp = new PropiedadesServidor();
            process = sp.procesador();
            lblProcesador.Text = "";
            

           lblProcesador.Text = process.name + " " + process.velocity + " " + process.addressWidth + " " +process.status;
            string json = JsonConvert.SerializeObject(process, Formatting.Indented);
            // txtDescripcion.Text += item + " - ";

        }
        public void bios()
        {
            EstructuraPropiedades.Bios bi;
            sp = new PropiedadesServidor();
            bi = sp.bios();
            lblBios.Text = "";
            lblBios.Text = bi.name + " " + bi.version + " ";
            string json = JsonConvert.SerializeObject(bi, Formatting.Indented);
            // txtDescripcion.Text += item + " - ";

        }
        public void sistemaOperativo()
        {
            EstructuraPropiedades.SistemaOperativo so;
            sp = new PropiedadesServidor();
            so = sp.sistemaOperativo();
            lblSO.Text = "";
           lblSO.Text = so.name + " " +  so.organization +" " + so.primary;
                // txtDescripcion.Text += item + " - ";
       
        }
        public void temperatura()
        {
            EstructuraPropiedades.Temperatura temp;
            sp = new PropiedadesServidor();
            temp = sp.temperatura();
            lblTemperatura.Text = "";
            lblTemperatura.Text = temp.status + " " + temp.temperature;
                // txtDescripcion.Text += item + " - ";
       
        }
        public void conexion() {
            
            txtMensaje.Text = servidor.conexionSocket();
        }

        

    }
}
