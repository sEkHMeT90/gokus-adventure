/** 
 *   Partida: Logica de una partida de juego
 *  
 *   @see Hardware
 *   @author 1-DAI IES San Vicente 2010/11
 */

/* --------------------------------------------------         
   Versiones hasta la fecha:
   
   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  17-Dic-2010  Nacho Cabanes
                      Version inicial: esqueleto, muestra el personaje,
                        permite moverlo a la derecha, izquierda, arriba,
                        abajo y (vacio) Disparar
 
   0.02  05-Jul-2011  Andrés Marotta
                      Agregados el atributo "miMapa" para enlazar con
                        las clase "Mapa"
 
   0.03  11-Jul-2011  Antonio Pérez
                      Agregados atributos para los carteles de ayuda
                        (fuenteSans12, PartidaPausada, cartelAyuda, 
                        recuadroCartelAyuda)
   0.04  12-Jul-2011  Varios
                      Cambiado el color de fondo de negro a celeste.
 ---------------------------------------------------- */

public class Partida
{
  // Atributos
  private Fuente fuenteSans12;

  // Componentes del juego
  private Personaje miPersonaje;
  private Mapa miMapa;

  // Otros datos del juego
  int puntos;             // Puntuacion obtenida por el usuario
  bool partidaTerminada;  // Si ha terminado una partida
  bool partidaPausada;    // Si se ha pausado la partida

  // Necesarias para el Scroll
  int scrollHorizontal = 0;
  int incrX = 4;
  int DERECHA = -4;
  int IZQUIERDA = 4;

  // Variables para los carteles de ayuda
  static int MAX_CARTELES = 1;
  Ayuda cartelAyuda;
  ElemGrafico recuadroCartelAyuda = new ElemGrafico();
  bool posibleMostrarCartel = false;

  // Inicialización al comenzar la sesión de juego
  public Partida()
  {
    miPersonaje = new Personaje( this );
    miMapa = new Mapa( this, miPersonaje );
    puntos = 0;
    partidaTerminada = false;
    partidaPausada = false;
    cartelAyuda = new Ayuda( "Esto es una prueba...", 150, 200 );
    recuadroCartelAyuda.CargarImagen( "imagenes/Mapa/recuadroCartelAyuda.PNG" );
    fuenteSans12 = new Fuente( "FreeSansBold.ttf", 12 );
  }

  // --- Comprobación de teclas, ratón y joystick -----
  void comprobarTeclas()
  {
    // Muevo si se pulsa alguna flecha del teclado
    if ( Hardware.TeclaPulsada( Hardware.TECLA_IZQ ) )
    {
      if ( miMapa.EsPosibleMover( miPersonaje.GetX() - incrX, miPersonaje.GetY(),
      miPersonaje.GetAncho(), miPersonaje.GetAlto(), scrollHorizontal ) )
      {
        // Si la X del personaje es mayor a 350 se mueve solo el personaje
        if ( miPersonaje.GetX() > 350 )
          miPersonaje.MoverIzquierda();
        // Si no movemos el resto de elementos simulando Scroll
        else
        {
          MovimientoScroll( IZQUIERDA );
        }
      }
    }

    if ( Hardware.TeclaPulsada( Hardware.TECLA_DER ) )
    {
      if ( miMapa.EsPosibleMover( miPersonaje.GetX() + incrX, miPersonaje.GetY(),
      miPersonaje.GetAncho(), miPersonaje.GetAlto(), scrollHorizontal ) )
      {
        // Si la X del personaje es mayor a 450 se mueve solo el personaje
        if ( miPersonaje.GetX() < 450 )
          miPersonaje.MoverDerecha();
        // Si no movemos el resto de elementos simulando Scroll
        else
        {
          MovimientoScroll( DERECHA );
        }
      }
    }

    if ( Hardware.TeclaPulsada( Hardware.TECLA_ARR ) )
      miPersonaje.MoverArriba();

    if ( Hardware.TeclaPulsada( Hardware.TECLA_ABA ) )
      miPersonaje.MoverAbajo();

    if ( Hardware.TeclaPulsada( Hardware.TECLA_ESP ) )
      miPersonaje.Disparar();

    if ( Hardware.TeclaPulsada( Hardware.TECLA_C ) && (!partidaPausada) )
      partidaPausada = true;

    if ( Hardware.TeclaPulsada( Hardware.TECLA_V ) && (partidaPausada) )
      partidaPausada = false;

    // Compruebo el Joystick
    if ( Hardware.JoystickPulsado( 0 ) )
      miPersonaje.Disparar();

    int posXJoystick, posYJoystick;
    if ( Hardware.JoystickMovido( out posXJoystick, out posYJoystick ) )
    {
      if ( posXJoystick > 0 ) miPersonaje.MoverDerecha();
      else if ( posXJoystick < 0 ) miPersonaje.MoverIzquierda();
      else if ( posYJoystick > 0 ) miPersonaje.MoverAbajo();
      else if ( posYJoystick < 0 ) miPersonaje.MoverArriba();
    }

    // Compruebo el raton
    int posXRaton = 0, posYRaton = 0;
    if ( Hardware.RatonPulsado( out posXRaton, out posYRaton ) )
    {
      miPersonaje.MoverA( posXRaton, posYRaton );
    }

    // Si se pulsa ESC, por ahora termina la partida... y el juego
    if ( Hardware.TeclaPulsada( Hardware.TECLA_ESC ) )
      partidaTerminada = true;
  }

  // --- Animación de los enemigos y demás objetos "que se muevan solos" -----
  void moverElementos()
  {
    // Nada por ahora
  }

  // --- Movimiento de todos los elementos al hacer uso del Scroll ---
  void MovimientoScroll( int valor )
  {
    // Mapa
    scrollHorizontal += valor;

    /*
    // Enemigos        
    for (int i = 0; i < mapaActual.GetNumEnemigos(); i++)
        mapaActual.GetEnemigo(i).MoverScroll(valor);
    */
  }

  // --- Comprobar colisiones de enemigo con personaje, etc ---
  void comprobarColisiones()
  {
    if ( miPersonaje.ColisionCon( cartelAyuda ) )
      posibleMostrarCartel = true;
    else
      posibleMostrarCartel = false;
  }


  // --- Dibujar en pantalla todos los elementos visibles del juego ---
  void dibujarElementos()
  {
    // Borro pantalla      
    Hardware.BorrarPantallaOculta( 135, 206, 235 );

    // Dibujo el mapa
    miMapa.DibujarOculta( scrollHorizontal );

    // Dibujo el personaje
    miPersonaje.DibujarOculta();

    if ( partidaPausada )
    {
      recuadroCartelAyuda.DibujarOculta( 250, 20 );
      Hardware.EscribirTextoOculta( cartelAyuda.GetTextoAyuda(), 260, 30, 0, 0, 0, fuenteSans12 );
      Hardware.EscribirTextoOculta( "Pulsa V para cerrar", 330, 100, 0, 0, 0, fuenteSans12 );
    }

    // Finalmente, muestro en pantalla
    Hardware.VisualizarOculta();
  }

  // --- Pausa tras cada fotograma de juego, para velocidad de 25 fps -----
  void pausaFotograma()
  {
    Hardware.Pausa( 40 );
  }

  // --- Bucle principal de juego -----
  public void BuclePrincipal()
  {

    partidaTerminada = false;
    do
    {
      comprobarTeclas();
      moverElementos();
      comprobarColisiones();
      dibujarElementos();
      pausaFotograma();
    } while ( !partidaTerminada );
  }

} /* fin de la clase Partida */
