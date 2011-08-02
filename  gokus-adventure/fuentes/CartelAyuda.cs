/** 
 *   CartelAyuda: Contiene la información de los carteles de ayuda del nivel
 **/

/* --------------------------------------------------         
   Goku's Adventure
   Versiones hasta la fecha:
   
   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  05-Jul-2011  Andrés Marotta
                       Version inicial: Creada la clase "Ayuda". 
   0.02  11-Jul-2011  Antonio Pérez
                       Crear constructor y metodos para los atributos.     
   0.03  02-Ago-2011  Antonio Pérez y Pedro Zalacain
                       Renombrada la clase a "CartelAyuda"
                       
 ---------------------------------------------------- */

using System;

public class CartelAyuda : ElemGrafico
{
    Nivel NivelPertenece;
    ElemGrafico iconoBoton;
    ElemGrafico imagenCartel;

    public CartelAyuda(short NuevaX, short NuevaY, string nombreImagen, Nivel nivel)
    {
        NivelPertenece = nivel;

        CargarImagen("imagenes/CartelesAyuda/imagenCartel.PNG");
        x = NuevaX;
        y = NuevaY;
        ancho = 37;
        alto = 27;

        // Imagen del Cartel
        imagenCartel = new ElemGrafico(nombreImagen);
        imagenCartel.MoverA(250, 150);

        // Boton lectura Cartel
        iconoBoton = new ElemGrafico("imagenes/CartelesAyuda/teclaC.PNG");        
        iconoBoton.SetVisible(false);
        iconoBoton.MoverA(NuevaX + 5, NuevaY - 25);
    }

    public void ComprobarCercania(int xPersonaje, int yPersonaje)
    {
        // Si el personaje esta a una distancia de 50 pixeles en Horizontal y Vertical
        if (x - xPersonaje <= 50 && x - xPersonaje >= -50 && y - yPersonaje <= 50 && y - yPersonaje >= -50)
        {
            iconoBoton.SetVisible(true);
            if (Hardware.TeclaPulsada(Hardware.TECLA_C))
                NivelPertenece.MostrarCartel(imagenCartel);
            if (Hardware.TeclaPulsada(Hardware.TECLA_V))
                NivelPertenece.QuitarCartel();
        }
        // Si no lo escondemos...
        else
        {
            iconoBoton.SetVisible(false);
        }
    }

    public void MoverScroll(int valor)
    {
        // Cartel
        x += (short)valor;

        // Boton lectura Cartel
        iconoBoton.MoverA(iconoBoton.GetX() + valor, iconoBoton.GetY());
    }

    public override void DibujarOculta()
    {
        base.DibujarOculta();
        iconoBoton.DibujarOculta();
    }

}
