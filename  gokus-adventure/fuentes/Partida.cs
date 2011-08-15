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
   0.05  13-Jul-2011  Andrés Marotta
                      Agregada la comprobación cuando no se toca ninguna
                        tecla.
   0.06  14-Jul-2011  Antonio Ramos
                      Modificada la funcion scroll para que cuando el personaje
                        llege al limite del scroll se mueva y no siga parado.
   0.07  02-Ago-2011  Antonio Perez y Pedro Zalacain
                       Agregada la muestra de carteles de ayuda.
   0.08  15-Ago-2011  Pedro Zalacain
                       Agregado Marcador.
                       Restado de vida al colisionar con enemigos.
                       Reinicio de la partida si salimos con ESC.
 ---------------------------------------------------- */

public class Partida
{
  // Componentes del juego
  public Personaje miPersonaje;
  public Mapa miMapa;
  public Marcador miMarcador;

  // Otros datos del juego
  int puntos;             // Puntuacion obtenida por el usuario
  bool partidaTerminada;  // Si ha terminado una partida

  // Necesarias para el Scroll
  int scrollHorizontal = 0;
  int incrX = 4;
  int DERECHA = -4;
  int IZQUIERDA = 4;

  // Necesarias para la muestra de carteles
  ElemGrafico cartelMostrado;
  bool mostrandoCartel;

  // Inicialización al comenzar la sesión de juego
  public Partida()
  {   
    Reiniciar();
  }

  public void Reiniciar()
  {
      miPersonaje = new Personaje(this);
      miMapa = new Mapa(this, miPersonaje);
      miMarcador = new Marcador(this);

      puntos = 0;

      // Para el cartel
      cartelMostrado = new ElemGrafico("imagenes/CartelesAyuda/CartelPrueba.PNG");
      cartelMostrado.SetVisible(false);
      mostrandoCartel = false;
  }

  // --- Comprobación de teclas, ratón y joystick -----
  void comprobarTeclas()
  {
      if (mostrandoCartel) return;

      // Salto del personaje (BARRA ESPACIO)
      if (Hardware.TeclaPulsada(Hardware.TECLA_ESP))
      {
          if (Hardware.TeclaPulsada(Hardware.TECLA_DER))
              miPersonaje.SaltarDerecha();
          else if (Hardware.TeclaPulsada(Hardware.TECLA_IZQ))
              miPersonaje.SaltarIzquierda();
          else
              miPersonaje.Saltar();
      }

    // Muevo si se pulsa alguna flecha del teclado
    if ( Hardware.TeclaPulsada( Hardware.TECLA_IZQ ) )
    {
      if ( miMapa.EsPosibleMover( miPersonaje.GetX() - incrX, miPersonaje.GetY(),
      miPersonaje.GetAncho(), miPersonaje.GetAlto(), scrollHorizontal ) )
      {
        // Si la X del personaje es mayor a 350 se mueve solo el personaje
        if (miPersonaje.GetX() > 350 || miPersonaje.GetX() < miPersonaje.GetMinX())
          miPersonaje.MoverIzquierda();
        // Si no movemos el resto de elementos simulando Scroll
        else
        {
          MovimientoScroll( IZQUIERDA );
          miPersonaje.CambiarDireccion((byte)3);
          miPersonaje.SetCayendo(true);
          miPersonaje.SiguienteFotograma();
        }
      }
    }

    if ( Hardware.TeclaPulsada( Hardware.TECLA_DER ) )
    {
      if ( miMapa.EsPosibleMover( miPersonaje.GetX() + incrX, miPersonaje.GetY(),
      miPersonaje.GetAncho(), miPersonaje.GetAlto(), scrollHorizontal ) )
      {
        // Si la X del personaje es menor a 450 se mueve solo el personaje
        if (miPersonaje.GetX() < 450 || miPersonaje.GetX() > miPersonaje.GetMaxX())
          miPersonaje.MoverDerecha();
        // Si no movemos el resto de elementos simulando Scroll
        else
        {
          MovimientoScroll( DERECHA );
          miPersonaje.CambiarDireccion((byte)2);
          miPersonaje.SetCayendo(true);
          miPersonaje.SiguienteFotograma();
        }
      }
    }
    if ( Hardware.TeclaPulsada( Hardware.TECLA_ARR ) )
      miPersonaje.MoverArriba();

    if ( Hardware.TeclaPulsada( Hardware.TECLA_ABA ) )
      miPersonaje.MoverAbajo();

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

    /*
    // Compruebo el raton    
    int posXRaton = 0, posYRaton = 0;
    if ( Hardware.RatonPulsado( out posXRaton, out posYRaton ) )
    {
        miPersonaje.MoverA( posXRaton, posYRaton );
    }
    */ 

    // Si se pulsa ESC, por ahora termina la partida... y el juego
    if (Hardware.TeclaPulsada(Hardware.TECLA_ESC))
    {
        partidaTerminada = true;
        Reiniciar();
    }

    // Si no se pulsa ninguna tecla
    if ( ( !Hardware.TeclaPulsada( Hardware.TECLA_DER ) ) && ( !Hardware.TeclaPulsada( Hardware.TECLA_IZQ ) ) &&
         ( !Hardware.TeclaPulsada( Hardware.TECLA_ARR ) ) && ( !Hardware.TeclaPulsada( Hardware.TECLA_ABA ) ) &&
         ( !Hardware.TeclaPulsada( Hardware.TECLA_ESP ) ) && ( !Hardware.TeclaPulsada( Hardware.TECLA_C ) ) &&
         ( !Hardware.TeclaPulsada( Hardware.TECLA_V ) ) && ( !Hardware.TeclaPulsada( Hardware.TECLA_ESC ) ) )
    {
      miPersonaje.Esperar();
    }
  }

