/* --------------------------------------------------
   Parte de: Goku's Adventure - Moneda.cs
   Versiones hasta la fecha:

   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  25-Ago-2011  Pedro Zalacain
                       Moneda +10 Puntos (@see: Partida.cs)
 ---------------------------------------------------- */

public class Moneda : ObjetoRecogible
{
    public Moneda(short nuevaX, short nuevaY)
        : base(nuevaX, nuevaY)
    {
        ancho = 40;
        alto = 40;

        CargarSecuencia(DERECHA,
            new string[] {
              "imagenes/Objetos/Moneda/moneda01.PNG", "imagenes/Objetos/Moneda/moneda01.PNG",
              "imagenes/Objetos/Moneda/moneda02.PNG", "imagenes/Objetos/Moneda/moneda02.PNG",
              "imagenes/Objetos/Moneda/moneda03.PNG", "imagenes/Objetos/Moneda/moneda03.PNG",
              "imagenes/Objetos/Moneda/moneda04.PNG", "imagenes/Objetos/Moneda/moneda04.PNG"}
            );

        direccion = DERECHA;
    }

} /* end class Moneda */