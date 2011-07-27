/** 
 *   Nivel: 
 **/

/* --------------------------------------------------         
   Goku's Adventure
   Versiones hasta la fecha:

   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  09-Jul-2011  Pedro Zalacain
   					   Creada la clase
                       Enlazado con Mapa para AvanzarNivel
   0.02  12-Jul-2011  Antonio Pérez
                       Agregado el atributo "cartel" y el caso "C"
                       en el switch que dibuja el fondo
 ---------------------------------------------------- */

public class Nivel
{
    // Datos del mapa de fondo 
    protected Partida miPartida;

    private int altoMapa = 18, anchoMapa = 97;
    private int anchoTile = 32, altoTile = 32;
    private int margenIzqdo = 0, margenSuperior = 30;
    
    protected Mapa mapaPertenece;

    // Imagenes para el fondo
    ElemGrafico muroRojo, hierba, cartel;

    //Enemigos
    protected int numEnemigos;
    protected Enemigo[] listaEnemigos;

    string[] datosNivel; // Datos en el momento de Juego

    protected string[] datosNivelIniciales = {
    	"                                                                                                 ",
        "                                                                                                 ",
    	"                                                                                                 ",
        "                                                                                                 ",
        "                                                                                                 ",
        "                                                                                                 ",
        "                                                                                                 ",
    	"                                                                                                 ",
    	"                                                                                                 ",
    	"                                                                                                 ",
        "                                                                                                 ",
        "                                                                                                 ",
        "                                                                                                 ",
        "                                                                                                 ",
        "                                                                                                 ",
        "                                                                                                 ",
        "                                                                                                 ",
        "                                                                                                 "};

    // Constructor
    public Nivel(Mapa elMapa)
    {
        mapaPertenece = elMapa;

        // Casillas repetitivas para el fondo
        muroRojo = new ElemGrafico("imagenes/Mapa/muroRojo.PNG");
        hierba = new ElemGrafico("imagenes/Mapa/hierba.PNG");
        cartel = new ElemGrafico( "imagenes/Mapa/imagenCartel.PNG" );

        numEnemigos = 0;
        datosNivel = new string[altoMapa];
        Reiniciar();
    }

    public virtual void Reiniciar()
    {
        for (int fila = 0; fila < altoMapa; fila++)
            datosNivel[fila] = datosNivelIniciales[fila];
    }

    public void DibujarOculta(int valor) // TODO: ····· PRUEBAS SCROLL!
    {
        // Dibujo el fondo
        for (int i = 0; i < altoMapa; i++)
            for (int j = 0; j < anchoMapa; j++)
            {
                int posX = j * anchoTile + margenIzqdo;
                int posY = i * altoTile + margenSuperior;
                switch (datosNivel[i][j])
                {
                    case 'R': muroRojo.DibujarOculta(posX + valor, posY); break;
                    case 'H': hierba.DibujarOculta(posX + valor, posY); break;
                    case 'C': cartel.DibujarOculta( posX + valor, posY ); break;
                }
            }
    }

    public bool EsPosibleMover(int x, int y, int ancho, int alto, int scroll)
    {
        // Voy a comprobar si coincide con el fondo 
        // alguna de las cuatro esquinas del personaje:
        // (x,y)  (x+ancho,y)  (x,y+alto)  (x+ancho,y+alto)
        // y dos puntos intermedios de los costados
        // (x, y+(alto/2))  (x+ancho, y+(alto/2))

        // Primera esquina: (x,y)
        int xMapa = (x - margenIzqdo - scroll) / anchoTile;
        int yMapa = (y - margenSuperior) / altoTile;
        if (datosNivel[yMapa][xMapa] == 'H')
            return false;

        // Segunda esquina: (x+ancho,y)
        xMapa = (x + ancho - margenIzqdo - scroll) / anchoTile;
        yMapa = (y - margenSuperior) / altoTile;
        if (datosNivel[yMapa][xMapa] == 'H')
            return false;

        // Tercera esquina: (x,y+alto)
        xMapa = (x - margenIzqdo - scroll) / anchoTile;
        yMapa = (y + alto - margenSuperior) / altoTile;
        if (datosNivel[yMapa][xMapa] == 'H')
            return false;

        // Cuarta esquina: (x+ancho,y+alto)
        xMapa = (x + ancho - margenIzqdo - scroll) / anchoTile;
        yMapa = (y + alto - margenSuperior) / altoTile;
        if (datosNivel[yMapa][xMapa] == 'H')
            return false;

        // Punto intermedio: (x, y+(alto/2))
        xMapa = (x - margenIzqdo - scroll) / anchoTile;
        yMapa = (y + (alto / 2) - margenSuperior) / altoTile;
        if (datosNivel[yMapa][xMapa] == 'H')
            return false;

        // Punto intermedio:  (x+ancho, y+(algo/2))
        xMapa = (x + ancho - margenIzqdo - scroll) / anchoTile;
        yMapa = (y + (alto / 2) - margenSuperior) / altoTile;
        if (datosNivel[yMapa][xMapa] == 'H')
            return false;

        return true;
    }

    public bool EsPosibleCaer(int x, int y, int ancho, int alto, int scroll)
    {
        // Pie Izquierdo: (x,y+alto)
        int xMapa = (x - margenIzqdo - scroll) / anchoTile;
        int yMapa = (y + alto - margenSuperior) / altoTile;

        if (datosNivel[yMapa][xMapa] == 'H')
            return false;

        // Pie Derecho: (x+ancho,y+alto)
        xMapa = (x + ancho - margenIzqdo - scroll) / anchoTile;
        yMapa = (y + alto - margenSuperior) / altoTile;

        if (datosNivel[yMapa][xMapa] == 'H')
            return false;

        return true;
    }

    public int GetMaxX()
    {
        return 800 - margenIzqdo;
    }


    public int GetMinX()
    {
        return margenIzqdo;
    }


    public int GetMaxY()
    {
        return 600 - margenSuperior;
    }


    public int GetMinY()
    {
        return margenSuperior;
    }

    public void AvanzarNivel()
    {
        mapaPertenece.Avanzar();
    }

    //Para los enemigos
    public int GetNumEnemigos()
    {
        return numEnemigos;
    }

    public Enemigo GetEnemigo(int i)
    {
        if (numEnemigos > i)
            return listaEnemigos[i];

        return null;
    }

} /* end class Mapa */