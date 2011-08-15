/* --------------------------------------------------
   Parte de: Goku's Adventure
   Versiones hasta la fecha:

   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  15-Ago-2011  Pedro Zalacain
                       Esqueleto inicial: Muestra las vidas del personaje,
                       barra de salud.                       
 ---------------------------------------------------- */

public class Marcador
{
    private int puntuacion;
    private int vidas;
    private int salud;

    private Partida miPartida;
    private ElemGrafico vidaGoku, barraVida;

    public Marcador(Partida p)
    {
        miPartida = p;

        vidaGoku = new ElemGrafico(@"imagenes\Marcador\vidaGoku.png");
        barraVida = new ElemGrafico(@"imagenes\Marcador\barraVida.png");
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
        vidaGoku.DibujarOculta(-10, -10);
        
        // SALUD DEL PERSONAJE      
        for (int index = 0; index < salud; index++)
        {
            barraVida.DibujarOculta(91 + (2 * index), 40);
        }
        
    }
} /* end class Marcador */