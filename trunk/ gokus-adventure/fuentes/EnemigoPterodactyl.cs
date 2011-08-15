/** 
 *   EnemigoPterodactyl: Contiene la información del enemigo Pterodactyl.
 **/

/* --------------------------------------------------         
   Goku's Adventure
   Versiones hasta la fecha:
   
   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  05-Jul-2011  Andrés Marotta
                      Version inicial: Creada la clase "Enemigo".
   
 ---------------------------------------------------- */

using System;

public class EnemigoPterodactyl : Enemigo
{
  public EnemigoPterodactyl(int x, int y, int velocidad )
    {
      CargarSecuencia( DERECHA,
            new string[] {
              "imagenes/Enemigos/Pterodactyl/volandoD1.png", "imagenes/Enemigos/Pterodactyl/volandoD1.png",
              "imagenes/Enemigos/Pterodactyl/volandoD2.png", "imagenes/Enemigos/Pterodactyl/volandoD2.png",
              "imagenes/Enemigos/Pterodactyl/volandoD3.png", "imagenes/Enemigos/Pterodactyl/volandoD3.png",
              "imagenes/Enemigos/Pterodactyl/volandoD4.png", "imagenes/Enemigos/Pterodactyl/volandoD4.png",
              "imagenes/Enemigos/Pterodactyl/volandoD5.png", "imagenes/Enemigos/Pterodactyl/volandoD5.png",
              "imagenes/Enemigos/Pterodactyl/volandoD6.png", "imagenes/Enemigos/Pterodactyl/volandoD6.png",}
          ); 
      CargarSecuencia( IZQUIERDA,
             new string[] {
              "imagenes/Enemigos/Pterodactyl/volandoI1.png", "imagenes/Enemigos/Pterodactyl/volandoI1.png",
              "imagenes/Enemigos/Pterodactyl/volandoI2.png", "imagenes/Enemigos/Pterodactyl/volandoI2.png",
              "imagenes/Enemigos/Pterodactyl/volandoI3.png", "imagenes/Enemigos/Pterodactyl/volandoI3.png",
              "imagenes/Enemigos/Pterodactyl/volandoI4.png", "imagenes/Enemigos/Pterodactyl/volandoI4.png",
              "imagenes/Enemigos/Pterodactyl/volandoI5.png", "imagenes/Enemigos/Pterodactyl/volandoI5.png",
              "imagenes/Enemigos/Pterodactyl/volandoI6.png", "imagenes/Enemigos/Pterodactyl/volandoI6.png",}
           );

      CambiarDireccion( DERECHA );
      SetAnchoAlto( 61, 45 );
      MoverA( x, y );
      SetVelocidad( velocidad, 0 );
     }
}
