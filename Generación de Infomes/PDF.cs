using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generación_de_Infomes
{
    public class Pdf : Informe
    {
        protected override void AplicarCalculos(string ObjetoDatos)
        {
            Console.WriteLine("Realizando calculos necesarios");
            //Se retornan los datos modificados a la variable datos
        }

        protected override void EnviarReporte(string ObjetoDatos)
        {
            Console.WriteLine("Enviando reporte de los datos obtenidos en formato PDF\n");
            //Se usan los datos formateados
        }

        protected override void ExtraerData(string ObjetoDatos)
        {
            Console.WriteLine("Extrayendo datos de la base de datos");
            //Se retornan los datos obtenidos a la variable datos
        }

        protected override void FormatearResultado(string ObjetoDatos)
        {
            Console.WriteLine($"Formateando resultado del informe {ObjetoDatos} en PDF");
        }
    }
}
