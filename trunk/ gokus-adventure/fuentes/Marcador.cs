/* --------------------------------------------------
   Parte de: Goku's Adventure
   Versiones hasta la fecha:

   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  15-Ago-2011  Pedro Zalacain
                       Esqueleto inicial: Muestra las vidas del personaje,
                       barra de salud.                       
 ---------------------------------------------------- */

using System;

public class Marcador
{
    private int puntuacion;
    private int vidas;
    private int salud;

    private Fuente fuentedball42;
    private Partida miPartida;
    private ElemGrafico vidaGoku, barraVida;

    public Marcador(Partida p)
    {
        miPartida = p;

        vidaGoku = new ElemGrafico(@"imagenes\Marcador\vidaGoku.png");
        barraVida = new ElemGrafico(@"imagenes\Marcador\barraVida.png");
        fuentedball42 = new Fuente("FreeSansBold.ttf", 42);
    }

    public void SetVidas(int valor)
    {
        vidas = valor;
    }

    public void SetToques(int valor)
    {
        salud = valor;
    }

    public int GetVidas()
    {
        return vidas;
    }

    /// Devuelve el valor de la puntuación
    public int GetPuntuacion()
    {
        return puntuacion;
    }

    /// Cambia el valor de la puntuación
    public void SetPuntuacion(int valor)
    {
        puntuacion = valor;
    }


    /// Incrementa el valor de la puntuación
    public void IncrPuntuacion(int valor)
    {
        puntuacion += valor;
    }


    public void DibujarOculta()
    {
        // Imagen vidas
        vidaGoku.DibujarOculta(-10, -20);
        
        // SALUD DEL PERSONAJE      
        for (int index = 0; index < salud; index++)
        {
            barraVida.DibujarOculta(91 + (2 * index), 30);
        }

        // Puntos
        Hardware.EscribirTextoOculta(Convert.ToString(puntuacion), 400, 15, 0xFF, 0x99, 0x00, fuentedball42);        
    }
} /* end class Marcador */