
using Generación_de_Infomes;


Informe informe = new Html();

informe.GenerarInforme("Contabilidad");

Informe informeExcel = new Excel();
informeExcel.GenerarInforme("Marketing");

Informe informePDF = new Pdf();
informePDF.GenerarInforme("Marketing");