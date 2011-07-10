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
 ---------------------------------------------------- */

public class Presentacion
{
  // Atributos    
  private ElemGrafico fondo;
  private ElemGrafico bola;
  private Fuente fuenteSans18;
  private int opcionEscogida;

  // Opciones posibles
  public const byte OPC_JUGAR = 0;
  public const byte OPC_CREDITOS = 1;
  public const byte OPC_SALIR = 2;


  /// Constructor
  public Presentacion()  // Constructor
  {
    fondo = new ElemGrafico( "imagenes/present.png" );
    bola = new ElemGrafico( "imagenes/bolaMenu.png" );
    fuenteSans18 = new Fuente("FreeSansBold.ttf", 24);
    opcionEscogida = OPC_JUGAR;
  }

  /// Lanza la presentacion
  public void Ejecutar()
  {
    // Hasta que se pulse INTRO (sin saturar la CPU)
    do
    {
      // Borro la pantalla
      Hardware.BorrarPantallaOculta(0,0,0);

      // Dibujo la imagen de la presentacion
      fondo.DibujarOculta( 0, 0 );

      // Escribo las opciones del menú, con sombra
      Hardware.EscribirTextoOculta( "Jugar", 579, 49, 225, 225, 225, fuenteSans18 );
      Hardware.EscribirTextoOculta( "Jugar", 580, 50, 255, 230, 0, fuenteSans18 );

      Hardware.EscribirTextoOculta( "Créditos", 579, 119, 225, 225, 225, fuenteSans18 );
      Hardware.EscribirTextoOculta( "Créditos", 580, 120, 255, 230, 0, fuenteSans18 );

      Hardware.EscribirTextoOculta( "Salir", 579, 189, 225, 225, 225, fuenteSans18 );
      Hardware.EscribirTextoOculta( "Salir", 580, 190, 255, 230, 0, fuenteSans18 );

      // Dibujo las bolas que señalan la opción
      if ( opcionEscogida == OPC_JUGAR )
      {
        bola.DibujarOculta( 545, 53 );
        bola.DibujarOculta( 665, 53 );
      }

      if ( opcionEscogida == OPC_CREDITOS )
      {
        bola.DibujarOculta( 545, 123 );
        bola.DibujarOculta( 700, 123 );
      }

      if ( opcionEscogida == OPC_SALIR )
      {
        bola.DibujarOculta( 545, 193 );
        bola.DibujarOculta( 655, 193 );
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
