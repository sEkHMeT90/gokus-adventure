/** 
 *   Nivel01: 
 **/

/* --------------------------------------------------         
   Goku's Adventure
   Versiones hasta la fecha:

   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  09-Jul-2011  Pedro Zalacain
                       Creado el Nivel 1
   0.02  12-Jul-2011  Antonio Pérez
                       Modificado el array del nivel para agregar
                       un cartel (C)
 ---------------------------------------------------- */

public class Nivel01 : Nivel
{
    public Nivel01(Mapa m)
        : base(m)
    {
        datosNivelIniciales[ 0] = "                                                                                                 ";
        datosNivelIniciales[ 1] = "                                                                                                 ";
        datosNivelIniciales[ 2] = "                                                                                                 ";
        datosNivelIniciales[ 3] = "                                                                                                 ";
        datosNivelIniciales[ 4] = "                                                                                                 ";
        datosNivelIniciales[ 5] = "                                                                                                 ";
        datosNivelIniciales[ 6] = "                                                                                                 ";
        datosNivelIniciales[ 7] = "                                                                                                 ";
        datosNivelIniciales[ 8] = "                                                                                                 ";
        datosNivelIniciales[ 9] = "                                                                                                 ";
        datosNivelIniciales[10] = "                                                                                                 ";
        datosNivelIniciales[11] = "                                                                                                 ";
        datosNivelIniciales[12] = "                                                                                                 ";
        datosNivelIniciales[13] = "      C                                                                                          ";
        datosNivelIniciales[14] = "HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH";
        datosNivelIniciales[15] = "RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR";
        datosNivelIniciales[16] = "RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR";
        datosNivelIniciales[17] = "RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR";

        this.Reiniciar();

    }

    public override void Reiniciar()
    {
        CrearEnemigos();
        base.Reiniciar();
    }

    public void CrearEnemigos()
    {
        numEnemigos = 1;        
        listaEnemigos = new Enemigo[numEnemigos];

        listaEnemigos[0] = new Enemigo();
        listaEnemigos[0].MoverA(630, 360);
        listaEnemigos[0].SetVelocidad(2, 0);
        listaEnemigos[0].setMinMaxX(625, 700);
        listaEnemigos[0].SetAnchoAlto(25, 25);
    }

} /* fin de la clase Nivel01 */
