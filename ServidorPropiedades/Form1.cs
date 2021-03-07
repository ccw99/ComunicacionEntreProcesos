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

namespace ServidorPropiedades
{
    public partial class Form1 : Form
    {
        List<string> listapropiedades;
        DateTime date;
        PropiedadesServidor sp;
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
            listapropiedades = new List<string>();
            sp = new PropiedadesServidor();
            listapropiedades = sp.tarjetaMadre();
            lblTarjetaMadre.Text = "";
            foreach (string item in listapropiedades)
            {
                
                lblTarjetaMadre.Text += item + " ";
            }
        }
        public void discoDuro()
        {
            listapropiedades = new List<string>();
            sp = new PropiedadesServidor();
            listapropiedades = sp.discoDuro();
            lblDiscoDuro.Text = "";
            foreach (string item in listapropiedades)
            {
                
                lblDiscoDuro.Text += item + " ";
                
            }
        }
        public void procesador()
        {
            listapropiedades = new List<string>();
            sp = new PropiedadesServidor();
            listapropiedades = sp.procesador();
            lblProcesador.Text = "";
            foreach (string item in listapropiedades)
            {

                lblProcesador.Text += item + " ";
               // txtDescripcion.Text += item + " - ";
            }
        }
        public void bios()
        {
            listapropiedades = new List<string>();
            sp = new PropiedadesServidor();
            listapropiedades = sp.bios();
            lblBios.Text = "";
            foreach (string item in listapropiedades)
            {

                lblBios.Text += item + " ";
                // txtDescripcion.Text += item + " - ";
            }
        }
        public void sistemaOperativo()
        {
            listapropiedades = new List<string>();
            sp = new PropiedadesServidor();
            listapropiedades = sp.sistemaOperativo();
            lblSO.Text = "";
            foreach (string item in listapropiedades)
            {

                lblSO.Text += item + " ";
                // txtDescripcion.Text += item + " - ";
            }
        }
        public void temperatura()
        {
            listapropiedades = new List<string>();
            sp = new PropiedadesServidor();
            listapropiedades = sp.temperatura();
            lblTemperatura.Text = "";
            foreach (string item in listapropiedades)
            {

                lblTemperatura.Text += item + " ";
                // txtDescripcion.Text += item + " - ";
            }
        }

    }
}
