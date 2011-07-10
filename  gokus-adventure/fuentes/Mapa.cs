﻿/** 
 *   Mapa: 
 **/

/* --------------------------------------------------         
   Goku's Adventure
   Versiones hasta la fecha:

   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  09-Jul-2011  Pedro Zalacain
   					   Creada la clase
   					   Creado DibujarOculta aplicando Scroll
   					   Enlazada clase Mapa con Nivel
                       Funcion ReiniciarNivel() -> (@see: Nivel.cs)               
                       Funcion ColisionElementos() -> (@see: Nivel.cs)
 ---------------------------------------------------- */

public class Mapa
{
    Nivel nivelActual;
    Nivel[] listaNiveles;
    Partida miPartida;
    Personaje miPersonaje;

    const int MAX_NIVELES = 1;
    int numeroNivelActual = 0;

    // Constructor
    public Mapa(Partida p, Personaje pers)
    {
        miPartida = p;
        miPersonaje = pers;

        listaNiveles = new Nivel[MAX_NIVELES];
        listaNiveles[0] = new Nivel01(this);
        // listaNiveles[1] = new Nivel02(this);

        nivelActual = listaNiveles[numeroNivelActual];
    }

    public void Reiniciar()
    {
        numeroNivelActual = 0;
        nivelActual = listaNiveles[numeroNivelActual];
        nivelActual.Reiniciar();
    }

    public void ReiniciarNivel()
    {
        nivelActual.Reiniciar();
    }

    public void DibujarOculta(int valor)
    {
        nivelActual.DibujarOculta(valor);
    }

    public bool EsPosibleMover(int x, int y, int xmax, int ymax, int scroll)
    {
        return nivelActual.EsPosibleMover(x, y, xmax, ymax, scroll);
    }

    public bool EsPosibleCaer(int x, int y, int xmax, int ymax, int scroll)
    {
        return nivelActual.EsPosibleCaer(x, y, xmax, ymax, scroll);
    }

    public void Avanzar()
    {
        numeroNivelActual++;
        if (numeroNivelActual >= MAX_NIVELES)
            numeroNivelActual = 0;

        nivelActual = listaNiveles[numeroNivelActual];

        miPersonaje.MoverA(400, 395);
        // miPersonaje.SetMaxMinX(2580, 250);
        // miPartida.SetScroll(-104);

        nivelActual.Reiniciar();

        /*

        // Borro los disparos (aparecerian en el siguiente nivel si el personaje justo dispara)
        for (int x = 0; x < miPersonaje.GetCantidadDisparos() - 1; x++)
            miPersonaje.GetDisparo(x).Reiniciar();
          
        */ 

        // Pequeña pausa antes de lanza el nuevo nivel
        System.Threading.Thread.Sleep(1000);

        /*
        // Usado en GnG (Pedro Zalacain) para el mostrar el mapa intermedio
        miPartida.SetAvanzada(true);
        */
    }

    public int GetMaxX()
    {
        return nivelActual.GetMaxX();
    }


    public int GetMinX()
    {
        return nivelActual.GetMinX();
    }


    public int GetMaxY()
    {
        return nivelActual.GetMaxY();
    }


    public int GetMinY()
    {
        return nivelActual.GetMinY();
    }
    /*
    public int GetNumEnemigos()
    {
        return nivelActual.GetNumEnemigos();
    }

    public Enemigo GetEnemigo(int i)
    {
        return nivelActual.GetEnemigo(i);
    }
    */
    public void SetNivel(int valor) // Empleado al cargar Partida
    {
        numeroNivelActual = valor;
        nivelActual = listaNiveles[numeroNivelActual];
    }

    public int GetNivel()
    {
        return numeroNivelActual;
    }

} /* fin de la clase Mapa */