/** 
 *   Nivel: Contiene la información del nivel actual
 **/

/* --------------------------------------------------         
   Goku's Adventure
   Versiones hasta la fecha:
   
   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  05-Jul-2011  Andrés Marotta
                      Version inicial: Creada la clase "Nivel".
                      Agregados los atributos "ayuda" y "enemigo"
                        para enlazar con las clases "Ayuda" y "Enemigo"
                        respectivamente.
                      
 ---------------------------------------------------- */

using System;

class Nivel
{
  private Ayuda ayuda;
  private Enemigo enemigo;

  public Nivel()
  {
    ayuda = new Ayuda();
    enemigo = new Enemigo();
  }

  // TODO
}
