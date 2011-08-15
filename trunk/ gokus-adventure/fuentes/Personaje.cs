/** 
 *   Personaje: El personaje que es controlado por el usuario
 *  
 *   @see Hardware ElemGrafico Juego
 *   @author 1-DAI IES San Vicente 2010/11
 */

/* --------------------------------------------------
   Versiones hasta la fecha:
   
   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  17-Dic-2010  Nacho Cabanes
                      Personaje inicial, con una imagen, capaz de
                        moverse a la derecha,izquierda, arriba, abajo
                         y (vacio) Disparar o Mover de forma automatica
   0.02  05-Jul-2011  Andrés Marotta
                      Agregados el atributo "miPoder" para enlazar con
                        las clase "Poder"
   0.03  12-Jul-2011  Varios
                      Modificada la imagen del personaje: Ya es Goku.
   0.04  14-Jul-2011  Andrés Marotta
                      Agregadas las secuencias de imágenes para los
                        movimientos hacia derecha e izquierda.
                      Modificadas las funciones "MoverDerecha" y
                        "MoverIzquierda" para utilizar la secuencia
                        de imágenes correspondiente a cada una.
   0.05 14-Jul-2011   Antonio Ramos
                       Añadida la funcion MoverSiguienteFotograma para
                       que se mueva el personaje cuando llegue al
                       limite del scroll
 ---------------------------------------------------- */

public class Personaje : ElemGrafico
{

  // Datos del personaje
  Partida miPartida; // Para poder comunicar con la partida
  // y preguntarle sobre enemigos, mapa, etc   
  Poder miPoder;
  short vidas;  // Vidas restantes
  private int toques;

  // Necesarios para el Salto y la Caida (+ Gravedad)  
  private bool saltando, cayendo;
  private int velocidadCaidaY = 6;
  private int fotogramaMvto;
  private int cantidadMovimientoSalto;
  private int[] pasosSaltoArriba = {-14, -14,-12, -12, -10, -10, -8, -8, -6, -6, -4, -2, -1, -1, 
                                  0, 0, 0, 0, 0, 0, 1, 1, 2, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14};

  // Constructor
  public Personaje(Partida p)
  {
    miPartida = p;   // Para enlazar con el resto de componentes
    miPoder = new Poder();
    x = 500;         // Resto de valores iniciales
    y = 300;
    vidas = 3;
    toques = 57;

    CargarSecuencia( DERECHA,
                      new string[] { "imagenes/Goku/caminandoD1.png", "imagenes/Goku/caminandoD1.png",
                                     "imagenes/Goku/caminandoD2.png", "imagenes/Goku/caminandoD2.png",
                                     "imagenes/Goku/caminandoD3.png", "imagenes/Goku/caminandoD3.png",
                                     "imagenes/Goku/caminandoD4.png", "imagenes/Goku/caminandoD4.png",
                                     "imagenes/Goku/caminandoD5.png", "imagenes/Goku/caminandoD5.png",
                                     "imagenes/Goku/caminandoD6.png", "imagenes/Goku/caminandoD6.png",
                                     "imagenes/Goku/caminandoD7.png", "imagenes/Goku/caminandoD7.png",
                                     "imagenes/Goku/caminandoD8.png", "imagenes/Goku/caminandoD8.png"} );

    CargarSecuencia( IZQUIERDA,
                      new string[] { "imagenes/Goku/caminandoI1.png", "imagenes/Goku/caminandoI1.png",
                                     "imagenes/Goku/caminandoI2.png", "imagenes/Goku/caminandoI2.png",
                                     "imagenes/Goku/caminandoI3.png", "imagenes/Goku/caminandoI3.png",
                                     "imagenes/Goku/caminandoI4.png", "imagenes/Goku/caminandoI4.png",
                                     "imagenes/Goku/caminandoI5.png", "imagenes/Goku/caminandoI5.png",
                                     "imagenes/Goku/caminandoI6.png", "imagenes/Goku/caminandoI6.png",
                                     "imagenes/Goku/caminandoI7.png", "imagenes/Goku/caminandoI7.png",
                                     "imagenes/Goku/caminandoI8.png", "imagenes/Goku/caminandoI8.png"} );

    CargarSecuencia( ESPERANDOD,
                      new string[] { "imagenes/Goku/paradoD1.png", "imagenes/Goku/paradoD1.png",
                                     "imagenes/Goku/paradoD2.png", "imagenes/Goku/paradoD2.png",
                                     "imagenes/Goku/paradoD3.png", "imagenes/Goku/paradoD3.png",
                                     "imagenes/Goku/paradoD4.png", "imagenes/Goku/paradoD4.png",
                                     "imagenes/Goku/paradoD5.png", "imagenes/Goku/paradoD5.png",
                                     "imagenes/Goku/paradoD6.png", "imagenes/Goku/paradoD6.png"} );

    CargarSecuencia( ESPERANDOI,
                      new string[] { "imagenes/Goku/paradoI1.png", "imagenes/Goku/paradoI1.png",
                                     "imagenes/Goku/paradoI2.png", "imagenes/Goku/paradoI2.png",
                                     "imagenes/Goku/paradoI3.png", "imagenes/Goku/paradoI3.png",
                                     "imagenes/Goku/paradoI4.png", "imagenes/Goku/paradoI4.png",
                                     "imagenes/Goku/paradoI5.png", "imagenes/Goku/paradoI5.png",
                                     "imagenes/Goku/paradoI6.png", "imagenes/Goku/paradoI6.png"} );

    CargarSecuencia( GIRANDOPALO,
                      new string[] { "imagenes/Goku/palo1.png", "imagenes/Goku/palo1.png",
                                     "imagenes/Goku/palo2.png", "imagenes/Goku/palo2.png",
                                     "imagenes/Goku/palo3.png", "imagenes/Goku/palo3.png",
                                     "imagenes/Goku/palo4.png", "imagenes/Goku/palo4.png",
                                     "imagenes/Goku/palo5.png", "imagenes/Goku/palo5.png",
                                     "imagenes/Goku/palo6.png", "imagenes/Goku/palo6.png",
                                     "imagenes/Goku/palo7.png", "imagenes/Goku/palo7.png",
                                     "imagenes/Goku/palo8.png", "imagenes/Goku/palo8.png",
                                     "imagenes/Goku/palo2.png", "imagenes/Goku/palo2.png"} );
    
    direccion = ESPERANDOD;
    SetAnchoAlto( 45, 45 );

    cantidadMovimientoSalto = pasosSaltoArriba.Length;

    minX = 350;
    maxX = 1000;
  }


