/** 
         *   Creditos: pantalla de créditos (autor/es)
         *  
         *       @see Hardware Juego Presentacion
         *       @author 1-DAI IES San Vicente 2010/11
         */

/* --------------------------------------------------
   Versiones hasta la fecha:
   
   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  17-Dic-2010  Nacho Cabanes
                        Version inicial: muestra el nombre del (supuesto) autor
                      del remake, y del juego original
   0.02  12-Jul-2011  Raquel Lloréns
                        Actualizado con los autores y el nombre del juego reales.
                        Añadida imágen de fondo.
                        Añadidas sombras a los textos.
 ---------------------------------------------------- */


public class Creditos
{
    // Atributos
    private ElemGrafico fondo;
    private Fuente fuenteSans18;
    private Fuente fuenteSans12;
    private Fuente fuentedball88;

    public Creditos()  // Constructor
    {
        fondo = new ElemGrafico("imagenes/creditos.png");
        fuenteSans18 = new Fuente("Saiyan-Sans.ttf", 44);
        fuenteSans12 = new Fuente("FreeSansBold.ttf", 12);
        fuentedball88 = new Fuente("Saiyan-Sans.ttf", 88);
    }


    /// Lanza la pantalla de creditos
    public void Ejecutar()
    {
        bool salir = false;
        int yMax = 50;
        int y = 600;
        
        while (!salir)
        {
            // Borro la pantalla
            Hardware.BorrarPantallaOculta(0, 0, 0);

            // Dibujo la imagen de la presentacion
            fondo.DibujarOculta(0, 0);

            while (y > yMax)
            {
                // Borro la pantalla
                Hardware.BorrarPantallaOculta(0, 0, 0);

                // Dibujo la imagen de la presentacion
                fondo.DibujarOculta(0, 0);
                
                // Muestro los créditos

                Hardware.EscribirTextoOculta(
                    "GOKU'S ADVENTURE", 101, (short)(y + 1),
                      255, 255, 0, fuentedball88);
                Hardware.EscribirTextoOculta(
                    "GOKU'S ADVENTURE", 100, (short) y,
                      255, 140, 0, fuentedball88);
                Hardware.EscribirTextoOculta(
                    "2011", 371, (short)(y + 101),
                      0, 0, 128, fuenteSans12);
                Hardware.EscribirTextoOculta(
                    "2011", 370, (short)(y + 100),
                      255, 255, 0, fuenteSans12);

                Hardware.EscribirTextoOculta("Aitor Salgado Molina", 271, (short)(y + 141),
                      0, 0, 128, fuenteSans18);
                Hardware.EscribirTextoOculta("Aitor Salgado Molina", 270, (short) (y + 140),
                      255, 0, 0, fuenteSans18); 
                Hardware.EscribirTextoOculta("Andres Marotta", 271, (short)(y + 191),
                       0, 0, 128, fuenteSans18);
                Hardware.EscribirTextoOculta("Andres Marotta", 270, (short)(y + 190),
                      255, 0, 0, fuenteSans18);
                Hardware.EscribirTextoOculta("Antonio Perez Pareja", 271, (short)(y + 241),
                      0, 0, 128, fuenteSans18);
                Hardware.EscribirTextoOculta("Antonio Perez Pareja", 270, (short)(y + 240),
                      255, 0, 0, fuenteSans18);
                Hardware.EscribirTextoOculta("Antonio Ramos Torres", 271, (short)(y + 291),
                      0, 0, 128, fuenteSans18);
                Hardware.EscribirTextoOculta("Antonio Ramos Torres", 270, (short)(y + 290),
                      255, 0, 0, fuenteSans18);
                Hardware.EscribirTextoOculta("Pedro Zalacain", 271, (short)(y + 341),
                      0, 0, 128, fuenteSans18);
                Hardware.EscribirTextoOculta("Pedro Zalacain", 270, (short)(y + 340),
                      255, 0, 0, fuenteSans18);
                Hardware.EscribirTextoOculta("Raquel Llorens Gambin", 271, (short)(y + 391),
                      0, 0, 128, fuenteSans18);
                Hardware.EscribirTextoOculta("Raquel Llorens Gambin", 270, (short)(y + 390),
                      255, 0, 0, fuenteSans18);

                Hardware.EscribirTextoOculta(
                      "Pulsa ESC para volver a la presentación...",
                      50, (short)(y + 490), 0xAA, 0xAA, 0xAA, fuenteSans12);

                Hardware.VisualizarOculta();

                y -= 10;
            }

            Hardware.Pausa(40);

            salir = Hardware.TeclaPulsada(Hardware.TECLA_ESC);


        }
    }

} /* fin de la clase Creditos */
