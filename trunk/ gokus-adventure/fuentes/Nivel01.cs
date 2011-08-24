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
        datosNivelIniciales[ 6] = "HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH";
        datosNivelIniciales[ 7] = "RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR";

        this.Reiniciar();

    }

    public override void Reiniciar()
    {
        CrearEnemigos();
        CrearCarteles();
        CrearObjetos();
        base.Reiniciar();
    }

    public void CrearEnemigos()
    {
        numEnemigos = 1;        
        listaEnemigos = new Enemigo[numEnemigos];

        listaEnemigos[ 0 ] = new EnemigoPterodactyl( 630 , 360 , 2);
        listaEnemigos[ 0 ].setMinMaxX( 425, 700 );
        listaEnemigos[ 0 ].CambiarDireccion( ElemGrafico.DERECHA );
    }

    public void CrearCarteles()
    {
        numCarteles = 2;
        listaCarteles = new CartelAyuda[numCarteles];

        listaCarteles[0] = new CartelAyuda(200, 500, "imagenes/CartelesAyuda/CartelPrueba.PNG", this);
        listaCarteles[1] = new CartelAyuda(600, 500, "imagenes/CartelesAyuda/CartelPrueba2.PNG", this);
    }

    public void CrearObjetos()
    {
        numObjetos = 3;
        listaObjetos = new ObjetoRecogible[numObjetos];

        listaObjetos[0] = new Moneda(100, 450);
        listaObjetos[1] = new Moneda(150, 450);
        listaObjetos[2] = new Moneda(200, 450);
    }

} /* fin de la clase Nivel01 */
