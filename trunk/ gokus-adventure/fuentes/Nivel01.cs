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
 ---------------------------------------------------- */

public class Nivel01 : Nivel
{
    public Nivel01(Mapa m)
        : base(m)
    {
        datosNivelIniciales[0] = "                                                                                                 ";
        datosNivelIniciales[1] = "                                                                                                 ";
        datosNivelIniciales[2] = "                                                                                                 ";
        datosNivelIniciales[3] = "                                                                                                 ";
        datosNivelIniciales[4] = "                                                                                                 ";
        datosNivelIniciales[5] = "                                                                                                 ";
        datosNivelIniciales[6] = "                                                                                                 ";
        datosNivelIniciales[7] = "                                                                                                 ";
        datosNivelIniciales[8] = "                                                                                                 ";
        datosNivelIniciales[9] = "                                                                                                 ";
        datosNivelIniciales[10] = "                                                                                                 ";
        datosNivelIniciales[11] = "                                                                                                 ";
        datosNivelIniciales[12] = "                                                                                                 ";
        datosNivelIniciales[13] = "                                                                                                 ";
        datosNivelIniciales[14] = "HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH";
        datosNivelIniciales[15] = "RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR";
        datosNivelIniciales[16] = "RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR";
        datosNivelIniciales[17] = "RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR";

        this.Reiniciar();
    }

    public override void Reiniciar()
    {
        base.Reiniciar();
        // CrearEnemigos();
    }

} /* fin de la clase Nivel01 */
