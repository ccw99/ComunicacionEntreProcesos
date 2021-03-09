using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;


namespace ServidorPropiedades
{
    public class PropiedadesServidor
    {
        EstructuraPropiedades estpro;
       // ManagementObjectSearcher tarjetaMadre = new ManagementObjectSearcher("SELECT * FROM Win32_MotherboardDevice");
        //ManagementClass wmi = new ManagementClass(" //Class//");
        ManagementClass wmi;

        public PropiedadesServidor()
        {
            estpro = new EstructuraPropiedades();

        }
        
        
        
        
        
        public EstructuraPropiedades.TarjetaMadre tarjetaMadre() {
            wmi = new ManagementClass("Win32_MotherboardDevice");
            var providers = wmi.GetInstances();
            EstructuraPropiedades.TarjetaMadre tarmadre = new EstructuraPropiedades.TarjetaMadre();
            foreach (var item  in providers)
            {
                tarmadre = new EstructuraPropiedades.TarjetaMadre(item["DeviceID"].ToString(), item["PrimaryBusType"].ToString(),item["Status"].ToString());
            }
            return tarmadre;
        }

        public List<EstructuraPropiedades.DiscoDuro> discoDuro() {
            wmi = new ManagementClass("Win32_DiskDrive");
            var providers = wmi.GetInstances();
            EstructuraPropiedades.DiscoDuro discoD;
            List<EstructuraPropiedades.DiscoDuro> propiedades = new List<EstructuraPropiedades.DiscoDuro>();
            foreach (var item in providers)
            {
                discoD = new EstructuraPropiedades.DiscoDuro(item["Name"].ToString(), item["Partitions"].ToString(), item["Status"].ToString(), item["Size"] + "");

                propiedades.Add(discoD);

               // propiedades.Add(item["Name"].ToString());
               //  propiedades.Add(item["Model"].ToString());
               //  propiedades.Add(item["Partitions"].ToString());
               //  propiedades.Add(item["Status"].ToString());
               //propiedades.Add(item["Size"] + "" );

            }


            return propiedades;
        }
        public EstructuraPropiedades.Procesador procesador()
        {
            wmi = new ManagementClass("Win32_Processor");
            var providers = wmi.GetInstances();
            EstructuraPropiedades.Procesador process = new EstructuraPropiedades.Procesador();
            foreach (var item in providers)
            {
                process = new EstructuraPropiedades.Procesador(item["Name"].ToString(), item["AddressWidth"].ToString(), item["CurrentClockSpeed"].ToString(), item["Status"].ToString());
            }


            return process;
        }
        public EstructuraPropiedades.Bios bios()
        {
            wmi = new ManagementClass("Win32_BIOS");
            var providers = wmi.GetInstances();
            EstructuraPropiedades.Bios bi = new EstructuraPropiedades.Bios();
            foreach (var item in providers)
            {
                bi = new EstructuraPropiedades.Bios(item["Name"].ToString(), item["Version"].ToString());
                //propiedades.Add(item["Size"] + "" );
            }


            return bi;
        }
        public EstructuraPropiedades.SistemaOperativo sistemaOperativo()
        {
            wmi = new ManagementClass("Win32_OperatingSystem");
            var providers = wmi.GetInstances();
            EstructuraPropiedades.SistemaOperativo so = new EstructuraPropiedades.SistemaOperativo();
            foreach (var item in providers)
            {
                
                so = new EstructuraPropiedades.SistemaOperativo(item["Name"].ToString(), item["Organization"].ToString(), item["Primary"] + "");
            }


            return so;
        }
        public EstructuraPropiedades.Temperatura temperatura()
        {
            wmi = new ManagementClass("Win32_TemperatureProbe");
            var providers = wmi.GetInstances();
            EstructuraPropiedades.Temperatura temp = new EstructuraPropiedades.Temperatura();
            foreach (var item in providers)
            {
               
                temp = new EstructuraPropiedades.Temperatura(item["Status"].ToString(), "");
            }


            return temp;
        }


    }
}
