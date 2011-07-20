﻿/** 
 *   Enemigo: Contiene la información de los enemigos del nivel
 **/

/* --------------------------------------------------         
   Goku's Adventure
   Versiones hasta la fecha:
   
   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  05-Jul-2011  Andrés Marotta
                      Version inicial: Creada la clase "Enemigo".
   0.02  10-Jul-2011  Antonio Ramos
                      Creado un constructor vacio para probar los movimientos del enemigo y la funcion mover
 ---------------------------------------------------- */

using System;

class Enemigo : ElemGrafico
{
    /* Para su funcionamiento:
      
        miEnemigo.MoverA(400, 360);         coloca el la posicion
        miEnemigo.SetVelocidad(2, 0);       depende de si es horizontal o vertical
        miEnemigo.setMinMaxX(100, 700);     desde hasta donde quiere llevar
        miEnemigo.SetAnchoAlto(25, 25);     medidas de la imagen
      
      miEnemigo.Mover(); para que se mueva solo.
      
     */

    // Constructor para probar el movimiento automatico imagen del personaje para verlo en movimiento de prueba
    public Enemigo()
    {
        CargarImagen("imagenes/personaje.png");
    }


    // Funcion para mover al personaje automaticamente.
    // TODO: El movimiento es independiente del scroll
    //       para futuras versiones solucionar el problema del scroll
    public new void Mover()
    {
        if (incrX != 0)
        {
            x += incrX;

            if ((x < minX) || (x > maxX))
            {
                incrX = (short)(-incrX);
            }
        }
        if (incrY != 0)
        {
            y += incrY;

            if ((y < minY) || (y > maxY))
            {
                incrY = (short)(-incrY);
            }
        }
    }

    public void MoverScroll(int valor)
    {
        x += (short) valor;
    }

}
