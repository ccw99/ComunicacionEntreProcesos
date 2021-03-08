using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorPropiedades
{
    public class EstructuraPropiedades
    {
        public struct TarjetaMadre {
            public string deviceID;
            public string primaryBus;
            public string status;

            public TarjetaMadre(string deviceID, string primaryBus, string status)
            {
                this.deviceID = deviceID;
                this.primaryBus = primaryBus;
                this.status = status;
            }

        }

        public struct DiscoDuro {
            public string name;
            public string model;
            public string partitions;
            public string status;

            public DiscoDuro(string name,string model,string partitions, string status)
            {
                this.name = name;
                this.model = model;
                this.partitions = partitions;
                this.status = status;
            }
        }

        public struct Procesador {
            public string name;
            public string addressWidth;
            public string velocity;
            public string status;

            public Procesador(string name, string addressWidth,string velocity,string status)
            {
                this.name = name;
                this.addressWidth = addressWidth;
                this.velocity = velocity;
                this.status = status;
            }


        }

        public struct Bios {
            public string name;
            public string version;

            public Bios(string name, string version)
            {
                this.name = name;
                this.version = version;
            }
        }

        public struct SistemaOperativo {
            public string name;
            public string organization;
            public string primary;

            public SistemaOperativo(string name, string organization, string primary)
            {
                this.name = name;
                this.organization = organization;
                this.primary = primary;
            }
        }

        public struct Temperatura {
            public string status;
            public string temperature;

            public Temperatura(string status, string temperature)
            {
                this.status = status;
                this.temperature = temperature;
            }
        }

        public struct DetallesPC {

            public string hora { get; set; }
            public string fecha { get; set; }
            public TarjetaMadre tarjeM { get; set; }
            public List<DiscoDuro> discoD { get; set; }
            public Procesador process { get; set; }
            public Bios bi { get; set; }

            public SistemaOperativo so { get; set; }

            public Temperatura temp { get; set; }

            public DetallesPC(string hora, string fecha, TarjetaMadre tarjeM, List<DiscoDuro> discoD, Procesador process, Bios bi, SistemaOperativo so, Temperatura temp)
            {
                this.hora = hora;
                this.fecha = fecha;
                this.tarjeM = tarjeM;
                this.discoD = discoD;
                this.process = process;
                this.bi = bi;
                this.so = so;
                this.temp = temp;
            }
        }


    }
}