  // Métodos de movimiento
  public void MoverDerecha()
  {
      // Limitamos que no salga de la pantalla
      if (x > (790 - ancho)) return;
      
      direccion = DERECHA;
      cayendo = true;
      x += 4;
      SiguienteFotograma();
  }

  public void MoverIzquierda()
  {
      // Limitamos que no salga de la pantalla
      if (x < 10) return;

      direccion = IZQUIERDA;
      cayendo = true;
      x -= 4;
      SiguienteFotograma();
  }

  public void MoverArriba()
  {
      // NADA
  }

  public void MoverAbajo()
  {
      // NADA
  }

  public void Saltar()
  {
      if (saltando || cayendo) return;

      saltando = true;
      fotogramaMvto = 0;

      /*
      if (direccion == DERECHA)
          CambiarDireccion(SALTODERECHA);

      if (direccion == IZQUIERDA)
          CambiarDireccion(SALTOIZQUIERDA);
      */
  }

  // Comienza la secuencia de salto hacia la derecha
  public void SaltarDerecha()
  {
      if (saltando || cayendo) return;

      Saltar();
      // CambiarDireccion(SALTODERECHA);
  }


  // Comienza la secuencia de salto hacia la izquierda
  public void SaltarIzquierda()
  {
      if (saltando || cayendo) return;

      Saltar();
      // CambiarDireccion(SALTOIZQUIERDA);
  }

  public void Esperar()
  {
    if ( (direccion == IZQUIERDA) || (direccion == ESPERANDOI) )
    {
      direccion = ESPERANDOI;
      SiguienteFotograma();
    }

    if ( (direccion == DERECHA) || (direccion == ESPERANDOD) )
    {
      direccion = ESPERANDOD;
      SiguienteFotograma();
    }
  }

  public void GirarPalo()
  {
    direccion = GIRANDOPALO;
    SiguienteFotograma();
  }

  // Para cuando deba moverse solo, p.ej. saltando, o en
  // movimiento continuo, como el PacMan
  public void Mover(Mapa m, int scrollHorizontal)
  {
      // Movimiento del personaje cuando esta saltando...
      if (saltando)
      {
          // Calculo la siguiente posicion y veo si es valida
          short yProxMov = (short)(y + pasosSaltoArriba[fotogramaMvto]);

          // Si todavía se puede mover, avanzo
          if (m.EsPosibleMover(x, yProxMov, ancho, alto, scrollHorizontal))
          {
              y = yProxMov;
          }
          // Y si no, quizá esté cayendo
          else
          {
              saltando = false;
              cayendo = true;
          }

          fotogramaMvto++;
          if (fotogramaMvto >= cantidadMovimientoSalto)
          {
              saltando = false;
              cayendo = true;
          }
      }
      else if (cayendo)
      {
          if (m.EsPosibleCaer(
          x, y + 2, ancho, alto, scrollHorizontal))
          {
              if (m.EsPosibleCaer(
              x, y + velocidadCaidaY, ancho, alto, scrollHorizontal))
                  y += (short) velocidadCaidaY;
              else
                  y += 2;

              // Cuando más altura tenga la caída, mayor es el incremento...
              if (velocidadCaidaY <= 10)
                  velocidadCaidaY++;
          }
          else
          {
              cayendo = false;
              velocidadCaidaY = 4;
              /*
              // Al terminar el salto o caida vuelve la imagen del personaje parado...
              if (direccion == SALTODERECHA)
                  CambiarDireccion(DERECHA);

              if (direccion == SALTOIZQUIERDA)
                  CambiarDireccion(IZQUIERDA);
              */
              // SiguienteFotograma();
          }
      }
  }

  // Necesaria para las limitaciones del mapa...
  public void MoverScroll(int valor)
  {
      minX += valor;
      maxX += valor;
  }


  public void Disparar()
  {
      // TODO: Vacio por ahora
  }


  // Métodos de acceso a las vidas
  public int GetVidas()
  {
      return vidas;
  }

  public void SetVidas(short n)
  {
      vidas = n;
  }

  public void Morir()
  {
      vidas--;
  }

  public int GetAncho()
  {
      return ancho;
  }

  public int GetAlto()
  {
      return alto;
  }

  public int GetToques()
  {
      return toques;
  }

  public void SetToques(int valor)
  {
      toques = valor;
  }

  public void SetX(short valor)
  {
    x = valor;
  }

  public void SetY(short valor)
  {
    y = valor;
  }

  public void SetCayendo(bool valor)
  {
      cayendo = true;
  }

} /* fin de la clase Personaje */
