/** 
 *   Presentacion: pantalla de presentacion
 *  
 *   @see Hardware ElemGrafico Juego
 *   @author 1-DAI IES San Vicente 2010/11
 */

/* --------------------------------------------------         
   Versiones hasta la fecha:
   
   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  17-Dic-2010  Nacho Cabanes
                      Version inicial: muestra la pantalla de presentacion 
                        y permite entra a créditos o jugar una partida
   0.02  10-Jul-2011  Andrés Marotta
                      Cambiada la imagen de presentación, creado el menú
                        dinámico con dos bolas de dragón que se muestran
                        en la opción seleccionada
   0.03  11-Jul-2011  Raquel Lloréns
                      Añadida imagen inicial de presentación y texto con
                        el nombre del juego (TODO: Falta de de animación 
                        en el nombre del juego por no tener el personaje).
   0.04  16-Jul-2011  Raquel Lloréns
                      Unificadas las dos presentaciones anteriores.
                      Añadida animación del personaje.
   0.05  18-Jul-2011  Raquel Lloréns
                      Añadido acceso directo en el menú al nivel de ayuda.
   0.06  19-Jul-2011  Raquel Lloréns
                      Modificado texto del menú.
 ---------------------------------------------------- */

public class Presentacion : ElemGrafico
{
  // Atributos    
  private ElemGrafico fondo;
  private ElemGrafico bola;
  private Fuente fuentedball42;
  private Fuente fuentedball88;
  private int opcionEscogida;
  //private int xPresent;

  //Componentes
  private Personaje miPersonaje;
  private Partida miPartida;

  // Opciones posibles
  public const byte OPC_JUGAR = 0;
  public const byte OPC_NIVELAYUDA = 1;
  public const byte OPC_CREDITOS = 2;
  public const byte OPC_SALIR = 3;


  /// Constructor
  public Presentacion()  // Constructor
  {
    miPersonaje = new Personaje( miPartida );

    fondo = new ElemGrafico( "imagenes/Present/imgPresent.png" );
    bola = new ElemGrafico( "imagenes/Present/bolaMenu.png" );
    fuentedball42 = new Fuente( "Saiyan-Sans.ttf", 42 );
    fuentedball88 = new Fuente("Saiyan-Sans.ttf", 88);
    opcionEscogida = OPC_JUGAR;
  }

  /// Lanza la presentacion
  public void Ejecutar()
  {
    /*
    xPresent = 800;

    while (xPresent > 10)
    {
        // Borro la pantalla
        Hardware.BorrarPantallaOculta(135, 206, 235);
        presentInicio.DibujarOculta(xPresent, 10);
        Hardware.VisualizarOculta();
        xPresent -= 20;
    }
    
    // TODO: Animación en el nombre del juego con el personaje 

    Hardware.EscribirTextoOculta(
          "GOKU'S ADVENTURE", 102, 480,
            255, 255, 0, fuentedball88 );
    Hardware.EscribirTextoOculta(
        "GOKU'S ADVENTURE", 101, 480,
          255, 255, 0, fuentedball88 ); 
    Hardware.EscribirTextoOculta(
        "GOKU'S ADVENTURE", 100, 479,
          255, 140, 0, fuentedball88);

    Hardware.VisualizarOculta();

    Hardware.Pausa(1000);
    */

    miPersonaje.SetX( 500 );
    miPersonaje.SetY( 480 );
     
    // Hasta que se pulse INTRO (sin saturar la CPU)
    do
    {
      // Borro la pantalla
      Hardware.BorrarPantallaOculta(0,0,0);

      // Dibujo la imagen de la presentacion
      fondo.DibujarOculta( 0, 0 );

      // Escribo las opciones del menú, con sombra
      Hardware.EscribirTextoOculta( "Jugar", 520, 184, 0xFF, 0x99, 0x00, fuentedball42 );
      Hardware.EscribirTextoOculta( "Jugar", 519, 185, 255, 230, 0, fuentedball42 );

      Hardware.EscribirTextoOculta( "Nivel de ayuda", 520, 254, 0xFF, 0x99, 0x00, fuentedball42 );
      Hardware.EscribirTextoOculta( "Nivel de ayuda", 519, 255, 255, 230, 0, fuentedball42 );

      Hardware.EscribirTextoOculta( "Creditos", 520, 324, 0xFF, 0x99, 0x00, fuentedball42 );
      Hardware.EscribirTextoOculta( "Creditos", 519, 325, 255, 230, 0, fuentedball42 );

      Hardware.EscribirTextoOculta( "Salir", 520, 394, 0xFF, 0x99, 0x00, fuentedball42 );
      Hardware.EscribirTextoOculta( "Salir", 519, 395, 255, 230, 0, fuentedball42 );

      // Muestro la secuencia del personaje
      miPersonaje.GirarPalo();
      miPersonaje.DibujarOculta();
      

      // Dibujo las bolas que señalan la opción
      if ( opcionEscogida == OPC_JUGAR )
      {
        bola.DibujarOculta( 485, 188 );
        bola.DibujarOculta( 615, 188 );
      }

      if ( opcionEscogida == OPC_NIVELAYUDA )
      {
         bola.DibujarOculta( 485, 260 );
         bola.DibujarOculta( 745, 260 );
      }

      if ( opcionEscogida == OPC_CREDITOS )
      {
         bola.DibujarOculta( 485, 328 );
         bola.DibujarOculta( 640, 328 );
      }

      if ( opcionEscogida == OPC_SALIR )
      {
        bola.DibujarOculta( 485, 398 );
        bola.DibujarOculta( 600, 398 );
      }

      // Finalmente, muestro en pantalla
      Hardware.VisualizarOculta();

      // Compruebo teclas para ver si se eligió una opción
      // distinta de la actual
      if ( Hardware.TeclaPulsada( Hardware.TECLA_ABA ) )
      {
        if ( opcionEscogida < OPC_SALIR )
          opcionEscogida++;
      }

      if ( Hardware.TeclaPulsada( Hardware.TECLA_ARR ) )
      {
        if ( opcionEscogida > OPC_JUGAR )
          opcionEscogida--;
      }

      // Pausa para no cargarme la "multitarea" de Windows
      Hardware.Pausa(40);
    }
    while ( !Hardware.TeclaPulsada(Hardware.TECLA_INTRO) );
  }

  public int GetOpcionEscogida()
  {
    return opcionEscogida;
  }

} /* fin de la clase Presentacion */
