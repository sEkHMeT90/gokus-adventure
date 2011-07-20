﻿/** 
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

  // Constructor

  public Personaje(Partida p)
  {
    miPartida = p;   // Para enlazar con el resto de componentes
    miPoder = new Poder();
    x = 500;         // Resto de valores iniciales
    y = 300;
    vidas = 3;

    CargarSecuencia( DERECHA,
                      new string[] { "imagenes/Goku/caminandoD1.png", "imagenes/Goku/caminandoD1.png",
                                     "imagenes/Goku/caminandoD2.png", "imagenes/Goku/caminandoD2.png",
                                     "imagenes/Goku/caminandoD3.png", "imagenes/Goku/caminandoD3.png",
                                     "imagenes/Goku/caminandoD4.png", "imagenes/Goku/caminandoD4.png",
                                     "imagenes/Goku/caminandoD5.png", "imagenes/Goku/caminandoD5.png",
                                     "imagenes/Goku/caminandoD6.png", "imagenes/Goku/caminandoD6.png",
                                     "imagenes/Goku/caminandoD7.png", "imagenes/Goku/caminandoD7.png",
                                     "imagenes/Goku/caminandoD8.png", "imagenes/Goku/caminandoD8.png"} );
    direccion = DERECHA;

    CargarSecuencia( IZQUIERDA,
                      new string[] { "imagenes/Goku/caminandoI1.png", "imagenes/Goku/caminandoI1.png",
                                     "imagenes/Goku/caminandoI2.png", "imagenes/Goku/caminandoI2.png",
                                     "imagenes/Goku/caminandoI3.png", "imagenes/Goku/caminandoI3.png",
                                     "imagenes/Goku/caminandoI4.png", "imagenes/Goku/caminandoI4.png",
                                     "imagenes/Goku/caminandoI5.png", "imagenes/Goku/caminandoI5.png",
                                     "imagenes/Goku/caminandoI6.png", "imagenes/Goku/caminandoI6.png",
                                     "imagenes/Goku/caminandoI7.png", "imagenes/Goku/caminandoI7.png",
                                     "imagenes/Goku/caminandoI8.png", "imagenes/Goku/caminandoI8.png"} );
    direccion = IZQUIERDA;

    CargarSecuencia( ESPERANDOD,
                      new string[] { "imagenes/Goku/paradoD1.png", "imagenes/Goku/paradoD1.png",
                                     "imagenes/Goku/paradoD2.png", "imagenes/Goku/paradoD2.png",
                                     "imagenes/Goku/paradoD3.png", "imagenes/Goku/paradoD3.png",
                                     "imagenes/Goku/paradoD4.png", "imagenes/Goku/paradoD4.png",
                                     "imagenes/Goku/paradoD5.png", "imagenes/Goku/paradoD5.png",
                                     "imagenes/Goku/paradoD6.png", "imagenes/Goku/paradoD6.png"} );

    direccion = ESPERANDOD;

    CargarSecuencia( ESPERANDOI,
                      new string[] { "imagenes/Goku/paradoI1.png", "imagenes/Goku/paradoI1.png",
                                     "imagenes/Goku/paradoI2.png", "imagenes/Goku/paradoI2.png",
                                     "imagenes/Goku/paradoI3.png", "imagenes/Goku/paradoI3.png",
                                     "imagenes/Goku/paradoI4.png", "imagenes/Goku/paradoI4.png",
                                     "imagenes/Goku/paradoI5.png", "imagenes/Goku/paradoI5.png",
                                     "imagenes/Goku/paradoI6.png", "imagenes/Goku/paradoI6.png"} );

    direccion = ESPERANDOI;

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
  }


  // Métodos de movimiento
  public void MoverDerecha()
  {
    direccion = DERECHA;
    x += 4;
    SiguienteFotograma();
  }

  public void MoverIzquierda()
  {
    direccion = IZQUIERDA;
    x -= 4;
    SiguienteFotograma();
  }

  public void MoverArriba()
  {
      y -= 4;
  }

  public void MoverAbajo()
  {
      y += 4;
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
  public new void Mover()
  {
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

  public void SetX(short valor)
  {
    x = valor;
  }

  public void SetY(short valor)
  {
    y = valor;
  }

} /* fin de la clase Personaje */
