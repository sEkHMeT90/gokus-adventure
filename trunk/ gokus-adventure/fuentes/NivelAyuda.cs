/** 
 *   NivelAyuda: 
 **/

/* --------------------------------------------------         
   Goku's Adventure
   Versiones hasta la fecha:

   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  15-Jul-2011  Raquel Lloréns
                       Creada la clase.
 ---------------------------------------------------- */

public class NivelAyuda : Nivel
{
    public NivelAyuda(Mapa m)
        : base(m)
    {
        datosNivelIniciales[ 0] = "                                                                                                 ";
        datosNivelIniciales[ 1] = "                                                                                                 ";
        datosNivelIniciales[ 2] = "                                                                                                 ";
        datosNivelIniciales[ 3] = "                                                                                                 ";
        datosNivelIniciales[ 4] = "                                                                                                 ";
        datosNivelIniciales[ 5] = "                                                                                                 ";
        datosNivelIniciales[ 6] = "HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH";
        datosNivelIniciales[ 7] = "RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR";

        this.Reiniciar();
    }

    public override void Reiniciar()
    {
        base.Reiniciar();
        // CrearEnemigos();
    }

} /* fin de la clase NivelAyuda */
