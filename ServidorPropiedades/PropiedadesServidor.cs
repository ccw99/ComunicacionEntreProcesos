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
       // ManagementObjectSearcher tarjetaMadre = new ManagementObjectSearcher("SELECT * FROM Win32_MotherboardDevice");
        //ManagementClass wmi = new ManagementClass(" //Class//");
        ManagementClass wmi;

        public PropiedadesServidor()
        {
           

        }
        
        
        
        
        
        public List<string> tarjetaMadre() {
            wmi = new ManagementClass("Win32_MotherboardDevice");
            var providers = wmi.GetInstances();
            List<string> propiedades = new List<string>();
            foreach (var item  in providers)
            {
                propiedades.Add(item["DeviceID"].ToString());
                propiedades.Add(item["PrimaryBusType"].ToString());
                propiedades.Add(item["SecondaryBusType"].ToString());
                propiedades.Add(item["Status"].ToString());
            }
            return propiedades;
        }

        public List<string> discoDuro() {
            wmi = new ManagementClass("Win32_DiskDrive");
            var providers = wmi.GetInstances();
            List<string> propiedades = new List<string>();
            foreach (var item in providers)
            {
                propiedades.Add(item["Name"].ToString());
                propiedades.Add(item["Model"].ToString());
                propiedades.Add(item["Partitions"].ToString());
                propiedades.Add(item["Status"].ToString());
                //propiedades.Add(item["Size"] + "" );
            }


            return propiedades;
        }
        public List<string> procesador()
        {
            wmi = new ManagementClass("Win32_Processor");
            var providers = wmi.GetInstances();
            List<string> propiedades = new List<string>();
            foreach (var item in providers)
            {
                propiedades.Add(item["Name"].ToString());
                propiedades.Add(item["AddressWidth"].ToString());
                propiedades.Add(item["CurrentClockSpeed"].ToString());
                propiedades.Add(item["Status"].ToString());
                //propiedades.Add(item["Size"] + "" );
            }


            return propiedades;
        }
        public List<string> bios()
        {
            wmi = new ManagementClass("Win32_BIOS");
            var providers = wmi.GetInstances();
            List<string> propiedades = new List<string>();
            foreach (var item in providers)
            {
                propiedades.Add(item["Name"].ToString());
                
                propiedades.Add(item["Version"].ToString());
                //propiedades.Add(item["Size"] + "" );
            }


            return propiedades;
        }
        public List<string> sistemaOperativo()
        {
            wmi = new ManagementClass("Win32_OperatingSystem");
            var providers = wmi.GetInstances();
            List<string> propiedades = new List<string>();
            foreach (var item in providers)
            {
                propiedades.Add(item["Name"].ToString());

                propiedades.Add(item["Organization"].ToString());
                propiedades.Add(item["Primary"] + "" );
            }


            return propiedades;
        }
        public List<string> temperatura()
        {
            wmi = new ManagementClass("Win32_TemperatureProbe");
            var providers = wmi.GetInstances();
            List<string> propiedades = new List<string>();
            foreach (var item in providers)
            {
                

                propiedades.Add(item["Status"].ToString());
                propiedades.Add(item["CurrentReading"] + "");
            }


            return propiedades;
        }


    }
}
