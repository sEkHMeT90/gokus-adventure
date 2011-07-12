/** 
 *   Ayuda: Contiene la información de los carteles de ayuda del nivel
 **/

/* --------------------------------------------------         
   Goku's Adventure
   Versiones hasta la fecha:
   
   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  05-Jul-2011  Andrés Marotta
                      Version inicial: Creada la clase "Ayuda".
 
   0.02  11-Jul-2011  Antonio Pérez
                      Crear constructor y metodos para los atributos.                      
 ---------------------------------------------------- */

using System;

class Ayuda : ElemGrafico
{
  string texto;

  public Ayuda( string textoAyuda, short NuevaX, short NuevaY )
  {
    texto = textoAyuda;
    x = NuevaX;
    y = NuevaY;
    ancho = 32;
    alto = 27;
  }

  public Ayuda GetAyuda()
  {
    return this;
  }

  public string GetTextoAyuda()
  {
    return texto;
  }
}
