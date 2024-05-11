using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generación_de_Infomes
{
    public abstract class Informe
      
    {
        public void GenerarInforme(string ObjetoDatos)
        {
            ExtraerData(ObjetoDatos);
            AplicarCalculos(ObjetoDatos);
            FormatearResultado(ObjetoDatos);
            EnviarReporte(ObjetoDatos);
        }

        protected abstract void ExtraerData(string ObjetoDatos);
        protected abstract void AplicarCalculos( string ObjetoDatos);
        protected abstract void FormatearResultado(string ObjetoDatos);
        protected abstract void EnviarReporte(string ObjetoDatos);

    }
}