  // --- Animación de los enemigos y demás objetos "que se muevan solos" -----
  void moverElementos()
  {
      if (mostrandoCartel) return;

      // Personaje
      miPersonaje.Mover(miMapa, scrollHorizontal);

      // Enemigos
      for (int i = 0; i < miMapa.GetNumEnemigos(); i++)
          miMapa.GetEnemigo(i).Mover();
  }

  // --- Movimiento de todos los elementos al hacer uso del Scroll ---
  void MovimientoScroll( int valor )
  {
    // Mapa
    scrollHorizontal += valor;

    // Enemigos
    for (int i = 0; i < miMapa.GetNumEnemigos(); i++)
        miMapa.GetEnemigo(i).MoverScroll(valor);

    // Carteles de Ayuda
    for (int i = 0; i < miMapa.GetNumCarteles(); i++)
        miMapa.GetCartel(i).MoverScroll(valor);

    // Personaje
    miPersonaje.MoverScroll(valor);
  }

  // --- Comprobar colisiones de enemigo con personaje, etc ---
  void comprobarColisiones()
  {
      /// Cercania a los carteles
      for (int i = 0; i < miMapa.GetNumCarteles(); i++)
          miMapa.GetCartel(i).ComprobarCercania(miPersonaje.GetX(), miPersonaje.GetY());

      if (mostrandoCartel) return;

      for (int i = 0; i < miMapa.GetNumEnemigos(); i++)
          if (miPersonaje.ColisionCon(miMapa.GetEnemigo(i)))
              miPersonaje.SetToques(miPersonaje.GetToques() - 1);
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

    // Dibujo los enemigos
    for (int i = 0; i < miMapa.GetNumEnemigos(); i++)
        miMapa.GetEnemigo(i).DibujarOculta();

    // Dibujo los carteles
    for (int i = 0; i < miMapa.GetNumCarteles(); i++)
        miMapa.GetCartel(i).DibujarOculta();

    // Marcador

    // miMarcador.SetPuntuacion(puntos);
    // miMarcador.SetVidas(miPersonaje.GetVidas());
    miMarcador.SetToques(miPersonaje.GetToques());
    miMarcador.DibujarOculta();

    // Por ultimo mostramos el cartel de ayuda (en caso que haya...)
    cartelMostrado.DibujarOculta();

    // Finalmente, muestro en pantalla
    Hardware.VisualizarOculta();
  }

  // --- Pausa tras cada fotograma de juego, para velocidad de 25 fps -----
  void pausaFotograma()
  {
    Hardware.Pausa( 25 );
  }

  public void MostrarCartel(ElemGrafico cartelMostrar)
  {
      cartelMostrado = cartelMostrar;
      cartelMostrado.SetVisible(true);
      mostrandoCartel = true;
  }

  public void QuitarCartel()
  {
      cartelMostrado.SetVisible(false);
      mostrandoCartel = false;
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
